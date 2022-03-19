using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;

namespace DMS.DataClass.Pub
{
    public class SystemMenu
    {
        private Hashtable hashMenuTable = null;
        public event AfterMenuTreeClickEventHandler AfterMenuTreeClickEvent;

        public static List<MenuData> GetAllMenus()
        {
            List<MenuData> menuDatas = new List<MenuData>();
            XmlDocument xml = XmlHelper.GetXmlDocument("menu.xml", true);
            try
            {
                XmlNode list = XmlHelper.GetNodeByPath(@"DMS/Menus", xml);
                foreach (XmlNode item in list.ChildNodes)
                {
                    MenuData data = new MenuData()
                    {
                        Code = item.Attributes["Code"].Value,
                        Name = item.InnerText,
                        Order = Convert.ToInt32(item.Attributes["Order"].Value),
                        MenuClassName = item.Attributes["FullName"].Value,
                        ParentCode = item.Attributes["Parent"].Value,
                        IsLeaf = item.Attributes["IsLeaf"].Value == "0" ? false : true
                    };

                    menuDatas.Add(data);
                }
            }
            catch { }

            return menuDatas;
        }

        public static List<MenuData> GetAllShortCuts()
        {
            List<MenuData> shortCuts = new List<MenuData>();
            List<string> shortsCode = GetAllShortCutCode();
            try
            {
                shortCuts = PubContext.Menus.FindAll(c => shortsCode.Contains(c.MenuClassName));
            }
            catch { }

            return shortCuts;
        }

        public static List<string> GetAllShortCutCode()
        {
            List<string> cuts = new List<string>();
            XmlDocument xml = XmlHelper.GetXmlDocument("menu.xml", true);
            try
            {
                XmlNode list = XmlHelper.GetNodeByPath(@"DMS/Users/User/ShortCut/Items", xml);
                foreach (XmlNode item in list.ChildNodes)
                {
                    cuts.Add(item.InnerText);
                }
            }
            catch { }

            return cuts;
        }

        public void CreateMenu(MenuStrip mainMenu,List<MenuData> menuRightData)
        {
            List<MenuData> menuDataTemp = PubContext.Menus.OrderBy(c => c.Code + c.ParentCode + c.Order).ToList();

            if ((null != menuDataTemp) && (menuDataTemp.Count > 0))
            {
                int rowCount = menuDataTemp.Count;
                hashMenuTable = new Hashtable(rowCount);
                if (rowCount > 0)
                {
                    foreach (MenuData item in menuDataTemp)
                    {
                        string parentCode = item.ParentCode.Trim();
                        ToolStripMenuItem parentMenu = FindParentMenu(parentCode);
                        if (parentMenu != null)
                        {
                            string showContent = item.Name.Trim();
                            if ("-" != showContent)
                            {
                                ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
                                newMenuItem.Text = showContent;
                                newMenuItem.Tag = item;
                                newMenuItem.Click += new EventHandler(subMenu_Click);
                                parentMenu.Click -= new EventHandler(subMenu_Click);
                                parentMenu.DropDownItems.Add(newMenuItem);
                                string code = item.Code;
                                hashMenuTable.Add(code, newMenuItem);
                            }
                            else
                            {
                                ToolStripSeparator newMenuItem = new ToolStripSeparator();
                                newMenuItem.Text = "-";
                                newMenuItem.Tag = null;
                                parentMenu.DropDownItems.Add(newMenuItem);
                                string code = item.Code.Trim();
                                hashMenuTable.Add(code, newMenuItem);
                            }
                        }
                        else
                        {
                            if (parentCode == "0")
                            {
                                ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
                                string showContent = item.Name.Trim();

                                if ("-" != showContent)
                                {
                                    newMenuItem.Text = showContent;
                                    newMenuItem.Tag = item;
                                    mainMenu.MdiWindowListItem = newMenuItem;
                                    mainMenu.Items.Add(newMenuItem);
                                    string code = item.Code.Trim();
                                    string fullName = item.MenuClassName.Trim();
                                    if (!string.IsNullOrEmpty(fullName))
                                        newMenuItem.Click += new EventHandler(subMenu_Click);
                                    hashMenuTable.Add(code, newMenuItem);
                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }
        }

        private ToolStripMenuItem FindParentMenu(string parentID)
        {
            ToolStripMenuItem node = null;
            try
            {
                node = (ToolStripMenuItem)hashMenuTable[parentID];
            }
            catch
            {

            }
            return node;
        }

        void subMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = ((ToolStripMenuItem)sender);
            if (menu.Tag != null)
            {
                MenuData menuData = (MenuData)menu.Tag;
                string menuCode = menuData.Code;
                string FullClassName = menuData.MenuClassName;
                string FormText = menuData.Name;
                AfterMenuTreeClickEvent(sender, FullClassName, -1, FormText);
            }
        }

        public bool CreateTool(ToolStrip ShotcutTools, MenuData row)
        {
            bool isExsit = false;
            string code = row.Code;
            for (int i = 0; i < ShotcutTools.Items.Count; i++)
            {
                if (ShotcutTools.Items[i] is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)ShotcutTools.Items[i];
                    if (null != btn.Tag && !string.IsNullOrEmpty(btn.Tag.ToString()))
                    {
                        MenuData tmpRow = (MenuData)btn.Tag;
                        string tmpmenCode = tmpRow.Code;
                        if (tmpmenCode == code)
                        {
                            isExsit = true;
                            break;
                        }
                    }
                }

            }
            if (!isExsit)
            {
                ToolStripButton button = new ToolStripButton();
                button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
                button.ImageTransparentColor = System.Drawing.Color.Magenta;
                button.Name = row.Code;
                string showcontent = row.Name;
                button.Text = showcontent;
                button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                button.ToolTipText = string.Empty;
                button.Tag = row;
                button.Click += new EventHandler(button_Click);
                ShotcutTools.Items.Add(button);
            }
            else
            {
                MessageBox.Show("该快捷方式已存在!");
            }
            return !isExsit;
        }

        void button_Click(object sender, EventArgs e)
        {
            ToolStripButton menu = ((ToolStripButton)sender);
            if (menu.Tag != null)
            {
                MenuData row = (MenuData)menu.Tag;
                if (row != null)
                {
                    string code = row.Code;
                    string FullClassName = row.MenuClassName;
                    string FormText = row.Name;
                    AfterMenuTreeClickEvent(sender, FullClassName, -1, FormText);
                }
            }
        }

        public bool DeleteTool(ToolStrip ShotcutTools, MenuData row)
        {
            string code = row.Code;
            for (int i = 0; i < ShotcutTools.Items.Count; i++)
            {
                if (ShotcutTools.Items[i] is ToolStripButton)
                {
                    ToolStripButton btn = (ToolStripButton)ShotcutTools.Items[i];
                    if (null != btn.Tag && !string.IsNullOrEmpty(btn.Tag.ToString()))
                    {
                        MenuData tmpRow = (MenuData)btn.Tag;
                        string tmpmenCode = tmpRow.Code;
                        if (tmpmenCode == code)
                        {
                            ShotcutTools.Items.Remove(btn);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }

    public class MenuData : IComparable<MenuData>
    {
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 菜单绑定界面全名
        /// </summary>
        public string MenuClassName { get; set; }

        /// <summary>
        /// 父级菜单编码
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 是否叶节点
        /// </summary>
        public bool IsLeaf { get; set; }

        public string MenuDesc { get; set; }

        #region IComparable 成员

        public int CompareTo(MenuData obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            return (this.Code + this.ParentCode + this.Order).CompareTo(obj.Code + obj.ParentCode + obj.Order);
        }

        #endregion
    }
}
