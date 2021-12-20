using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using DMS.Controls;
using System.Data.Common;
using System.Data.SqlClient;

namespace DMS.Forms
{
    public partial class frmTest : DMS.Forms.BaseForm
    {
        TestDetailControl testDetailControl;
        public frmTest()
        {
            InitializeComponent();

            GetCPUID();
            GetBoardID();

            InitData();
            ResizeControl();
        }

        public void InitData()
        {
            TestControl ctr = new TestControl();
            ctr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            ctr.Location = new Point(0, 0);
            ctr.Width = this.Width - 10;
            this.flowPanel.Controls.Add(ctr);

            testDetailControl = new TestDetailControl();
            testDetailControl.Height = 300;
            testDetailControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.Controls.Add(testDetailControl);

            KillSumControl ksc = new KillSumControl();
            this.flowPanel2.Controls.Add(ksc);

            KillSumControl ksc2 = new KillSumControl();
            ksc2.flag = 1;
            this.flowPanel3.Controls.Add(ksc2);
        }

        public string GetCPUID()
        {
            try
            {
                string str = "";
                ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
                foreach (ManagementObject obj2 in instances)
                {
                    str = obj2.Properties["ProcessorId"].Value.ToString();
                }
                instances = null;
                return str;
            }
            catch
            {
                return "unknow";
            }
        }

        public string GetBoardID()
        {
            string str = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_baseboard");
            foreach (ManagementObject obj2 in searcher.Get())
            {
                return obj2["SerialNumber"].ToString();
            }
            return str;
        }

        private void ResizeControl()
        {
            this.SuspendLayout();
            int y = 0;
            foreach (Control c in flowPanel.Controls)
            {
                c.Width = this.flowPanel.Width;
                if (!(c is TestDetailControl))
                {
                    y += c.Height;
                }
            }
            foreach (Control c in flowPanel.Controls)
            {
                if (c is TestDetailControl)
                {
                    c.Height = flowPanel.Height - y;
                    break;
                }
            }
            this.ResumeLayout(false);
        }

        private void flowPanel_Resize(object sender, EventArgs e)
        {
            ResizeControl();
        }

        private void flowPanel2_Resize(object sender, EventArgs e)
        {
            this.SuspendLayout();
            foreach (Control c in flowPanel2.Controls)
            {
                c.Width = this.flowPanel2.Width;
                if (c is KillSumControl)
                {
                    c.Height = flowPanel2.Height;
                }
            }
            this.ResumeLayout(false);
        }

        private void flowPanel3_Resize(object sender, EventArgs e)
        {
            this.SuspendLayout();
            foreach (Control c in flowPanel3.Controls)
            {
                c.Width = this.flowPanel3.Width;
                if (c is KillSumControl)
                {
                    c.Height = flowPanel3.Height;
                }
            }
            this.ResumeLayout(false);
        }
    }
}
