using DMS.DataClass.Pub;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DMS.Forms {
    public partial class frmCheckUpdate : BaseForm {
        bool needUpgrade = false;
        string newVersion = "";
        public frmCheckUpdate() {
            InitializeComponent();
            Upgrade();
        }

        public void Upgrade() {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            newVersion = NewVersion();
            needUpgrade = newVersion.CompareTo(version) > 0;
            if (needUpgrade) {
                PubContext.NewVesion = newVersion;
                this.SetVersionText(needUpgrade);
                if (MessageBox.Show("检测到最新版本：" + newVersion + "，是否更新?", "请选择", MessageBoxButtons.OKCancel)
                    == DialogResult.OK) {
                    CommonHelper.StartUpgradeProgram(newVersion);
                }
            } else {
                PubContext.NewVesion = string.Empty;
                MessageBox.Show("当前程序已是最新版本，无需更新...");
            }
        }

        private void SetVersionText(bool needUpgrade) {
            this.lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                + (needUpgrade ? "" : "（最新）");
            this.lblNewVersion.Text = newVersion;
            this.lblNew.Visible = needUpgrade;
            this.lblNewVersion.Visible = needUpgrade;
        }
        

        public string NewVersion() {
            try {
                List<string> fileList = FtpHelper.GetFileListFromFtp(PubContext.DmsFtpServer, PubContext.DmsFtpUser, PubContext.DmsFtpPwd, "/");
                string maxFileName = fileList.Max();
                return maxFileName.Substring(maxFileName.IndexOf("_") + 1).TrimEnd(".zip".ToCharArray());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        private void frmCheckUpdate_Load(object sender, EventArgs e) {
            this.SetVersionText(needUpgrade);
        }

        private void tsbUpgrade_Click(object sender, EventArgs e) {
            this.Upgrade();
        }

        private void tsbViewLog_Click(object sender, EventArgs e) {
            try {
                string logName = Path.Combine(Environment.CurrentDirectory, "DMS.log");
                Process.Start("NOTEPAD.exe", logName);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
