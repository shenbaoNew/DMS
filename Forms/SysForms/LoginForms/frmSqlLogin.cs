using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms
{
    public partial class frmSqlLogin : BaseForm
    {
        public AfterConfirmEventHandler AfterConnected;

        public frmSqlLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string database = txtDataBaseName.Text.Trim();
            string serverName = txtIP.Text.Trim();
            string uid = txtUserID.Text.Trim();
            string pwd = Security.Encryp(txtPwd.Text.Trim(),SecurityEnum.MMS);
            bool result = CheckIput(database, serverName, uid, pwd);
            if (result)
            {
                CustSqlConnection conn = new CustSqlConnection(serverName, database, uid, pwd);
                SqlConnectionManager manager = new SqlConnectionManager();
                StartProgress("正在测试连接，请稍后...");
                bool isseccess = manager.IsSuccess(conn);
                EndProgress();
                if (isseccess)
                {
                    this.DialogResult = DialogResult.OK;

                    manager.AddConnectionData(conn);
                    SqlConnectionManager.CurrentConnection = conn;
                }
                else
                {
                    MessageBox.Show("数据库测试连接失败", "系统提示", MessageBoxButtons.OKCancel);
                }
            }
        }
        private bool CheckIput(string database, string serverName, string uid, string pwd)
        {
            if (string.IsNullOrEmpty(serverName))
            {
                this.txtIP.Focus();
                MessageBox.Show("服务器名不能为空。");
                return false;
            }
            if (string.IsNullOrEmpty(database))
            {
       
                this.txtDataBaseName.Focus();
                MessageBox.Show("数据库名不能为空。");
                return false;
            }
            if (string.IsNullOrEmpty(uid))
            {
                this.txtUserID.Focus();
                MessageBox.Show("登录名名不能为空。");
                return false;
            }
            if (string.IsNullOrEmpty(pwd))
            {                  this.txtPwd.Focus();
                MessageBox.Show("密码不能为空。");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
