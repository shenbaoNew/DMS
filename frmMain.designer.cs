namespace DMS
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dockPanel = new DevComponents.DotNetBar.DockPanel();
            this.barStatus = new DevComponents.DotNetBar.Bar();
            this.lblNewVesion = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dockPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(697, 348);
            this.dockPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dockPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dockPanel.TabIndex = 0;
            // 
            // barStatus
            // 
            this.barStatus.AntiAlias = true;
            this.barStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.barStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barStatus.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.barStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblNewVesion});
            this.barStatus.Location = new System.Drawing.Point(0, 348);
            this.barStatus.Name = "barStatus";
            this.barStatus.Size = new System.Drawing.Size(697, 44);
            this.barStatus.Stretch = true;
            this.barStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barStatus.TabIndex = 2;
            this.barStatus.TabStop = false;
            this.barStatus.Text = "bar1";
            // 
            // lblNewVesion
            // 
            this.lblNewVesion.ForeColor = System.Drawing.Color.Red;
            this.lblNewVesion.Name = "lblNewVesion";
            this.lblNewVesion.Text = "新版本";
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(697, 392);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.barStatus);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "辅助开发管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.DockPanel dockPanel;
        private DevComponents.DotNetBar.Bar barStatus;
        private DevComponents.DotNetBar.LabelItem lblNewVesion;
    }
}

