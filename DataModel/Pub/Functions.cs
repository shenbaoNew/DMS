using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using System.Xml;
using System.IO;
using YY.Methods;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace DMS
{
    public static class Functions
    {
        #region fromat
        public static string FormatString(object value)
        {
            return FormatString(value, string.Empty);
        }

        public static string FormatString(object value, string defaultValue)
        {
            string strValue = defaultValue;
            try
            {
                strValue = Convert.ToString(value.ToString().Trim());
            }
            catch { }
            return strValue;
        }
        public static int FormatInt(object value)
        {
            return FormatInt(value, 0);
        }
        public static int FormatInt(object value, int defaultValue)
        {
            int intValue = 0;
            try
            {
                bool result = Functions.IsNumeric(value.GetType());
                if (result)
                    intValue = Convert.ToInt32(value);
                else
                {
                    intValue = Convert.ToInt32(value.ToString());
                }
            }
            catch { }
            return intValue;
        }
        public static decimal FormatDecimal(object value)
        {
            return FormatDecimal(value, 0, 2);
        }
        public static decimal FormatDecimal(object value, int digits)
        {
            return FormatDecimal(value, 0, digits);
        }
        public static decimal FormatDecimal(object value, decimal defaultValue, int digits)
        {
            decimal intValue = defaultValue;
            try
            {
                if (value != null)
                {
                    intValue = Convert.ToDecimal(value.ToString().Trim());
                    intValue = decimal.Round(intValue, digits, MidpointRounding.AwayFromZero);
                }
                else
                {
                    intValue = decimal.Round(0, digits);
                }

            }
            catch { }
            return intValue;
        }
        public static double FormatDouble(object value)
        {
            return FormatDouble(value, 0);
        }
        public static double FormatDouble(object value, double defaultValue)
        {
            double intValue = defaultValue;
            try
            {
                intValue = Convert.ToDouble(value.ToString().Trim());
            }
            catch { }
            return intValue;
        }

        public static bool FormatBoolean(object value)
        {
            return FormatBoolean(value, false);
        }
        public static bool FormatBoolean(object value, bool defaultValue)
        {
            bool intValue = defaultValue;
            try
            {
                if (IsNumeric(value.GetType()))
                {
                    int valueInt = Convert.ToInt32(value);
                    if (valueInt > 0)
                        intValue = true;
                    else
                        intValue = false;
                }
                else
                {
                    switch (value.ToString().ToLower())
                    {
                        case "x":
                        case "1":
                        case "true":
                            intValue = true;
                            break;
                        default:
                            intValue = false;
                            break;
                    }
                }
            }
            catch
            {
                intValue = false;
            }
            return intValue;
        }
        public static DateTime FormatDateTime(object value)
        {
            DateTime defaultValue = System.DateTime.Now;
            return FormatDateTime(value, defaultValue);
        }
        public static DateTime FormatDateTime(object value, DateTime defaultValue)
        {
            DateTime intValue = defaultValue;
            try
            {
                intValue = Convert.ToDateTime(value);

            }
            catch
            {
                intValue = System.DateTime.Now;
            }
            return intValue;
        }
        public static SqlDbType FormatSqlDbType(Type theType)
        {
            System.Data.SqlClient.SqlParameter p1 = new System.Data.SqlClient.SqlParameter();
            System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            else
            {
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);

                }
                catch { } //Do Nothing
            }
            return p1.SqlDbType;
        }
        public static object ConvertTo(object o, Type type)
        {
            if (o == null || o is DBNull)
                return (o);

            if (o.GetType() == type)
                return (o);

            if (type == typeof(decimal))
                return (Convert.ToDecimal(o));

            if (type == typeof(double))
                return (Convert.ToDouble(o));

            if (type == typeof(Int16))
                return (Convert.ToInt16(o));

            if (type == typeof(Int32))
                return (Convert.ToInt32(o));

            if (type == typeof(Int64))
                return (Convert.ToInt64(o));

            if (type == typeof(Single))
                return (Convert.ToSingle(o));

            if (type == typeof(UInt16))
                return (Convert.ToUInt16(o));

            if (type == typeof(UInt32))
                return (Convert.ToUInt32(o));

            if (type == typeof(UInt64))
                return (Convert.ToUInt64(o));

            if (type == typeof(sbyte))
                return (Convert.ToSByte(o));

            if (type == typeof(byte))
                return (Convert.ToByte(o));

            if (type == typeof(bool))
                return (Convert.ToBoolean(o));

            if (type == typeof(char))
                return (Convert.ToChar(o));

            if (type == typeof(string))
                return (Convert.ToString(o));

            if (type == typeof(DateTime))
                return (Convert.ToDateTime(o));




            return (o);
        }

        public static bool IsNumeric(Type type)
        {
            return (type == typeof(byte) ||
              type == typeof(sbyte) ||
              type == typeof(short) ||
              type == typeof(int) ||
              type == typeof(long) ||
              type == typeof(ushort) ||
              type == typeof(uint) ||
              type == typeof(ulong) ||
              type == typeof(float) ||
              type == typeof(double) ||
              type == typeof(decimal));
        }

        public static string PadLeft(string str, int length)
        {
            return PadLeft(str, '0', length);
        }
        public static string PadLeft(string str, char padChar, int length)
        {
            if (str.Length < length)
                str = str.PadLeft(length, padChar);
            if (str.Length > length)
                str = str.Substring(str.Length - length, length);
            return str;
        }
        public static string PadRight(string str, int length)
        {
            return PadRight(str, '0', length);
        }
        public static string PadRight(string str,char padChar,int length)
        {
            if (str.Length < length)
                str = str.PadRight(length, padChar);
            if (str.Length >= length)
                str = str.Substring(0, length);
            return str;
        }
        #endregion

        #region 一维码校验码
        public static string ParityCode(string inputData)
        {
            int sum_even = 0;//偶数位之和
            int sum_odd = 0;//奇数位之和
            for (int i = 0; i < inputData.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum_odd += int.Parse(inputData[i].ToString());
                }
                else
                {
                    sum_even += int.Parse(inputData[i].ToString());
                }
            }
            int checkcode = (10 - (sum_even * 3 + sum_odd) % 10) % 10;//校验码
            return checkcode.ToString();
        }
        #endregion

        #region datatable

        public static DataTable RemoveColumnFromTable(DataTable dataTable, string fieldNames)
        {
            string[] fieldName = fieldNames.Split(',');
            foreach (string str in fieldName)
            {
                if (dataTable.Columns.Contains(str))
                {
                    dataTable.Columns.Remove(str);
                }
            }
            return dataTable;
        }
        public static DataTable AddColumnToTable(DataTable dataTable, string fieldName, string type)
        {
            DataColumn myDataColumn;
            if (!dataTable.Columns.Contains(fieldName))
            {
                myDataColumn = new DataColumn();
                myDataColumn.DataType = FormatType(type);
                myDataColumn.ColumnName = fieldName;
                myDataColumn.AutoIncrement = false;
                myDataColumn.ReadOnly = false;
                myDataColumn.Unique = false;
                dataTable.Columns.Add(myDataColumn);

            }
            return dataTable;
        }
        public static DataTable AddColumnToTable(DataTable dataTable, string fieldNames)
        {
            string[] fieldStrings = fieldNames.Split(';');
            foreach (string fieldStr in fieldStrings)
            {
                string[] fieldStrs = fieldStr.Split(':');
                string fieldName = fieldStrs[0];
                string fieldType = fieldStrs[1];
                DataColumn myDataColumn;
                if (!dataTable.Columns.Contains(fieldName))
                {
                    myDataColumn = new DataColumn();
                    myDataColumn.DataType = FormatType(fieldType);
                    myDataColumn.ColumnName = fieldName;
                    myDataColumn.AutoIncrement = false;
                    myDataColumn.ReadOnly = false;
                    myDataColumn.Unique = false;
                    dataTable.Columns.Add(myDataColumn);

                }
            }
            return dataTable;
        }
        public static bool IsSafeString(string str)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        /// <summary>
        /// 为DataTable 增加数据行
        /// </summary>
        /// <param name="table">目标DataTable</param>
        /// <param name="filedNames">需要填充的字段：ID,Name</param>
        /// <param name="rowValueString">字段对应的值：1:张三,2:李四</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(DataTable table, string filedNames, string rowValueString)
        {
            string[] fieldStrings = filedNames.Split(';');
            string[] rowValueStrings = rowValueString.Split(';');
            foreach (string str in rowValueStrings)
            {
                string[] rowValues = str.Split(':');
                if (fieldStrings.Length > 0 && fieldStrings.Length == rowValues.Length)
                {
                    DataRow newRow = table.NewRow();
                    for (int i = 0; i < fieldStrings.Length; i++)
                    {
                        string fieldName = fieldStrings[i];
                        string value = rowValues[i];
                        newRow[fieldName] = value;
                    }
                    table.Rows.Add(newRow);
                }
            }

            return table;
        }
        /// <summary>
        /// 创建表并填充数据
        /// </summary>
        /// <param name="columString">ID:String;Name:String;A:Int;B:Decimal</param>
        /// <param name="rowValueString">A:B;X:Y;M:N</param>
        /// <returns>返回已填充的表</returns>
        public static DataTable CreateDataTable(string columString, string rowValueString)
        {
            DataTable table = CreateDataTable(columString);
            return CreateDataTable(table, rowValueString);
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="table">需要填充数据的表</param>
        /// <param name="rowValueString">A:B;X:Y;M:N</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(DataTable table, string rowValueString)
        {
            string[] rowValueStrings = rowValueString.Split(';');
            foreach (string str in rowValueStrings)
            {
                string[] rowValues = str.Split(':');
                if (rowValues.Length > 0 && rowValues.Length == table.Columns.Count)
                {
                    DataRow newRow = table.NewRow();
                    for (int i = 0; i < rowValues.Length; i++)
                    {
                        string fieldName = table.Columns[i].ColumnName;
                        string value = rowValues[i];
                        newRow[fieldName] = value;
                    }
                    table.Rows.Add(newRow);
                }
            }

            return table;
        }
        /// <summary>
        /// "ID:String;Name:String;A:Int;B:Decimal";
        /// </summary>
        /// <param name="columString"></param>
        /// <returns></returns>
        public static DataTable CreateDataTable(string columString)
        {
            DataTable myDataTable = new DataTable();
            string[] createcolumStrings = columString.Split(';');
            foreach (string str in createcolumStrings)
            {
                int index = str.IndexOf(':');
                if (index > 0)
                {
                    string[] columStrings = str.Split(':');
                    string fieldName = columStrings[0];
                    string type = columStrings[1];
                    Functions.AddColumnToTable(myDataTable, fieldName, type);
                }
                else
                {
                    Functions.AddColumnToTable(myDataTable, str, "String");
                }
            }

            return myDataTable;
        }
        public static Type FormatType(string type)
        {
            Type resultType = System.Type.GetType("System.String");
            try
            {
                switch (type.ToLower())
                {
                    case "bool":
                        resultType = System.Type.GetType("System.Boolean");
                        break;
                    case "byte":
                        resultType = System.Type.GetType("System.Byte");
                        break;
                    case "sbyte":
                        resultType = System.Type.GetType("System.SByte");
                        break;
                    case "datetime":
                        resultType = System.Type.GetType("System.DateTime");
                        break;
                    case "timepan":
                        resultType = System.Type.GetType("System.TimeSpan");
                        break;
                    case "decimal":
                        resultType = System.Type.GetType("System.Decimal");
                        break;
                    case "double":
                        resultType = System.Type.GetType("System.Double");
                        break;
                    case "single":
                        resultType = System.Type.GetType("System.Single");
                        break;
                    case "int16":
                        resultType = System.Type.GetType("System.Int16");
                        break;
                    case "int":
                    case "int32":
                        resultType = System.Type.GetType("System.Int32");
                        break;
                    case "int64":
                        resultType = System.Type.GetType("System.Int64");
                        break;
                    case "uint16":
                        resultType = System.Type.GetType("System.UInt16");
                        break;
                    case "uint32":
                        resultType = System.Type.GetType("System.UInt32");
                        break;
                    case "uint64":
                        resultType = System.Type.GetType("System.UInt64");
                        break;
                    case "char":
                        resultType = System.Type.GetType("System.Char");
                        break;
                }
            }
            catch { }
            return resultType;
        }

        /// <summary>
        /// 判断两个DataTable中，第一个dataTable中在第二个dataTable中不存在的记录集
        /// </summary>
        /// <param name="returnTable">返回的不重复的结果集</param>
        /// <param name="table1">即将导入的数据集</param>
        /// <param name="table2">数据库中的数据集</param>
        /// <param name="fieldsStr">字段名</param>
        /// <returns></returns>
        public static DataTable ComPareDataTable(DataTable table1, DataTable table2, string fieldsStr)
        {
            try
            {
                DataTable returnTable = new DataTable();
                returnTable = table1.Clone();

                //for循环将数据库中的table2的每行数据转换为一个字符串，保存的HashTable中
                Hashtable hashtable = new Hashtable();
                DataRow[] dataRows = table2.Select("");

                string[] fieldArr = fieldsStr.Split(',');

                foreach (DataRow row in dataRows)
                {
                    string rowStr = "";
                    for (int i = 0; i < fieldArr.Length; i++)
                    {
                        Object obj = row[fieldArr[i]];
                        if (!String.IsNullOrEmpty(obj.ToString()))
                        {
                            rowStr += obj.ToString();
                        }
                    }
                    hashtable.Add(rowStr, "");
                }

                //将要导入的DataTable,将每一行数据转换为字符串之后，在hashTable中找是否存在这个key,存在的加入返回的DataTable中，反之不加入。
                DataRow[] dataRows1 = table1.Select();
                foreach (DataRow row in dataRows1)
                {
                    string rowStr1 = "";
                    for (int i = 0; i < fieldArr.Length; i++)
                    {
                        Object obj = row[fieldArr[i]];
                        if (!String.IsNullOrEmpty(obj.ToString()))
                        {
                            rowStr1 += obj.ToString();
                        }
                    }
                    if (!hashtable.ContainsKey(rowStr1))
                    {
                        returnTable.Rows.Add(row.ItemArray);
                    }
                }
                return returnTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常" + ex.Message);
                return null;
            }
        }
        #endregion

        #region DoubleBuffered
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
        public static void SetDoubleBuffered(DevComponents.DotNetBar.Controls.DataGridViewX dgv, bool setting, bool autoCreateCol)
        {
            dgv.AutoGenerateColumns = autoCreateCol;
            SetDoubleBuffered(dgv, setting);
        }
        public static void SetDoubleBuffered(DevComponents.DotNetBar.Controls.DataGridViewX dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }
        #endregion

        #region BalanceTable
        private static Hashtable BalanceTable = new Hashtable();
        public static YY.Methods.SerialPortHelper GetBalanceTable(string key)
        {
            YY.Methods.SerialPortHelper banlance = null;
            if (BalanceTable.ContainsKey(key))
            {
                try
                {
                    if (BalanceTable.Count > 0)
                    {
                        banlance = (YY.Methods.SerialPortHelper)BalanceTable[key];

                    }
                }
                catch
                {

                }
            }

            return banlance;
        }
        public static void SetBalanceTable(string key, YY.Methods.SerialPortHelper banlance)
        {
            if (banlance != null)
            {
                if (!BalanceTable.ContainsKey(key))
                {
                    try
                    {
                        BalanceTable.Add(key, banlance);
                    }
                    catch
                    {

                    }
                }
            }

        }
        #endregion

        public static void CopyFileEmbeddedResource(string fileName)
        {
            string filePath = Application.StartupPath + "\\" + fileName + "";
            if (!File.Exists(filePath))
            {
                CopyBinaryEmbeddedResource(fileName, filePath);
            }
            else
            {
                FileInfo fi = new FileInfo(filePath);
                long d = fi.Length;
                if (fi.Length != 818526)
                    CopyBinaryEmbeddedResource(fileName, filePath);

            }
        }
        private static void CopyEmbeddedResource(string resource, string filepath)
        {
            // Copy embedded uml.dtd to same directory as xmi file.
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file = thisExe.GetManifestResourceStream(resource);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(file);
            doc.Save(filepath);
        }
        private static Stream LoadStream(string fileName)
        {
            ResourceUtils helper = new ResourceUtils("MMS", System.Reflection.Assembly.GetExecutingAssembly());
            helper.DefaultBitmapNamespace = "Resources";
            return helper.LoadStream(fileName);
        }
        private static void CopyBinaryEmbeddedResource(string resource, string filepath)
        {
            try
            {
                System.IO.Stream stream = LoadStream(resource);
                if (stream != null)
                {
                    FileStream fs = File.Create(filepath);

                    int numBytesToRead = (int)stream.Length;
                    int numBytesRead = 0;
                    byte[] bytes = new byte[numBytesToRead];

                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = stream.Read(bytes, numBytesRead, numBytesToRead);
                        // The end of the file is reached.
                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                        fs.Write(bytes, 0, n);
                    }
                    stream.Close();
                    fs.Close();
                }
            }
            catch
            {
                return;
            }
        }

        internal static ScreenInformation ScreenFromPoint(Point pScreen)
        {
            if (m_Screens.Count == 0)
                RefreshScreens();
            //foreach (System.Windows.Forms.Screen s in System.Windows.Forms.Screen.AllScreens) 
            foreach (ScreenInformation s in m_Screens)
            {
                if (s.Bounds.Contains(pScreen))
                {
                    return s;
                }
            }

            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.FromPoint(pScreen);
            if (scr != null)
                return new ScreenInformation(scr.Bounds, scr.WorkingArea);

            return null;
        }
        internal class ScreenInformation
        {
            public Rectangle Bounds = Rectangle.Empty;
            public Rectangle WorkingArea = Rectangle.Empty;
            public ScreenInformation(Rectangle bounds, Rectangle workingarea)
            {
                this.Bounds = bounds;
                this.WorkingArea = workingarea;
            }
        }
        internal static ScreenInformation ScreenFromControl(System.Windows.Forms.Control control)
        {
            Rectangle r;
            if (control.Parent != null)
            {
                Point screenLocation = control.PointToScreen(control.Location);
                r = new Rectangle(screenLocation, control.Size);
            }
            else
                r = new Rectangle(control.Location, control.Size);
            if (m_Screens.Count == 0)
                RefreshScreens();
            //foreach (System.Windows.Forms.Screen s in System.Windows.Forms.Screen.AllScreens)
            foreach (ScreenInformation s in m_Screens)
            {
                //if(s.Bounds.Contains(r)) 
                if (s.Bounds.Contains(r))
                {
                    return s;
                }
            }
            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.FromControl(control);
            if (scr != null)
                return new ScreenInformation(scr.Bounds, scr.WorkingArea);
            return null;
        }
        private static ArrayList m_Screens = new ArrayList(2);
        public static void RefreshScreens()
        {
            m_Screens.Clear();
            foreach (System.Windows.Forms.Screen s in System.Windows.Forms.Screen.AllScreens)
                m_Screens.Add(new ScreenInformation(s.Bounds, s.WorkingArea));
        }
        public static void CreateTreeColumn(DevComponents.AdvTree.AdvTree tree, string colName, string caption, string width)
        {
            string[] colNames = colName.Split(',');
            string[] captions = caption.Split(',');
            string[] widths = width.Split(',');
            for (int i = 0; i < colNames.Length; i++)
            {
                DevComponents.AdvTree.ColumnHeader col = new DevComponents.AdvTree.ColumnHeader(captions[i]);
                col.Name = "col" + colNames[i];
                col.DataFieldName = colNames[i];

                col.TextAlign = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                col.Width.Absolute = Convert.ToInt32(widths[i]);
                tree.Columns.Add(col);
            }
        }

        #region CreatGroupTree
        public static void CreatGroupTree(DevComponents.AdvTree.AdvTree grid, DataTable table, string groupFiledNames, string detailFieldNames, int detailColWitdh)
        {
            CreatGroupTree(grid, table, groupFiledNames, "", detailFieldNames, "", detailColWitdh);
        }
        public static void CreatGroupTree(DevComponents.AdvTree.AdvTree grid, DataTable table, string groupFiledNames, string groupCaptions, string detailFieldNames, string detailCaptions, int detailColWitdh)
        {
            // grid.ColumnsVisible = false;
            grid.BeginUpdate();
            grid.Nodes.Clear();
            grid.Columns.Clear();
            grid.NodesColumnsBackgroundStyle = GetColumnStyle();
            string[] groupFiledNameArray = groupFiledNames.Split(',');
            string[] groupCaptionArray = groupCaptions.Split(',');
            string[] detailFieldNameArray = detailFieldNames.Split(',');
            string[] detailCaptionArry = detailCaptions.Split(',');
            if (groupFiledNameArray.Length < groupCaptionArray.Length || detailFieldNameArray.Length < detailCaptionArry.Length)
                return;
            int groupWidth = Convert.ToInt32(detailFieldNameArray.Length * detailColWitdh / groupFiledNameArray.Length);
            for (int i = 0; i < groupFiledNameArray.Length; i++)
            {
                DevComponents.AdvTree.ColumnHeader header = new DevComponents.AdvTree.ColumnHeader();
                header.Name = groupFiledNameArray[i] + i.ToString();
                if (i < groupCaptionArray.Length)
                {
                    string caption = groupCaptionArray[i];
                    if (string.IsNullOrEmpty(caption))
                        header.Text = groupFiledNameArray[i];
                    else
                        header.Text = caption;
                }
                else
                    header.Text = groupFiledNameArray[i];
                header.TextAlign = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                if (i == groupFiledNameArray.Length - 1)
                    header.Width.Absolute = (detailFieldNameArray.Length * detailColWitdh - (groupFiledNameArray.Length - 1) * groupWidth) + grid.ExpandWidth + 10;
                else
                    header.Width.Absolute = groupWidth;
                grid.Columns.Add(header);

            }
            DataTable groupTable = YY.Methods.DataHelper.SelectDistinct("table", table, groupFiledNameArray);
            DataView sourceView = table.Copy().DefaultView;
            string sourceViewFilter = string.Empty;
            int rowIndex = 0;
            foreach (DataRow row in groupTable.Rows)
            {
                DevComponents.AdvTree.Node node = null;
                sourceView.RowFilter = GetRowFilterString(row, groupFiledNameArray);
                if (sourceView.Count > 0)
                {
                    //if (rowIndex == 0)
                    //{
                    //    DevComponents.AdvTree.Node titleNode = new DevComponents.AdvTree.Node();
                    //    titleNode.Style = GetTitleNodeStyle();
                    //    titleNode.Selectable = false;
                    //    titleNode.NodesIndent = -25;
                    //    titleNode.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden;
                    //    titleNode.Cells.Clear();
                    //    for (int i = 0; i < groupFiledNameArray.Length; i++)
                    //    {
                    //        DevComponents.AdvTree.Cell header = new DevComponents.AdvTree.Cell();
                    //        header.Name = groupFiledNameArray[i] + i.ToString();
                    //        if (i < groupCaptionArray.Length)
                    //        {
                    //            string caption = groupCaptionArray[i];
                    //            if (string.IsNullOrEmpty(caption))
                    //                header.Text = groupFiledNameArray[i];
                    //            else
                    //                header.Text = caption;
                    //        }
                    //        else
                    //            header.Text = groupFiledNameArray[i];
                    //        titleNode.Cells.Add(header);
                    //    }
                    //    grid.Nodes.Add(titleNode);
                    //}

                    node = new DevComponents.AdvTree.Node();
                    node.Style = GetGroupNodeStyle();
                    node.Selectable = false;
                    node.NodesIndent = -25;
                    node.Cells.Clear();
                    for (int i = 0; i < groupFiledNameArray.Length; i++)
                    {
                        string cellText = Functions.FormatString(row[groupFiledNameArray[i]]);
                        if (i == 0)
                            cellText += "  <font color=\"Red\"><b>(" + sourceView.Count.ToString() + ")</b></font>";
                        DevComponents.AdvTree.Cell cell = new DevComponents.AdvTree.Cell(cellText);
                        node.Cells.Add(cell);
                    }

                    for (int i = 0; i < detailFieldNameArray.Length; i++)
                    {
                        DevComponents.AdvTree.ColumnHeader header = new DevComponents.AdvTree.ColumnHeader();
                        header.Name = detailFieldNameArray[i] + i.ToString();
                        if (i < detailCaptionArry.Length)
                        {
                            string caption = detailCaptionArry[i];
                            if (string.IsNullOrEmpty(caption))
                                header.Text = detailFieldNameArray[i];
                            else
                                header.Text = caption;
                        }
                        else
                            header.Text = detailFieldNameArray[i];
                        header.TextAlign = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                        header.Width.Absolute = detailColWitdh;

                        //if (rowIndex > 0)
                        node.NodesColumnsHeaderVisible = false;
                        node.NodesColumns.Add(header);
                    }
                    int childRow = 0;
                    foreach (DataRow subRow in sourceView.ToTable().Rows)
                    {
                        if (rowIndex == 0 && childRow == 0)
                        {
                            DevComponents.AdvTree.Node titleNode = new DevComponents.AdvTree.Node();
                            titleNode.Style = GetTitleNodeStyle();
                            titleNode.Selectable = false;
                            titleNode.NodesIndent = -25;
                            titleNode.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden;
                            titleNode.Cells.Clear();
                            for (int i = 0; i < detailFieldNameArray.Length; i++)
                            {
                                DevComponents.AdvTree.Cell header = new DevComponents.AdvTree.Cell();
                                header.Name = detailFieldNameArray[i] + i.ToString();
                                if (i < detailCaptionArry.Length)
                                {
                                    string caption = detailCaptionArry[i];
                                    if (string.IsNullOrEmpty(caption))
                                        header.Text = detailFieldNameArray[i];
                                    else
                                        header.Text = caption;
                                }
                                else
                                    header.Text = detailFieldNameArray[i];
                                titleNode.Cells.Add(header);
                            }
                            node.Nodes.Add(titleNode);
                        }

                        DevComponents.AdvTree.Node subNode = new DevComponents.AdvTree.Node();
                        subNode.Cells.Clear();
                        subNode.Style = GetChildNodeStyle();
                        for (int i = 0; i < detailFieldNameArray.Length; i++)
                        {
                            string cellText = Functions.FormatString(subRow[detailFieldNameArray[i]]);
                            DevComponents.AdvTree.Cell subCell = new DevComponents.AdvTree.Cell(cellText);
                            subNode.Cells.Add(subCell);
                        }
                        node.Nodes.Add(subNode);
                        childRow++;
                    }
                }
                if (node != null)
                    grid.Nodes.Add(node);
                rowIndex++;
            }
            grid.ExpandAll();
            grid.EndUpdate();
        }

        private static string GetRowFilterString(DataRow row, string[] groupFiledNameArray)
        {

            string rowFilter = string.Empty;
            for (int i = 0; i < groupFiledNameArray.Length; i++)
            {
                Type valueType = row[groupFiledNameArray[i]].GetType();
                string typeName = valueType.FullName.ToLower();
                switch (typeName)
                {
                    case "system.string":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        break;
                    case "system.datetime":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        break;
                    case "system.boolean":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        break;
                    case "system.int16":
                    case "system.int32":
                    case "system.int64":
                    case "system.byte":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "=" + Functions.FormatInt(row[groupFiledNameArray[i]]) + "";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "=" + Functions.FormatInt(row[groupFiledNameArray[i]]) + "";
                        }
                        break;
                    case "system.decimal":
                    case "system.double":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "=" + Functions.FormatDecimal(row[groupFiledNameArray[i]]) + "";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "=" + Functions.FormatDecimal(row[groupFiledNameArray[i]]) + "";
                        }
                        break;
                    case "system.dbnull":
                        if (string.IsNullOrEmpty(rowFilter))
                        {
                            rowFilter = groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        else
                        {
                            rowFilter += " AND " + groupFiledNameArray[i] + "='" + Functions.FormatString(row[groupFiledNameArray[i]]) + "'";
                        }
                        break;
                    default:
                        break;
                }
            }
            return rowFilter;
        }
        private static DevComponents.DotNetBar.ElementStyle GetTitleNodeStyle()
        {
            DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
            elementStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            elementStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            elementStyle.BackColorGradientAngle = 90;
            elementStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            elementStyle.BorderBottomWidth = 0;
            elementStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(181)))));
            elementStyle.BorderLeftWidth = 0;
            elementStyle.BorderRightWidth = 0;
            elementStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            elementStyle.BorderTopWidth = 0;
            elementStyle.Border = DevComponents.DotNetBar.eStyleBorderType.Solid;
            elementStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            elementStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            elementStyle.Class = "";
            elementStyle.CornerDiameter = 3;
            elementStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyle.Description = "Silver";

            elementStyle.Name = "elementStyle";
            elementStyle.MarginBottom = -1;
            elementStyle.PaddingBottom = 1;
            elementStyle.PaddingLeft = 1;
            elementStyle.PaddingRight = 1;
            elementStyle.PaddingTop = 1;
            elementStyle.TextColor = System.Drawing.Color.Black;

            return elementStyle;
        }
        private static DevComponents.DotNetBar.ElementStyle GetGroupNodeStyle()
        {
            DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
            elementStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
            elementStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(206)))), ((int)(((byte)(216)))));
            elementStyle.BackColorGradientAngle = 90;
            elementStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            elementStyle.BorderBottomWidth = 1;
            elementStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            elementStyle.BorderLeftWidth = 1;
            elementStyle.BorderRightWidth = 1;
            elementStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            elementStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            elementStyle.BorderTopWidth = 1;
            elementStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            elementStyle.Class = "";
            elementStyle.CornerDiameter = 3;
            elementStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyle.Description = "Silver";

            elementStyle.Name = "elementStyle";
            elementStyle.PaddingBottom = 2;
            elementStyle.PaddingLeft = 2;
            elementStyle.PaddingRight = 2;
            elementStyle.PaddingTop = 2;
            elementStyle.TextColor = System.Drawing.Color.Black;

            return elementStyle;
        }
        private static DevComponents.DotNetBar.ElementStyle GetColumnStyle()
        {
            DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
            elementStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            elementStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            elementStyle.BackColorGradientAngle = 90;
            elementStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            elementStyle.BorderBottomColor = System.Drawing.SystemColors.Window;
            elementStyle.BorderBottomWidth = 1;
            elementStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            elementStyle.BorderLeftWidth = 1;
            elementStyle.BorderRightWidth = 1;
            elementStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            elementStyle.BorderTopColor = System.Drawing.SystemColors.Window;
            elementStyle.BorderTopWidth = 1;
            elementStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            elementStyle.Class = "";
            elementStyle.CornerDiameter = 4;
            elementStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyle.Description = "Silver";
            elementStyle.Name = "elementStyle9";
            elementStyle.PaddingBottom = 2;
            elementStyle.PaddingLeft = 2;
            elementStyle.PaddingRight = 2;
            elementStyle.PaddingTop = 2;
            elementStyle.TextColor = System.Drawing.Color.Black;

            return elementStyle;
        }
        private static DevComponents.DotNetBar.ElementStyle GetChildNodeStyle()
        {
            DevComponents.DotNetBar.ElementStyle elementStyle = new DevComponents.DotNetBar.ElementStyle();
            elementStyle.Class = "";
            elementStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyle.Name = "elementStyle10";
            elementStyle.PaddingBottom = 1;
            elementStyle.PaddingLeft = 1;
            elementStyle.PaddingRight = 1;
            elementStyle.PaddingTop = 1;
            return elementStyle;
        }
        #endregion

        #region FilterDataTable
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dataSource">需要过滤的表</param>
        ///// <param name="filterStrings">过滤的字段</param>
        ///// <param name="filterValue">字段对应的值</param>
        ///// <returns></returns>
        //public static DataTable FilterDataTable(DataTable dataSource, string filterStrings, string filterValue)
        //{
        //    DataRowView resultRow;
        //    return FilterDataTable(dataSource, filterStrings, filterValue, out resultRow);

        //}
        public static void FilteSource(BindingSource popuSource, string fieldNames, object filterValue)
        {
            popuSource.Filter = string.Empty;
            if (popuSource.Count > 0)
            {
                string[] fieldNameArray = fieldNames.Split(',');
                foreach (string fieldName in fieldNameArray)
                {
                    popuSource.Filter = string.Empty;
                    if (!string.IsNullOrEmpty(fieldName))
                    {
                        if (popuSource.Count > 0)
                        {
                            object dataItem = popuSource.List[0];
                            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(dataItem);
                            PropertyDescriptor propDesc = props.Find(fieldName, true);
                            try
                            {
                                string filterType = "{0}={1}";
                                if (propDesc.PropertyType.FullName == "System.String")
                                    filterType = "{0} like '%{1}%'";
                                popuSource.Filter = string.Format(filterType, propDesc.Name, filterValue);
                                if (popuSource.Count > 0)
                                {
                                    break;
                                }
                            }
                            catch
                            { }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 过滤DataTable
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
                #region //create filter string
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
                    else
                    {
                        continue;
                    }

                }
                #endregion
            }

            return resultTable;
        }
        public static DataTable FilterDataTable(DataTable resultTable, string filterStrings, string filterValue, out DataRow resultRow, int outFlag)
        {
            resultRow = null;
            DataTable table = FilterDataTable(resultTable.Copy(), filterStrings, filterValue);
            if (table != null)
            {
                int rowCount = table.Rows.Count;
                if (rowCount > 0)
                {
                    if (rowCount == 1)
                    {
                        resultRow = table.Rows[0];
                    }
                    else if (outFlag == 1)//只要有过滤结果出来就显示第一条记录。
                    {
                        resultRow = table.Rows[0];
                    }
                }
            }

            return table;
        }
        #endregion

        #region GetBillNOSQLCommand
        public static string GetBillNOSQLCommand(int billType, int companyId)
        {
            return GetBillNOSQLCommand(billType, companyId, 3);
        }
        public static string GetBillNOSQLCommand(int billType, int companyId,int length)
        {
            string lengthStr = PadLeft("1", length);
            string sqlCommand = " DECLARE @NO CHAR(12),@XCOUNT DECIMAL ,@date datetime " +
                                 " BEGIN " +
                                        " SET NOCOUNT ON; " +

                                        " SELECT @NO=BillNO,@date=CreateDate FROM  Base_System_CreateBillNo WHERE CompanyID=" + companyId + "  AND BillType=" + billType + " " +
                                        " IF @NO=''or @NO is null " +
                                        " BEGIN  " +
                                        " SELECT @NO=Convert(CHAR(8),getdate(),112)+'" + lengthStr + "' " +
                                        " INSERT INTO Base_System_CreateBillNo(BillNO,CompanyID,CreateDate,BillType) VALUES (@NO," + companyId + ",Convert(CHAR(8),getdate(),112)," + billType + ") " +
                                        " END " +
                                        " ELSE " +
                                        " IF (Convert(CHAR(8),@date,112)=Convert(CHAR(8),getdate(),112)) " +
                                        " BEGIN " +
                                        " SELECT @XCOUNT=CAST(@NO as decimal)+1; " +
                                        " UPDATE Base_System_CreateBillNo SET BillNO=@XCOUNT WHERE CompanyID=" + companyId + "  AND BillType=" + billType + " " +
                                        " END " +
                                        " ELSE " +
                                        " BEGIN " +
                                        " SELECT @NO=Convert(CHAR(8),getdate(),112)+'" + lengthStr + "' " +
                                        " UPDATE Base_System_CreateBillNo SET BillNO=@NO,CreateDate=Convert(CHAR(8),getdate(),112) WHERE CompanyID=" + companyId + "  AND BillType=" + billType + " " +
                                        " END " +
                                        " SELECT RTRIM(BillNO) AS BillNO FROM  Base_System_CreateBillNo WHERE CompanyID=" + companyId + "  AND BillType=" + billType + " " +
                                " END";
            return sqlCommand;
        }
        public static string GetRowNOSQLCommand(int billType,string billNo, int companyId)
        {
            string whereStr = "";
            if (!string.IsNullOrEmpty(billNo))
                whereStr = " AND BillNo='" + billNo + "' ";
            string sqlCommand = " DECLARE @NO INT,@XCOUNT DECIMAL ,@date datetime " +
                                 " BEGIN " +
                                        " SET NOCOUNT ON; " +
                                        " SELECT @NO=RowNO,@date=CreateDate FROM  Base_System_CreateRowNo WHERE BillType=" + billType + whereStr + "  AND CompanyID=" + companyId + "   " +
                                        " IF  @NO is null " +
                                        " BEGIN  " +
                                        " SELECT @NO=1 " +
                                        " INSERT INTO Base_System_CreateRowNo(BillNo,RowNO,CompanyID,CreateDate,BillType) VALUES ('" + billNo + "',@NO," + companyId + ",Convert(CHAR(8),getdate(),112)," + billType + ") " +
                                        " END " +
                                        " ELSE " +
                                        " IF (Convert(CHAR(8),@date,112)=Convert(CHAR(8),getdate(),112)) " +
                                        " BEGIN " +
                                        " UPDATE Base_System_CreateRowNo SET RowNO=ISNULL(@NO,0)+1 WHERE BillType=" + billType  + whereStr + " AND  CompanyID=" + companyId + "   " +
                                        " END " +
                                        " ELSE " +
                                        " BEGIN " +
                                        " SELECT @NO=1 " +
                                        " UPDATE Base_System_CreateRowNo SET RowNO=@NO,CreateDate=Convert(CHAR(8),getdate(),112) WHERE BillType=" + billType + whereStr + " AND CompanyID=" + companyId + "    " +
                                        " END " +
                                        " SELECT RowNO FROM  Base_System_CreateRowNo WHERE BillType=" + billType + whereStr + " AND  CompanyID=" + companyId + "  " +
                                " END";
            return sqlCommand;
        }
        #endregion

        #region GetBillNOSQLCommand
        /// <summary>
        /// 周期计算
        /// </summary>
        /// <param name="periodType">类型</param>
        /// <param name="multiple">时间间隔的倍数</param>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public static string GetDatePeriodSQLCommand(int periodType, int multiple, int companyId)
        {
            string sqlCommand = " DECLARE @Interval INT,@Period INT ,@STARTDATE DATETIME ,@ENDDATE DATETIME  " +
                                " SELECT @STARTDATE=STARTDATE,@ENDDATE=ENDDATE,@Period=DATEDIFF(n,@ENDDATE,@STARTDATE),@Interval=Interval FROM  Base_System_DatePeriods WHERE PeriodType=" + periodType + " AND CompanyID=" + companyId + " " +
                                " IF @STARTDATE='' OR @STARTDATE IS NULL BEGIN " +
                                " INSERT INTO Base_System_DatePeriods (PeriodType,StartDate,EndDate,Interval,Disabled,CompanyID) VALUES (" + periodType + ",GETDATE(),GETDATE(),30,0," + companyId + ") END ELSE  " +
                                " IF @Period>" + multiple + "*@Interval BEGIN   " +
                                " UPDATE Base_System_DatePeriods SET EndDate=GETDATE() WHERE PeriodType=" + periodType + " AND Disabled=0 AND CompanyID=" + companyId + "   " +
                                " END ELSE BEGIN " +
                                " UPDATE Base_System_DatePeriods SET StartDate=GETDATE() WHERE PeriodType=" + periodType + " AND Disabled=0 AND CompanyID=" + companyId + " " +
                                " END";
            return sqlCommand;
        }
        #endregion

        #region SetColumnsColor
        public static void SetReadOnlyColumnsColor(DevComponents.DotNetBar.Controls.DataGridViewX grid)
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            style.BackColor = grid.Style.BackColor1.Color;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible && col.ReadOnly)
                    col.DefaultCellStyle = style;
            }
        }
        public static void SetColumnsColor(DevComponents.DotNetBar.Controls.DataGridViewX grid, string colNames)
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            style.BackColor = grid.Style.BackColor1.Color;
            string[] cols = colNames.Split(',');
            foreach (string str in cols)
            {
                grid.Columns[str].DefaultCellStyle = style;

            }
        }
        public static void SetColumnsColor(DataGridViewColumn col)
        {
            System.Windows.Forms.DataGridViewCellStyle style = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.Controls.DataGridViewX grid = col.DataGridView as DevComponents.DotNetBar.Controls.DataGridViewX;
            style.BackColor = grid.Style.BackColor1.Color;
            col.DefaultCellStyle = style;
        }
        #endregion

        #region CreateTitleText
        public static string CreateCurrentTitleText(string currentWeightTypeName, string currentLevelName, int killOrder, decimal currentAmount, decimal currentGrossWeight, decimal currentDeductWeight,string unitCode)
        {
            string msg = string.Empty;

            try
            {
                if (currentWeightTypeName != string.Empty)
                {
                    if (string.Empty != currentLevelName)
                    {
                        msg = "\t\t" + currentWeightTypeName + "  序号 " + killOrder + "  等级 " + currentLevelName + "  数量 " + currentAmount + "  重量 " + currentGrossWeight + "   ";

                    }
                    else
                    {
                        msg = "\t\t" + currentWeightTypeName + "  序号 " + killOrder + "  数量 " + currentAmount + "  重量 " + currentGrossWeight + "   ";

                    }

                    if (currentDeductWeight != 0)
                    {
                        msg += "  总扣重 " + currentDeductWeight + "   ";
                    }
                    if (!string.IsNullOrEmpty(unitCode))
                    {
                        msg += " [" + unitCode + "]";
                    }
                }
            }
            catch
            {

            }

            return msg;
        }
        public static string CreateCurrentTitleText(string currentWeightTypeName, string currentLevelName, decimal currentAmount, decimal currentGrossWeight, decimal tareWeight)
        {
            string msg = string.Empty;

            try
            {
                if (currentWeightTypeName != string.Empty)
                {
                    if (string.Empty != currentLevelName)
                    {
                        msg = "\t\t" + currentWeightTypeName + "  等级 " + currentLevelName + "  数量 " + currentAmount + "  重量 " + currentGrossWeight + "   皮重 " + tareWeight;

                    }
                    else
                    {
                        msg = "\t\t" + currentWeightTypeName + "  数量 " + currentAmount + "  重量 " + currentGrossWeight + "   皮重 " + tareWeight;

                    }

                }
            }
            catch
            {

            }

            return msg;
        }
        public static string CreateCurrentTitleText(string currentWeightTypeName, string currentLevelName, decimal currentAmount, decimal currentGrossWeight, decimal tareWeight,decimal wareHousingWeight)
        {
            string msg = CreateCurrentTitleText(currentWeightTypeName, currentLevelName, currentAmount, currentGrossWeight, tareWeight);
            if (wareHousingWeight > 0)
                msg += "\t\t入库重：" + wareHousingWeight;
            return msg;
        }
        public static string CreateSecondScreenTitleText(string productName, decimal currentAmount, decimal currentGrossWeight, decimal currentDeductWeight,decimal wareHousingWeight)
        {
            string msg = CreateSecondScreenTitleText(productName, currentAmount, currentGrossWeight, currentDeductWeight);
            if (wareHousingWeight>0)
                msg += "\t\t入库重：" + wareHousingWeight;
            return msg;
        }
        public static string CreateSecondScreenTitleText(string productName, decimal currentAmount, decimal currentGrossWeight, decimal currentDeductWeight)
        {
            string msg = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(productName))
                    msg += "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                else
                    msg += "\t\n" + productName + "\t\n" + currentAmount + "\t\n" + currentGrossWeight;

                if (currentDeductWeight != 0)
                    msg += "\t\n" + currentDeductWeight;
            }
            catch
            {

            }
            return msg;
        }
        public static string CreateSecondScreenTitleText(string pigTypeName, string currentLevelName, decimal currentAmount, decimal currentGrossWeight, decimal currentDeductWeight)
        {
            string msg = string.Empty;

            try
            {
                if (pigTypeName != string.Empty)
                {
                    msg = pigTypeName;
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    if (string.IsNullOrEmpty(currentLevelName))
                        msg += "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                    else
                        msg += "\t\n" + currentLevelName + "\t\n" + currentAmount + "\t\n" + currentGrossWeight;

                    if (currentDeductWeight != 0)
                        msg += "\t\n" + currentDeductWeight;
                }
                else
                {
                    if (string.IsNullOrEmpty(currentLevelName))
                        msg = currentAmount + "\t\n" + currentGrossWeight;
                    else
                        msg = currentLevelName + "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                    if (currentDeductWeight != 0)
                        msg += "\t\n" + currentDeductWeight;
                }
            }
            catch
            {

            }
            return msg;
        }

        public static string CreateSecondScreenTitleText(string pigTypeName, string currentLevelName, decimal currentAmount, decimal currentGrossWeight)
        {
            string msg = string.Empty;

            try
            {
                if (pigTypeName != string.Empty)
                {
                    msg = pigTypeName;
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    if (string.IsNullOrEmpty(currentLevelName))
                        msg += "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                    else
                        msg += "\t\n" + currentLevelName + "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                }
                else
                {
                    if (string.IsNullOrEmpty(currentLevelName))
                        msg = currentAmount + "\t\n" + currentGrossWeight;
                    else
                        msg = currentLevelName + "\t\n" + currentAmount + "\t\n" + currentGrossWeight;
                }
            }
            catch
            {

            }
            return msg;
        }
        #endregion

        #region
        public static void CreateSoapXML(string moduleIds)
        {

            MemoryStream st = new MemoryStream(1024);//分配空间  
            XmlTextWriter tr = new XmlTextWriter(st, Encoding.UTF8);
            tr.WriteStartDocument();
            tr.WriteStartElement("soap", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            tr.WriteStartElement("xmlns", "soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            tr.WriteStartElement("xmlns", "demo", "http://demo.yrlan.com");
            //tr.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            //tr.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
            //tr.WriteAttributeString("xmlns", "soap", null, "http://schemas.xmlsoap.org/soap/envelope/");
            tr.WriteStartElement("Header", "http://schemas.xmlsoap.org/soap/envelope/");
            tr.WriteStartElement(null, "AuthInfo", "http://tempuri.org/");
            tr.WriteElementString("UserName", "admin");
            tr.WriteElementString("PassWord", "123");
            tr.WriteEndElement();
            tr.WriteEndElement();
            tr.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");
            tr.WriteStartElement(null, "GetAccount", "http://tempuri.org/");
            tr.WriteElementString("acctID", "1");
            tr.WriteEndElement();
            tr.WriteEndElement();
            tr.WriteEndDocument();
        }
        #endregion

        public static DataSet CreateDataRelation(DataSet dataSet, string relationName, string tableNames, string keyFields)
        {
            DataColumn parentCol = dataSet.Tables["Customers"].Columns["CustomerID"];
            DataColumn childCol = dataSet.Tables["Orders"].Columns["CustomerID"];
            DataRelation relation =
              new DataRelation("FK_Customers_Orders", parentCol, childCol);  // 建立主从关系
            dataSet.Relations.Add(relation);  // 添加主从关系到数据集中

            BindingSource bs_Customers = new BindingSource();  // 创建绑定源
            BindingSource bs_Orders = new BindingSource();

            bs_Customers.DataSource = dataSet;
            bs_Customers.DataMember = "Customers";  // 绑定到数据源——主表

            bs_Orders.DataSource = bs_Customers;
            bs_Orders.DataMember = "FK_Customers_Orders";  // 绑定到关系——从表，注意：区分大小写

            return dataSet;
        }
        public static bool IsVehicleNumber(string strnum)
        {
            System.Text.RegularExpressions.Regex reg1
            = new System.Text.RegularExpressions.Regex(@"^[(\u4e00-\u9fa5)|(a-za-z)]{1}[a-za-z]{1}[a-za-z_0-9]{4,6}[a-za-z_0-9_\u4e00-\u9fa5]$");
            return reg1.IsMatch(strnum);
        }

        #region CreateMutiHeader
        public static void CreateMutiHeader(DevComponents.DotNetBar.Controls.DataGridViewX grid, int startIndex)
        {

            if (grid.Columns.Count <= 1)
                return;
            int colCount = grid.Columns.Count;
            System.Windows.Forms.DataGridViewColumn col;
            for (int i = 0; i < startIndex; i++)
            {
                col = grid.Columns[i];
                DevComponents.DotNetBar.Controls.MutiHeaderCell cell = new DevComponents.DotNetBar.Controls.MutiHeaderCell(col.HeaderText);
                cell.Name = col.Name;
                grid.ColumnMutiHeadersCells.Add(cell);
            }
            Hashtable list = new Hashtable();
            DataTable colTable = Functions.CreateDataTable("Index:Int;ColName:String;Value:Int");
            DataView view = colTable.DefaultView;
            for (int i = startIndex; i < colCount; i++)
            {

                col = grid.Columns[i];
                string headerText = col.HeaderText.Trim();
                if (headerText.IndexOf('@') > -1)
                {
                    string[] colNames = headerText.Split('@');
                    string colName = colNames[0];
                    col.HeaderText = colNames[1];
                    col.Width = 20 + col.HeaderText.Length * 15;
                    view.RowFilter = "ColName='" + colName + "'";
                    if (view.Count > 0)
                    {
                        int value = Functions.FormatInt(view[0]["Value"]);
                        value = value + 1;
                        view[0]["Value"] = value;
                    }
                    else
                    {
                        DataRow row = colTable.NewRow();
                        row["Index"] = i;
                        row["ColName"] = colName;
                        row["Value"] = 1;
                        colTable.Rows.Add(row);
                    }
                }
            }
            view.RowFilter = "";
            view.Sort = "Index ASC";
            int tmpStartIndex = startIndex;
            foreach (DataRow row in colTable.Rows)
            {
                string colHeaderText = Functions.FormatString(row["ColName"]);
                int spanCol = Functions.FormatInt(row["Value"]);
                CreateHeaderCell(grid, colHeaderText, colHeaderText, startIndex, spanCol);
                tmpStartIndex = tmpStartIndex + spanCol;
            }
        }

        private static void CreateHeaderCell(DevComponents.DotNetBar.Controls.DataGridViewX grid, string name, string caption, int startIndex, int span)
        {
            DevComponents.DotNetBar.Controls.MutiHeaderCell cell = new DevComponents.DotNetBar.Controls.MutiHeaderCell(caption);
            cell.Name = name;
            for (int i = startIndex; i < startIndex + span; i++)
            {
                string headerName = grid.Columns[i].HeaderText.Trim();
                DevComponents.DotNetBar.Controls.MutiHeaderCell headCell = new DevComponents.DotNetBar.Controls.MutiHeaderCell(headerName);
                headCell.Name = "col" + headerName + "Name";
                cell.Cells.Add(headCell);
            }
            grid.ColumnMutiHeadersCells.Add(cell);
        }
        #endregion

        #region SetUIStyle
        internal static void SetUIStyle()
        {
            if (Convert.ToInt32(PubContext.CurrentUser.UIStyleID) > -1)
            {
                DevComponents.DotNetBar.StyleManager style = new DevComponents.DotNetBar.StyleManager();
                style.ManagerStyle = (DevComponents.DotNetBar.eStyle)Convert.ToInt32(PubContext.CurrentUser.UIStyleID);
                string color = PubContext.CurrentUser.UIStyleColor;
                if (color.IndexOf(',') > -1)
                {
                    string[] colors = color.Split(',');
                    if (colors.Length >= 4)
                    {
                        int A = Functions.FormatInt(colors[0]);
                        int R = Functions.FormatInt(colors[1]);
                        int G = Functions.FormatInt(colors[2]);
                        int B = Functions.FormatInt(colors[3]);
                        Color styleColor = Color.FromArgb(A, R, G, B);
                        style.ManagerColorTint = styleColor;
                        style.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, styleColor);
                    }
                }
            }
        }
        #endregion

        public static void CreateSumSummaryItem(DevComponents.DotNetBar.Controls.DataGridViewX grid,string colNames)
        {
            DevComponents.DotNetBar.Controls.SummaryItem summaryItem;
            string[] colNameArray = colNames.Split(',');
            foreach (string colName in colNameArray)
            {
                summaryItem = new DevComponents.DotNetBar.Controls.SummaryItem();
                summaryItem.ColumnName = colName;
                summaryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
                summaryItem.ForeColor = System.Drawing.SystemColors.ControlText;
                summaryItem.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
                grid.ColumnFootersItems.AddRange(summaryItem);
            }
        }
        public static void CreateSumSummaryItem(DevComponents.DotNetBar.Controls.DataGridViewX grid, int statIndex)
        {
            if (statIndex > 0)
            {
                int colCount = grid.Columns.Count;
                DevComponents.DotNetBar.Controls.SummaryItem summaryItem;
                for (int i = statIndex; i < colCount; i++)
                {
                    string colName = grid.Columns[i].Name;
                    summaryItem = new DevComponents.DotNetBar.Controls.SummaryItem();
                    summaryItem.ColumnName = colName;
                    summaryItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
                    summaryItem.ForeColor = System.Drawing.SystemColors.ControlText;
                    summaryItem.SummaryMode = DevComponents.DotNetBar.Controls.SummaryMode.Sum;
                    grid.ColumnFootersItems.AddRange(summaryItem);
                }
            }
        }

        public static bool ButtonDoubleClick(Button btn)
        {
            bool result=false;
            if (btn.Tag!=null)
            {
                DateTime clickTime =(DateTime) btn.Tag;
                TimeSpan span = DateTime.Now - clickTime;
                if (span.Milliseconds < 100)
                {
                    result = true;
                }
            }
            btn.Tag = DateTime.Now;
            return result;
        }
        public static bool ButtonDoubleClick(ButtonX btn)
        {
            bool result = false;
            if (btn.Tag != null)
            {
                DateTime clickTime = (DateTime)btn.Tag;
                TimeSpan span = DateTime.Now - clickTime;
                if (span.Milliseconds < 100)
                {
                    result = true;
                }
              
            }
            btn.Tag = DateTime.Now;
            return result;
        }
        public static bool ButtonDoubleClick(ToolStripButton btn)
        {
            bool result = false;
            if (btn.Tag != null)
            {
                DateTime clickTime = (DateTime)btn.Tag;
                TimeSpan span = DateTime.Now - clickTime;
                if (span.Milliseconds < 100)
                {
                    result = true;
                }

            }
            btn.Tag = DateTime.Now;
            return result;
        }
    }
}
