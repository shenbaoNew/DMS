using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.DataClass.Systems.User;
using System.Windows.Forms;
using DMS.DataClass.Pub;

namespace DMS
{
    class PubContext
    {
        #region 本地数据库标识

        /// <summary>
        /// 数据库登陆用户
        /// </summary>
        public static string DBLoginUser;
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string DBServer;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBDataBase;
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public static string DBPsd;
        /// <summary>
        /// 数据连接
        /// </summary>
        public static string DBConnection;

        #endregion

        #region mariadb

        /// <summary>
        /// 数据库登陆用户
        /// </summary>
        public static string MariaDBLoginUser;
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string MariaDBServer;
        /// <summary>
        /// 数据库端口号
        /// </summary>
        public static string MariaDBPort;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string MariaDBDataBase;
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public static string MariaDDBPsd;
        /// <summary>
        /// 数据连接
        /// </summary>
        public static string MariadbDBConnection;

        #endregion

        #region 远程数据库标识

        /// <summary>
        /// 数据库登陆用户
        /// </summary>
        public static string RemoteDBLoginUser;
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string RemoteDBServer;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string RemoteDBDataBase;
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public static string RemoteDBPsd = "JOW[F~SVj^lA4=jzo";
        /// <summary>
        /// 数据连接
        /// </summary>
        public static string RemoteDBConnection;

        #endregion

        #region 数据库管理



        #endregion

        #region 系统相关

        public static SystemFlag syatemFlag = SystemFlag.Q;

        /// <summary>
        /// 系统版本
        /// </summary>
        public static string SystemVersion = string.Empty;

        #endregion

        #region 系统更新
        public static bool Upgrade { get; set; }
        public static string DmsFtpUser = "dms";
        public static string DmsFtpPwd = "123!@#shen";
        public static string DmsFtpServer = "114.55.34.43";
        #endregion

        public static UserData CurrentUser { get; set; }

        public static string logUser;

        public static Form formMain = null;

        public static bool IsAdmin = false;

        //系统菜单
        public static List<MenuData> Menus
        {
            get;
            set;
        }

        //快捷菜单
        public static List<MenuData> ShortCutMenus
        {
            get;
            set;
        }

        /// <summary>
        /// 所有用户
        /// </summary>
        public static List<UserData> AllUsers
        {
            get; 
            set; 
        }
    }

    /// <summary>
    /// 系统标识
    /// T Q PRD
    /// </summary>
    public enum SystemFlag
    {
        T,
        Q,
        PRD
    }
}
