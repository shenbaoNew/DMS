namespace DMS.Forms
{
    partial class ProgressForm
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
            this.lblProgress = new System.Windows.Forms.Label();
            this.topPanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.pic_Status = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Status)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(12, 114);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(325, 23);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topPanel
            // 
            this.topPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.topPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.topPanel.Controls.Add(this.pic_Status);
            this.topPanel.Controls.Add(this.lblProgress);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.ExpandButtonVisible = false;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(349, 151);
            this.topPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.topPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.topPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.topPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.topPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.topPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.topPanel.Style.GradientAngle = 90;
            this.topPanel.TabIndex = 3;
            this.topPanel.TitleHeight = 0;
            this.topPanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.topPanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.topPanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.topPanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.topPanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.topPanel.TitleStyle.GradientAngle = 90;
            this.topPanel.TitleText = "  Manufacture Management System";
            // 
            // pic_Status
            // 
            this.pic_Status.Location = new System.Drawing.Point(155, 55);
            this.pic_Status.Name = "pic_Status";
            this.pic_Status.Size = new System.Drawing.Size(40, 40);
            this.pic_Status.TabIndex = 1;
            this.pic_Status.TabStop = false;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(349, 151);
            this.ControlBox = false;
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.Shown += new System.EventHandler(this.ProgressForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProgressForm_Paint);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProgress;
        private DevComponents.DotNetBar.ExpandablePanel topPanel;
        private System.Windows.Forms.PictureBox pic_Status;
    }
}