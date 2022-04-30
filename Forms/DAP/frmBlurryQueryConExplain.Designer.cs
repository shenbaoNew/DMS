namespace DMS.Forms {
    partial class frmBlurryQueryConExplain {
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtCon = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.btnCase = new DevComponents.DotNetBar.ButtonX();
            this.btnParse = new DevComponents.DotNetBar.ButtonX();
            this.txtJson = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblFormat = new System.Windows.Forms.LinkLabel();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1474, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.txtCon);
            this.panelEx1.Controls.Add(this.btnCase);
            this.panelEx1.Controls.Add(this.btnParse);
            this.panelEx1.Controls.Add(this.txtJson);
            this.panelEx1.Controls.Add(this.lblFormat);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 25);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1474, 1208);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 15;
            // 
            // txtCon
            // 
            this.txtCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCon.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtCon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCon.Location = new System.Drawing.Point(139, 903);
            this.txtCon.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(1249, 278);
            this.txtCon.TabIndex = 16;
            // 
            // btnCase
            // 
            this.btnCase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCase.Location = new System.Drawing.Point(363, 831);
            this.btnCase.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCase.Name = "btnCase";
            this.btnCase.Size = new System.Drawing.Size(185, 58);
            this.btnCase.TabIndex = 13;
            this.btnCase.Text = "范例";
            this.btnCase.Click += new System.EventHandler(this.btnCase_Click);
            // 
            // btnParse
            // 
            this.btnParse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnParse.Location = new System.Drawing.Point(139, 831);
            this.btnParse.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(185, 58);
            this.btnParse.TabIndex = 13;
            this.btnParse.Text = "解析";
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtJson
            // 
            this.txtJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJson.IsReadOnly = false;
            this.txtJson.Location = new System.Drawing.Point(139, 43);
            this.txtJson.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(1249, 777);
            this.txtJson.TabIndex = 11;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(42, 43);
            this.lblFormat.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(67, 29);
            this.lblFormat.TabIndex = 12;
            this.lblFormat.TabStop = true;
            this.lblFormat.Text = "Json";
            this.lblFormat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFormat_LinkClicked);
            // 
            // frmBlurryQueryConExplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 1246);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "frmBlurryQueryConExplain";
            this.TabText = "BaseForm";
            this.Text = "Athena模糊查询json解析";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private ICSharpCode.TextEditor.TextEditorControl txtJson;
        private System.Windows.Forms.LinkLabel lblFormat;
        private DevComponents.DotNetBar.ButtonX btnParse;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtCon;
        private DevComponents.DotNetBar.ButtonX btnCase;
    }
}