using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DMS.Forms
{
    public partial class TestControl : UserControl
    {
        private DevComponents.Editors.LabelComboBox cmbKillOrder;
        private DevComponents.Editors.LabelComboBox cmbBodyType;
        private DevComponents.Editors.LabelComboBox cmbScoreID;
        private DevComponents.Editors.LabelComboBox cmbInDepots;
        private DevComponents.Editors.LabelComboBox cmbProducts;
        private DevComponents.Editors.LabelDoubleBox txtAmount;
        private DevComponents.Editors.LabelDoubleBox txtSecAmount;
        private DevComponents.Editors.LabelDoubleBox txtWeight;
        private DevComponents.Editors.LabelSapBatchBox cmbBatchNos;

        private int columnCount = 2;
        private int rowCount = 0;

        public TestControl()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                InitData();
            }
        }

        #region 序号

        private void CreateKillOrderBox(int tabIndex, bool tabStop)
        {
            this.cmbKillOrder = new DevComponents.Editors.LabelComboBox();
            this.tablePanel.Controls.Add(this.cmbKillOrder);
            this.cmbKillOrder.AllowEdit = true;
            this.cmbKillOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKillOrder.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbKillOrder.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cmbKillOrder.Caption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKillOrder.Caption.Text = "序号：";
            this.cmbKillOrder.Caption.Width = 80;
            this.cmbKillOrder.EditBoxWidth = 20;
            this.cmbKillOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cmbKillOrder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbKillOrder.Name = "cmbKillOrder";
            this.cmbKillOrder.TabIndex = tabIndex;
            this.cmbKillOrder.TabStop = tabStop;
            this.cmbKillOrder.FilteredToNextControl = true;
            this.cmbKillOrder.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            //this.cmbKillOrder.SelectedIndexChanged += new System.EventHandler(this.cmbKillOrder_SelectedIndexChanged);
            this.cmbKillOrder.Size = new System.Drawing.Size(200, 23);
        }

        #endregion

        #region 类型

        private void CreatePigTypeBox(int tabIndex, bool tabStop)
        {
            this.cmbBodyType = new DevComponents.Editors.LabelComboBox();
            this.tablePanel.Controls.Add(this.cmbBodyType);
            this.cmbBodyType.AllowEdit = true;
            this.cmbBodyType.Caption.Width = 80;
            this.cmbBodyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBodyType.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbBodyType.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBodyType.Caption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBodyType.Caption.Text = "类型：";
            this.cmbBodyType.EditBoxWidth = 20;
            this.cmbBodyType.DropDownHeight = 100;
            this.cmbBodyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBodyType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBodyType.Name = "cmbPigType";
            this.cmbBodyType.TabIndex = tabIndex;
            this.cmbBodyType.FilteredToNextControl = true;
            this.cmbBodyType.TabStop = tabStop;
            this.cmbBodyType.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.cmbBodyType.Size = new System.Drawing.Size(200, 23);
        }

        #endregion

        #region 品种

        private void CreateScoreBox(int tabIndex, bool tabStop)
        {
            this.cmbScoreID = new DevComponents.Editors.LabelComboBox();
            this.tablePanel.Controls.Add(this.cmbScoreID);
            this.cmbScoreID.AllowEdit = true;
            this.cmbScoreID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbScoreID.Caption.Width = 80;
            this.cmbScoreID.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbScoreID.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbScoreID.Caption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbScoreID.Caption.Text = "品种：";
            this.cmbScoreID.EditBoxWidth = 20;
            this.cmbScoreID.DropDownHeight = 100;
            this.cmbScoreID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbScoreID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbScoreID.Name = "cmbScore";
            this.cmbScoreID.TabIndex = tabIndex;
            this.cmbScoreID.TabStop = tabStop;
            this.cmbScoreID.FilteredToNextControl = true;
            this.cmbScoreID.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.cmbScoreID.Size = new System.Drawing.Size(200, 23);
        }

        #endregion

        #region 入库点

        private void CreateInDepotsBox(int tabIndex, bool tabStop)
        {
            this.cmbInDepots = new DevComponents.Editors.LabelComboBox();
            this.tablePanel.Controls.Add(this.cmbInDepots);
            this.cmbInDepots.AllowEdit = true;
            this.cmbInDepots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInDepots.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbInDepots.Caption.Width = 80;
            this.cmbInDepots.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInDepots.Caption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbInDepots.Caption.Text = "入库点：";
            this.cmbInDepots.EditBoxLength = 6;
            this.cmbInDepots.EditBoxWidth = 40;
            this.cmbInDepots.ColumnWidths = "30%,70%";
            this.cmbInDepots.FilteredToNextControl = true;
            this.cmbInDepots.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInDepots.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbInDepots.Name = "cmbInDepots";
            this.cmbInDepots.TabIndex = tabIndex;
            this.cmbInDepots.TabStop = tabStop;
            this.cmbInDepots.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.cmbInDepots.Size = new System.Drawing.Size(200, 23);
            //this.cmbInDepots.SelectedValueChanged += new EventHandler(cmbDepots_SelectedValueChanged);
        }

        #endregion

        #region 品名

        private void CreateProductsBox(int tabIndex, bool tabStop)
        {
            this.cmbProducts = new DevComponents.Editors.LabelComboBox();
            this.tablePanel.Controls.Add(this.cmbProducts);
            this.tablePanel.SetColumnSpan(this.cmbProducts, columnCount);
            this.cmbProducts.AllowEdit = true;
            this.cmbProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProducts.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbProducts.Caption.Width = 80;
            this.cmbProducts.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProducts.Caption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProducts.Caption.Text = "品名：";
            this.cmbProducts.EditBoxLength = 6;
            this.cmbProducts.EditBoxWidth = 60;
            this.cmbProducts.FilteredToNextControl = true;
            this.cmbProducts.FilterType = DevComponents.AdvTree.eFilterType.RightMatch;
            this.cmbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProducts.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.TabIndex = tabIndex;
            this.cmbProducts.TabStop = tabStop;
            //this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            this.cmbProducts.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.cmbProducts.Size = new System.Drawing.Size(200, 23);
        }

        #endregion

        #region 数量
        private void CreateAmountBox(int tabIndex, bool tabStop)
        {
            this.txtAmount = new DevComponents.Editors.LabelDoubleBox();
            this.tablePanel.Controls.Add(this.txtAmount);
            this.txtAmount.AllowMouseUpDown = false;
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.Color.Empty;
            this.txtAmount.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtAmount.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAmount.Caption.Text = "数量：";
            this.txtAmount.Caption.Width = 80;
            this.txtAmount.DisplayFormat = "0.0";
            this.txtAmount.ValueChanged += new EventHandler(txtAmount_TextChanged);
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.TabIndex = tabIndex;
            this.txtAmount.TabStop = tabStop;
            this.txtAmount.TextAlign = DevComponents.Editors.eHorizontalAlignment.Right;
            this.txtAmount.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtAmount.Size = new System.Drawing.Size(200, 20);

        }

        void txtAmount_TextChanged(object sender, EventArgs e)
        {
            //decimal amount = Functions.FormatDecimal(txtAmount.Value);
            //if (amount < 1 && amount != Convert.ToDecimal(0.5))
            //{
            //    txtAmount.Value = 0.5;
            //}
        }
        private void CreateSecAmountBox(int tabIndex, bool tabStop)
        {
            this.txtSecAmount = new DevComponents.Editors.LabelDoubleBox();
            this.tablePanel.Controls.Add(this.txtSecAmount);
            this.txtSecAmount.AllowMouseUpDown = false;
            this.txtSecAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecAmount.BackColor = System.Drawing.Color.Empty;
            this.txtSecAmount.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtSecAmount.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtSecAmount.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSecAmount.Caption.Text = "规格：";
            this.txtSecAmount.Caption.Width = 80;
            this.txtSecAmount.DisplayFormat = "0.0";
            this.txtSecAmount.ValueChanged += new EventHandler(txtAmount_TextChanged);
            this.txtSecAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtSecAmount.Name = "txtSecAmount";
            this.txtSecAmount.TabIndex = tabIndex;
            this.txtSecAmount.TabStop = tabStop;
            this.txtSecAmount.TextAlign = DevComponents.Editors.eHorizontalAlignment.Right;
            this.txtSecAmount.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtSecAmount.Size = new System.Drawing.Size(200, 20);
        }
        #endregion

        #region 重量
        private void CreateWeightBox(int tabIndex, bool tabStop)
        {
            this.txtWeight = new DevComponents.Editors.LabelDoubleBox();
            this.tablePanel.Controls.Add(this.txtWeight);
            this.txtWeight.AllowMouseUpDown = false;
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.BackColor = System.Drawing.Color.Empty;
            this.txtWeight.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtWeight.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtWeight.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtWeight.Caption.Text = "重量：";
            this.txtWeight.Caption.Width = 80;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWeight.TabIndex = tabIndex;
            this.txtWeight.TabStop = tabStop;
            this.txtWeight.TextAlign = DevComponents.Editors.eHorizontalAlignment.Right;
            this.txtWeight.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtWeight.Size = new System.Drawing.Size(200, 20);
        }
        #endregion

        #region 批次

        private void CreateBatchNoBox(int tabIndex, bool tabStop)
        {
            this.cmbBatchNos = new DevComponents.Editors.LabelSapBatchBox();
            this.tablePanel.Controls.Add(cmbBatchNos);
            this.tablePanel.Anchor = (System.Windows.Forms.AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
        }

        #endregion

        private void ResetSize()
        {
            if (this.tablePanel.Visible)
            {
                this.tablePanel.SuspendLayout();
                int rowCount = GetVisibleControlCount();
                this.tablePanel.RowCount = rowCount;
                this.Height = this.expandPanel.TitleHeight + rowCount * 32 + 20;
                this.tablePanel.ResumeLayout();
            }
        }
        private int GetVisibleControlCount()
        {
            int rowCount = 0;
            int startCount = 0;
            int xcount = tablePanel.Controls.Count;
            for (int n = 0; n < xcount; n++)
            {
                Control c = tablePanel.Controls[n];
                if (c.Visible)
                {
                    int spanCol = this.tablePanel.GetColumnSpan(c);
                    startCount += spanCol;
                    if (startCount > columnCount)
                    {
                        rowCount++;
                        startCount = spanCol;
                    }
                    else if (startCount == columnCount)
                    {
                        rowCount++;
                        startCount = 0;
                    }
                }
            }
            if (startCount > 0 && startCount < columnCount)
                rowCount++;

            this.rowCount = rowCount;
            return rowCount;
        }

        public void InitData()
        {
            this.tablePanel.ColumnCount = columnCount;

            CreatePanelColumn();
            CreatePanelRow();

            CreateProductsBox(0, true);
            CreateKillOrderBox(1, true);
            CreatePigTypeBox(2, true);
            CreateScoreBox(3, true);
            //CreateAmountBox(4, true);
            //CreateSecAmountBox(5, true);
            //CreateWeightBox(6, true);

            ResetSize();
            this.Validate();
        }

        private void CreatePanelRow()
        {
            this.tablePanel.RowStyles.Clear();

            this.tablePanel.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Absolute, 32));
        }

        private void CreatePanelColumn()
        {
            this.tablePanel.ColumnStyles.Clear();
            Single perF = Convert.ToSingle(100 / columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, perF));
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Database=Test;Server=10.10.254.66;uid=sa;pwd=shenbao;"))
                {
                    conn.Open();
                    System.Data.Common.DbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Users(ID,Code,Name) Values(1,'code','name')";
                    int i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！！！\n" + ex.Message);
            }
        }
    }
}
