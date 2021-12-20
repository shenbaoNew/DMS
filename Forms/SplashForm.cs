using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMS.Forms;

namespace DMS
{
    public partial class SplashForm : Form, ISplashForm
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        void ISplashForm.SetStatusInfo(string NewStatusInfo)
        {
            labMsg.Text = NewStatusInfo;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }

    }
}
