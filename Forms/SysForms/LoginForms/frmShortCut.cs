using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DMS.Forms;
using DMS.DataClass.Pub;
using System.Xml;
namespace DMS
{

    public partial class frmShortCut : BaseQueryForm
    {
        public event AfterMenuTreeClickEventHandler AfterMenuTreeClickEvent;
        private Array arrayList = Enum.GetValues(typeof(DevComponents.DotNetBar.Metro.eMetroTileColor));
        private frmManageShorCut shortCut;
        private List<MenuData> m_FullMenus;
        private List<MenuData> m_RightMenus;
        private List<MenuData> m_ShortCutMenus;
        private List<string> _shortCuts=new List<string>();

        public List<string> ShortCuts
        {
            get {
                if (_shortCuts == null)
                    _shortCuts = GetAllShortCutCode();
                return _shortCuts;
            }
        }

        public frmShortCut(int dockFlag,List<MenuData> fullMenus, List<MenuData> rightMenus)
        {
            InitializeComponent();
            DockPosion(dockFlag);
            this.TabPageContextMenuStrip = null;
            this.m_FullMenus = fullMenus;
            this.m_RightMenus = rightMenus;
            this._shortCuts = GetAllShortCutCode();
            this.m_ShortCutMenus = GetAllShortCuts();
            FillTree(m_ShortCutMenus);

        }
        private void DockPosion(int dockFlag)
        {
            switch(dockFlag)
            {
                case 1:
                    this.DockAreas = DevComponents.DotNetBar.DockAreas.DockLeft;
                    break;
                case 2:
                    this.DockAreas = DevComponents.DotNetBar.DockAreas.DockRight;
                    break;
                case 3:
                    this.DockAreas = DevComponents.DotNetBar.DockAreas.DockBottom;
                    break;
            }
        }

        public List<string> GetAllShortCutCode()
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

        public List<MenuData> GetAllShortCuts()
        {
            List<MenuData> shortCuts = null;
            try
            {
                shortCuts = PubContext.Menus.FindAll(c => this.ShortCuts.Contains(c.MenuClassName));
            }
            catch { }

            return shortCuts;
        }

        private void FillTree(List<MenuData> menus)
        {
            int i = 0;
            itemPanel.Items.Clear();
            foreach (MenuData item in menus)
            {
                DevComponents.DotNetBar.Metro.MetroTileItem tileItem = new DevComponents.DotNetBar.Metro.MetroTileItem();
                string menuText = Functions.FormatString(item.Name);
                string menuDescs = Functions.FormatString(item.MenuDesc);
                string menuCode = Functions.FormatString(item.Code);
                if (!string.IsNullOrEmpty(menuCode)&&menuCode.Length>1)
                {
                    menuCode=menuCode.Substring(0,2);
                }
                tileItem.SymbolColor = System.Drawing.Color.Empty;
                if (!string.IsNullOrEmpty(menuDescs))
                {
                    string desc = "";
                    string[] menuDescArray=menuDescs.Split(':');
                    if (menuDescArray.Length>1)
                    {
                        desc = "<font size=\"+3\">" + menuDescArray[0] + "</font><br/>\r\n" + menuDescArray[1] + "";
                    }
                    else if (menuDescArray.Length>0)
                    {
                        desc =  menuDescArray[0] ;
                    }
                    tileItem.Text = desc;
                }

                if (i>arrayList.Length)
                {
                    i = 0;
                   
                }
                tileItem.TileColor = (DevComponents.DotNetBar.Metro.eMetroTileColor)arrayList.GetValue(i);
                tileItem.Click += tileItem_Click;
                tileItem.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                tileItem.TitleText = menuText;
                tileItem.Tag = item;
                itemPanel.Items.Add(tileItem);
                i++;
            }
            this.Refresh();
        }

        void tileItem_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Metro.MetroTileItem tileItem = sender as DevComponents.DotNetBar.Metro.MetroTileItem;
            if (tileItem != null && tileItem.Tag != null)
            {
                MenuData row = (MenuData)tileItem.Tag;
                string code = row.Code;
                string FullClassName = row.MenuClassName.Trim();
                string FormText = row.Name.Trim();
                if (AfterMenuTreeClickEvent != null)
                {
                    AfterMenuTreeClickEvent(sender, FullClassName, -1, FormText);
                }
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            string frmName = "frmManageShorCut";
            bool result = IsExistChildForm(frmName);
            if (!result)
            {
                shortCut = new frmManageShorCut(this.m_FullMenus, this.m_RightMenus, this.m_ShortCutMenus);
                shortCut.AfterSaveDataEvent -= shortCut_AfterSaveDataEvent;
                shortCut.AfterSaveDataEvent += shortCut_AfterSaveDataEvent;
                shortCut.Show(this.DockPanel);
            }
        }
        void shortCut_AfterSaveDataEvent(object sender, bool isSave, List<MenuData> shortCutTable)
        {
            FillTree(shortCutTable);
        }
       
    }
}