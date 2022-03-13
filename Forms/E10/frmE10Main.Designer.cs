namespace DMS.Forms
{
    partial class frmE10Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmE10Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenPath = new DevComponents.DotNetBar.ButtonItem();
            this.btnSetE10 = new DevComponents.DotNetBar.ButtonItem();
            this.btnPathClear = new DevComponents.DotNetBar.ButtonItem();
            this.btnStartServer = new DevComponents.DotNetBar.ButtonX();
            this.subItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.subItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.subItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.subItem0 = new DevComponents.DotNetBar.ButtonItem();
            this.btnStartClient = new DevComponents.DotNetBar.ButtonX();
            this.subItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.subItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.subItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.expandablePanel3 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.cmbBox1 = new DevComponents.Editors.LabelComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.expandablePanel4 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnStartCM = new DevComponents.DotNetBar.ButtonX();
            this.btnCM = new DevComponents.DotNetBar.ButtonX();
            this.btnSubCM = new DevComponents.DotNetBar.ButtonItem();
            this.btnCMClear = new DevComponents.DotNetBar.ButtonItem();
            this.txtCM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnStartOOQL = new DevComponents.DotNetBar.ButtonX();
            this.btnOOQL = new DevComponents.DotNetBar.ButtonX();
            this.btnSubOOQL = new DevComponents.DotNetBar.ButtonItem();
            this.btnOOQLClear = new DevComponents.DotNetBar.ButtonItem();
            this.txtOOQL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnCopy = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyClient = new DevComponents.DotNetBar.ButtonItem();
            this.btnCopyServer = new DevComponents.DotNetBar.ButtonItem();
            this.btnCopyAll = new DevComponents.DotNetBar.ButtonItem();
            this.txtSrcPath = new System.Windows.Forms.TextBox();
            this.btnSrcSelect = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnSrcClear = new DevComponents.DotNetBar.ButtonItem();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.galleryContainer1 = new DevComponents.DotNetBar.GalleryContainer();
            this.panelEx1.SuspendLayout();
            this.expandablePanel3.SuspendLayout();
            this.expandablePanel4.SuspendLayout();
            this.expandablePanel2.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "E10环境路径：";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(222, 120);
            this.txtPath.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(882, 36);
            this.txtPath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(1125, 118);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(200, 51);
            this.btnSelect.StopPulseOnMouseOver = false;
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOpenPath,
            this.btnSetE10,
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
            // btnSetE10
            // 
            this.btnSetE10.GlobalItem = false;
            this.btnSetE10.Name = "btnSetE10";
            this.btnSetE10.Text = "设置环境";
            this.btnSetE10.Click += new System.EventHandler(this.btnSetE10_Click);
            // 
            // btnPathClear
            // 
            this.btnPathClear.GlobalItem = false;
            this.btnPathClear.Name = "btnPathClear";
            this.btnPathClear.Text = "清除";
            this.btnPathClear.Click += new System.EventHandler(this.btnPathClear_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartServer.AutoExpandOnClick = true;
            this.btnStartServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartServer.Location = new System.Drawing.Point(1398, 118);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(230, 51);
            this.btnStartServer.SplitButton = true;
            this.btnStartServer.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.subItem1,
            this.subItem2,
            this.subItem3,
            this.subItem0});
            this.btnStartServer.TabIndex = 3;
            this.btnStartServer.Text = "启动服务端";
            // 
            // subItem1
            // 
            this.subItem1.Name = "subItem1";
            this.subItem1.Tag = "/d";
            this.subItem1.Text = "/d";
            // 
            // subItem2
            // 
            this.subItem2.Name = "subItem2";
            this.subItem2.Tag = "/u";
            this.subItem2.Text = "/u";
            // 
            // subItem3
            // 
            this.subItem3.Name = "subItem3";
            this.subItem3.Tag = "/r";
            this.subItem3.Text = "/r";
            // 
            // subItem0
            // 
            this.subItem0.Name = "subItem0";
            this.subItem0.Text = "Normal";
            // 
            // btnStartClient
            // 
            this.btnStartClient.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartClient.AutoExpandOnClick = true;
            this.btnStartClient.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartClient.Location = new System.Drawing.Point(1655, 118);
            this.btnStartClient.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Size = new System.Drawing.Size(230, 51);
            this.btnStartClient.SplitButton = true;
            this.btnStartClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartClient.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.subItem4,
            this.subItem5,
            this.subItem6});
            this.btnStartClient.TabIndex = 3;
            this.btnStartClient.Text = "启动客户端";
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // subItem4
            // 
            this.subItem4.GlobalItem = false;
            this.subItem4.Name = "subItem4";
            this.subItem4.Tag = "/d";
            this.subItem4.Text = "/d";
            // 
            // subItem5
            // 
            this.subItem5.Name = "subItem5";
            this.subItem5.Tag = "d /l";
            this.subItem5.Text = "d /l";
            // 
            // subItem6
            // 
            this.subItem6.GlobalItem = false;
            this.subItem6.Name = "subItem6";
            this.subItem6.Text = "Normal";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.expandablePanel3);
            this.panelEx1.Controls.Add(this.expandablePanel4);
            this.panelEx1.Controls.Add(this.expandablePanel2);
            this.panelEx1.Controls.Add(this.expandablePanel1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 24);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1930, 1074);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // expandablePanel3
            // 
            this.expandablePanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel3.Controls.Add(this.btnReset);
            this.expandablePanel3.Controls.Add(this.cmbBox1);
            this.expandablePanel3.Controls.Add(this.label5);
            this.expandablePanel3.Controls.Add(this.lblLicense);
            this.expandablePanel3.Controls.Add(this.label3);
            this.expandablePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel3.Location = new System.Drawing.Point(0, 747);
            this.expandablePanel3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.expandablePanel3.Name = "expandablePanel3";
            this.expandablePanel3.Size = new System.Drawing.Size(1930, 315);
            this.expandablePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel3.Style.GradientAngle = 90;
            this.expandablePanel3.TabIndex = 6;
            this.expandablePanel3.TitleHeight = 58;
            this.expandablePanel3.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel3.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel3.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel3.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel3.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel3.TitleStyle.GradientAngle = 90;
            this.expandablePanel3.TitleText = "LicenseCenter";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.AutoExpandOnClick = true;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(1125, 152);
            this.btnReset.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 51);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重新设置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbBox1
            // 
            this.cmbBox1.AllowEdit = true;
            this.cmbBox1.BackColor = System.Drawing.Color.Transparent;
            this.cmbBox1.Caption.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBox1.Caption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBox1.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbBox1.Caption.Text = "";
            this.cmbBox1.ColumnsVisible = true;
            this.cmbBox1.DropDownHeight = 200;
            this.cmbBox1.DropDownWidth = 0;
            this.cmbBox1.EditBoxLength = 32767;
            this.cmbBox1.Location = new System.Drawing.Point(235, 154);
            this.cmbBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbBox1.Name = "cmbBox1";
            this.cmbBox1.Size = new System.Drawing.Size(875, 80);
            this.cmbBox1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "更换License：";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(215, 91);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(91, 29);
            this.lblLicense.TabIndex = 2;
            this.lblLicense.Text = "current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前License：";
            // 
            // expandablePanel4
            // 
            this.expandablePanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel4.Controls.Add(this.btnStartCM);
            this.expandablePanel4.Controls.Add(this.btnCM);
            this.expandablePanel4.Controls.Add(this.txtCM);
            this.expandablePanel4.Controls.Add(this.label4);
            this.expandablePanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel4.Location = new System.Drawing.Point(0, 531);
            this.expandablePanel4.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.expandablePanel4.Name = "expandablePanel4";
            this.expandablePanel4.Size = new System.Drawing.Size(1930, 216);
            this.expandablePanel4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel4.Style.GradientAngle = 90;
            this.expandablePanel4.TabIndex = 7;
            this.expandablePanel4.TitleHeight = 58;
            this.expandablePanel4.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel4.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel4.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel4.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel4.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel4.TitleStyle.GradientAngle = 90;
            this.expandablePanel4.TitleText = "CM";
            // 
            // btnStartCM
            // 
            this.btnStartCM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartCM.AutoExpandOnClick = true;
            this.btnStartCM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartCM.Location = new System.Drawing.Point(1398, 107);
            this.btnStartCM.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartCM.Name = "btnStartCM";
            this.btnStartCM.Size = new System.Drawing.Size(230, 51);
            this.btnStartCM.TabIndex = 5;
            this.btnStartCM.Text = "启动";
            this.btnStartCM.Click += new System.EventHandler(this.btnStartCM_Click);
            // 
            // btnCM
            // 
            this.btnCM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCM.Location = new System.Drawing.Point(1125, 107);
            this.btnCM.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCM.Name = "btnCM";
            this.btnCM.Size = new System.Drawing.Size(200, 51);
            this.btnCM.SplitButton = true;
            this.btnCM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCM.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSubCM,
            this.btnCMClear});
            this.btnCM.SubItemsExpandWidth = 20;
            this.btnCM.TabIndex = 4;
            this.btnCM.Text = "选择";
            this.btnCM.Click += new System.EventHandler(this.btnCM_Click);
            // 
            // btnSubCM
            // 
            this.btnSubCM.GlobalItem = false;
            this.btnSubCM.Name = "btnSubCM";
            this.btnSubCM.Text = "打开路径";
            this.btnSubCM.Click += new System.EventHandler(this.btnSubCM_Click);
            // 
            // btnCMClear
            // 
            this.btnCMClear.GlobalItem = false;
            this.btnCMClear.Name = "btnCMClear";
            this.btnCMClear.Text = "清除";
            this.btnCMClear.Click += new System.EventHandler(this.btnCMClear_Click);
            // 
            // txtCM
            // 
            this.txtCM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCM.Location = new System.Drawing.Point(222, 107);
            this.txtCM.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCM.Name = "txtCM";
            this.txtCM.Size = new System.Drawing.Size(882, 36);
            this.txtCM.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "CM根目录：";
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.btnStartOOQL);
            this.expandablePanel2.Controls.Add(this.btnOOQL);
            this.expandablePanel2.Controls.Add(this.txtOOQL);
            this.expandablePanel2.Controls.Add(this.label2);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel2.Location = new System.Drawing.Point(0, 308);
            this.expandablePanel2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(1930, 223);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 5;
            this.expandablePanel2.TitleHeight = 58;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = "OOQL";
            // 
            // btnStartOOQL
            // 
            this.btnStartOOQL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartOOQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOOQL.AutoExpandOnClick = true;
            this.btnStartOOQL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartOOQL.Location = new System.Drawing.Point(1398, 114);
            this.btnStartOOQL.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStartOOQL.Name = "btnStartOOQL";
            this.btnStartOOQL.Size = new System.Drawing.Size(230, 51);
            this.btnStartOOQL.TabIndex = 4;
            this.btnStartOOQL.Text = "启动";
            this.btnStartOOQL.Click += new System.EventHandler(this.btnStartOOQL_Click);
            // 
            // btnOOQL
            // 
            this.btnOOQL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOOQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOOQL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOOQL.Location = new System.Drawing.Point(1125, 114);
            this.btnOOQL.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnOOQL.Name = "btnOOQL";
            this.btnOOQL.Size = new System.Drawing.Size(200, 51);
            this.btnOOQL.StopPulseOnMouseOver = false;
            this.btnOOQL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOOQL.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSubOOQL,
            this.btnOOQLClear});
            this.btnOOQL.SubItemsExpandWidth = 20;
            this.btnOOQL.TabIndex = 3;
            this.btnOOQL.Text = "选择";
            this.btnOOQL.Click += new System.EventHandler(this.btnOOQL_Click);
            // 
            // btnSubOOQL
            // 
            this.btnSubOOQL.GlobalItem = false;
            this.btnSubOOQL.Name = "btnSubOOQL";
            this.btnSubOOQL.Text = "打开路径";
            this.btnSubOOQL.Click += new System.EventHandler(this.btnSubOOQL_Click);
            // 
            // btnOOQLClear
            // 
            this.btnOOQLClear.GlobalItem = false;
            this.btnOOQLClear.Name = "btnOOQLClear";
            this.btnOOQLClear.Text = "清除";
            this.btnOOQLClear.Click += new System.EventHandler(this.btnOOQLClear_Click);
            // 
            // txtOOQL
            // 
            this.txtOOQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOOQL.Location = new System.Drawing.Point(222, 114);
            this.txtOOQL.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtOOQL.Name = "txtOOQL";
            this.txtOOQL.Size = new System.Drawing.Size(882, 36);
            this.txtOOQL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "OOQL根目录：";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.btnCopy);
            this.expandablePanel1.Controls.Add(this.txtSrcPath);
            this.expandablePanel1.Controls.Add(this.txtPath);
            this.expandablePanel1.Controls.Add(this.btnSrcSelect);
            this.expandablePanel1.Controls.Add(this.btnSelect);
            this.expandablePanel1.Controls.Add(this.btnStartClient);
            this.expandablePanel1.Controls.Add(this.btnStartServer);
            this.expandablePanel1.Controls.Add(this.label6);
            this.expandablePanel1.Controls.Add(this.label1);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.ExpandButtonVisible = false;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(1930, 308);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 4;
            this.expandablePanel1.TitleHeight = 58;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "E10";
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.AutoExpandOnClick = true;
            this.btnCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopy.Location = new System.Drawing.Point(1398, 194);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(230, 51);
            this.btnCopy.SplitButton = true;
            this.btnCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCopy.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnCopyClient,
            this.btnCopyServer,
            this.btnCopyAll});
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "复制到环境";
            // 
            // btnCopyClient
            // 
            this.btnCopyClient.GlobalItem = false;
            this.btnCopyClient.Name = "btnCopyClient";
            this.btnCopyClient.Text = "Client";
            this.btnCopyClient.Click += new System.EventHandler(this.btnCopyClient_Click);
            // 
            // btnCopyServer
            // 
            this.btnCopyServer.GlobalItem = false;
            this.btnCopyServer.Name = "btnCopyServer";
            this.btnCopyServer.Text = "Server";
            this.btnCopyServer.Click += new System.EventHandler(this.btnCopyServer_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.GlobalItem = false;
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Text = "All";
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // txtSrcPath
            // 
            this.txtSrcPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcPath.Location = new System.Drawing.Point(222, 199);
            this.txtSrcPath.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtSrcPath.Name = "txtSrcPath";
            this.txtSrcPath.Size = new System.Drawing.Size(882, 36);
            this.txtSrcPath.TabIndex = 2;
            // 
            // btnSrcSelect
            // 
            this.btnSrcSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSrcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrcSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSrcSelect.Location = new System.Drawing.Point(1125, 196);
            this.btnSrcSelect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSrcSelect.Name = "btnSrcSelect";
            this.btnSrcSelect.Size = new System.Drawing.Size(200, 51);
            this.btnSrcSelect.StopPulseOnMouseOver = false;
            this.btnSrcSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSrcSelect.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.btnSrcClear});
            this.btnSrcSelect.SubItemsExpandWidth = 20;
            this.btnSrcSelect.TabIndex = 2;
            this.btnSrcSelect.Text = "选择";
            this.btnSrcSelect.Click += new System.EventHandler(this.btnSrcSelect_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.GlobalItem = false;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "打开路径";
            this.buttonItem1.Click += new System.EventHandler(this.btnSrcOpenPath_Click);
            // 
            // btnSrcClear
            // 
            this.btnSrcClear.GlobalItem = false;
            this.btnSrcClear.Name = "btnSrcClear";
            this.btnSrcClear.Text = "清除";
            this.btnSrcClear.Click += new System.EventHandler(this.btnSrcClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "E10源码路径：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1930, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // galleryContainer1
            // 
            // 
            // 
            // 
            this.galleryContainer1.BackgroundStyle.Class = "";
            this.galleryContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.galleryContainer1.EnableGalleryPopup = false;
            this.galleryContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.galleryContainer1.MinimumSize = new System.Drawing.Size(150, 200);
            this.galleryContainer1.MultiLine = false;
            this.galleryContainer1.Name = "galleryContainer1";
            this.galleryContainer1.PopupUsesStandardScrollbars = false;
            // 
            // 
            // 
            this.galleryContainer1.TitleStyle.Class = "";
            this.galleryContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // frmE10Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1930, 1098);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.Name = "frmE10Main";
            this.TabText = "BaseForm";
            this.Text = "E10Main";
            this.panelEx1.ResumeLayout(false);
            this.expandablePanel3.ResumeLayout(false);
            this.expandablePanel3.PerformLayout();
            this.expandablePanel4.ResumeLayout(false);
            this.expandablePanel4.PerformLayout();
            this.expandablePanel2.ResumeLayout(false);
            this.expandablePanel2.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnStartServer;
        private DevComponents.DotNetBar.ButtonX btnStartClient;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevComponents.DotNetBar.ButtonItem subItem1;
        private DevComponents.DotNetBar.ButtonItem subItem2;
        private DevComponents.DotNetBar.ButtonItem subItem3;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonItem subItem4;
        private DevComponents.DotNetBar.ButtonItem subItem0;
        private DevComponents.DotNetBar.ButtonItem subItem5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevComponents.DotNetBar.ButtonItem btnOpenPath;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private DevComponents.DotNetBar.ButtonX btnStartOOQL;
        private DevComponents.DotNetBar.ButtonX btnOOQL;
        private DevComponents.DotNetBar.ButtonItem btnSubOOQL;
        private System.Windows.Forms.TextBox txtOOQL;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label label5;
        private DevComponents.Editors.LabelComboBox cmbBox1;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel4;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnStartCM;
        private DevComponents.DotNetBar.ButtonX btnCM;
        private DevComponents.DotNetBar.ButtonItem btnSubCM;
        private System.Windows.Forms.TextBox txtCM;
        private DevComponents.DotNetBar.GalleryContainer galleryContainer1;
        private DevComponents.DotNetBar.ButtonItem btnSetE10;
        private DevComponents.DotNetBar.ButtonItem subItem6;
        private System.Windows.Forms.TextBox txtSrcPath;
        private DevComponents.DotNetBar.ButtonX btnSrcSelect;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btnCopy;
        private DevComponents.DotNetBar.ButtonItem btnCopyClient;
        private DevComponents.DotNetBar.ButtonItem btnCopyServer;
        private DevComponents.DotNetBar.ButtonItem btnCopyAll;
        private DevComponents.DotNetBar.ButtonItem btnPathClear;
        private DevComponents.DotNetBar.ButtonItem btnSrcClear;
        private DevComponents.DotNetBar.ButtonItem btnCMClear;
        private DevComponents.DotNetBar.ButtonItem btnOOQLClear;
    }
}