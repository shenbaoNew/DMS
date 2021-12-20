using DMS.DataClass.Pub;
using DMS.Forms.DAP.InitIDE;
using DMS.Forms.DAP.SelectWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DMS.Forms {
    public partial class frmInitIDE : BaseForm {
        public frmInitIDE() {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSrcSelect_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                cmbVersion.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void chk301_CheckedChanged(object sender, EventArgs e) {
            if (chk301.Checked) {
                chk311.Checked = false;
                chk312.Checked = false;
                chk401.Checked = false;

                cmbVersion.Text = "3.0.1.";
            }
        }

        private void chk311_CheckedChanged(object sender, EventArgs e) {
            if (chk311.Checked) {
                chk301.Checked = false;
                chk312.Checked = false;
                chk401.Checked = false;

                cmbVersion.Text = "3.1.1.";
            }
        }

        private void chk312_CheckedChanged(object sender, EventArgs e) {

            if (chk312.Checked) {
                chk301.Checked = false;
                chk311.Checked = false;
                chk401.Checked = false;

                cmbVersion.Text = "3.1.2.";
            }
        }

        private void chk401_CheckedChanged(object sender, EventArgs e) {
            if (chk401.Checked) {
                chk301.Checked = false;
                chk311.Checked = false;
                chk312.Checked = false;

                cmbVersion.Text = "4.0.1.";
            }
        }

        private void btnStartInit_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(this.txtPath.Text.Trim())) {
                MessageBox.Show("请输入DAP项目路径");
                return;
            }
            if (string.IsNullOrEmpty(this.txtJdkPath.Text.Trim())) {
                MessageBox.Show("请输入OpenJDK路径");
                return;
            }
            if (string.IsNullOrEmpty(this.cmbVersion.Text.Trim())) {
                MessageBox.Show("请输入运行环境版本");
                return;
            }
            this.txtLog.Text = "";
            InitTool tool = new InitTool(this.txtLog, this.txtPath.Text.Trim(), this.GetVersion(), this.cmbVersion.Text.Trim()
                , this.txtJdkPath.Text.Trim()
                , this.chkFirst.Checked);
            tool.InitDapRunEnvironment();
        }

        private string GetVersion() {
            int index = this.cmbVersion.Text.LastIndexOf(".");
            return this.cmbVersion.Text.Substring(0, index);
        }

        private void btnOpenPath_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                return;

            OpenPath(txtPath.Text.Trim());
        }

        private void OpenPath(string path) {
            if (Directory.Exists(path)) {
                Process.Start("Explorer.exe", path);
            }
        }

        private void btnJdk_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                txtJdkPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnOpenJdk_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtJdkPath.Text.Trim()))
                return;

            OpenPath(txtJdkPath.Text.Trim());
        }

        private void btnPathClear_Click(object sender, EventArgs e) {
            this.txtPath.Text = "";
        }

        private void btnClearJdk_Click(object sender, EventArgs e) {
            this.txtJdkPath.Text = "";
        }

        public bool SaveConfig() {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load("menu.xml");

                XmlNode node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/ProjectPath", xml);
                node.InnerText = this.txtPath.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/JdkPath", xml);
                node.InnerText = this.txtJdkPath.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/Version", xml);
                node.InnerText = this.cmbVersion.Text.Trim();

                xml.Save("menu.xml");

                return true;
            } catch {
                return false;
            }
        }

        public void LoadConfig() {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load("menu.xml");

                XmlNode node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/ProjectPath", xml);
                this.txtPath.Text = node.InnerText;
                node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/JdkPath", xml);
                this.txtJdkPath.Text = node.InnerText;
                node = XmlHelper.GetNodeByPath(@"DMS/DAP/Init/Version", xml);
                this.cmbVersion.Text = node.InnerText;

                xml.Save("menu.xml");
            } catch {
            }
        }

        private void frmInitIDE_Load(object sender, EventArgs e) {
            this.showToolTip();
            this.LoadConfig();
        }

        private void showToolTip() {
            this.firstTip.SetToolTip(this.chkFirst, "首次安装dap环境，用于新项目启动，还未进行任何开发");
        }

        private void btnSaveConfig_Click(object sender, EventArgs e) {
            this.SaveConfig();
            MessageBox.Show("保存成功");
        }

        private void chkFirst_CheckedChanged(object sender, EventArgs e) {
            if (this.chkFirst.Checked) {
                this.lblFirst.Text = "首次安装dap环境，用于新项目启动，还未进行任何开发";
            } else {
                this.lblFirst.Text = string.Empty;
            }
        }

        private void tsbRanInit_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(this.txtPath.Text.Trim())) {
                MessageBox.Show("请输入DAP项目路径");
                return;
            }
            InitTool initTool = new InitTool();
            bool success = initTool.StartRunBat(this.txtPath.Text.Trim());
            if (!success) {
                MessageBox.Show("系统错误或者项目路径下升级文件不存在");
            }
        }

        private void tsbDapVersion_Click(object sender, EventArgs e) {
            this.SelectDapVersion("toolbar");
        }

        private void btnSelectVersion_Click(object sender, EventArgs e) {
            this.SelectDapVersion("select");
        }

        private void SelectDapVersion(string from) {
            frmSelectDapVersion selectVersion = new frmSelectDapVersion(from);
            selectVersion.ShowDialog();
            if (selectVersion.DialogResult == DialogResult.OK && selectVersion.SelectPatch != null) {
                this.cmbVersion.Text = selectVersion.SelectPatch;
            }
        }

        private void tsbParameter_Click(object sender, EventArgs e) {
            frmParameter parameter = new frmParameter(this.txtPath.Text.Trim());
            parameter.ShowDialog();
        }
    }
}
