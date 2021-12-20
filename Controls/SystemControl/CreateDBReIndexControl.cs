using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Controls
{
    public partial class CreateDBReIndexControl : UserControl
    {
        private SQLManageData sqlManager;
          private BindingSource mBs;
        public CreateDBReIndexControl()
        {
            InitializeComponent();
            sqlManager = new SQLManageData();
            mBs = new BindingSource();
            GetTableName();
        }
        private void GetTableName()
        {
            DataSet tmpds = sqlManager.GetDBTableName();
            if (tmpds != null && tmpds.Tables.Count > 0)
            {
                DataTable table = tmpds.Tables[0];
                DataView view = table.DefaultView;
                view.RowFilter = "TABLENAME LIKE 'Flow*' OR TABLENAME LIKE 'Middle*' OR TABLENAME LIKE 'SAP*'  OR TABLENAME LIKE 'Temp*' ";
                view.Sort = " TABLENAME ASC";
                this.mBs.DataSource=view.ToTable();
                masterGrid.DataSource = mBs;
            }
        }
        private void masterGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.masterGrid.Columns[e.ColumnIndex].Name == "colChecked")
            {
                RestButton();
            }
        }
        private void masterGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (masterGrid.Columns[masterGrid.CurrentCell.ColumnIndex].Name == "colChecked")
            {
                if (masterGrid.IsCurrentCellDirty)
                {
                    masterGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }
        private DataTable GetResultMasterTable()
        {
            this.mBs.EndEdit();
            DataTable resultTable = new DataTable();
            DataTable tmpdt = (DataTable)this.mBs.DataSource;
            if (null != tmpdt && tmpdt.Rows.Count > 0)
            {
                resultTable = tmpdt.Clone();
                DataView dv = tmpdt.Copy().DefaultView;
                dv.RowFilter = "IsConfirm=1";
                resultTable = dv.ToTable();
            }
            return resultTable;
        }
        private void RestButton()
        {
            DataTable resultTable = GetResultMasterTable();
            if (resultTable.Rows.Count > 0)
            {
                btnOK.Enabled = true;
                btnCreate.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
                btnCreate.Enabled = false;
            }
        }
        private void CreateIndex(int index)
        {
            DataTable table = GetResultMasterTable();
            bool result = false;
            foreach (DataRow row in table.Rows)
            {
                string tableName = row["TABLENAME"].ToString().Trim();
                if (index > 0)
                {
                    result = sqlManager.DeleteAndCreateIndex(tableName);
                }
                else
                {
                    result = sqlManager.ReIndexDataBase(tableName);
                }
                this.txtMsg.AppendText("\n【" + tableName + "】索引重建结束！");
                this.txtMsg.ScrollToCaret();
            }
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            this.txtMsg.Clear();
            this.txtMsg.AppendText("\n正在创建索引，请稍后.....！");
            CreateIndex(0);
            this.btnOK.Enabled = true;
            this.txtMsg.AppendText("\n重建索引结束！");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            this.txtMsg.Clear();
            this.txtMsg.AppendText("\n正在创建索引，请稍后.....！");
            CreateIndex(1);
            this.btnOK.Enabled = true;
            this.txtMsg.AppendText("\n重建索引结束！");
        }
    }
}