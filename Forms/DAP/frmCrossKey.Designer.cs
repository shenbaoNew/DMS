namespace DMS.Forms {
    partial class frmCrossKey {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOut = new System.Windows.Forms.CheckBox();
            this.btnGen = new DevComponents.DotNetBar.ButtonX();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtHost = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.txtService = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "digiService：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "digiHost：";
            // 
            // cbOut
            // 
            this.cbOut.AutoSize = true;
            this.cbOut.Location = new System.Drawing.Point(76, 190);
            this.cbOut.Name = "cbOut";
            this.cbOut.Size = new System.Drawing.Size(75, 17);
            this.cbOut.TabIndex = 11;
            this.cbOut.Text = "外调cross";
            this.cbOut.UseVisualStyleBackColor = true;
            // 
            // btnGen
            // 
            this.btnGen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGen.Location = new System.Drawing.Point(76, 226);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(85, 35);
            this.btnGen.TabIndex = 12;
            this.btnGen.Text = "digi-key";
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(184, 233);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(276, 20);
            this.tbKey.TabIndex = 13;
            this.tbKey.Text = "B3C7372BBFCC8828EC220F83C0368521";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.txtService);
            this.panelEx1.Controls.Add(this.txtHost);
            this.panelEx1.Controls.Add(this.tbKey);
            this.panelEx1.Controls.Add(this.btnGen);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.cbOut);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(742, 407);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 14;
            // 
            // txtHost
            // 
            // 
            // 
            // 
            this.txtHost.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtHost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHost.Location = new System.Drawing.Point(76, 13);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(589, 74);
            this.txtHost.TabIndex = 14;
            this.txtHost.Text = "{\"prod\":\"E10\",\"ver\":\"5.0.0.2\",\"ip\":\"172.16.2.161\",\"lang\":\"zh_CN\",\"timestamp\":\"202" +
    "01009110912004\",\"id\":\"DemoCompany\",\"acct\":\"dcms\"}";
            // 
            // txtService
            // 
            // 
            // 
            // 
            this.txtService.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtService.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtService.Location = new System.Drawing.Point(76, 98);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(589, 77);
            this.txtService.TabIndex = 15;
            this.txtService.Text = "{\"prod\":\"HNTE\",\"name\":\"hnte.erpsync.setsyncresult\",\"ip\":\"172.16.1.24\",\"id\":\"hnteb" +
    "sync60\"}";
            // 
            // frmCrossKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 407);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmCrossKey";
            this.TabText = "BaseForm";
            this.Text = "生成CrossKey";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbOut;
        private DevComponents.DotNetBar.ButtonX btnGen;
        private System.Windows.Forms.TextBox tbKey;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtService;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtHost;
    }
}

