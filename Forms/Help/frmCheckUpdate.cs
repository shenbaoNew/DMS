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

namespace DMS.Forms
{
    public partial class frmCheckUpdate : BaseForm
    {
        private long sizeOfUpdate = 0; 
        public frmCheckUpdate()
        {
            InitializeComponent();
            Upgrade();
        }

        public void Upgrade() {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string newVersion = NewVersion();
            bool needUpgrade = newVersion.CompareTo(version) > 0;
            if (needUpgrade) {
                if(MessageBox.Show("检测到最新版本：" + newVersion + "，是否更新?", "请选择", MessageBoxButtons.OKCancel)
                    == DialogResult.OK) {

                }
            }
        }

        public void DownLoadFile() {
            FtpHelper.DownLoadFileFromFtp("114.55.34.43", "dms", "123!@#shen", "/DMS_V1.0.1.47.zip"
                , @"E:\temp\test\DMS_V1.0.1.47.zip");
           
            
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

        private void UpdateApplication()
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
            downloadStatus.Text = "启动智能升级程序" + e.ProgressPercentage.ToString() + "%";
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

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("错误：对不起，您不能更新当前版本！原因：\n" + e.Error.Message + "\n请与软件发布者联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("当前更新已取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }

            // Ask the user if they would like to update the application now.
            if (e.UpdateAvailable)
            {
                sizeOfUpdate = e.UpdateSizeBytes;

                if (!e.IsUpdateRequired)
                {
                    DialogResult dr = MessageBox.Show("检测到有可用更新，确定升级当前版本吗？", "更新检测", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == dr)
                    {
                        BeginUpdate();
                    }
                    else
                    {
                        ApplicationDeployment.CurrentDeployment.UpdateAsyncCancel();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("检测到有可用更新，将重启该软件系统，进行强制更新！");
                    BeginUpdate();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("您计算机上安装的辅助开发管理系统已是最新版本，此时不需要更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult.OK == dr)
                {
                    this.Dispose();
                }

            }
        }

        //开始更新
        private void BeginUpdate()
        {
            this.Text = "辅助开发管理系统在线升级程序";
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
            ad.UpdateAsync();
        }

        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("已完成下载{1:D}K 中的{0:D}K -  已完成：{2:D}%", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage);
            downloadStatus.Text = progressText;
            ProgressStatus.Value = e.ProgressPercentage;//给进度条赋值
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DialogResult dr = DialogResult.None;
            if (e.Cancelled)
            {
                dr = MessageBox.Show("应用程序更新已被取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult.OK == dr)
                {
                    this.Close();
                }

            }
            else if (e.Error != null)
            {
                dr = MessageBox.Show("错误：对不起，不能更新当前版本！原因：\n" + e.Error.Message + "\n请与软件发布者联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult.OK == dr)
                {
                    this.Close();
                }
            }

            dr = MessageBox.Show("更新成功！是否现在重起应用程序？(如果您现在不重启，当前使用的还是旧版本，最新版本将下次启动本系统时使用！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
            else if (DialogResult.Cancel == dr)
            {
                this.Close();
            }
        }

        //取消更新
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定取消当前更新吗？", "取消更新", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                    ad.UpdateAsyncCancel();
                    this.Close();
                }
            }
        }

        private void frmCheckUpdate_Load(object sender, EventArgs e)
        {
            downloadStatus.Text = "";
            //ProgressStatus.ProgressBarColor = Color.BlueViolet;
            UpdateApplication(); 
        }


    }
}
