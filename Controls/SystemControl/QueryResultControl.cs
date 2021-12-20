using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace DMS.Controls
{
    public partial class QueryResultControl : UserControl
    {
        private string connectionString;
        private bool isexcute;

        public string DisplayText
        {
            set { lblServer.Text = value; }
        }

        public QueryResultControl(string connectionString,string sqlString,bool isExcute)
        {
            InitializeComponent();
            _txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            this.connectionString = connectionString;
            this._txtSql.Text = sqlString;
            this.isexcute = isExcute;
            this._txtSql.Refresh();
            QuerySQL();

        }
        private void QuerySQL()
        {
            DataTable dt = null;
            try
            {
                if (!string.IsNullOrEmpty(this._txtSql.Text.Trim())&&isexcute)
                {
                    // get the data
                    var da = new System.Data.OleDb.OleDbDataAdapter(this._txtSql.Text.Trim(), this.connectionString);
                    dt = new DataTable("Query");
                    da.Fill(dt);

                    this.resultGrid.DataSource = dt;

                    if (dt == null || dt.Rows.Count <= 0)
                        this.expandablePanel1.TitleText = "查询已完成,无查询结果";
                    else
                        this.expandablePanel1.TitleText = "查询已完成";
                }
            }
            catch (Exception x)
            {
                string msg = string.Format("查询数据出错:{0}", x.Message);
                this.expandablePanel1.TitleText = msg;
                MessageBox.Show(this,
                    msg,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void _btnViewResults_Click(object sender, EventArgs e)
        {
            this.isexcute = true;
            this.expandablePanel1.TitleText = "正在查询……";
            QuerySQL();
        }

        private void _btnClearQuery_Click(object sender, EventArgs e)
        {
            this.resultGrid.DataSource = null;
        }
    }
}
