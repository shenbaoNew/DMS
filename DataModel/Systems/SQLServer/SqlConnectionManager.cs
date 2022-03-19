using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class SqlConnectionManager:SQLHelper
    {
        private static object syncObj = new object();

        #region const字段

        public const string SearchMenuName = "select reverse(substring(ltrim(reverse(FullClassName)),1,charindex('.',ltrim(reverse(FullClassName)))-1)) as 类名, \n"
                        + "MenuText as 显示名称 ,FullClassName as 类全名 From Base_System_MenuTree \n"
                        + "where MenuText like '%半成品入库%' \n"
                        + "--或者-- \n"
                        + "select FullClassName as 类全名, \n"
                        + "MenuText as 显示名称 From Base_System_MenuTree \n"
                        + "where MenuText like '%半成品入库%'";

        public const string AddPriceGroup = "--这里ApplicationID=100,具体应用时需要更改-- \n"
                        + "--猪：1,牛：2,羊：3,禽业：4-- \n"
                        + "declare @ApplicationID int  set @ApplicationID=100 \n"
                        + "if(@ApplicationID<=4) BEGIN \n"
                        + "insert into [DBIMS].[dbo].[Base_Parameter_Regions](RegionName,ShowIndex,CompanyID,[Disabled],[ApplicationID]) \n"
                        + "values ('科右',0,310,0,100)"
                        + "END";

        public const string AddLossStandard = "--这里CompanyID=100000,具体应用时需要更改-- \n"
                        + "insert into [DBIMS].[dbo].[Base_Parameter_LossStandard] ( \n"
                        + "LossItemID, \n"
                        + "StartValue, \n"
                        + "EndValue, \n"
                        + "WarningValue, \n"
                        + "ForbiddenValue, \n"
                        + "StandardFlag, \n"
                        + "Disabled, \n"
                        + "ModificationLevel, \n"
                        + "Description, \n"
                        + "CompanyID) \n"
                        + "SELECT \n"
                        + "[LossItemID] \n"
                        + ",[StartValue] \n"
                        + ",[EndValue] \n"
                        + ",[WarningValue] \n"
                        + " ,[ForbiddenValue] \n"
                        + ",[StandardFlag] \n"
                        + ",[Disabled] \n"
                        + ",[ModificationLevel] \n"
                        + ",[Description] \n"
                        + ",74 AS [CompanyID] \n"
                        + "FROM [DBIMS].[dbo].[Base_Parameter_LossStandard] where CompanyID=100000 ";

        public const string BackUpDatabase = @"backup database T8430 to disk='d:\backup\T8430_ShenBao_Full_201410300835.bak'";

        public const string UpdateCompanyArea = "update [CSM].[dbo].[COMPANY_INFO] set company_area=1 where company_code='7030'";

        public const string UpdateIdentityColumn = "SET IDENTITY_Insert [Base_Parameter_BodyShape] ON ";

        public const string ResetMMSPassword = "--初始化MMS admin密码为111-- \n"
                        + "update base_system_users set UserPassword= 0xA1946CF023DFDAE4BA0A2FFF04BCD47D3D0C0D857AB9760E where userid = 'admin'";

        public const string SearchMonthPurchase = "--查询月度收购汇总-- \n"
                        + " select Months 月份,sum(AllCount) 单据数量,sum(AllAmount) 总宰量,Sum(GrossWeight) 总收购重量,Sum(AllTotal) 总金额 \n"
                        + " From Flow_Supply_PurchaseBilllMonthly group by Months order by Months";

        public const string SearchLossAppend = "--查询备份丢失数据[扣重明细]--\n"
                        + " select  Convert(char(10),inputdate,120) as [date] into #tmp From [dbo].[Flow_Balance_MetageAppend] order by inputdate \n"
                        + " select distinct [date] from #tmp order by [date]";

        public static List<string> E10SQLs = new List<string>() { 
            " SELECT *FROM SALES_ORDER_DOC_D "+
            " WHERE SALES_ORDER_DOC_ID IN () "
        };

        #endregion

        /// <summary>
        /// 数据库连接集合
        /// </summary>
        public static Dictionary<string, CustSqlConnection> SQLConnList = new Dictionary<string, CustSqlConnection>();

        public static CustSqlConnection _currentConnection = null;

        public static string _currentFlag = string.Empty;

        public static string CurrentFlag
        {
            get 
            {
                if (_currentConnection != null)
                    return _currentConnection.ConnecFlag;
                else
                    return "";
            }
        }

        public static CustSqlConnection CurrentConnection
        {
            get { return _currentConnection; }
            set 
            {
                lock (syncObj)
                {
                    _currentConnection = value;
                }
            }
        }

        public SqlConnectionManager(CustSqlConnection conn)
        {
            if (!SQLConnList.ContainsKey(conn.ConnecFlag))
                SQLConnList.Add(conn.ConnecFlag, conn);
        }

        public SqlConnectionManager()
        { }

        public void AddConnectionData(CustSqlConnection conn)
        {
            if (!SQLConnList.ContainsKey(conn.ConnecFlag))
                SQLConnList.Add(conn.ConnecFlag, conn);

            _currentConnection = conn;
        }

        public static void AddConnection(CustSqlConnection conn)
        {
            if (!SQLConnList.ContainsKey(conn.ConnecFlag))
                SQLConnList.Add(conn.ConnecFlag, conn);

            _currentConnection = conn;
        }

        public static void RemoveConnection(CustSqlConnection conn)
        {
            if (SqlConnectionManager.SQLConnList.ContainsKey(conn.ConnecFlag))
            {
                SqlConnectionManager.SQLConnList.Remove(conn.ConnecFlag);
                if (SqlConnectionManager.CurrentConnection != null
                    && conn != null && SqlConnectionManager.CurrentConnection.ConnecFlag == conn.ConnecFlag)
                {
                    SqlConnectionManager.CurrentConnection = null;
                }
            }
        }

        public static void RemoveConnection(string connFlag)
        {
            if (SqlConnectionManager.SQLConnList.ContainsKey(connFlag))
            {
                SqlConnectionManager.SQLConnList.Remove(connFlag);
                if (SqlConnectionManager.CurrentConnection != null
                    && SqlConnectionManager.CurrentConnection.ConnecFlag == connFlag)
                {
                    SqlConnectionManager.CurrentConnection = null;
                }
            }
        }

        public bool IsSuccess(CustSqlConnection conn)
        {
            return OpenServerTest(conn.server, conn.db, conn.user, Security.Decrypt(conn.psd,SecurityEnum.MMS));
        }

        protected override string ConnectionString()
        {
            if (_currentConnection == null)
                throw new Exception("当前连接没有初始化");

            return _currentConnection.ConnectionString;
        }
    }

    /// <summary>
    /// 数据库连接
    /// </summary>
    public class CustSqlConnection
    {
        public string server;
        public string db;
        public string user;
        public string psd;

        public readonly List<string> ConntionList = new List<string>();

        public string connectionString;

        public string ConnecFlag
        {
            get
            {
                return server + "（" + user + "," + db + "）";
            }
        }

        public string DisplayText
        {
            get
            {
                return "服务器：" + server + "   用户：" + user + "    数据库：" + db;
            }
        }

        public CustSqlConnection(string _server, string _db, string _user, string _psd)
        {
            this.server = _server;
            this.db = _db;
            this.user = _user;
            this.psd = _psd;

            //this.connectionString = "Server= " + server + ";Network Library=DBMSSOCN;Database=" + db + ";uid=" + user + ";pwd=" + Security.Decrypt(psd, SecurityEnum.Common) + ";";
            this.connectionString = " Provider=SQLOLEDB;Password=" + Security.Decrypt(psd, SecurityEnum.MMS)
                + ";Persist Security Info=True;User ID=" + user + ";Initial Catalog=" + db + ";Data Source=" + server + " ";
        }

        public CustSqlConnection(CustSqlConnection conn)
        {
            this.server = conn.server;
            this.db = conn.db;
            this.user = conn.user;
            this.psd = conn.psd;

            this.connectionString = conn.connectionString;
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }
    }
}