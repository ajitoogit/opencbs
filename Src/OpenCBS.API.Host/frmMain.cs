using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCBS.API.Host
{
    public partial class frmMain : Form
    {
        AppHost appHost = null;
        private const string listeningOn = "http://localhost:83/";
        public frmMain()
        {
            InitializeComponent();
            appHost = new AppHost();
            appHost.Init();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            appHost.Start(listeningOn);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            appHost.Stop();
        }
    }
}
