namespace DMS.Forms
{
    partial class TestControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.expandPanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.marginPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.expandPanel.SuspendLayout();
            this.marginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandPanel
            // 
            this.expandPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandPanel.Controls.Add(this.marginPanel);
            this.expandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandPanel.ExpandButtonVisible = false;
            this.expandPanel.Location = new System.Drawing.Point(0, 0);
            this.expandPanel.Name = "expandPanel";
            this.expandPanel.Padding = new System.Windows.Forms.Padding(1);
            this.expandPanel.Size = new System.Drawing.Size(518, 114);
            this.expandPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandPanel.Style.GradientAngle = 90;
            this.expandPanel.TabIndex = 2;
            this.expandPanel.TitleHeight = 28;
            this.expandPanel.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandPanel.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandPanel.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandPanel.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandPanel.TitleStyle.Font = new System.Drawing.Font("黑体", 13F);
            this.expandPanel.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandPanel.TitleStyle.GradientAngle = 90;
            this.expandPanel.TitleText = "红白条生产入库";
            // 
            // marginPanel
            // 
            this.marginPanel.ColumnCount = 2;
            this.marginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.marginPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.marginPanel.Controls.Add(this.tablePanel, 0, 1);
            this.marginPanel.Controls.Add(this.buttonX1, 1, 1);
            this.marginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marginPanel.Location = new System.Drawing.Point(1, 29);
            this.marginPanel.Name = "marginPanel";
            this.marginPanel.RowCount = 3;
            this.marginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.marginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.marginPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.marginPanel.Size = new System.Drawing.Size(516, 84);
            this.marginPanel.TabIndex = 1;
            // 
            // tablePanel
            // 
            this.tablePanel.ColumnCount = 1;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 10);
            this.tablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.Size = new System.Drawing.Size(416, 64);
            this.tablePanel.TabIndex = 0;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(428, 42);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(76, 29);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "测试";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandPanel);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(518, 114);
            this.expandPanel.ResumeLayout(false);
            this.marginPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandPanel;
        private System.Windows.Forms.TableLayoutPanel marginPanel;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
