using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timed2Shutdown
{
    public partial class ShutdownForm : Form
    {
        public string time = "";
        public ShutdownForm()
        {
            InitializeComponent();
        }

        private void txtSubmit_Click(object sender, EventArgs e)
        {
            int hours = int.Parse(txtHour.Text) * 3600;
            int minutes = int.Parse(txtMinute.Text) * 60;
            int seconds = int.Parse(txtSecond.Text);
            time = (hours + minutes + seconds).ToString();
            DialogResult = DialogResult.OK;
        }
    }
}
