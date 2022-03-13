using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Reflection;
using System.Diagnostics;

namespace DMS.Forms
{
    public partial class frmAboutForm : BaseWindowsForm
    {
        private bool m_showing = true;
        private string linkInfos = string.Empty;

        public frmAboutForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.linkInfos = "http://my.csdn.net/nidexuanzhe";
            string ver = string.Empty;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                ver = "V" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            else
                ver = "V" + Application.ProductVersion;

            labelVersion.Text = String.Format("Version {0}", ver);
            AssemblyName[] other = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (AssemblyName a in other)
            {
                listAssemblies.Items.Add(string.Format("{0} ({1})", a.Name, a.Version));
            }
            this.Opacity = 0.0;
            this.Activate();
            this.Refresh();
            fadeTimer.Start();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Closing(object sender, CancelEventArgs e)
        {
            //Owner.Activate();
            m_showing = false;
            fadeTimer.Start();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (m_showing)
            {
                double d = 1000.0 / fadeTimer.Interval / 100.0;
                if (Opacity + d >= 1.0)
                {
                    Opacity = 1.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity = Opacity + d;
                }
            }
            else
            {
                double d = 1000.0 / fadeTimer.Interval / 100.0;
                if (Opacity - d <= 0.0)
                {
                    Opacity = 0.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity = Opacity - d;
                }
            }
        }

        private void linkInfo_Click(object sender, EventArgs e)
        {
            try
            {

                Process.Start("IEXPLORE.EXE", linkInfos);
            }
            catch
            {
                // could not display the website, don't display the error
            }
        }
    }
}
