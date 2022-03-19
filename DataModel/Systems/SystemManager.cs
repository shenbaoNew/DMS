using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DMS.DataClass.Pub;
using DMS.DataClass.Systems.User;
using DMS.Properties;

namespace DMS
{
    class SystemManager
    {

        public static void InitPubData()
        {
            try
            {
                XmlDocument xml = XmlHelper.GetXmlDocument("menu.xml", true);

                if (xml != null)
                {
                    //本地连接
                    PubContext.DBServer = XmlHelper.GetNodeByPath(@"DMS/DataBase/LocalDBConnect/Server", xml).InnerText;
                    PubContext.DBDataBase = XmlHelper.GetNodeByPath(@"DMS/DataBase/LocalDBConnect/DataBase", xml).InnerText;
                    PubContext.DBLoginUser = XmlHelper.GetNodeByPath(@"DMS/DataBase/LocalDBConnect/User", xml).InnerText;
                    PubContext.DBPsd = XmlHelper.GetNodeByPath(@"DMS/DataBase/LocalDBConnect/Psd", xml).InnerText;

                    //Mariadb
                    PubContext.MariaDBServer = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Server", xml).InnerText;
                    PubContext.MariaDBDataBase = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/DataBase", xml).InnerText;
                    PubContext.MariaDBLoginUser = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/User", xml).InnerText;
                    PubContext.MariaDDBPsd = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Psd", xml).InnerText;
                    PubContext.MariaDBPort = XmlHelper.GetNodeByPath(@"DMS/DataBase/Mariadb/Port", xml).InnerText;
                    PubContext.MariadbDBConnection = string.Format("server={0};user id={1};password={2};database={3}", PubContext.MariaDBServer, PubContext.MariaDBLoginUser, PubContext.MariaDDBPsd, PubContext.MariaDBDataBase);

                    PubContext.DBConnection = "Server= " + PubContext.DBServer + ";Network Library=DBMSSOCN;Database="
                        + PubContext.DBDataBase + ";uid=" + PubContext.DBLoginUser + ";pwd=" + Security.Decrypt(PubContext.DBPsd, SecurityEnum.MMS) + ";";

                    CustSqlConnection conn = new CustSqlConnection(PubContext.DBServer, PubContext.DBDataBase, PubContext.DBLoginUser, PubContext.DBPsd);
                    SqlConnectionManager.AddConnection(conn);

                    //数据库标识
                    string flag = XmlHelper.GetNodeByPath(@"DMS/SystemConfig/SystemFlag", xml).InnerText;
                    //系统版本
                    PubContext.SystemVersion = XmlHelper.GetNodeByPath(@"DMS/SystemConfig/Version", xml).InnerText;

                    if (flag.Trim().ToUpper() == "T")
                        PubContext.syatemFlag = SystemFlag.T;
                    else if (flag.Trim().ToUpper() == "Q")
                        PubContext.syatemFlag = SystemFlag.Q;
                    else if (flag.Trim().ToUpper() == "PRD")
                        PubContext.syatemFlag = SystemFlag.PRD;

                    //所有用户
                    PubContext.AllUsers = GetAllUsers(xml);

                    //菜单
                    PubContext.Menus = SystemMenu.GetAllMenus();
                    //快捷菜单
                    PubContext.ShortCutMenus = SystemMenu.GetAllShortCuts();
                }
                else
                {
                    ShowMessage.ShowError("加载菜单文件失败。。。");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示");
            }
        }

        private static List<UserData> GetAllUsers(XmlDocument xml)
        {
            List<UserData> users = new List<UserData>();
            XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/Users", xml);
            if (parent == null)
                return users;

            XmlNodeList list = parent.ChildNodes;
            if (list == null || list.Count <= 0)
                return users;

            foreach (XmlNode item in list)
            {
                //用户
                string code = item.SelectSingleNode(@"Code").InnerText;
                string name = item.SelectSingleNode(@"Name").InnerText;
                string uiStyleID = item.SelectSingleNode(@"UIStyleID").InnerText;
                string uiStyleColor = item.SelectSingleNode(@"UIStyleColor").InnerText;
                string formModule = item.SelectSingleNode(@"FormModule").InnerText;
                string shortCut = item.SelectSingleNode(@"ShortCut/Style").InnerText;
                string psd = item.SelectSingleNode(@"Psd").InnerText;
                string isAdmin = item.SelectSingleNode(@"IsAdmin").InnerText;

                UserData user = new UserData(code, name, psd, (isAdmin == "1" ? true : false), uiStyleID, uiStyleColor, formModule, shortCut);
                users.Add(user);
            }

            return users;
        }

        public static bool SaveSystemVerson(string verson)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("menu.xml");

                XmlNode node = XmlHelper.GetNodeByPath(@"DMS/SystemConfig/Version", xml);
                if (node == null)
                    return false;

                if (node != null)
                    node.InnerText = verson;

                xml.Save("menu.xml");

                return true;
            }
            catch
            {
                return false;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;
        public static System.Drawing.Image GetImage()
        {
            StringBuilder wallPaperPath = new StringBuilder(200);
            System.Drawing.Image bakImage = null;
            try
            {
                if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
                {
                    bakImage = ImageFast.FromFile(wallPaperPath.ToString());
                }
                if (bakImage != null)
                {
                    bakImage = KiResizeImage(bakImage);
                    bakImage = KiCut(bakImage);
                }
            }
            catch { }
            return bakImage;
        }
        public static System.Drawing.Bitmap KiCut(System.Drawing.Image b)
        {
            int iHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int iWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            int StartX = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.X;
            int StartY = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Y;
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (StartX >= w || StartY >= h)
            {
                return null;
            }

            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }

            try
            {
                System.Drawing.Bitmap bmpOut = new System.Drawing.Bitmap(iWidth, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
        public static Image KiResizeImage(Image bmp)
        {
            try
            {
                int newH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                int newW = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}
