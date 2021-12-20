using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMS.DataClass.MMSData;

namespace DMS.Controls
{
    public partial class KillSumControl : UserControl
    {
        MMSData mmsData;

        public int flag = 0;

        public KillSumControl()
        {
            InitializeComponent();

            mmsData = new MMSData();
            dgvGrid.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date = this.dtDate.Value.ToString("yyyyMMdd");
            DataSet ds = null;
            string msg;
            dgvGrid.DataSource = null;
            if (flag == 0)
                ds = mmsData.QueryKillSum(date, date, out msg);
            else
                ds = mmsData.QueryKillSum2(date, date, out msg);

            if (!string.IsNullOrEmpty(msg))
                ShowMessage.ShowError(msg);
            else
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                        dgvGrid.DataSource = dt;
                }
            }
        }
    }
}
