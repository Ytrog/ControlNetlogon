using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlNetlogon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public ServiceControllerStatus Status {
            get
            {
                return scNetlogon.Status;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToggleButtons();
        }

        private void ToggleButtons()
        {
            if (Status == ServiceControllerStatus.Running || Status == ServiceControllerStatus.StartPending)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            scNetlogon.Start();
            scNetlogon.WaitForStatus(ServiceControllerStatus.Running);
            ToggleButtons();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            scNetlogon.Stop();
            scNetlogon.WaitForStatus(ServiceControllerStatus.Stopped);
            ToggleButtons();
        }
    }
}
