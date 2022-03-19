using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace DMS
{
    class CreateHistoryData:LocalDataBase
    {
        public CreateHistoryData()
        {
        }

        private string CreateHistoryInvoiceTemplateData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            
            sqlCommand += " SELECT * INTO #TMPINVOICEMASTER FROM Flow_Payment_InvoiceMaster WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPINVOICEDETAIL FROM Flow_Payment_InvoiceDetail WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPTEMPLATEDTAIL FROM Flow_Payment_InvoiceTemplateDetails WHERE InvoiceID IN (SELECT InvoiceID FROM #TMPINVOICEMASTER)" +
                                " INSERT INTO History_Flow_Payment_InvoiceTemplateMaster SELECT *  FROM Flow_Payment_InvoiceTemplateMaster WHERE MergeID IN (SELECT MergeID FROM #TMPTEMPLATEDTAIL)" +
                                " INSERT INTO History_Flow_Payment_InvoiceTemplateDetails SELECT * FROM #TMPTEMPLATEDTAIL " +
                                " DELETE FROM Flow_Payment_InvoiceTemplateDetails WHERE MergeID IN (SELECT MergeID FROM #TMPTEMPLATEDTAIL)" +
                                " DELETE FROM Flow_Payment_InvoiceTemplateMaster WHERE MergeID IN (SELECT MergeID FROM #TMPTEMPLATEDTAIL)" +
                                " DROP TABLE #TMPBILLNO,#TMPINVOICEMASTER,#TMPINVOICEDETAIL,#TMPTEMPLATEDTAIL";
            return sqlCommand;
        }
        private string CreateHistoryInvoicePlanPayforData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " SELECT * INTO #TMPINVOICEMASTER FROM Flow_Payment_InvoiceMaster WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPINVOICEDETAIL FROM Flow_Payment_InvoiceDetail WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPTEMPLATEDTAIL FROM Flow_Payment_InvoicePlanPayforDetail WHERE InvoiceID IN (SELECT InvoiceID FROM #TMPINVOICEMASTER)" +
                                " INSERT INTO History_Flow_Payment_InvoicePlanPayforMaster SELECT *  FROM Flow_Payment_InvoicePlanPayforMaster WHERE PlanID IN (SELECT PlanID FROM #TMPTEMPLATEDTAIL)" +
                                " INSERT INTO History_Flow_Payment_InvoicePlanPayforDetail SELECT * FROM #TMPTEMPLATEDTAIL " +
                                " DELETE FROM Flow_Payment_InvoicePlanPayforDetail WHERE PlanID IN (SELECT PlanID FROM #TMPTEMPLATEDTAIL)" +
                                " DELETE FROM Flow_Payment_InvoicePlanPayforMaster WHERE PlanID IN (SELECT PlanID FROM #TMPTEMPLATEDTAIL)" +
                                " DROP TABLE #TMPBILLNO,#TMPINVOICEMASTER,#TMPINVOICEDETAIL,#TMPTEMPLATEDTAIL";
            return sqlCommand;
        }
        private string CreateHistoryInvoicePayforData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " SELECT * INTO #TMPINVOICEMASTER FROM Flow_Payment_InvoiceMaster WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPINVOICEDETAIL FROM Flow_Payment_InvoiceDetail WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " SELECT * INTO #TMPTEMPLATEDTAIL FROM Flow_Payment_InvoicePayforDetail WHERE BillNO IN (SELECT BillNO FROM #TMPINVOICEMASTER)" +
                                " INSERT INTO History_Flow_Payment_InvoicePayforMaster SELECT *  FROM Flow_Payment_InvoicePayforMaster WHERE PayforID IN (SELECT PayforID FROM #TMPTEMPLATEDTAIL)" +
                                " INSERT INTO History_Flow_Payment_InvoicePayforDetail SELECT * FROM #TMPTEMPLATEDTAIL " +
                                " DELETE FROM Flow_Payment_InvoicePayforDetail WHERE PayforID IN (SELECT PayforID FROM #TMPTEMPLATEDTAIL)" +
                                " DELETE FROM Flow_Payment_InvoicePayforMaster WHERE PayforID IN (SELECT PayforID FROM #TMPTEMPLATEDTAIL)" +
                                " DROP TABLE #TMPBILLNO,#TMPINVOICEMASTER,#TMPINVOICEDETAIL,#TMPTEMPLATEDTAIL";
            return sqlCommand;
        }
        private string CreateHistoryInvoiceData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Flow_Payment_InvoiceMaster SELECT * FROM Flow_Payment_InvoiceMaster WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Payment_InvoiceDetail SELECT * FROM Flow_Payment_InvoiceDetail WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Payment_InvoiceAppend SELECT * FROM Flow_Payment_InvoiceAppend WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Payment_InvoiceAppend WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Payment_InvoiceDetail WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Payment_InvoiceMaster WHERE BillNO IN (SELECT BillNO FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO";
            return sqlCommand;
        }
        private string CreateHistoryMiddleData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Middle_Payment_AfterKilledAnalysis SELECT *  FROM Middle_Payment_AfterKilledAnalysis WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Middle_Balance_MetageDetailBak SELECT *  FROM Middle_Balance_MetageDetailBak WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Middle_Balance_MetageDetail SELECT *  FROM Middle_Balance_MetageDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Middle_Payment_AfterKilledAnalysis WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Middle_Balance_MetageDetailBak WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Middle_Balance_MetageDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO";
            return sqlCommand;
        }
        private string CreateHistoryPurchaseData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO,PlanID INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Flow_Supply_PurchaseBilll SELECT *  FROM Flow_Supply_PurchaseBilll WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Supply_PurchasePrice SELECT *  FROM Flow_Supply_PurchasePrice WHERE (CONVERT(CHAR(10),FromDate, 120)) BETWEEN  '" + startDate + "' AND '" + endData + "'" +
                                " INSERT INTO History_Flow_Supply_PrepurchaseDetail SELECT *  FROM Flow_Supply_PrepurchaseDetail WHERE PKID IN (SELECT PlanID FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Supply_PurchaseBilll WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Supply_PurchasePrice WHERE (CONVERT(CHAR(10),FromDate, 120)) BETWEEN  '" + startDate + "' AND '" + endData + "'" +
                                " DELETE FROM Flow_Supply_PrepurchaseDetail WHERE PKID IN (SELECT PlanID FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO";
            return sqlCommand;
        }
        private string CreateHistoryContractData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO,ContractID INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Flow_Supply_ContractMaster SELECT *  FROM Flow_Supply_ContractMaster WHERE ContractID IN (SELECT ContractID FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Supply_ContractDetails SELECT *  FROM Flow_Supply_ContractDetails WHERE ContractID IN (SELECT ContractID FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Supply_ContractDetails WHERE ContractID IN (SELECT ContractID FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Supply_ContractMaster  WHERE ContractID IN (SELECT ContractID FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO ";
            return sqlCommand;
        }
        private string CreateHistoryMetageDetailData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " SELECT PKID  INTO #TMPMetage FROM Temp_Balance_MetageDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Temp_Balance_MetageDetailBak SELECT *  FROM Temp_Balance_MetageDetailBak WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Balance_ChangeMetageDetailTrack SELECT *  FROM Flow_Balance_ChangeMetageDetailTrack  WHERE PKID IN (SELECT PKID FROM #TMPMetage)" +
                                " INSERT INTO History_Temp_Balance_MetageDetail SELECT *  FROM Temp_Balance_MetageDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Temp_Balance_MetageDetailBak WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Balance_ChangeMetageDetailTrack WHERE PKID IN (SELECT PKID FROM #TMPMetage)" +
                                " DELETE FROM Temp_Balance_MetageDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO,#TMPMetage";
            return sqlCommand;
        }
        private string CreateHistoryTobeKillDetailData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Flow_Feed_TobeKillDetail SELECT *  FROM Flow_Feed_TobeKillDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO) " +
                                " INSERT INTO History_Flow_Feed_Pretreatment SELECT * FROM Flow_Feed_Pretreatment WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO) " +
                                " DELETE FROM Flow_Feed_TobeKillDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO) " +
                                " DELETE FROM Flow_Feed_Pretreatment WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO) " +
                                " DROP TABLE #TMPBILLNO";
            return sqlCommand;
        }
        private string CreateHistoryGrossWeightData(string startDate, string endData, string excludeBillnos)
        {
            string sqlCommand = " SELECT BILLNO INTO #TMPBILLNO FROM Flow_Feed_GrossWeightMaster WHERE (CONVERT(CHAR(10),PurchaseDate, 120)) BETWEEN '" + startDate + "' AND '" + endData + "'";
            if (!string.IsNullOrEmpty(excludeBillnos))
            {
                sqlCommand += " AND BILLNO NOT IN (" + excludeBillnos + ")";
            }
            sqlCommand += " INSERT INTO History_Flow_Feed_GrossWeightMaster SELECT *  FROM Flow_Feed_GrossWeightMaster WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Feed_GrossWeightDetail SELECT * FROM Flow_Feed_GrossWeightDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " INSERT INTO History_Flow_Feed_GrossWeightAppend SELECT * FROM Flow_Feed_GrossWeightAppend WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Feed_GrossWeightAppend WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Feed_GrossWeightDetail WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DELETE FROM Flow_Feed_GrossWeightMaster WHERE BILLNO IN (SELECT BILLNO FROM #TMPBILLNO)" +
                                " DROP TABLE #TMPBILLNO";
            return sqlCommand;
        }

        public bool CreateHistoryDatas(string startDate, string endData, string excludeBillnos)
        {
            bool isSave = true;
            YY.Data.Sql.SqlDatabase db = SqlDatabase;
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    string sqlCommand = CreateHistoryInvoiceTemplateData(startDate, endData, excludeBillnos);
                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryInvoicePlanPayforData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryInvoicePayforData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryInvoiceData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryMiddleData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryPurchaseData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryContractData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryMetageDetailData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryTobeKillDetailData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);

                    sqlCommand = CreateHistoryGrossWeightData(startDate, endData, excludeBillnos);
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                }
                catch
                {
                    isSave = false;
                    transaction.Rollback();

                }
                connection.Close();
            }
            return isSave;
        }
    }
}
