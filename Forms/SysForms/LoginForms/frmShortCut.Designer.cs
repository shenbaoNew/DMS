namespace DMS
{
    partial class frmShortCut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShortCut));
            this.itemPanel = new DevComponents.DotNetBar.ItemPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new DMS.VistaButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPanel
            // 
            // 
            // 
            // 
            this.itemPanel.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.itemPanel.BackgroundStyle.Class = "RibbonFileMenuContainer";
            this.itemPanel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel.ContainerControlProcessDialogKey = true;
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemPanel.ItemSpacing = 8;
            this.itemPanel.Location = new System.Drawing.Point(0, 2);
            this.itemPanel.MultiLine = true;
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(425, 222);
            this.itemPanel.TabIndex = 0;
            this.itemPanel.Text = "itemPanel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnConfig.CornerRadius = 2;
            this.btnConfig.Image = global::DMS.Properties.Resources.settings;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfig.ImageSize = new System.Drawing.Size(29, 29);
            this.btnConfig.Location = new System.Drawing.Point(0, 0);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(30, 30);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // frmShortCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(194)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(425, 256);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.panel1);
            this.DockAreas = DevComponents.DotNetBar.DockAreas.DockLeft;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShortCut";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "快捷桌面 ";
            this.Text = "快捷桌面 ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private DevComponents.DotNetBar.ItemPanel itemPanel;
        private System.Windows.Forms.Panel panel1;
        private DMS.VistaButton btnConfig;






    }
}