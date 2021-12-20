using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAP.Middleware.Connector;

namespace DMS.DataClass.DataBase.Sap
{
    public class SapRfcHelper:SapRfcBase
    {
        public DataSet ExecuteSAPDataSet(string sapFunName, string innerTableName, string strucName, out string msg, params string[] paras)
        {
            DataSet ds = new DataSet();
            RfcDestination rd = null;
            RfcRepository rp = null;
            msg = string.Empty;

            try
            {
                rd = RegisterDestination();
                rp = rd.Repository;
                IRfcFunction fun = rp.CreateFunction(sapFunName);

                foreach (string para in paras)
                {
                    string[] fileds = para.Split(':');
                    fun.SetValue(fileds[0], fileds[1]);
                }

                fun.Invoke(rd);

                string[] innserTables = innerTableName.Split(',');
                foreach (string table in innserTables)
                {
                    IRfcTable sapTable = fun.GetTable(table);
                    DataTable dt = RfcTableToDataTable(sapTable);
                    ds.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                RfcSessionManager.EndContext(rd);
                UnRegisterDestination();
                rd = null;
                rp = null;
            }
            return ds;
        }

        public DataSet ExecuteSAPDataSet2(string sapFunName, string innerTableName, string strucName,out string msg, params string[] paras)
        {
            DataSet ds = new DataSet();
            RfcDestination rd = null;
            RfcRepository rp = null;
            msg = string.Empty;

            try
            {
                rd = RegisterDestination();
                rp = rd.Repository;
                IRfcFunction fun = rp.CreateFunction(sapFunName);


                foreach (string para in paras)
                {
                    string[] fileds = para.Split(':');
                    fun.SetValue(fileds[0], fileds[1]);
                }

                fun.Invoke(rd);

                string[] innserTables = innerTableName.Split(',');
                foreach (string table in innserTables)
                {
                    IRfcTable sapTable = fun.GetTable(table);
                    DataTable dt = RfcTableToDataTable2(sapTable);
                    ds.Tables.Add(dt);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                RfcSessionManager.EndContext(rd);
                UnRegisterDestination();
                rd = null;
                rp = null;
            }
            return ds;
        }

        /// <summary>
        /// 将内表转换成DataTable
        /// </summary>
        /// <param name="rfcTable">内表名称</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable RfcTableToDataTable(IRfcTable rfcTable)
        {
            DataTable dt = new DataTable();
            if (rfcTable != null)
            {
                //建立表结构
                for (int col = 0; col < rfcTable.ElementCount; col++)
                {
                    RfcElementMetadata rfcCol = rfcTable.GetElementMetadata(col);
                    string columnName = rfcCol.Name;
                    dt.Columns.Add(columnName);
                }

                for (int rx = 0; rx < rfcTable.RowCount; rx++)
                {
                    object[] dr = new object[rfcTable.ElementCount];
                    for (int cx = 0; cx < dt.Columns.Count; cx++)
                    {
                        dr[cx] = rfcTable[rx][dt.Columns[cx].ColumnName].GetValue();
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        /// <summary>
        /// 将内表转换成DataTable
        /// </summary>
        /// <param name="rfcTable">内表名称</param>
        /// <returns>返回一个DataTable</returns>
        public DataTable RfcTableToDataTable2(IRfcTable rfcTable)
        {
            DataTable dt = new DataTable();
            if (rfcTable != null)
            {
                //建立表结构
                for (int col = 0; col < rfcTable.ElementCount; col++)
                {
                    RfcElementMetadata rfcCol = rfcTable.GetElementMetadata(col);
                    string columnName = rfcCol.Name;
                    dt.Columns.Add(columnName);
                }

                for (int rx = 0; rx < rfcTable.RowCount; rx++)
                {
                    DataRow dr = dt.NewRow();
                    for (int cx = 0; cx < dt.Columns.Count; cx++)
                    {
                        dr[cx] = rfcTable[rx][dt.Columns[cx].ColumnName].GetValue();
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public IRfcTable RfcTableToDataTable(RfcRepository rd,IRfcFunction func,string sapTable, DataTable dt)
        {
            IRfcTable sapT = func.GetTable(sapTable);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    IRfcStructure structure = rd.GetStructureMetadata(sapTable).CreateStructure();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        structure[i].SetValue(dr[i]);
                    }
                    sapT.Insert(structure);
                }
            }

            return sapT;
        }

        public IRfcTable CreateRfcTable(IRfcFunction func, string sapTableName,IRfcTable sapTable)
        {
            IRfcTable sapT = func.GetTable(sapTableName);
            for (int i = 0; i < sapTable.RowCount*2; i++)
            {
                sapT.Insert();
                for (int j = 0; j < sapT.ElementCount; j++)
                { 
                }
            }

            return null;
        }

        public IRfcTable RfcTableToDataTable2(RfcRepository rd, IRfcFunction func, string sapTable, DataTable dt)
        {
            IRfcTable sapT = func.GetTable(sapTable);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sapT.Insert();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sapT.CurrentRow.SetValue(i, dr[i]);
                    }
                }
            }

            return sapT;
        }

        public IRfcTable RfcTableToDataTable3(RfcRepository rd, IRfcFunction func, string sapTable, DataTable dt)
        {
            IRfcTable sapT = func.GetTable(sapTable);
            if (dt != null && dt.Rows.Count > 0)
            {
                sapT.Insert(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    sapT.CurrentIndex = i;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sapT.CurrentRow.SetValue(j, dt.Rows[i][j]);
                    }
                }
            }

            return sapT;
        }
    }
}
