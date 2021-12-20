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
    public partial class RemoveHistoryDataControl : UserControl
    {
        private DateTime startDate ;
        private CreateHistoryData createHistoryData;
        public RemoveHistoryDataControl()
        {
            InitializeComponent();
            startDate = System.DateTime.Today.AddYears(-1);
            txtendDate.Value = startDate;
            createHistoryData = new CreateHistoryData();
        }

        private void txtendDate_ValueChanged(object sender, EventArgs e)
        {
            if (txtendDate.Value > startDate)
                txtendDate.Value = startDate;
            //Functions.DateRange(txtstartDate, txtendDate, 1, 1, DatePeriodKind.Month);
        }

        private void txtstartDate_ValueChanged(object sender, EventArgs e)
        {
            //Functions.DateRange(txtstartDate, txtendDate, 0, 1, DatePeriodKind.Month);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string startDateTime = txtstartDate.Value.ToString("yyyy'-'MM'-'dd");
            string endDateTime = txtendDate.Value.ToString("yyyy'-'MM'-'dd");
            string billNo= string.Empty;
            string txtBillNos = txtBillNo.Text.Trim();
             bool result=false;
             if (string.IsNullOrEmpty(txtBillNos))
                 result = createHistoryData.CreateHistoryDatas(startDateTime, endDateTime, string.Empty);
             else
             {
                 string[] billNos = txtBillNos.Split(',');
                 foreach (string str in billNos)
                 {
                     if (!string.IsNullOrEmpty(str))
                     {
                         if (string.IsNullOrEmpty(billNo))
                         {
                             billNo = "'" + str + "'";
                         }
                         else
                         {
                             billNo += ",'" + str + "'";
                         }
                     }
                 }
                 if (!string.IsNullOrEmpty(billNo))
                 {
                     result = createHistoryData.CreateHistoryDatas(startDateTime, endDateTime, billNo);
                 }
             }
             if (result)
             {
                 txtstartDate.Value.AddMonths(1);
                 MessageBox.Show("系统提示", "数据转移完成！");
             }
        }
    }
}
