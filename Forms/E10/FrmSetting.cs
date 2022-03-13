using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DMS.Forms;

namespace KMSearchTools {
    public partial class FrmSetting : Form {
        public FrmSetting() {
            InitializeComponent();

            txtIP.Text = frmE10SearchMain.FSettingPara.DatabaseIP;
            txtDB.Text = frmE10SearchMain.FSettingPara.DatabaseName;
            txtUser.Text = frmE10SearchMain.FSettingPara.DatabaseUser;
            string sPW = frmE10SearchMain.FSettingPara.DatabasePW;
            txtPW.Text = Security.DecryptDES(sPW);
        }

        private void button2_Click(object sender, EventArgs e) {

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SettingPara dbp = new SettingPara();
            dbp.DatabaseIP = txtIP.Text;
            dbp.DatabaseName = txtDB.Text;
            dbp.DatabaseUser = txtUser.Text;
            dbp.DatabasePW = Security.EncryptDES(txtPW.Text);

            cfa.AppSettings.Settings["DatabaseIP"].Value = dbp.DatabaseIP;
            cfa.AppSettings.Settings["DatabaseName"].Value = dbp.DatabaseName;
            cfa.AppSettings.Settings["DatabaseUser"].Value = dbp.DatabaseUser;
            cfa.AppSettings.Settings["DatabasePW"].Value = dbp.DatabasePW;
            cfa.Save();

            frmE10SearchMain.FSettingPara = dbp;
            DialogResult = DialogResult.OK;
        }

        private void FrmSetting_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            string MyConn = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtIP.Text, txtDB.Text, txtUser.Text, txtPW.Text);
            SqlConnection MyConnection = new SqlConnection(MyConn);
            try {
                MyConnection.Open();
                MessageBox.Show("测试成功！");
            } catch (Exception ex) {
                MessageBox.Show("测试失败："+ex.Message);
            } finally {
                MyConnection.Close();
            }

        }
     
    }
}
