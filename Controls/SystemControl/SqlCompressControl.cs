using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DMS.Controls
{
    public partial class SqlCompressControl : UserControl
    {
        private SQLManageData smd;
        private DataSet compressResult;
        public SqlCompressControl()
        {
            InitializeComponent();
            smd = new SQLManageData();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            string dbName = txtDBNam.Text.Trim();
            string dbLogName = txtLogName.Text.Trim();
            if (!string.IsNullOrEmpty(dbName) && !string.IsNullOrEmpty(dbLogName))
            {
                compressResult = smd.CompressDataBase(dbName, dbLogName);
            }
            if (compressResult != null)
            {
                DataTable table1 = compressResult.Tables[0];
                DataTable table2 = compressResult.Tables[2];
                if (table1.Rows.Count > 0)
                {
                    foreach (DataRow row in table1.Rows)
                    {
                        labOrSize.Text = row["OLDSIZE"].ToString().Trim();
                    }
                }
                if (table2.Rows.Count > 0)
                {
                    foreach (DataRow row in table2.Rows)
                    {
                        labNeSize.Text = row["NEWSIZE"].ToString().Trim();
                    }
                }
            }
            btnOK.Enabled = true;
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {

        }
    }
}
