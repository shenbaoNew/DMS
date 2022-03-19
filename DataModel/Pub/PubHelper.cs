using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace DMS
{
    class PubHelper
    {
        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="conn"></param>
        public static void InitPubProperty(string conn)
        {
            string[] conns = conn.Split(';');
            if (conns.Length >= 5)
            {
                PubContext.DBServer = conns[0].Split('=')[1].Trim();
                PubContext.DBDataBase = conns[2].Split('=')[1].Trim();
                PubContext.DBLoginUser = conns[3].Split('=')[1].Trim();
                PubContext.DBPsd = conns[4].Split('=')[1].Trim();
            }
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static DataTable CreateTable(string tableName,DataColumn[] columns)
        {
            if (columns == null)
                return null;

            DataTable dt = new DataTable();
            dt.TableName = tableName;
            dt.Columns.AddRange(columns);

            return dt;
        }

        /// <summary>
        /// 过滤表
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="filterStrings"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        public static DataTable FilterDataTable(DataTable dataSource, string filterStrings, string filterValue)
        {
            DataTable table = dataSource.Copy();
            DataTable resultTable = dataSource.Clone();
            string[] filterString = filterStrings.Split(',');
            filterValue = filterValue.ToUpper();
            foreach (string str in filterString)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DataView view = table.DefaultView;
                    string operString = "";
                    if (dataSource.Columns.Contains(str))
                    {
                        switch (dataSource.Columns[str].DataType.ToString())
                        {
                            case "System.Boolean":
                            case "System.Byte":
                            case "System.SByte":
                            case "System.DateTime":
                            case "System.TimeSpan":
                            case "System.Decimal":
                            case "System.Double":
                            case "System.Single":
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.UInt16":
                            case "System.UInt32":
                            case "System.UInt64":
                                operString = str + " =" + filterValue + "";
                                break;
                            case "System.Char":
                            case "System.String":
                                operString = str + " LIKE '%" + filterValue + "%'";
                                break;
                        }
                    }
                    view.RowFilter = operString;
                    if (view.Count > 0)
                    {
                        resultTable = view.ToTable();
                        break;
                    }
                }
            }

            return resultTable;
        }

        public static void SetDoubleBuffered(DataGridView dgv, bool setting, bool autoCreateCol)
        {
            dgv.AutoGenerateColumns = autoCreateCol;
            SetDoubleBuffered(dgv, setting);
        }

        public static void SetDoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
