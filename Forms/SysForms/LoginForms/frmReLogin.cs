using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DMS.DataClass.Systems.User;

namespace DMS.Forms
{
    public partial class frmReLogin : BaseWindowsForm
    {
        private System.Drawing.Image CustomBackgroundImage;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        public event AfterSaveDataEventHandler AfterSaveDataEvent;

        public frmReLogin()
        {
            InitializeComponent();

            StartProgress("正在加载窗体，请稍后...");
            SystemManager.InitPubData();
            OperateMainFormShowMin();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                this.lblVersion.Text = "V" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            else
                this.lblVersion.Text = "V" + Application.ProductVersion;

            EndProgress();
        }

        private void StartProgress(string title)
        {
            ShowProgress.Stop();
            ShowProgress.Show(this, title);
        }

        private void EndProgress()
        {
            ShowProgress.Stop();
        }

        private void OperateMainFormShowMin()
        {
            frmMain main = PubContext.formMain as frmMain;
            if (main != null)
                main.Visible = false;
        }

        private void OperateMainFormShowMax()
        {
            frmMain main = PubContext.formMain as frmMain;
            if (main != null)
                main.Visible = true;
        }

        private void CreateControls()
        {
            CustomBackgroundImage = SystemManager.GetImage();
            tablePanel = new TableLayoutPanel();
            //
            // 
            // tablePanel
            // 
            this.tablePanel.BackColor = System.Drawing.Color.Transparent;
            this.tablePanel.ColumnCount = 1;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(128, 3);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel.TabIndex = 0;
        }

        private void loadBackgroundImage()
        {
            if (base.EnableGlass)
                this.tablePanel.BackgroundImage = CustomBackgroundImage;
        }

        private void loadControls()
        {
            SetDoubleBuffered(tablePanel);
            this.tablePanel.SuspendLayout();
            this.Controls.Add(this.tablePanel);
            this.tablePanel.ResumeLayout(false);
            loadBackgroundImage();
        }

        private static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            AfterLogin();

            if (AfterSaveDataEvent != null)
                AfterSaveDataEvent(this, true);
            this.Close();
        }

        public bool CheckInput()
        {
            if (txtUserName.Text.Trim() == string.Empty)
                ShowMessage.ShowInformation("请输入用户名");
            else if (txtPsd.Text.Trim() == string.Empty)
                ShowMessage.ShowInformation("请输入密码");
            else
            {
                UserData user = PubContext.AllUsers.Find(c => c.Code == txtUserName.Text.Trim());
                if (user == null)
                    ShowMessage.ShowError("不存在此用户");
                else
                {
                    string psd = Security.Encryp(txtPsd.Text.Trim(), SecurityEnum.Common);
                    if (user.Psd != psd)
                        ShowMessage.ShowError("密码输入错误");
                    else
                        return true;
                }
            }

            return false;
        }

        private void AfterLogin()
        {
            Program.Flag = true;
            PubContext.logUser = txtUserName.Text.Trim();

            PubContext.CurrentUser = PubContext.AllUsers.Find(c => c.Code == txtUserName.Text.Trim());
            if (PubContext.CurrentUser != null)
                PubContext.IsAdmin = PubContext.CurrentUser.IsAdmin;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            OperateMainFormShowMax();
        }
    }
}
