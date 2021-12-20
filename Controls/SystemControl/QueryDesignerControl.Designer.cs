namespace DMS.Controls
{
    partial class QueryDesignerControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryDesignerControl));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._grid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutPut = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colGroupBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._txtSql = new ICSharpCode.TextEditor.TextEditorControl();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this._lblStatus = new System.Windows.Forms.Label();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnGroupBy = new System.Windows.Forms.ToolStripButton();
            this._btnProperties = new System.Windows.Forms.ToolStripButton();
            this._btnCheckSql = new System.Windows.Forms.ToolStripButton();
            this._btnViewResults = new System.Windows.Forms.ToolStripButton();
            this._btnClearQuery = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._grid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._txtSql);
            this.splitContainer2.Size = new System.Drawing.Size(617, 243);
            this.splitContainer2.SplitterDistance = 100;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 1;
            // 
            // _grid
            // 
            this._grid.AllowDrop = true;
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColumn,
            this.colAlias,
            this.colTable,
            this.colOutPut,
            this.colGroupBy,
            this.colSort,
            this.colFilter});
            this._grid.DataGridViewCaption = "_grid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle2;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Margin = new System.Windows.Forms.Padding(2);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.RowHeadersWidth = 21;
            this._grid.RowTemplate.Height = 24;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(617, 100);
            this._grid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this._grid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this._grid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this._grid.Style.GradientAngle = 90;
            this._grid.TabIndex = 0;
            this._grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellClick);
            this._grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellContentClick);
            this._grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._grid_CellContentClick);
            // 
            // colColumn
            // 
            this.colColumn.DataPropertyName = "Column";
            this.colColumn.HeaderText = "字段名";
            this.colColumn.Name = "colColumn";
            this.colColumn.ReadOnly = true;
            // 
            // colAlias
            // 
            this.colAlias.DataPropertyName = "ColAlias";
            this.colAlias.HeaderText = "重命名";
            this.colAlias.Name = "colAlias";
            // 
            // colTable
            // 
            this.colTable.DataPropertyName = "Table";
            this.colTable.HeaderText = "表名";
            this.colTable.Name = "colTable";
            this.colTable.ReadOnly = true;
            // 
            // colOutPut
            // 
            this.colOutPut.DataPropertyName = "OutPut";
            this.colOutPut.HeaderText = "是否输出";
            this.colOutPut.Name = "colOutPut";
            this.colOutPut.ReadOnly = true;
            this.colOutPut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOutPut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colGroupBy
            // 
            this.colGroupBy.DataPropertyName = "GroupBy";
            this.colGroupBy.HeaderText = "分组";
            this.colGroupBy.Name = "colGroupBy";
            this.colGroupBy.Visible = false;
            // 
            // colSort
            // 
            this.colSort.DataPropertyName = "Sort";
            this.colSort.HeaderText = "排序";
            this.colSort.Name = "colSort";
            this.colSort.ReadOnly = true;
            // 
            // colFilter
            // 
            this.colFilter.DataPropertyName = "Filter";
            this.colFilter.HeaderText = "条件";
            this.colFilter.Name = "colFilter";
            // 
            // _txtSql
            // 
            this._txtSql.BackColor = System.Drawing.SystemColors.Window;
            this._txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtSql.IsReadOnly = false;
            this._txtSql.Location = new System.Drawing.Point(0, 0);
            this._txtSql.Margin = new System.Windows.Forms.Padding(2);
            this._txtSql.Name = "_txtSql";
            this._txtSql.ShowLineNumbers = false;
            this._txtSql.ShowSpaces = true;
            this._txtSql.ShowTabs = true;
            this._txtSql.Size = new System.Drawing.Size(617, 140);
            this._txtSql.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this._lblStatus);
            this.panelEx1.Controls.Add(this.btnClear);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 268);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(617, 39);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Location = new System.Drawing.Point(13, 10);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(0, 12);
            this._lblStatus.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(514, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 21);
            this.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "取 消";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(420, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 21);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this._btnViewResults_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGroupBy,
            this._btnProperties,
            this._btnCheckSql,
            this._btnViewResults,
            this._btnClearQuery});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(617, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // _btnGroupBy
            // 
            this._btnGroupBy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnGroupBy.Image = ((System.Drawing.Image)(resources.GetObject("_btnGroupBy.Image")));
            this._btnGroupBy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGroupBy.Name = "_btnGroupBy";
            this._btnGroupBy.Size = new System.Drawing.Size(23, 22);
            this._btnGroupBy.Text = "Group results";
            this._btnGroupBy.Click += new System.EventHandler(this._btnGroupBy_Click);
            // 
            // _btnProperties
            // 
            this._btnProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnProperties.Image = ((System.Drawing.Image)(resources.GetObject("_btnProperties.Image")));
            this._btnProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnProperties.Name = "_btnProperties";
            this._btnProperties.Size = new System.Drawing.Size(23, 22);
            this._btnProperties.Text = "Query properties";
            this._btnProperties.Click += new System.EventHandler(this._btnProperties_Click);
            // 
            // _btnCheckSql
            // 
            this._btnCheckSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnCheckSql.Image = ((System.Drawing.Image)(resources.GetObject("_btnCheckSql.Image")));
            this._btnCheckSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCheckSql.Name = "_btnCheckSql";
            this._btnCheckSql.Size = new System.Drawing.Size(23, 22);
            this._btnCheckSql.Text = "Check SQL syntax";
            this._btnCheckSql.Click += new System.EventHandler(this._btnCheckSql_Click);
            // 
            // _btnViewResults
            // 
            this._btnViewResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnViewResults.Image = ((System.Drawing.Image)(resources.GetObject("_btnViewResults.Image")));
            this._btnViewResults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnViewResults.Name = "_btnViewResults";
            this._btnViewResults.Size = new System.Drawing.Size(23, 22);
            this._btnViewResults.Text = "View query results";
            this._btnViewResults.Click += new System.EventHandler(this._btnViewResults_Click);
            // 
            // _btnClearQuery
            // 
            this._btnClearQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnClearQuery.Image = ((System.Drawing.Image)(resources.GetObject("_btnClearQuery.Image")));
            this._btnClearQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnClearQuery.Name = "_btnClearQuery";
            this._btnClearQuery.Size = new System.Drawing.Size(23, 22);
            this._btnClearQuery.Text = "Clear query";
            this._btnClearQuery.Click += new System.EventHandler(this._btnClearQuery_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Column";
            this.dataGridViewTextBoxColumn1.HeaderText = "字段名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ColAlias";
            this.dataGridViewTextBoxColumn2.HeaderText = "重命名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Table";
            this.dataGridViewTextBoxColumn3.HeaderText = "表名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Sort";
            this.dataGridViewTextBoxColumn4.HeaderText = "排序";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Filter";
            this.dataGridViewTextBoxColumn5.HeaderText = "条件";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Filter";
            this.dataGridViewTextBoxColumn6.HeaderText = "条件";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // QueryDesignerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelEx1);
            this.Name = "QueryDesignerControl";
            this.Size = new System.Drawing.Size(617, 307);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.Controls.DataGridViewX _grid;
        private ICSharpCode.TextEditor.TextEditorControl _txtSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOutPut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnGroupBy;
        private System.Windows.Forms.ToolStripButton _btnProperties;
        private System.Windows.Forms.ToolStripButton _btnCheckSql;
        private System.Windows.Forms.ToolStripButton _btnViewResults;
        private System.Windows.Forms.ToolStripButton _btnClearQuery;
        private System.Windows.Forms.Label _lblStatus;
    }
}
