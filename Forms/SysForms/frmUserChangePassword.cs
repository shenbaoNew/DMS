using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DMS.DataClass.Systems.User;

namespace DMS.Forms
{
    public partial class frmUserChangePassword :DevComponents.DotNetBar.BaseWindowsForm
    {
        public frmUserChangePassword()
        {
            InitializeComponent();
            LoadInitData();
        }

        private void LoadInitData()
        {
            txtUserID.Text = PubContext.CurrentUser.Code;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string userId = this.txtUserID.Text.Trim();
            string newPassword1 = this.txtNewPwd1.Text.Trim();
            string newPassword2 = this.txtNewPwd2.Text.Trim();
            string old = this.txtOldPwd.Text.Trim();
            bool cheOld = ConfirmOldPsd(old);
            if (cheOld)
            {
                bool ischeck = confirmNewPwd(newPassword1, newPassword2);
                if (ischeck)
                {
                    bool retVal = (new UserData()).UpdatePsd(userId, newPassword2);
                    if (retVal)
                    {
                        PubContext.CurrentUser.Psd = Security.Encryp(txtNewPwd2.Text, SecurityEnum.Common);

                        MessageBox.Show("�����޸ĳɹ�,��������ϵͳ�������Ч!", "�����޸�...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("�����޸�ʧ��,���Ժ�����!", "�����޸�...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("�������������!", "��������֤...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtNewPwd2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkInputPwd()
        {
            string firstPassword = txtNewPwd1.Text.Trim();
            string secondPassword = txtNewPwd2.Text.Trim();
            bool ischeck = confirmNewPwd(firstPassword, secondPassword);
            if (ischeck)
                this.AcceptButton = this.btnOK;
        }
        private bool confirmoldPwd(string oldPwd,string newPwd)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(oldPwd))
            {
                if (oldPwd != newPwd.Trim())
                {
                    MessageBox.Show("�������������!", "��������֤...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtOldPwd.Focus();
                    result = false;
                }
            }
            else
            {
                MessageBox.Show("�����벻��Ϊ��!", "��������֤...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtOldPwd.Focus();
                result = false;

            }
            return result;
        }
        private bool confirmNewPwd(string first, string second)
        {
            if (first == second)
            {
                if (string.IsNullOrEmpty(first))
                {
                    MessageBox.Show("��ϵͳ��֧�ֿ�����!", "��������֤...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPwd1.Focus();
                    return false;
                }
                else

                    return true;
            }
            else
            {
                MessageBox.Show("�������������벻һ��!", "��������֤...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPwd1.Text = string.Empty;
                txtNewPwd2.Text = string.Empty;
                txtNewPwd1.Focus();
                return false;

            }
        }

        private bool ConfirmOldPsd(string old)
        {
            if (Security.Encryp(old, SecurityEnum.Common) != PubContext.CurrentUser.Psd)
                return false;

            return true;
        }

        private bool ConfirmUserInfo()
        {
            string userId = txtUserID.Text.Trim();
            string oldPassword = txtOldPwd.Text.Trim();
            string firstPassword = txtNewPwd1.Text.Trim();
            string secondPassword = txtNewPwd2.Text.Trim();
            bool ischeck = confirmNewPwd(firstPassword, secondPassword);
             if (ischeck)
                    ischeck =confirmoldPwd(oldPassword, secondPassword); 
             return ischeck;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}