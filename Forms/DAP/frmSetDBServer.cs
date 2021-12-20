using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DMS.DataClass.Systems.User;
using DMS.Helper;

namespace DMS.Forms {
    public partial class frmSetDBServer : DevComponents.DotNetBar.BaseWindowsForm {
        public frmSetDBServer() {
            InitializeComponent();
            LoadInitData();
        }

        private void LoadInitData() {
            this.txtPwd.Text = PubContext.MariaDDBPsd;
            this.txtDB.Text = PubContext.MariaDBDataBase;
            this.txtServer.Text = PubContext.MariaDBServer;
            this.txtUser.Text = PubContext.MariaDBLoginUser;
            this.txtPort.Text = PubContext.MariaDBPort;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            string server = this.txtServer.Text.Trim();
            string user = this.txtUser.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();
            string db = this.txtDB.Text.Trim();
            string port = this.txtPort.Text.Trim();

            MySQLHelper helper = new MySQLHelper(server, db, user, pwd, port);
            try {
                helper.TestConn();
                this.SaveConfit();
                PubContext.MariaDBServer = server;
                PubContext.MariaDBPort = port;
                PubContext.MariaDBDataBase = db;
                PubContext.MariaDBLoginUser = user;
                PubContext.MariaDDBPsd = pwd;
                PubContext.MariadbDBConnection = string.Format("server={0};user id={1};password={2};database={3};port={4};Charset=utf8", PubContext.MariaDBServer,
                    PubContext.MariaDBLoginUser, PubContext.MariaDDBPsd, PubContext.MariaDBDataBase, PubContext.MariaDBPort);

                MessageBox.Show("连接成功");
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public bool SaveConfit() {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load("menu.xml");

                XmlNode node = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Server", xml);
                node.InnerText = this.txtServer.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/DataBase", xml);
                node.InnerText = this.txtDB.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/User", xml);
                node.InnerText = this.txtUser.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Psd", xml);
                node.InnerText = this.txtPwd.Text.Trim();
                node = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Port", xml);
                node.InnerText = this.txtPort.Text.Trim();

                xml.Save("menu.xml");

                return true;
            } catch {
                return false;
            }
        }

        private void txtNewPwd2_TextChanged(object sender, EventArgs e) {

        }

        private void checkInputPwd() {
            string firstPassword = txtUser.Text.Trim();
            string secondPassword = txtPwd.Text.Trim();
            bool ischeck = confirmNewPwd(firstPassword, secondPassword);
            if (ischeck)
                this.AcceptButton = this.btnOK;
        }
        private bool confirmoldPwd(string oldPwd, string newPwd) {
            bool result = true;
            if (!string.IsNullOrEmpty(oldPwd)) {
                if (oldPwd != newPwd.Trim()) {
                    MessageBox.Show("旧密码输入错误!", "旧密码验证...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDB.Focus();
                    result = false;
                }
            } else {
                MessageBox.Show("旧密码不能为空!", "旧密码验证...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDB.Focus();
                result = false;

            }
            return result;
        }
        private bool confirmNewPwd(string first, string second) {
            if (first == second) {
                if (string.IsNullOrEmpty(first)) {
                    MessageBox.Show("本系统不支持空密码!", "新密码验证...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return false;
                } else

                    return true;
            } else {
                MessageBox.Show("新密码两次输入不一致!", "新密码验证...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Text = string.Empty;
                txtPwd.Text = string.Empty;
                txtUser.Focus();
                return false;

            }
        }

        private bool ConfirmOldPsd(string old) {
            if (Security.Encryp(old, SecurityEnum.Common) != PubContext.CurrentUser.Psd)
                return false;

            return true;
        }

        private bool ConfirmUserInfo() {
            string userId = txtServer.Text.Trim();
            string oldPassword = txtDB.Text.Trim();
            string firstPassword = txtUser.Text.Trim();
            string secondPassword = txtPwd.Text.Trim();
            bool ischeck = confirmNewPwd(firstPassword, secondPassword);
            if (ischeck)
                ischeck = confirmoldPwd(oldPassword, secondPassword);
            return ischeck;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}