using DMS.Forms;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS.Margin {
    public partial class frmSystemAddAuth : BaseForm {
        string connectionStr = string.Empty;
        //private const string E10 = "Data Source=121.40.19.209,1433;Initial Catalog=CHECK_E10;User Id=sa;Password=Dcms123456;";
        private const string E10 = "Data Source=127.0.0.1,1433;Initial Catalog=E10_6.0_KF_ICD;User Id=sa;Password=shenbao;";
        private const string YF = "Data Source=127.0.0.1,1433;Initial Catalog=CHECK_YIFEI;User Id=sa;Password=shenbao;";
        public frmSystemAddAuth() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (this.txtCode.Text.Trim() == string.Empty) {
                MessageBox.Show("请输入客户编号");
                return;
            }
            if (this.txtName.Text.Trim() == string.Empty) {
                MessageBox.Show("请输入客户名称");
                return;
            }
            if (this.txtUser.Text.Trim() == string.Empty) {
                MessageBox.Show("请输入ITCODE");
                return;
            }

            List<Dept> depts = GetDepts(this.txtUser.Text.Trim());
            Insert(txtCode.Text, txtName.Text, depts);

            MessageBox.Show("处理完成");
        }

        private List<Dept> GetDepts(string user) {
            string strResult = NewMethord("digiwin.com", "shenbao", "shenbaozql", user);
            string[] strList = strResult.Split('$');
            string userId = strList[0].Split('|')[0];
            List<Dept> deptList = new List<Dept>();
            //"shenbao|谌豹|BV0580|服務商品支持部$BV0000|服務商品暨軟件研發處$BV0500|E軟件產品中心";
            for (int index = 0; index < strList.Length; index++) {
                Dept dpt = new Dept();

                if (index == 0) {
                    dpt.Code = strList[0].Split('|')[2];
                    dpt.Name = strList[0].Split('|')[3];

                } else {
                    dpt.Code = strList[index].Split('|')[0];
                    dpt.Name = strList[index].Split('|')[1];
                }
                deptList.Add(dpt);
            }

            return deptList;
        }

        private bool Insert(string customerCode, string customerName, List<Dept> list) {
            bool b = false;
            if (list.Count <= 0)
                return false;
            using (SqlConnection conn = new SqlConnection(connectionStr)) {
                conn.Open();
                SqlCommand cmd = null;
                Guid key = Guid.NewGuid();
                object obj = ExistsHeader(customerCode);
                if (obj != null && obj != DBNull.Value) {
                    key = (Guid)obj;
                } else {
                    b = true;
                    cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("INSERT INTO [CUSTOMER](CUSTOMER_ID,CUSTOMER_CODE,CUSTOMER_NAME,CreateBy,[Status]) VALUES('{0}','{1}','{2}','初始导入','Y')"
                        , key, customerCode, customerName);

                    int n = cmd.ExecuteNonQuery();
                }

                int seq = 1;
                foreach (var item in list) {
                    object line = ExistsLine(customerCode, item.Code);
                    if (line == null || line == DBNull.Value) {
                        cmd.CommandText = string.Format("INSERT INTO [CUSTOMER_DEPT](CUSTOMER_DEPT_ID,CUSTOMER_ID,SEQ,DEPARTMENT_CODE,DEPARTMENT_NAME," +
                            "IS_ALLOW,CreateBy,[Status]) VALUES ('{0}','{1}','{2}','{3}','{4}','1','初始导入','Y')"
                            , Guid.NewGuid(), key, seq++, item.Code, item.Name);
                        int n = cmd.ExecuteNonQuery();
                    }
                }
            }

            return b;
        }

        private object ExistsHeader(string customerCode) {
            using (SqlConnection conn = new SqlConnection(connectionStr)) {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(" select CUSTOMER_ID from CUSTOMER where CUSTOMER_CODE='{0}'", customerCode);
                object obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        private object ExistsLine(string customerCode, string depcode) {
            using (SqlConnection conn = new SqlConnection(connectionStr)) {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format(" select 1 from CUSTOMER A INNER JOIN CUSTOMER_DEPT B ON A.CUSTOMER_ID = B.CUSTOMER_ID where A.CUSTOMER_CODE='{0}' AND B.DEPARTMENT_CODE='{1}'", customerCode, depcode);
                object obj = cmd.ExecuteScalar();
                return obj;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.comboBox1.SelectedIndex == 0) {
                connectionStr = E10;
            } else {
                connectionStr = YF;
            }
        }

        public string NewMethord(string domain, string userid, string pwd, string searchUser) {
            List<string> strList = new List<string>();
            using (DirectoryEntry deUser = new DirectoryEntry(@"LDAP://" + domain, userid, pwd)) {
                DirectorySearcher src = new DirectorySearcher(deUser);
                src.Filter = "(&(&(objectCategory=person)(objectClass=user))(sAMAccountName=" + searchUser + "))";
                src.PropertiesToLoad.Add("cn");
                src.SearchRoot = deUser;
                src.SearchScope = SearchScope.Subtree;

                try {
                    SearchResult result = src.FindOne();
                    if (result != null) {
                        string userName = GetUserName(result.Path, searchUser);
                        string userInfo = searchUser + "|" + userName;
                        //LDAP://digiwin.com/CN=谌豹shenbao,OU=BV0580 服務商品暨軟件研發處.E軟件產品中心.服務商品支持部,OU=人員清冊,OU=Account,OU=DIGIWIN,DC=digiwin,DC=com
                        Regex regex = new Regex(@"OU=([\s\S]*?),");
                        MatchCollection mc = regex.Matches(result.Path);
                        if (mc.Count >= 0) {
                            //BV0580 服務商品暨軟件研發處.E軟件產品中心.服務商品支持部
                            string deptPath = mc[0].Groups[1].Value.ToString();
                            string[] paths = deptPath.Substring(deptPath.IndexOf(" ")).Split('.').Select(c => c.Trim()).ToArray();
                            if (paths != null) {
                                for (int index = 0; index < paths.Length; index++) {
                                    string deptCode = GetDeptCode(result.Path, string.Join(".", paths.Take(index + 1).ToArray()));
                                    string tmpStr = deptCode + "|" + paths[index];
                                    if (index != paths.Length - 1) {
                                        strList.Add(tmpStr);
                                    } else {
                                        strList.Insert(0, userInfo + "|" + tmpStr);
                                    }
                                }
                            }
                        }
                    }
                } catch {
                }
            }
            return strList.Count > 0 ? string.Join("$", strList) : string.Empty;
        }

        private string GetDeptCode(string path, string deptName) {
            string deptCode = string.Empty;
            try {
                DirectorySearcher search = new DirectorySearcher(path);
                search.Filter = "(cn=*" + deptName + ")";
                search.PropertiesToLoad.Add("memberOf");
                SearchResult result = search.FindOne();
                if (result != null) {
                    //特殊字符需要处理下
                    List<string> specialCharList = new List<string>() { "(", ")", "[", "]", "{", "}" };
                    Array.ForEach(specialCharList.ToArray(), c => deptName = deptName.Replace(c, "\\" + c));
                    string newPath = result.Path;
                    Regex regex = new Regex(@"CN=([\s\S]*?) [\s\S]*" + deptName + ",");
                    Match item = regex.Match(newPath);
                    if (item != null) {
                        deptCode = item.Groups[1].Value.ToString();
                    }
                }
            } catch {
            }

            return deptCode;
        }

        private string GetUserName(string path, string userCode) {
            Regex regex = new Regex(@"CN=([\s\S]*)" + userCode);
            Match item = regex.Match(path);
            if (item != null) {
                return item.Groups[1].Value.ToString();
            }
            return string.Empty;
        }

        public class Dept {
            public string Code { get; set; }
            public string Name { get; set; }
            public bool IsAllow { get; set; }
        }

        string fileName = string.Empty;
        private void button3_Click(object sender, EventArgs e) {
            openFileDialog1.Title = "选择文件";
            openFileDialog1.Filter = "Excel文件|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.txtPath.Text = openFileDialog1.FileName;
            }
        }

        Dictionary<string, List<Dept>> dic = new Dictionary<string, List<Dept>>();
        private void Import() {
            using (FileStream file = new FileStream(this.txtPath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                IWorkbook wb = WorkbookFactory.Create(file);
                ISheet sheet = wb.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                int index = 0;
                int count = 0;
                while (rows.MoveNext()) {
                    index++;
                    if (index == 1) {
                        continue;
                    }
                    IRow row = (IRow)rows.Current;
                    //ITCODE
                    ICell cell = row.GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                    string userId = GetCellValue(wb, cell).ToString();

                    //产品
                    cell = row.GetCell(2, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                    string pro = GetCellValue(wb, cell).ToString();

                    //客户编码
                    cell = row.GetCell(4, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                    string customerCode = GetCellValue(wb, cell).ToString();

                    //客户名称
                    cell = row.GetCell(3, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                    string customerName = GetCellValue(wb, cell).ToString();
                    if (string.IsNullOrEmpty(customerCode)) {
                        break;
                    }

                    if (pro.Trim() == "E10") {
                        connectionStr = E10;
                    } else {
                        connectionStr = YF;
                    }

                    try {
                        List<Dept> depts = null;
                        if (!dic.TryGetValue(userId, out depts)) {
                            depts = GetDepts(userId);
                            dic.Add(userId, depts);
                        }
                        Insert(customerCode, customerName, depts);

                        count++;
                    } catch (Exception ex) {
                    }
                }

                MessageBox.Show("成功导入" + count + "笔数据");
            }
        }

        private static object GetCellValue(IWorkbook wb, ICell cell) {
            object cellValue = null;
            //读取Excel格式，根据格式读取数据类型
            switch (cell.CellType) {
                case CellType.Blank: //空数据类型处理
                    cellValue = string.Empty;
                    break;
                case CellType.Numeric: //数字类型  
                    if (DateUtil.IsCellDateFormatted(cell)) {
                        cellValue = cell.DateCellValue;
                    } else {
                        cellValue = cell.NumericCellValue;
                    }
                    break;
                case CellType.Boolean:  //bool 类型
                    cellValue = cell.BooleanCellValue;
                    break;
                case CellType.Formula:  //公式类型
                    IFormulaEvaluator e = WorkbookFactory.CreateFormulaEvaluator(wb);
                    cellValue = e.Evaluate(cell).StringValue;
                    break;
                default:
                    cellValue = cell.StringCellValue;
                    break;
            }
            return cellValue;
        }

        private void button2_Click(object sender, EventArgs e) {
            if (txtPath.Text.Trim() == string.Empty) {
                MessageBox.Show("请选择文件");
                return;
            }
            Import();
        }

        private void button4_Click(object sender, EventArgs e) {
            textBox2.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.textBox1.Text ?? string.Empty));
        }

        private void button5_Click(object sender, EventArgs e) {
            textBox4.Text = Encoding.UTF8.GetString(Convert.FromBase64String(this.textBox3.Text ?? string.Empty));
        }
    }
}
