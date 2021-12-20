namespace DMS.Controls
{
    partial class CreateDBReIndexControl
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
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem1 = new DevComponents.DotNetBar.Controls.SummaryItem();
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem2 = new DevComponents.DotNetBar.Controls.SummaryItem();
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem3 = new DevComponents.DotNetBar.Controls.SummaryItem();
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem4 = new DevComponents.DotNetBar.Controls.SummaryItem();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new DevComponents.DotNetBar.ButtonX();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.masterGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCreate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtMsg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.masterGrid, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 374);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // btnCreate
            // 
            this.btnCreate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.CallBasePaintBackground = true;
            this.btnCreate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(61, 317);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(185, 32);
            this.btnCreate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "重建索引(删除后重建)";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMsg, 2);
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(3, 249);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(611, 61);
            this.txtMsg.TabIndex = 18;
            this.txtMsg.Text = "";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.labelX1, 2);
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(556, 56);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "  \r\n  重新创建索引，该操作只对流水表起作用。\r\n         （请在SQL不繁忙时执行该操作，否则将严重影响SQL的性能。）";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tableLayoutPanel1.SetColumnSpan(this.labelX2, 2);
            this.labelX2.Location = new System.Drawing.Point(3, 65);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(141, 22);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "选择重建索引的表：";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.CallBasePaintBackground = true;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(370, 317);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(185, 32);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "重建索引(SQL内部整理)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // masterGrid
            // 
            this.masterGrid.AllowUserToAddRows = false;
            this.masterGrid.AllowUserToDeleteRows = false;
            this.masterGrid.AllowUserToResizeRows = false;
            this.masterGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.masterGrid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            summaryItem1.Caption = "总磅数";
            summaryItem1.ColumnName = "clnProductName";
            summaryItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem1.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Count;
            summaryItem2.ColumnName = "clnAmount";
            summaryItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem2.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem2.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            summaryItem3.ColumnName = "clnGrossWeight";
            summaryItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem3.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem3.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            summaryItem4.ColumnName = "clnTareWeight";
            summaryItem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem4.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem4.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            this.masterGrid.ColumnFootersItems.AddRange(new DevComponents.DotNetBar.Controls.SummaryItem[] {
            summaryItem1,
            summaryItem2,
            summaryItem3,
            summaryItem4});
            this.masterGrid.ColumnFootersVisible = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.masterGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.masterGrid.ColumnHeadersHeight = 22;
            this.masterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.masterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChecked,
            this.colTableName});
            this.tableLayoutPanel1.SetColumnSpan(this.masterGrid, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.masterGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.masterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.masterGrid.EnableHeadersVisualStyles = false;
            this.masterGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.masterGrid.Location = new System.Drawing.Point(3, 93);
            this.masterGrid.MultiSelect = false;
            this.masterGrid.Name = "masterGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.masterGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.masterGrid.RowHeadersWidth = 16;
            this.masterGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.masterGrid.Size = new System.Drawing.Size(611, 150);
            this.masterGrid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.masterGrid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.masterGrid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.masterGrid.Style.GradientAngle = 90;
            this.masterGrid.TabIndex = 21;
            this.masterGrid.TabStop = false;
            this.masterGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.masterGrid_CellValueChanged);
            this.masterGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.masterGrid_CurrentCellDirtyStateChanged);
            // 
            // colChecked
            // 
            this.colChecked.DataPropertyName = "IsConfirm";
            this.colChecked.FalseValue = "0";
            this.colChecked.HeaderText = "选择";
            this.colChecked.Name = "colChecked";
            this.colChecked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colChecked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colChecked.TrueValue = "1";
            this.colChecked.Width = 60;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "数据库表";
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 300;
            // 
            // CreateDBReIndexControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "CreateDBReIndexControl";
            this.Size = new System.Drawing.Size(617, 374);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtMsg;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCreate;
        private DevComponents.DotNetBar.Controls.DataGridViewX masterGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;

    }
}