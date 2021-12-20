using DevComponents.DotNetBar;
namespace MMS.Forms
{
    public partial class BaseSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSettingForm));
            this.ItemTypes = new DevComponents.DotNetBar.ItemPanel();
            this.controlPanel = new DevComponents.DotNetBar.PanelEx();
            this.labMsg = new System.Windows.Forms.Label();
            this.tablePanel2 = new DevComponents.DotNetBar.PanelEx();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.topPanel = new DevComponents.DotNetBar.PanelEx();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemTypes
            // 
            // 
            // 
            // 
            this.ItemTypes.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.ItemTypes.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ItemTypes.BackgroundStyle.BorderBottomWidth = 1;
            this.ItemTypes.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.ItemTypes.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ItemTypes.BackgroundStyle.BorderLeftWidth = 1;
            this.ItemTypes.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ItemTypes.BackgroundStyle.BorderRightWidth = 1;
            this.ItemTypes.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.ItemTypes.BackgroundStyle.BorderTopWidth = 1;
            this.ItemTypes.BackgroundStyle.Class = "";
            this.ItemTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ItemTypes.BackgroundStyle.PaddingBottom = 1;
            this.ItemTypes.BackgroundStyle.PaddingLeft = 1;
            this.ItemTypes.BackgroundStyle.PaddingRight = 1;
            this.ItemTypes.BackgroundStyle.PaddingTop = 1;
            this.ItemTypes.ContainerControlProcessDialogKey = true;
            this.ItemTypes.Dock = System.Windows.Forms.DockStyle.Left;
            this.ItemTypes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTypes.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ItemTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ItemTypes.Location = new System.Drawing.Point(0, 43);
            this.ItemTypes.Name = "ItemTypes";
            this.ItemTypes.Size = new System.Drawing.Size(188, 269);
            this.ItemTypes.TabIndex = 4;
            this.ItemTypes.Text = "itemPanel1";
            // 
            // controlPanel
            // 
            this.controlPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.controlPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(188, 43);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(10);
            this.controlPanel.Size = new System.Drawing.Size(356, 269);
            this.controlPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.controlPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.controlPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.controlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.controlPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.controlPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.controlPanel.Style.GradientAngle = 90;
            this.controlPanel.TabIndex = 5;
            // 
            // labMsg
            // 
            this.labMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.ForeColor = System.Drawing.Color.Maroon;
            this.labMsg.Location = new System.Drawing.Point(3, 0);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(327, 34);
            this.labMsg.TabIndex = 2;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tablePanel2
            // 
            this.tablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tablePanel2.Controls.Add(this.btnOK);
            this.tablePanel2.Controls.Add(this.btnCancel);
            this.tablePanel2.Controls.Add(this.labMsg);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePanel2.Location = new System.Drawing.Point(0, 312);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Size = new System.Drawing.Size(544, 50);
            this.tablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.tablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.tablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.tablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.tablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.tablePanel2.Style.GradientAngle = 180;
            this.tablePanel2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(353, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(446, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // topPanel
            // 
            this.topPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.topPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(544, 43);
            this.topPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.topPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.topPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.topPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.topPanel.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.topPanel.Style.GradientAngle = 90;
            this.topPanel.TabIndex = 6;
            this.topPanel.Text = "   ";
            // 
            // BaseSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 362);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.ItemTypes);
            this.Controls.Add(this.tablePanel2);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseSettingForm";
            this.TabText = "系统管理";
            this.Text = "系统管理";
            this.tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemPanel ItemTypes;
        private System.Windows.Forms.Label labMsg;
        private DevComponents.DotNetBar.PanelEx tablePanel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        protected PanelEx controlPanel;
        private PanelEx topPanel;
    }
}