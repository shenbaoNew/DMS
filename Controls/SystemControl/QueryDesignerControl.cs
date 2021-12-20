using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using DMS.Forms;

namespace DMS.Controls
{
    public partial class QueryDesignerControl : UserControl
    {
        private QueryBuilder _builder;
        public event AfterSelectFinishedItemEventHandler AfterSelectFinished;
        public QueryDesignerControl(QueryBuilder builder)
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
               
                _txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
                this._builder = builder;
                _grid.DataSource = _builder.QueryFields;
                UpdateGridColumns();
                FixGridColumns();
            }
        }

      
        public QueryBuilder QueryBuilder
        {
            get { return _builder; }
            set
            {
                _builder = value;
            }
        }
       public void UpdateSqlDisplay()
        {
            _txtSql.Text = _builder.Sql;
          _lblStatus.Visible = _builder.MissingJoins;
          _txtSql.Refresh();
        }
        public void SelectField(QueryField field)
        {
            var cm = BindingContext[_grid.DataSource] as CurrencyManager;
            cm.Position = cm.List.IndexOf(field);
        }
        // update state of the grid columns
       public void UpdateGridColumns()
        {
            //_grid.Columns["colColumn"].Frozen = true;
            if (_grid.Columns.Contains("colGroupBy"))
           _grid.Columns["colGroupBy"].Visible = _builder.GroupBy;
        }
       public void FixGridColumns()
        {
            for (int i = 0; i < _grid.Columns.Count; i++)
            {
                var col = _grid.Columns[i];
                if (col.ValueType!=null&&col.ValueType.IsEnum)
                {
                    // create combo column for enum types
                    var cmb = new DataGridViewComboBoxColumn();
                    cmb.ValueType = col.ValueType;
                    cmb.Name = col.Name;
                    cmb.DataPropertyName = col.DataPropertyName;
                    cmb.HeaderText = col.HeaderText;
                    cmb.DisplayStyleForCurrentCellOnly = true;
                    cmb.DataSource = Enum.GetValues(col.ValueType);
                    cmb.Width = col.Width;

                    // replace original column with new combo column
                    _grid.Columns.RemoveAt(i);
                    _grid.Columns.Insert(i, cmb);
                }
                else if (col.Name == "colFilter")
                {
                    var btn = new DataGridViewButtonColumn();
                    btn.ValueType = col.ValueType;
                    btn.Name = col.Name;
                    btn.DataPropertyName = col.DataPropertyName;
                    btn.HeaderText = col.HeaderText;
                    btn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    btn.Width = col.Width;

                    // replace original column with new combo column
                    _grid.Columns.RemoveAt(i);
                    _grid.Columns.Insert(i, btn);
                }
            }

        }
       void _grid_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           if (_grid.Columns[e.ColumnIndex].Name == "colFilter" && e.RowIndex > -1 && e.ColumnIndex > -1)
           {
               using (var dlg = new FilterEditorForm())
               {
                   var field = _grid.Rows[e.RowIndex].DataBoundItem as QueryField;
                   dlg.Font = Font;
                   dlg.QueryField = field;
                   if (dlg.ShowDialog(this) == DialogResult.OK)
                   {
                       field.Filter = dlg.Value;
                   }
               }
           }
       }

       private void _grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
       }

       private void btnClear_Click(object sender, EventArgs e)
       {
           _builder.QueryFields.Clear();
           _txtSql.Refresh();
       }

       private void btnOK_Click(object sender, EventArgs e)
       {

       }

       private void _btnGroupBy_Click(object sender, EventArgs e)
       {

           _btnGroupBy.Checked = !_btnGroupBy.Checked;
           _builder.GroupBy = _btnGroupBy.Checked;
           UpdateSqlDisplay();
           UpdateGridColumns();
       }

       private void _btnClearQuery_Click(object sender, EventArgs e)
       {
           _builder.QueryFields.Clear();
           _txtSql.Refresh();
       }

       private void _btnProperties_Click(object sender, EventArgs e)
       {
           using (var dlg = new QueryPropertiesDialog())
           {
               dlg.Font = this.Font;
               dlg.QueryBuilder = _builder;
               if (dlg.ShowDialog() == DialogResult.OK)
               {
                   UpdateSqlDisplay();
               }
           }
       }

       private void _btnCheckSql_Click(object sender, EventArgs e)
       {
           try
           {
               string sqlString = this._txtSql.Text.Trim();
               if (!string.IsNullOrEmpty(sqlString))
               {
                   var da = new System.Data.OleDb.OleDbDataAdapter(this._txtSql.Text.Trim(), this._builder.ConnectionString);
                   var dt = new DataTable();
                   da.FillSchema(dt, SchemaType.Mapped);
                   MessageBox.Show(this,
                       "SQL语句正确",
                       Application.ProductName,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
               }
           }
           catch (Exception x)
           {
               var msg = string.Format("SQL语句存在语法错误:{0}", x.Message);
               MessageBox.Show(this,
                   msg,
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
           }
       }

       private void _btnViewResults_Click(object sender, EventArgs e)
       {
           if (AfterSelectFinished != null)
           {
               AfterSelectFinished(this,true,this._txtSql.Text.Trim(),true);
           }
       }

       private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
       {

       }

    }
}
