using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.DataClass.Pub;
using System.Xml;

namespace DMS.DataClass.Systems.User
{
    class UserData
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Psd { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 界面主题
        /// </summary>
        public string UIStyleID { get; set; }

        /// <summary>
        /// 界面颜色
        /// </summary>
        public string UIStyleColor { get; set; }

        /// <summary>
        /// 界面布局方式
        /// </summary>
        public string FormModule { get; set; }

        /// <summary>
        /// 快捷桌面显示方式
        /// </summary>
        public string ShortCutStyle { get; set; }

        public UserData(string code, string name, string psd,bool isAdmin, string uiStyleID, string uiStyleColor, string formModule, string shortCutStyle)
        {
            this.Code = code;
            this.Name = name;
            this.UIStyleID = uiStyleID;
            this.UIStyleColor = uiStyleColor;
            this.FormModule = formModule;
            this.ShortCutStyle = shortCutStyle;
            this.Psd = psd;
            this.IsAdmin = isAdmin;
        }

        public UserData()
        { }

        /// <summary>
        /// 保存快捷菜单
        /// </summary>
        /// <returns></returns>
        public bool InsertShortCust(List<MenuData> list)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("menu.xml");

            XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/Users/User/ShortCut/Items", xml);
            if (parent == null)
                return false;
            parent.RemoveAll();

            try
            {
                foreach (var item in list)
                {
                    XmlNode newNode = xml.CreateNode("element", "Item", "");
                    newNode.InnerText = item.MenuClassName;
                    parent.AppendChild(newNode);
                }

                xml.Save("menu.xml");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存快捷菜单
        /// </summary>
        /// <returns></returns>
        public bool InsertShortCust(MenuData menu)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("menu.xml");

                XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/Users/User/ShortCut/Items", xml);
                if (parent == null)
                    return false;

                XmlNodeList list = parent.ChildNodes;
                List<XmlNode> nodes = XmlHelper.XmlNodeListToList(list);
                if (nodes == null)
                    return false;
                XmlNode node = nodes.FirstOrDefault(c => c.InnerText == menu.MenuClassName);
                if (node != null)
                    return false;

                XmlNode newNode = xml.CreateNode("element", "Item", "");
                newNode.InnerText = menu.MenuClassName;
                parent.AppendChild(newNode);

                xml.Save("menu.xml");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除快捷菜单
        /// </summary>
        /// <returns></returns>
        public bool DeleteShortCust(MenuData menu)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("menu.xml");

                XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/Users/User/ShortCut/Items", xml);
                if (parent == null)
                    return false;

                XmlNodeList list = parent.ChildNodes;
                List<XmlNode> nodes = XmlHelper.XmlNodeListToList(list);
                if (nodes == null)
                    return false;
                XmlNode node = nodes.FirstOrDefault(c => c.InnerText == menu.MenuClassName);
                if (node == null)
                    return false;
                parent.RemoveChild(node);

                xml.Save("menu.xml");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePsd(string userCode, string psd)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("menu.xml");

                XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/Users", xml);
                if (parent == null)
                    return false;

                XmlNodeList list = parent.ChildNodes;
                if (list == null || list.Count <= 0)
                    return false;

                XmlNode node = null;
                foreach (XmlNode item in list)
                {
                    if (item.SelectSingleNode(@"Code").InnerText == userCode)
                    {
                        node = item;
                        break;
                    }
                }

                if (node == null)
                    return false;

                XmlNode psdNode = node.SelectSingleNode(@"Psd");
                if (psdNode != null)
                    psdNode.InnerText = Security.Encryp(psd, SecurityEnum.Common);

                xml.Save("menu.xml");

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
