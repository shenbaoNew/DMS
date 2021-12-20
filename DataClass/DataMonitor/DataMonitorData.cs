using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DMS
{
    class DataMonitorData:LocalDataBase
    {
        private RemoteDataBase remoteDB;

        public DataMonitorData()
        {
            remoteDB = new RemoteDataBase();
        }

        public DataSet GetMonitorData(string startDate, string endDate, string PlantCode, string PlantName)
        {
            string sqlCommand =

                        " SELECT C.BILLTYPENAME AS TITLE,B.USERNAME,A.MetageDate,ISNULL(COUNT(1),0) AS XCOUNT INTO #TMP FROM Temp_Stock_SaleDeliveryBill A " +
                        " LEFT JOIN Base_System_Users B ON B.USERID=A.USERID" +
                        " LEFT JOIN Base_Parameter_BillTypes C ON C.BILLTYPEID=A.BILLTYPEID" +
                        " WHERE CONVERT(CHAR(10),MetageDate,120) BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY A.USERID,B.USERNAME,C.BILLTYPENAME,A.MetageDate" +

                        " INSERT INTO #TMP(TITLE,USERNAME,MetageDate,XCOUNT)" +
                        " SELECT C.BILLTYPENAME AS TITLE,B.USERNAME,A.MetageDate,ISNULL(COUNT(1),0) AS XCOUNT FROM SAP_Stock_WarehousingBill A" +
                        " LEFT JOIN Base_System_Users B ON B.USERID=A.USERID" +
                        " LEFT JOIN Base_Parameter_BillTypes C ON C.BILLTYPEID=A.BILLTYPEID" +
                        " WHERE CONVERT(CHAR(10),MetageDate,120) BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY A.USERID,B.USERNAME,C.BILLTYPENAME,A.MetageDate" +

                        " INSERT INTO #TMP(TITLE,USERNAME,MetageDate,XCOUNT)" +
                        " SELECT C.BILLTYPENAME AS TITLE,B.USERNAME,A.MetageDate,ISNULL(COUNT(1),0) AS XCOUNT FROM SAP_Stock_CutterDeliveryBill A" +
                        " LEFT JOIN Base_System_Users B ON B.USERID=A.USERID" +
                        " LEFT JOIN Base_Parameter_BillTypes C ON C.BILLTYPEID=A.BILLTYPEID" +
                        " WHERE CONVERT(CHAR(10),MetageDate,120)  BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY A.USERID,B.USERNAME,C.BILLTYPENAME,A.MetageDate" +

                        " INSERT INTO #TMP(TITLE,USERNAME,MetageDate,XCOUNT)" +
                        " SELECT '生猪采购凭证' AS TITLE,USERNAME,InvoiceDate AS MetageDate,ISNULL(COUNT(1),0) AS XCOUNT FROM SAP_Supply_PurchaseOrder " +
                        " WHERE CONVERT(CHAR(10),InvoiceDate,120)  BETWEEN '" + startDate + "' AND '" + endDate + "' GROUP BY USERNAME,InvoiceDate" +

                        " SELECT BILLTYPENAME INTO #TMP0 FROM Base_Parameter_BillTypes " +
                        " INSERT INTO #TMP0(BILLTYPENAME) VALUES ('生猪采购凭证');" +
                        " SELECT RTRIM(A.BILLTYPENAME) AS TITLE,ISNULL(B.USERNAME,'') AS USERNAME,MetageDate,ISNULL(b.XCOUNT,0) AS XCOUNT INTO #TMP1 FROM #TMP0  A" +
                        " LEFT JOIN #TMP b  ON b.TITLE=a.BILLTYPENAME" +
                        " DECLARE @sql varchar(8000) " +
                        " SET @sql = 'SELECT MetageDate AS 操作日期,''" + PlantCode + "'' AS 工厂编码,''" + PlantName + "'' AS 工厂名称, USERNAME AS ' + '用户' " +
                        " SELECT @sql = @sql + ' ,SUM (case TITLE when ''' + TITLE + ''' then XCOUNT else NULL end) AS [' + TITLE + ']' " +
                        " FROM (select distinct TITLE from #TMP1) as a set @sql = @sql + ' from #TMP1 group by USERNAME,MetageDate' exec(@sql)" +
                        " DROP TABLE #TMP0,#TMP,#TMP1";
            remoteDB.ChangeConnectionString(SecurityEnum.MMS, "yrmmsadmin", "10.128.0.99", PubContext.syatemFlag.ToString() + PlantCode, "{SDH;;9VNZHVbny");
            return remoteDB.ExecuteDataSet(sqlCommand);
        }
    }
}
