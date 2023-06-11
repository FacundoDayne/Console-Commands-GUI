using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimedShutdown
{
    public partial class TimedShutdownForm : Form
    {
        public TimedShutdownForm()
        {
            InitializeComponent();

            //kurukuru.Play("C:\\Users\\Vaynes\\source\\repos\\TimedShutdown\\TimedShutdown\\kurukuru.mp4");
        }

        private void ipconfig()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = true;
            process.Start();
            process.StandardInput.Write("ipconfig");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");

            
        }
    }
}