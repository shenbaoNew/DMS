using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using DMS.DataClass.Pub;
using System.Reflection;
using System.Diagnostics;

namespace DMS.Forms {
    public partial class frmCheckUpdate : BaseForm {
        public frmCheckUpdate() {
            InitializeComponent();
            Upgrade();
        }

        public void Upgrade() {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string newVersion = NewVersion();
            bool needUpgrade = newVersion.CompareTo(version) > 0;
            if (needUpgrade) {
                if (MessageBox.Show("检测到最新版本：" + newVersion + "，是否更新?", "请选择", MessageBoxButtons.OKCancel)
                    == DialogResult.OK) {
                    this.StartUpgradeProgram(newVersion);
                } else {
                    MessageBox.Show("当前是最新版本，无需更新...");
                }
            }
        }

        private void StartUpgradeProgram(string version) {
            try {
                PubContext.Upgrade = true;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "DMSAutoUpdater.exe";
                startInfo.Arguments = version;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(startInfo);
                Application.Exit();
            } catch (Exception ex) {
                PubContext.Upgrade = false;
                MessageBox.Show(ex.Message);
            }
        }

        public string NewVersion() {
            try {
                List<string> fileList = FtpHelper.GetFileListFromFtp("114.55.34.43", "dms", "123!@#shen", "/");
                string maxFileName = fileList.Max();
                return maxFileName.Substring(maxFileName.IndexOf("_") + 1).TrimEnd(".zip".ToCharArray());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
    }
}
