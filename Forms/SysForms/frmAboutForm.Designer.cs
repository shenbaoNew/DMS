namespace DMS.Forms
{
    partial class frmAboutForm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butOK = new System.Windows.Forms.Button();
            this.listAssemblies = new System.Windows.Forms.ListBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.linkInfo = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::DMS.Properties.Resources.TopPanel;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.butOK.Location = new System.Drawing.Point(499, 304);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(68, 21);
            this.butOK.TabIndex = 8;
            this.butOK.Text = "OK";
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // listAssemblies
            // 
            this.listAssemblies.BackColor = System.Drawing.Color.LightCyan;
            this.listAssemblies.ItemHeight = 12;
            this.listAssemblies.Location = new System.Drawing.Point(27, 153);
            this.listAssemblies.Name = "listAssemblies";
            this.listAssemblies.Size = new System.Drawing.Size(538, 136);
            this.listAssemblies.TabIndex = 9;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Location = new System.Drawing.Point(27, 95);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(59, 12);
            this.labelVersion.TabIndex = 10;
            this.labelVersion.Text = "<Version>";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(27, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Assemblies:";
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 50;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // linkInfo
            // 
            this.linkInfo.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkInfo.BackColor = System.Drawing.Color.Transparent;
            this.linkInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.linkInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkInfo.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkInfo.Location = new System.Drawing.Point(25, 308);
            this.linkInfo.Name = "linkInfo";
            this.linkInfo.Size = new System.Drawing.Size(356, 15);
            this.linkInfo.TabIndex = 13;
            this.linkInfo.TabStop = true;
            this.linkInfo.Text = "Developed by ShenBao(http://my.csdn.net/nidexuanzhe)";
            this.linkInfo.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.linkInfo.Click += new System.EventHandler(this.linkInfo_Click);
            // 
            // frmAboutForm
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.BackgroundImage = global::DMS.Properties.Resources.background;
            this.CancelButton = this.butOK;
            this.ClientSize = new System.Drawing.Size(579, 337);
            this.Controls.Add(this.linkInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.listAssemblies);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于 DMS";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AboutForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.ListBox listAssemblies;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.LinkLabel linkInfo;
    }
}