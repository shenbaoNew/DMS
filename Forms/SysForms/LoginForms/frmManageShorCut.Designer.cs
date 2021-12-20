namespace DMS.Forms
{
    partial class frmManageShorCut
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageShorCut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Menutree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.shortCutGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnToLeft = new DevComponents.DotNetBar.ButtonX();
            this.btnToRight = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colShortCut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.shortCutGrid)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(431, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(326, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Menutree
            // 
            this.Menutree.BackColor = System.Drawing.Color.LightCyan;
            this.Menutree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Menutree.ImageIndex = 0;
            this.Menutree.ImageList = this.imageList;
            this.Menutree.Location = new System.Drawing.Point(3, 3);
            this.Menutree.Name = "Menutree";
            this.tableLayoutPanel1.SetRowSpan(this.Menutree, 2);
            this.Menutree.SelectedImageIndex = 0;
            this.Menutree.Size = new System.Drawing.Size(222, 323);
            this.Menutree.TabIndex = 6;
            this.Menutree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Menutree_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "close.png");
            this.imageList.Images.SetKeyName(1, "open.png");
            this.imageList.Images.SetKeyName(2, "leaf.png");
            // 
            // shortCutGrid
            // 
            this.shortCutGrid.AllowUserToAddRows = false;
            this.shortCutGrid.AllowUserToDeleteRows = false;
            this.shortCutGrid.AllowUserToResizeColumns = false;
            this.shortCutGrid.AllowUserToResizeRows = false;
            this.shortCutGrid.BackgroundColor = System.Drawing.Color.LightCyan;
            this.shortCutGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.shortCutGrid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shortCutGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.shortCutGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shortCutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShortCut});
            this.shortCutGrid.DataGridViewCaption = "shortCutGrid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shortCutGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.shortCutGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortCutGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.shortCutGrid.Location = new System.Drawing.Point(311, 3);
            this.shortCutGrid.Name = "shortCutGrid";
            this.shortCutGrid.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.shortCutGrid, 2);
            this.shortCutGrid.RowTemplate.Height = 23;
            this.shortCutGrid.Size = new System.Drawing.Size(222, 323);
            this.shortCutGrid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.shortCutGrid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.shortCutGrid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.shortCutGrid.Style.GradientAngle = 90;
            this.shortCutGrid.TabIndex = 11;
            this.shortCutGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shortCutGrid_CellDoubleClick);
            // 
            // btnToLeft
            // 
            this.btnToLeft.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnToLeft.Location = new System.Drawing.Point(234, 109);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnToLeft.Size = new System.Drawing.Size(68, 24);
            this.btnToLeft.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnToLeft.TabIndex = 12;
            this.btnToLeft.Text = "删除";
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnToRight.Location = new System.Drawing.Point(234, 79);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnToRight.Size = new System.Drawing.Size(68, 24);
            this.btnToRight.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnToRight.TabIndex = 13;
            this.btnToRight.Text = "添加";
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 329);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(536, 51);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnToLeft, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Menutree, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.shortCutGrid, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.21885F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.78116F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 329);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // colShortCut
            // 
            this.colShortCut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShortCut.DataPropertyName = "Name";
            this.colShortCut.HeaderText = "菜单快捷方式";
            this.colShortCut.Name = "colShortCut";
            this.colShortCut.ReadOnly = true;
            // 
            // frmManageShorCut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 380);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageShorCut";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TabText = "BaseForm";
            this.Text = "配置桌面";
            ((System.ComponentModel.ISupportInitialize)(this.shortCutGrid)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView Menutree;
        private DevComponents.DotNetBar.Controls.DataGridViewX shortCutGrid;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.ButtonX btnToLeft;
        private DevComponents.DotNetBar.ButtonX btnToRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortCut;
    }
}
