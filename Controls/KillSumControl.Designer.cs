namespace DMS.Controls
{
    partial class KillSumControl
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
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem1 = new DevComponents.DotNetBar.Controls.SummaryItem();
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem2 = new DevComponents.DotNetBar.Controls.SummaryItem();
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem3 = new DevComponents.DotNetBar.Controls.SummaryItem();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dtDate = new DevComponents.DotNetBar.Controls.ToolStripDateTimePicker();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDateTimePicker1 = new DevComponents.DotNetBar.Controls.ToolStripDateTimePicker();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.dgvGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.StoreSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KillSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KillWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dtDate,
            this.toolStripLabel1,
            this.toolStripDateTimePicker1,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(452, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.dtDate.CalendarForeColor = System.Drawing.SystemColors.ControlText;
            this.dtDate.CalendarMonthBackground = System.Drawing.SystemColors.Window;
            this.dtDate.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtDate.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtDate.CalendarTrailingForeColor = System.Drawing.SystemColors.GrayText;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(120, 22);
            this.dtDate.Text = "2015年1月31日";
            this.dtDate.Value = new System.DateTime(2015, 1, 31, 9, 32, 9, 497);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "到";
            // 
            // toolStripDateTimePicker1
            // 
            this.toolStripDateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 9F);
            this.toolStripDateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripDateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Window;
            this.toolStripDateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripDateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripDateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.toolStripDateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.toolStripDateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.toolStripDateTimePicker1.Name = "toolStripDateTimePicker1";
            this.toolStripDateTimePicker1.Size = new System.Drawing.Size(120, 22);
            this.toolStripDateTimePicker1.Text = "2015年1月31日";
            this.toolStripDateTimePicker1.Value = new System.DateTime(2015, 1, 31, 10, 35, 24, 663);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DMS.Properties.Resources.search;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 22);
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AllowUserToDeleteRows = false;
            this.dgvGrid.AllowUserToResizeRows = false;
            this.dgvGrid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            summaryItem1.ColumnName = "StoreSum";
            summaryItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem1.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            summaryItem2.ColumnName = "KillSum";
            summaryItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem2.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem2.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            summaryItem3.ColumnName = "KillWeight";
            summaryItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            summaryItem3.ForeColor = System.Drawing.SystemColors.ControlText;
            summaryItem3.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
            this.dgvGrid.ColumnFootersItems.AddRange(new DevComponents.DotNetBar.Controls.SummaryItem[] {
            summaryItem1,
            summaryItem2,
            summaryItem3});
            this.dgvGrid.ColumnFootersVisible = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreSum,
            this.KillSum,
            this.KillWeight});
            this.dgvGrid.DataGridViewCaption = "dataGridViewX1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvGrid.Location = new System.Drawing.Point(0, 25);
            this.dgvGrid.Name = "dgvGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrid.RowTemplate.Height = 23;
            this.dgvGrid.Size = new System.Drawing.Size(452, 211);
            this.dgvGrid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dgvGrid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dgvGrid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.dgvGrid.Style.GradientAngle = 90;
            this.dgvGrid.TabIndex = 1;
            // 
            // StoreSum
            // 
            this.StoreSum.DataPropertyName = "JCSL";
            this.StoreSum.HeaderText = "圈存量";
            this.StoreSum.Name = "StoreSum";
            // 
            // KillSum
            // 
            this.KillSum.DataPropertyName = "TZSL";
            this.KillSum.HeaderText = "屠宰量";
            this.KillSum.Name = "KillSum";
            // 
            // KillWeight
            // 
            this.KillWeight.DataPropertyName = "TZJZ";
            this.KillWeight.HeaderText = "屠宰重";
            this.KillWeight.Name = "KillWeight";
            // 
            // KillSumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvGrid);
            this.Controls.Add(this.toolStrip1);
            this.Name = "KillSumControl";
            this.Size = new System.Drawing.Size(452, 236);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevComponents.DotNetBar.Controls.ToolStripDateTimePicker dtDate;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvGrid;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DevComponents.DotNetBar.Controls.ToolStripDateTimePicker toolStripDateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn KillSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn KillWeight;
    }
}
