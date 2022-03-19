using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DMS
{
    internal class SQLManageData:LocalDataBase
    {

        public SQLManageData()
            : base()
        {
        }
        public DataSet CompressDataBase(string dbName, string logName)
        {
            string sqlCommand = "SET NOCOUNT ON " +
                  " DECLARE @LogicalFileName sysname, " +
                  "    @MaxMinutes INT, " +
                  "    @NewSize INT " +
                  " USE     " + dbName + "    " +                             // -- 要操作的数据库名
                  " SELECT  @LogicalFileName = '" + logName + "',  " +     // -- 日志文件名
                  "   @MaxMinutes = 10,      " + //                          -- Limit on time allowed to wrap log.
                  "   @NewSize = 1   " +   //                        -- 你想设定的日志文件的大小(M)

                  //-- Setup / initialize
                  " DECLARE @OriginalSize int " +
                  " SELECT @OriginalSize = size  " +
                  "  FROM sysfiles " +
                  " WHERE name = @LogicalFileName " +
                  " SELECT '' + db_name() + '日志压缩前大小为' +  " +
                  "  CONVERT(VARCHAR(30),@OriginalSize) + ' 8K pages or ' +  " +
                  " CONVERT(VARCHAR(30),(@OriginalSize*8/1024)) + 'MB' AS OLDSIZE " +
                  " FROM sysfiles " +
                  " WHERE name = @LogicalFileName " +

                  " CREATE TABLE DummyTrans " +
                  " (DummyColumn char (8000) not null) " +
                  " DECLARE @Counter   INT, " +
                  "  @StartTime DATETIME, " +
                  "  @TruncLog  VARCHAR(255) " +
                  " SELECT  @StartTime = GETDATE(), " +
                  " @TruncLog = 'BACKUP LOG ' + db_name() + ' WITH TRUNCATE_ONLY' " +

                  " DBCC SHRINKFILE (@LogicalFileName, @NewSize) " +
                  " EXEC (@TruncLog) " +
                //-- Wrap the log if necessary. "+
                  " WHILE     @MaxMinutes > DATEDIFF (mi, @StartTime, GETDATE())   " + // time has not expired
                  "  AND @OriginalSize = (SELECT size FROM sysfiles WHERE name = @LogicalFileName)  " +
                  "   AND (@OriginalSize * 8 /1024) > @NewSize   " +
                  "   BEGIN  " +//-- Outer loop. "+
                  "  SELECT @Counter = 0 " +
                  "  WHILE  ((@Counter < @OriginalSize / 16) AND (@Counter < 50000)) " +
                  "  BEGIN  " +//-- update
                  "  INSERT DummyTrans valueS ('Fill Log')   " +
                  "  DELETE DummyTrans " +
                  "  SELECT @Counter = @Counter + 1 " +
                  "  END    " +
                  "  EXEC (@TruncLog)   " +
                  "  END   " +
                  " SELECT ' ' + db_name() + '日志 压缩后大小为 ' + " +
                  "  CONVERT(VARCHAR(30),size) + ' 8K pages or ' +  " +
                  " CONVERT(VARCHAR(30),(size*8/1024)) + 'MB' AS NEWSIZE " +
                  " FROM sysfiles  " +
                  " WHERE name = 'dbmms_log' " +
                  " DROP TABLE DummyTrans " +
                  " SET NOCOUNT OFF ";
            DataSet tmpds = ExecuteDataSet(sqlCommand);
            return tmpds;
        }
        public DataSet GetDBTableName()
        {
            string sqlCommand = "SELECT OBJECT_NAME (id) AS TABLENAME,0 AS IsConfirm FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0";
            DataSet tmpds = ExecuteDataSet(sqlCommand);
            return tmpds;
        }
        public bool ReIndexDataBase(string tableName)
        {
            bool result = false;
            string sqlCommand = "DBCC DBREINDEX(" + tableName + ",'',90)";
            result = ExecuteNonQuery(sqlCommand);
            return result;
        }
        public bool DeleteAndCreateIndex(string tableName)
        {
            bool result = false;
            string colNames = string.Empty;
            string indexIName="IXI_"+tableName;
            string indexIIName = "IXII_" + tableName;
            string indexIIIName = "IXIII_" + tableName;
            if (!string.IsNullOrEmpty(tableName) )
            {
                switch (tableName)
                {
                    case "Temp_Balance_MetageDetail":
                        colNames = "MetageDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Temp_Balance_MetageDetailBak":
                        colNames = "MetageDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Feed_GrossWeightDetail":
                        colNames = "InputDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Feed_GrossWeightMaster":
                        colNames = "PurchaseDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Feed_TobeKillDetail":
                        colNames = " ToBeKillID DESC ";
                       // result = DeleteAndCreateClusteredIndex(tableName, indexIName, colNames);//聚集索引；
                        break;
                 
                    case "Flow_Payment_InvoiceMaster":
                        colNames = "InvoiceDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;

                    case "Flow_Payment_InvoiceDetail":
                        colNames = "InvoiceDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Payment_InvoicePayforDetail":
                        colNames = "PayforID DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Payment_InvoicePayforMaster":
                        colNames = "PayforID DESC ";
                       // result = DeleteAndCreateClusteredIndex(tableName, indexIName, colNames);//聚集索引；
                        break;
                    case "Flow_Payment_InvoicePlanPayforDetail":
                        colNames = "PlanID DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Payment_InvoicePlanPayforMaster":
                        colNames = "PlanID DESC ";
                      //  result = DeleteAndCreateClusteredIndex(tableName, indexIName, colNames);//聚集索引；
                        break;
                    case "Flow_Payment_InvoiceTemplateDetails":
                        colNames = "MergeID DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Payment_InvoiceTemplateMaster":
                        colNames = "MergeID DESC ";
                        result = DeleteAndCreateClusteredIndex(tableName, indexIName, colNames);//聚集索引；
                        break;
                    case "Flow_Supply_ContractDetails":
                        colNames = "ContractID DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Supply_ContractMaster":
                        colNames = "ContractID DESC ";
                        result = DeleteAndCreateClusteredIndex(tableName, indexIName, colNames);//聚集索引；
                        break;
                    case "Flow_Supply_PurchasePrice":
                        colNames = "FromDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Supply_PrepurchaseDetail":
                        colNames = "SupplyDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Flow_Supply_PurchaseBilll":
                        colNames = " BillNo DESC ";
                         result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                        
                    case "Middle_Balance_MetageDetail":
                        colNames = "InputDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Middle_Balance_MetageDetailBak":
                        colNames = "InputDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;
                    case "Middle_Payment_AfterKilledAnalysis":
                        colNames = "ToBeKillDate DESC ";
                        result = DeleteAndCreateNonClusteredIndex(tableName, indexIName, colNames);//非聚集索引；
                        break;


                }

            }
            return result;
        }
        #region
        /// <summary>
        /// Delete And Create Clustered Index
        /// </summary>
        /// <param name="tableName">table name </param>
        /// <param name="indexName">index name</param>
        /// <param name="colNames">column names eq:a desc,b asc,c,d ;must include unique column</param>
        private bool DeleteAndCreateClusteredIndex(string tableName, string indexName, string colNames)
        {
            string sqlCommand = "  IF EXISTS (SELECT name FROM sysindexes  " +
                                "  WHERE name = '" + indexName + "')" +
                                "  DROP INDEX " + tableName + "." + indexName + " " +
                                "  CREATE UNIQUE CLUSTERED INDEX " + indexName + "" +
                                "  ON " + tableName + " (" + colNames + ")";
            return ExecuteNonQuery(sqlCommand);
        }
        /// <summary>
        /// Delete And Create Clustered Index
        /// </summary>
        /// <param name="tableName">table name </param>
        /// <param name="indexName">index name</param>
        /// <param name="colNames">column names eq:a desc,b asc,c,d ;must not be include unique column</param>
        private bool DeleteAndCreateNonClusteredIndex(string tableName, string indexName, string colNames)
        {
            string sqlCommand = "  IF EXISTS (SELECT name FROM sysindexes  " +
                                "  WHERE name = '" + indexName + "')" +
                                "  DROP INDEX " + tableName + "." + indexName + " " +
                                "  CREATE INDEX " + indexName + "" +
                                "  ON " + tableName + " (" + colNames + ")";
            return ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}