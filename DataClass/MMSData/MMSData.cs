using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DMS.DataClass.DataBase.Sap;

namespace DMS.DataClass.MMSData
{
    public class MMSData : SapRfcHelper
    {
        public DataSet QueryKillSum(string dtStart, string dtEnd, out string msg)
        {
            string funName = "ZSM_GET_TZSL";
            string innerTable = "T_DATA";
            string para1 = "I_TZRQ:" + dtStart;
            string para2 = "I_BUKRS:8960";
            string para3 = "I_WERKS:8960";
            string para4 = "I_MATNR:50000000";

            return ExecuteSAPDataSet(funName, innerTable, "", out msg, para1, para2, para3, para4);
        }

        public DataSet QueryKillSum2(string dtStart, string dtEnd,out string msg)
        {
            string funName = "ZSM_GET_TZSL";
            string innerTable = "T_DATA";
            string para1 = "I_TZRQ:" + dtStart;
            string para2 = "I_BUKRS:8960";
            string para3 = "I_WERKS:8960";
            string para4 = "I_MATNR:50000000";

            return ExecuteSAPDataSet2(funName, innerTable, "", out msg, para1, para2, para3, para4);
        }
    }
}
