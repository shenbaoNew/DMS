using Digiwin.Designer.Sql;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DMS.Forms {
    public partial class frmSQLFormat : BaseForm {
        public frmSQLFormat() {
            InitializeComponent();

            txtSQLOld.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            txtSQLNew.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

        }

        private void btnFormat_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtSQLOld.Text))
                return;

            try {
                SqlFormat sqlF = new SqlFormat();
                string sql = buildSql();
                txtSQLNew.Text = sqlF.FormatTextRange(sql);
            } catch (Exception ex) {
                txtSQLNew.Text = ex.Message;
            }
        }

        private string buildSql() {
            string sql = txtSQLOld.Text;
            string p = Regex.Replace(this.txtParam.Text.Trim(), @"\(\w+?\)", "");
            if (!string.IsNullOrEmpty(p)) {
                string[] ps = p.Split(',');
                foreach (string item in ps) {
                    int index = sql.IndexOf('?');
                    if (index >= 0) {
                        sql = sql.Remove(index, 1);
                        sql = sql.Insert(index, string.Format("'{0}'", item.Trim()));
                    }
                }
            }
            return sql;
        }
    }
}
