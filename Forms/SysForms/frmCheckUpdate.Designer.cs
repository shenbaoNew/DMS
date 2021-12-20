namespace DMS.Forms
{
    partial class frmCheckUpdate
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
            this.ProgressStatus = new System.Windows.Forms.ProgressBar();
            this.downloadStatus = new DevComponents.DotNetBar.LabelX();
            this.tablPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tablPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressStatus
            // 
            this.ProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressStatus.Location = new System.Drawing.Point(47, 141);
            this.ProgressStatus.Name = "ProgressStatus";
            this.ProgressStatus.Size = new System.Drawing.Size(348, 20);
            this.ProgressStatus.TabIndex = 0;
            // 
            // downloadStatus
            // 
            this.downloadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadStatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.downloadStatus.BackgroundStyle.Class = "";
            this.downloadStatus.Location = new System.Drawing.Point(47, 99);
            this.downloadStatus.Name = "downloadStatus";
            this.downloadStatus.Size = new System.Drawing.Size(348, 23);
            this.downloadStatus.TabIndex = 1;
            // 
            // tablPanel
            // 
            this.tablPanel.BackColor = System.Drawing.Color.Transparent;
            this.tablPanel.ColumnCount = 3;
            this.tablPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tablPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablPanel.Controls.Add(this.downloadStatus, 1, 1);
            this.tablPanel.Controls.Add(this.ProgressStatus, 1, 2);
            this.tablPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablPanel.Location = new System.Drawing.Point(0, 0);
            this.tablPanel.Name = "tablPanel";
            this.tablPanel.RowCount = 4;
            this.tablPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tablPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tablPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablPanel.Size = new System.Drawing.Size(443, 262);
            this.tablPanel.TabIndex = 2;
            // 
            // frmCheckUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 262);
            this.Controls.Add(this.tablPanel);
            this.Name = "frmCheckUpdate";
            this.Text = "frmCheckUpdate";
            this.Load += new System.EventHandler(this.frmCheckUpdate_Load);
            this.tablPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressStatus;
        private DevComponents.DotNetBar.LabelX downloadStatus;
        private System.Windows.Forms.TableLayoutPanel tablPanel;

    }
}