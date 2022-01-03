namespace DMS.Forms {
    partial class frmInitIDE {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInitIDE));
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectVersion = new DevComponents.DotNetBar.ButtonX();
            this.lblFirst = new System.Windows.Forms.Label();
            this.chkFirst = new System.Windows.Forms.CheckBox();
            this.btnSaveConfig = new DevComponents.DotNetBar.ButtonX();
            this.txtJdkPath = new System.Windows.Forms.TextBox();
            this.btnJdk = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenJdk = new DevComponents.DotNetBar.ButtonItem();
            this.btnClearJdk = new DevComponents.DotNetBar.ButtonItem();
            this.label2 = new System.Windows.Forms.Label();
            this.groupLog = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtLog = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.btnStartInit = new DevComponents.DotNetBar.ButtonX();
            this.cmbVersion = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cb301_1010 = new DevComponents.Editors.ComboItem();
            this.cb311_1011 = new DevComponents.Editors.ComboItem();
            this.cb312_1017 = new DevComponents.Editors.ComboItem();
            this.cb312_1019 = new DevComponents.Editors.ComboItem();
            this.cb312_1021 = new DevComponents.Editors.ComboItem();
            this.cb312_1022 = new DevComponents.Editors.ComboItem();
            this.cb401_1006 = new DevComponents.Editors.ComboItem();
            this.chk401 = new System.Windows.Forms.CheckBox();
            this.chk311 = new System.Windows.Forms.CheckBox();
            this.chk312 = new System.Windows.Forms.CheckBox();
            this.chk301 = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenPath = new DevComponents.DotNetBar.ButtonItem();
            this.btnPathClear = new DevComponents.DotNetBar.ButtonItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.firstTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRanInit = new System.Windows.Forms.ToolStripButton();
            this.tsbDapVersion = new System.Windows.Forms.ToolStripButton();
            this.tsbParameter = new System.Windows.Forms.ToolStripButton();
            this.expandablePanel1.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.label3);
            this.expandablePanel1.Controls.Add(this.btnSelectVersion);
            this.expandablePanel1.Controls.Add(this.lblFirst);
            this.expandablePanel1.Controls.Add(this.chkFirst);
            this.expandablePanel1.Controls.Add(this.btnSaveConfig);
            this.expandablePanel1.Controls.Add(this.txtJdkPath);
            this.expandablePanel1.Controls.Add(this.btnJdk);
            this.expandablePanel1.Controls.Add(this.label2);
            this.expandablePanel1.Controls.Add(this.groupLog);
            this.expandablePanel1.Controls.Add(this.btnStartInit);
            this.expandablePanel1.Controls.Add(this.cmbVersion);
            this.expandablePanel1.Controls.Add(this.chk401);
            this.expandablePanel1.Controls.Add(this.chk311);
            this.expandablePanel1.Controls.Add(this.chk312);
            this.expandablePanel1.Controls.Add(this.chk301);
            this.expandablePanel1.Controls.Add(this.txtPath);
            this.expandablePanel1.Controls.Add(this.btnSelect);
            this.expandablePanel1.Controls.Add(this.label6);
            this.expandablePanel1.Controls.Add(this.label1);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 42);
            this.expandablePanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(1850, 1096);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 5;
            this.expandablePanel1.TitleHeight = 58;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "DAP环境初始化";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1100, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "项目文件夹最好以_backend结尾";
            // 
            // btnSelectVersion
            // 
            this.btnSelectVersion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectVersion.AutoExpandOnClick = true;
            this.btnSelectVersion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectVersion.Location = new System.Drawing.Point(873, 271);
            this.btnSelectVersion.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelectVersion.Name = "btnSelectVersion";
            this.btnSelectVersion.Size = new System.Drawing.Size(200, 51);
            this.btnSelectVersion.TabIndex = 21;
            this.btnSelectVersion.Text = "选择";
            this.btnSelectVersion.Click += new System.EventHandler(this.btnSelectVersion_Click);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.ForeColor = System.Drawing.Color.Red;
            this.lblFirst.Location = new System.Drawing.Point(1133, 341);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(0, 29);
            this.lblFirst.TabIndex = 20;
            // 
            // chkFirst
            // 
            this.chkFirst.AutoSize = true;
            this.chkFirst.Location = new System.Drawing.Point(1128, 285);
            this.chkFirst.Name = "chkFirst";
            this.chkFirst.Size = new System.Drawing.Size(95, 33);
            this.chkFirst.TabIndex = 19;
            this.chkFirst.Text = "首次";
            this.chkFirst.UseVisualStyleBackColor = true;
            this.chkFirst.CheckedChanged += new System.EventHandler(this.chkFirst_CheckedChanged);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveConfig.AutoExpandOnClick = true;
            this.btnSaveConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveConfig.Location = new System.Drawing.Point(534, 407);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(243, 66);
            this.btnSaveConfig.TabIndex = 18;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // txtJdkPath
            // 
            this.txtJdkPath.Location = new System.Drawing.Point(233, 197);
            this.txtJdkPath.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtJdkPath.Name = "txtJdkPath";
            this.txtJdkPath.Size = new System.Drawing.Size(604, 36);
            this.txtJdkPath.TabIndex = 16;
            // 
            // btnJdk
            // 
            this.btnJdk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnJdk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnJdk.Location = new System.Drawing.Point(873, 193);
            this.btnJdk.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnJdk.Name = "btnJdk";
            this.btnJdk.Size = new System.Drawing.Size(200, 51);
            this.btnJdk.StopPulseOnMouseOver = false;
            this.btnJdk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnJdk.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpenJdk,
            this.btnClearJdk});
            this.btnJdk.SubItemsExpandWidth = 20;
            this.btnJdk.TabIndex = 17;
            this.btnJdk.Text = "选择";
            this.btnJdk.Click += new System.EventHandler(this.btnJdk_Click);
            // 
            // btnOpenJdk
            // 
            this.btnOpenJdk.GlobalItem = false;
            this.btnOpenJdk.Name = "btnOpenJdk";
            this.btnOpenJdk.Text = "打开路径";
            this.btnOpenJdk.Click += new System.EventHandler(this.btnOpenJdk_Click);
            // 
            // btnClearJdk
            // 
            this.btnClearJdk.GlobalItem = false;
            this.btnClearJdk.Name = "btnClearJdk";
            this.btnClearJdk.Text = "清除";
            this.btnClearJdk.Click += new System.EventHandler(this.btnClearJdk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "JDK跟路径：";
            // 
            // groupLog
            // 
            this.groupLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupLog.Controls.Add(this.txtLog);
            this.groupLog.Location = new System.Drawing.Point(236, 529);
            this.groupLog.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(1367, 493);
            // 
            // 
            // 
            this.groupLog.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupLog.Style.BackColorGradientAngle = 90;
            this.groupLog.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupLog.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLog.Style.BorderBottomWidth = 1;
            this.groupLog.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupLog.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLog.Style.BorderLeftWidth = 1;
            this.groupLog.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLog.Style.BorderRightWidth = 1;
            this.groupLog.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLog.Style.BorderTopWidth = 1;
            this.groupLog.Style.Class = "";
            this.groupLog.Style.CornerDiameter = 4;
            this.groupLog.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupLog.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupLog.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupLog.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupLog.StyleMouseDown.Class = "";
            this.groupLog.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupLog.StyleMouseOver.Class = "";
            this.groupLog.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupLog.TabIndex = 14;
            this.groupLog.Text = "初始化日志";
            // 
            // txtLog
            // 
            // 
            // 
            // 
            this.txtLog.BackgroundStyle.Class = "";
            this.txtLog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1361, 453);
            this.txtLog.TabIndex = 0;
            // 
            // btnStartInit
            // 
            this.btnStartInit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartInit.AutoExpandOnClick = true;
            this.btnStartInit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartInit.Location = new System.Drawing.Point(236, 407);
            this.btnStartInit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartInit.Name = "btnStartInit";
            this.btnStartInit.Size = new System.Drawing.Size(243, 66);
            this.btnStartInit.TabIndex = 13;
            this.btnStartInit.Text = "开始初始化";
            this.btnStartInit.Click += new System.EventHandler(this.btnStartInit_Click);
            // 
            // cmbVersion
            // 
            this.cmbVersion.DisplayMember = "Text";
            this.cmbVersion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVersion.Font = new System.Drawing.Font("Courier New", 10F);
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.ItemHeight = 17;
            this.cmbVersion.Items.AddRange(new object[] {
            this.cb301_1010,
            this.cb311_1011,
            this.cb312_1017,
            this.cb312_1019,
            this.cb312_1021,
            this.cb312_1022,
            this.cb401_1006});
            this.cmbVersion.Location = new System.Drawing.Point(233, 275);
            this.cmbVersion.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(604, 23);
            this.cmbVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbVersion.TabIndex = 12;
            // 
            // cb301_1010
            // 
            this.cb301_1010.Text = "3.0.1.1010";
            // 
            // cb311_1011
            // 
            this.cb311_1011.Text = "3.1.1.1011";
            // 
            // cb312_1017
            // 
            this.cb312_1017.Text = "3.1.2.1017";
            // 
            // cb312_1019
            // 
            this.cb312_1019.Text = "3.1.2.1019";
            // 
            // cb312_1021
            // 
            this.cb312_1021.Text = "3.1.2.1021";
            // 
            // cb312_1022
            // 
            this.cb312_1022.Text = "3.1.2.1022";
            // 
            // cb401_1006
            // 
            this.cb401_1006.Text = "4.0.1.1006";
            // 
            // chk401
            // 
            this.chk401.AutoSize = true;
            this.chk401.Location = new System.Drawing.Point(1673, 285);
            this.chk401.Name = "chk401";
            this.chk401.Size = new System.Drawing.Size(101, 33);
            this.chk401.TabIndex = 6;
            this.chk401.Text = "4.0.1";
            this.chk401.UseVisualStyleBackColor = true;
            this.chk401.CheckedChanged += new System.EventHandler(this.chk401_CheckedChanged);
            // 
            // chk311
            // 
            this.chk311.AutoSize = true;
            this.chk311.Location = new System.Drawing.Point(1401, 285);
            this.chk311.Name = "chk311";
            this.chk311.Size = new System.Drawing.Size(101, 33);
            this.chk311.TabIndex = 5;
            this.chk311.Text = "3.1.1";
            this.chk311.UseVisualStyleBackColor = true;
            this.chk311.CheckedChanged += new System.EventHandler(this.chk311_CheckedChanged);
            // 
            // chk312
            // 
            this.chk312.AutoSize = true;
            this.chk312.Location = new System.Drawing.Point(1532, 285);
            this.chk312.Name = "chk312";
            this.chk312.Size = new System.Drawing.Size(101, 33);
            this.chk312.TabIndex = 4;
            this.chk312.Text = "3.1.2";
            this.chk312.UseVisualStyleBackColor = true;
            this.chk312.CheckedChanged += new System.EventHandler(this.chk312_CheckedChanged);
            // 
            // chk301
            // 
            this.chk301.AutoSize = true;
            this.chk301.Location = new System.Drawing.Point(1266, 285);
            this.chk301.Name = "chk301";
            this.chk301.Size = new System.Drawing.Size(101, 33);
            this.chk301.TabIndex = 3;
            this.chk301.Text = "3.0.1";
            this.chk301.UseVisualStyleBackColor = true;
            this.chk301.CheckedChanged += new System.EventHandler(this.chk301_CheckedChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(233, 120);
            this.txtPath.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(604, 36);
            this.txtPath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(873, 120);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(200, 51);
            this.btnSelect.StopPulseOnMouseOver = false;
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpenPath,
            this.btnPathClear});
            this.btnSelect.SubItemsExpandWidth = 20;
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.GlobalItem = false;
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Text = "打开路径";
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // btnPathClear
            // 
            this.btnPathClear.GlobalItem = false;
            this.btnPathClear.Name = "btnPathClear";
            this.btnPathClear.Text = "清除";
            this.btnPathClear.Click += new System.EventHandler(this.btnPathClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "DAP平台版本：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DAP项目路径：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRanInit,
            this.tsbDapVersion,
            this.tsbParameter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1850, 42);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRanInit
            // 
            this.tsbRanInit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRanInit.Image = ((System.Drawing.Image)(resources.GetObject("tsbRanInit.Image")));
            this.tsbRanInit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRanInit.Name = "tsbRanInit";
            this.tsbRanInit.Size = new System.Drawing.Size(127, 39);
            this.tsbRanInit.Text = "升级工具";
            this.tsbRanInit.Click += new System.EventHandler(this.tsbRanInit_Click);
            // 
            // tsbDapVersion
            // 
            this.tsbDapVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDapVersion.Image = ((System.Drawing.Image)(resources.GetObject("tsbDapVersion.Image")));
            this.tsbDapVersion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDapVersion.Name = "tsbDapVersion";
            this.tsbDapVersion.Size = new System.Drawing.Size(130, 39);
            this.tsbDapVersion.Text = "DAP版本";
            this.tsbDapVersion.Click += new System.EventHandler(this.tsbDapVersion_Click);
            // 
            // tsbParameter
            // 
            this.tsbParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbParameter.Image = ((System.Drawing.Image)(resources.GetObject("tsbParameter.Image")));
            this.tsbParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbParameter.Name = "tsbParameter";
            this.tsbParameter.Size = new System.Drawing.Size(127, 39);
            this.tsbParameter.Text = "通用参数";
            this.tsbParameter.Click += new System.EventHandler(this.tsbParameter_Click);
            // 
            // frmInitIDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 1136);
            this.Controls.Add(this.expandablePanel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "frmInitIDE";
            this.TabText = "BaseForm";
            this.Text = "frmInitIDE";
            this.Load += new System.EventHandler(this.frmInitIDE_Load);
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.groupLog.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.TextBox txtPath;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonItem btnOpenPath;
        private DevComponents.DotNetBar.ButtonItem btnPathClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk401;
        private System.Windows.Forms.CheckBox chk311;
        private System.Windows.Forms.CheckBox chk312;
        private System.Windows.Forms.CheckBox chk301;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbVersion;
        private DevComponents.Editors.ComboItem cb301_1010;
        private DevComponents.Editors.ComboItem cb311_1011;
        private DevComponents.Editors.ComboItem cb312_1017;
        private DevComponents.Editors.ComboItem cb312_1019;
        private DevComponents.Editors.ComboItem cb312_1021;
        private DevComponents.Editors.ComboItem cb312_1022;
        private DevComponents.Editors.ComboItem cb401_1006;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevComponents.DotNetBar.ButtonX btnStartInit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupLog;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtLog;
        private System.Windows.Forms.TextBox txtJdkPath;
        private DevComponents.DotNetBar.ButtonX btnJdk;
        private DevComponents.DotNetBar.ButtonItem btnOpenJdk;
        private DevComponents.DotNetBar.ButtonItem btnClearJdk;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnSaveConfig;
        private System.Windows.Forms.CheckBox chkFirst;
        private System.Windows.Forms.ToolTip firstTip;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRanInit;
        private System.Windows.Forms.ToolStripButton tsbDapVersion;
        private DevComponents.DotNetBar.ButtonX btnSelectVersion;
        private System.Windows.Forms.ToolStripButton tsbParameter;
        private System.Windows.Forms.Label label3;
    }
}