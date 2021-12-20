namespace DMS.Forms {
    partial class frmLangChange {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnChs2Cht = new DevComponents.DotNetBar.ButtonX();
            this.rtxt1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.rtxt2 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rtxt2);
            this.panelEx1.Controls.Add(this.rtxt1);
            this.panelEx1.Controls.Add(this.btnChs2Cht);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 25);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(864, 446);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnChs2Cht
            // 
            this.btnChs2Cht.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChs2Cht.AllowDrop = true;
            this.btnChs2Cht.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChs2Cht.Location = new System.Drawing.Point(33, 240);
            this.btnChs2Cht.Name = "btnChs2Cht";
            this.btnChs2Cht.Size = new System.Drawing.Size(88, 38);
            this.btnChs2Cht.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChs2Cht.TabIndex = 2;
            this.btnChs2Cht.Text = "简转繁";
            this.btnChs2Cht.Click += new System.EventHandler(this.btnChs2Cht_Click);
            // 
            // rtxt1
            // 
            // 
            // 
            // 
            this.rtxt1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rtxt1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rtxt1.Location = new System.Drawing.Point(33, 12);
            this.rtxt1.Name = "rtxt1";
            this.rtxt1.Size = new System.Drawing.Size(592, 100);
            this.rtxt1.TabIndex = 3;
            // 
            // rtxt2
            // 
            // 
            // 
            // 
            this.rtxt2.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rtxt2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rtxt2.Location = new System.Drawing.Point(33, 126);
            this.rtxt2.Name = "rtxt2";
            this.rtxt2.Size = new System.Drawing.Size(592, 100);
            this.rtxt2.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmLangChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 471);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmLangChange";
            this.Text = "frmLangChange";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnChs2Cht;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rtxt2;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rtxt1;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}