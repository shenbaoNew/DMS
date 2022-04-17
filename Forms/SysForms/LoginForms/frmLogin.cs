using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DMS.DataClass.Systems.User;
using System.Deployment.Application;
using DMS.DataClass.Pub;

namespace DMS.Forms
{
    public partial class frmLogin : BaseForm
    {
        public frmLogin()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            SplashClass.Status = "创建登录窗体...";
            SetDoubleBuffered(this);
            System.Threading.Thread.Sleep(1000);

            InitializeComponent();
            IinitMassages();
            this.showToolTip();

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                this.lblVersion.Text = "V" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            else
                this.lblVersion.Text = "V" + Application.ProductVersion;

            this.UpdateStyles();
        }

        private static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void IinitMassages() {
            SplashClass.Status = "加载相关数据和组件...";
            SystemManager.InitPubData();
            System.Threading.Thread.Sleep(1000);
            SplashClass.Status = "检查DMS与服务器的连通性...";
            CheckInitData();
            System.Threading.Thread.Sleep(1000);
            SplashClass.Status = "检查是否有新的版本...";
            PubContext.NewVesion = CommonHelper.NewVersion();
            this.lblNewVersion.Text = "V" + PubContext.NewVesion + "（新）";
            this.lblNewVersion.Visible = !string.IsNullOrEmpty(PubContext.NewVesion);
            System.Threading.Thread.Sleep(1000);
            SplashClass.Status = "友情提醒：相关数据和组件加载完成！";
            System.Threading.Thread.Sleep(1000);
            try {
                SplashClass.Close();
            } catch {

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;

            AfterLogin();

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

        private void CheckInitData()
        {
            CheckVersion();
        }

        private void CheckVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)//是否已连接 
            {
                this.ProgressStatus.Visible = true;
                CheckForUpdate();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BeginUpdate();
        }

        #region 升级

        private void CheckForUpdate()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                ad.CheckForUpdateCompleted += new System.Deployment.Application.CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                ad.CheckForUpdateProgressChanged += new System.Deployment.Application.DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);
                ad.CheckForUpdateAsync();
            }
        }

        void ad_CheckForUpdateProgressChanged(object sender, System.Deployment.Application.DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("下载中： {0}. {1:D}K of {2:D}K 已下载。", GetProgressString(e.State), e.BytesCompleted / 1024, e.BytesTotal / 1024);
            ProgressStatus.Value = e.ProgressPercentage;//给进度条赋值
            //downloadStatus.Text = "启动智能升级程序" + e.ProgressPercentage.ToString() + "%";
        }

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("错误：对不起，您不能更新当前版本！原因：\n" + e.Error.Message + "\n请与软件发布者联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("当前更新已取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Ask the user if they would like to update the application now.
            if (e.UpdateAvailable)
            {
                //this.lblVersonInfo.Visible = true;
                //this.btnUpdate.Visible = true;
            }
            else
                this.ProgressStatus.Visible = false;
        }

        string GetProgressString(System.Deployment.Application.DeploymentProgressState state)
        {
            if (state == System.Deployment.Application.DeploymentProgressState.DownloadingApplicationFiles)
            {
                return "正在下载组成应该应用程序的DLL与数据文件";
            }
            else if (state == DeploymentProgressState.DownloadingApplicationInformation)
            {
                return "正在下载应该程序清单";
            }
            else
            {
                return "配置程序清单";
            }
        }

        //开始更新
        private void BeginUpdate()
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
            ad.UpdateAsync();
        }

        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("已完成下载{1:D}K 中的{0:D}K -  已完成：{2:D}%", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage);
            //downloadStatus.Text = progressText;
            ProgressStatus.Value = e.ProgressPercentage;//给进度条赋值
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DialogResult dr = DialogResult.None;
            if (e.Cancelled)
            {
                dr = MessageBox.Show("应用程序更新已被取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Error != null)
            {
                dr = MessageBox.Show("错误：对不起，不能更新当前版本！原因：\n" + e.Error.Message + "\n请与软件发布者联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dr = MessageBox.Show("更新成功！是否现在重起应用程序？(如果您现在不重启，当前使用的还是旧版本，最新版本将下次启动本系统时使用！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
        }

        private void lblNewVersion_Click(object sender, EventArgs e) {
            if (MessageBox.Show("确定要升级吗？", "系统升级", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                CommonHelper.StartUpgradeProgram(PubContext.NewVesion);
            }
        }

        private void showToolTip() {
            this.toolTip.SetToolTip(this.lblNewVersion, "请点击进行升级");
        }

        #endregion
    }
}
