namespace DMS.Forms {
    partial class frmSendRequest {
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
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupEsp = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtOriRequest = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.groupFormat = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lblKey = new System.Windows.Forms.LinkLabel();
            this.txtReqHeader = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReqBody = new ICSharpCode.TextEditor.TextEditorControl();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUrl = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbesptest = new DevComponents.Editors.ComboItem();
            this.cbesphw = new DevComponents.Editors.ComboItem();
            this.cbespms = new DevComponents.Editors.ComboItem();
            this.cblocal = new DevComponents.Editors.ComboItem();
            this.cbe10 = new DevComponents.Editors.ComboItem();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chklocal = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSend = new DevComponents.DotNetBar.ButtonX();
            this.btnFormat = new DevComponents.DotNetBar.ButtonX();
            this.groupResponse = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtResponse = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbe10test = new DevComponents.Editors.ComboItem();
            this.cbwf = new DevComponents.Editors.ComboItem();
            this.cbt100 = new DevComponents.Editors.ComboItem();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupEsp.SuspendLayout();
            this.groupFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 25);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(769, 426);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.splitContainer1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(769, 426);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(769, 426);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupEsp);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupFormat);
            this.splitContainer3.Size = new System.Drawing.Size(769, 263);
            this.splitContainer3.SplitterDistance = 343;
            this.splitContainer3.TabIndex = 1;
            // 
            // groupEsp
            // 
            this.groupEsp.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupEsp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupEsp.Controls.Add(this.txtOriRequest);
            this.groupEsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEsp.Location = new System.Drawing.Point(0, 0);
            this.groupEsp.Name = "groupEsp";
            this.groupEsp.Size = new System.Drawing.Size(343, 263);
            // 
            // 
            // 
            this.groupEsp.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupEsp.Style.BackColorGradientAngle = 90;
            this.groupEsp.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupEsp.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupEsp.Style.BorderBottomWidth = 1;
            this.groupEsp.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupEsp.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupEsp.Style.BorderLeftWidth = 1;
            this.groupEsp.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupEsp.Style.BorderRightWidth = 1;
            this.groupEsp.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupEsp.Style.BorderTopWidth = 1;
            this.groupEsp.Style.Class = "";
            this.groupEsp.Style.CornerDiameter = 4;
            this.groupEsp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupEsp.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupEsp.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupEsp.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupEsp.StyleMouseDown.Class = "";
            this.groupEsp.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupEsp.StyleMouseOver.Class = "";
            this.groupEsp.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupEsp.TabIndex = 1;
            this.groupEsp.Text = "ESP调用记录";
            // 
            // txtOriRequest
            // 
            // 
            // 
            // 
            this.txtOriRequest.BackgroundStyle.Class = "";
            this.txtOriRequest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOriRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOriRequest.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtOriRequest.Location = new System.Drawing.Point(0, 0);
            this.txtOriRequest.Name = "txtOriRequest";
            this.txtOriRequest.Size = new System.Drawing.Size(337, 239);
            this.txtOriRequest.TabIndex = 0;
            // 
            // groupFormat
            // 
            this.groupFormat.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupFormat.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupFormat.Controls.Add(this.splitContainer4);
            this.groupFormat.Controls.Add(this.panel1);
            this.groupFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFormat.Location = new System.Drawing.Point(0, 0);
            this.groupFormat.Name = "groupFormat";
            this.groupFormat.Size = new System.Drawing.Size(422, 263);
            // 
            // 
            // 
            this.groupFormat.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupFormat.Style.BackColorGradientAngle = 90;
            this.groupFormat.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupFormat.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupFormat.Style.BorderBottomWidth = 1;
            this.groupFormat.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupFormat.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupFormat.Style.BorderLeftWidth = 1;
            this.groupFormat.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupFormat.Style.BorderRightWidth = 1;
            this.groupFormat.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupFormat.Style.BorderTopWidth = 1;
            this.groupFormat.Style.Class = "";
            this.groupFormat.Style.CornerDiameter = 4;
            this.groupFormat.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupFormat.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupFormat.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupFormat.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupFormat.StyleMouseDown.Class = "";
            this.groupFormat.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupFormat.StyleMouseOver.Class = "";
            this.groupFormat.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupFormat.TabIndex = 9;
            this.groupFormat.Text = "ESP请求";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 48);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lblKey);
            this.splitContainer4.Panel1.Controls.Add(this.txtReqHeader);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.txtReqBody);
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Panel2.Controls.Add(this.lblFormat);
            this.splitContainer4.Size = new System.Drawing.Size(416, 191);
            this.splitContainer4.SplitterDistance = 69;
            this.splitContainer4.SplitterWidth = 2;
            this.splitContainer4.TabIndex = 12;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(7, 26);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(23, 12);
            this.lblKey.TabIndex = 11;
            this.lblKey.TabStop = true;
            this.lblKey.Text = "Key";
            this.lblKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblKey_LinkClicked);
            // 
            // txtReqHeader
            // 
            this.txtReqHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtReqHeader.BackgroundStyle.Class = "";
            this.txtReqHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReqHeader.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtReqHeader.Location = new System.Drawing.Point(59, 6);
            this.txtReqHeader.Name = "txtReqHeader";
            this.txtReqHeader.Size = new System.Drawing.Size(338, 60);
            this.txtReqHeader.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Header：";
            // 
            // txtReqBody
            // 
            this.txtReqBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReqBody.IsReadOnly = false;
            this.txtReqBody.Location = new System.Drawing.Point(59, 3);
            this.txtReqBody.Name = "txtReqBody";
            this.txtReqBody.Size = new System.Drawing.Size(338, 126);
            this.txtReqBody.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Body：";
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(7, 27);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(29, 12);
            this.lblFormat.TabIndex = 10;
            this.lblFormat.TabStop = true;
            this.lblFormat.Text = "Json";
            this.lblFormat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFormat_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 48);
            this.panel1.TabIndex = 13;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.DisplayMember = "Text";
            this.txtUrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtUrl.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtUrl.FormattingEnabled = true;
            this.txtUrl.ItemHeight = 17;
            this.txtUrl.Items.AddRange(new object[] {
            this.cbesptest,
            this.cbesphw,
            this.cbespms,
            this.cblocal,
            this.cbe10,
            this.cbe10test,
            this.cbwf,
            this.cbt100});
            this.txtUrl.Location = new System.Drawing.Point(59, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(338, 23);
            this.txtUrl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtUrl.TabIndex = 11;
            // 
            // cbesptest
            // 
            this.cbesptest.FontSize = 10F;
            this.cbesptest.Text = "http://esp-test.apps.digiwincloud.com.cn/CROSS/RESTful";
            // 
            // cbesphw
            // 
            this.cbesphw.Text = "https://esp.apps.digiwincloud.com.cn/CROSS/RESTful";
            // 
            // cbespms
            // 
            this.cbespms.Text = "https://esp.apps.digiwincloud.com/CROSS/RESTful";
            // 
            // cblocal
            // 
            this.cblocal.Text = "http://127.0.0.1:8085/eai";
            // 
            // cbe10
            // 
            this.cbe10.Text = "http://127.0.0.1:8023/Restful";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chklocal);
            this.splitContainer2.Panel1.Controls.Add(this.btnSend);
            this.splitContainer2.Panel1.Controls.Add(this.btnFormat);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupResponse);
            this.splitContainer2.Size = new System.Drawing.Size(769, 159);
            this.splitContainer2.SplitterDistance = 36;
            this.splitContainer2.TabIndex = 0;
            // 
            // chklocal
            // 
            // 
            // 
            // 
            this.chklocal.BackgroundStyle.Class = "";
            this.chklocal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chklocal.Location = new System.Drawing.Point(194, 7);
            this.chklocal.Name = "chklocal";
            this.chklocal.Size = new System.Drawing.Size(100, 23);
            this.chklocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chklocal.TabIndex = 2;
            this.chklocal.Text = "本地调试";
            this.chklocal.CheckedChanged += new System.EventHandler(this.chklocal_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSend.Location = new System.Drawing.Point(103, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFormat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFormat.Location = new System.Drawing.Point(3, 6);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFormat.TabIndex = 0;
            this.btnFormat.Text = "格式化";
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // groupResponse
            // 
            this.groupResponse.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResponse.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResponse.Controls.Add(this.txtResponse);
            this.groupResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResponse.Location = new System.Drawing.Point(0, 0);
            this.groupResponse.Name = "groupResponse";
            this.groupResponse.Size = new System.Drawing.Size(769, 119);
            // 
            // 
            // 
            this.groupResponse.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupResponse.Style.BackColorGradientAngle = 90;
            this.groupResponse.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupResponse.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupResponse.Style.BorderBottomWidth = 1;
            this.groupResponse.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupResponse.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupResponse.Style.BorderLeftWidth = 1;
            this.groupResponse.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupResponse.Style.BorderRightWidth = 1;
            this.groupResponse.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupResponse.Style.BorderTopWidth = 1;
            this.groupResponse.Style.Class = "";
            this.groupResponse.Style.CornerDiameter = 4;
            this.groupResponse.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupResponse.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupResponse.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupResponse.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupResponse.StyleMouseDown.Class = "";
            this.groupResponse.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupResponse.StyleMouseOver.Class = "";
            this.groupResponse.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupResponse.TabIndex = 2;
            this.groupResponse.Text = "请求结果";
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.IsReadOnly = false;
            this.txtResponse.Location = new System.Drawing.Point(0, 0);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(763, 95);
            this.txtResponse.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbe10test
            // 
            this.cbe10test.Text = "http://172.16.1.102:8023/Restful";
            // 
            // cbwf
            // 
            this.cbwf.Text = "http://172.16.1.26/WFATN/WFATNService.svc/ATNPOST";
            // 
            // cbt100
            // 
            this.cbt100.Text = "http://10.40.40.18/wt10dev/ws/r/awsp920";
            // 
            // frmSendRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 451);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSendRequest";
            this.Text = "frmSendRequest";
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupEsp.ResumeLayout(false);
            this.groupFormat.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupResponse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.ButtonX btnFormat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevComponents.DotNetBar.ButtonX btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtReqHeader;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupEsp;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtOriRequest;
        private DevComponents.DotNetBar.Controls.GroupPanel groupFormat;
        private DevComponents.DotNetBar.Controls.GroupPanel groupResponse;
        private ICSharpCode.TextEditor.TextEditorControl txtReqBody;
        private System.Windows.Forms.LinkLabel lblFormat;
        private ICSharpCode.TextEditor.TextEditorControl txtResponse;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtUrl;
        private DevComponents.Editors.ComboItem cbesptest;
        private DevComponents.Editors.ComboItem cbesphw;
        private DevComponents.Editors.ComboItem cbespms;
        private DevComponents.Editors.ComboItem cblocal;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chklocal;
        private DevComponents.Editors.ComboItem cbe10;
        private System.Windows.Forms.LinkLabel lblKey;
        private DevComponents.Editors.ComboItem cbe10test;
        private DevComponents.Editors.ComboItem cbwf;
        private DevComponents.Editors.ComboItem cbt100;
    }
}