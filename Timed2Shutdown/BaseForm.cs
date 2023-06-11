using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timed2Shutdown
{
    public partial class BaseForm : Form 
    {
        string input = "a";
        bool shutdown = false;
        string time = "";
        public BaseForm()
        {
            InitializeComponent();
            cbCommand.SelectedIndex = 0;
            Controls.Add(pnlHome);
            btnEngage.Enabled = false;
            cbCommand.SelectedIndexChanged += changeScreen;
            btnEngage.Click += engage;
        }

        private void engage(object sender, EventArgs e)
        {
            engageCMDCommand();
        }

        private void changeScreen(object sender, EventArgs e)
        {
            switch(cbCommand.SelectedIndex)
            {
                //home
                case 0:
                    btnEngage.Enabled = false;
                    break;
                //shutdown
                case 1:
                    shutdown = true;
                    btnEngage.Enabled = true;
                    break;                    
                //ipconfig
                case 2:
                    input = "ipconfig";
                    btnEngage.Enabled = true;
                    break;
                default:
                    MessageBox.Show("Incorrect Index Entered");
                    btnEngage.Enabled = false;
                    break;
            }
        }
       

        private void engageCMDCommand()
        {
            if (shutdown)
            {
                ShutdownForm shutdownForm = new ShutdownForm();
                if (shutdownForm.ShowDialog() == DialogResult.OK)
                {
                    time = shutdownForm.time;
                    input = $"shutdown /s /t {time} /c \"Shutdown Authormized by obamba\"";
                    shutdownForm.Dispose();
                }
                else
                {
                    input = "";
                }
                shutdown = false;
            }
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(input);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
        }
    }
}
