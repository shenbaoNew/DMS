using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using DMS.DataClass.Pub;

namespace DMS
{
    public partial class frmMenu : BaseContentsForm
    {
        public event AfterMenuTreeClickEventHandler AfterMenuTreeClickEvent;
        public event AfterConfirmEventHandler AfterFormCloseEvent;
        public event AfterContentMenuClickEventHandler AfterContentMenuClickEvent;
        public event AfterContentMenuClickJumpToEventHandler AfterContentMenuClickJumpToEvent;

        private XmlNodeList treeNode;
        private List<XmlNode> nodeList;

        public frmMenu()
        {
            InitializeComponent();
            GetTreeData();
        }

        public void GetTreeData()
        {
            try
            {
                XmlDocument xml = XmlHelper.GetXmlDocument("menu.xml", true);
                GetNodesByPath(@"DMS/Menus", xml);

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示");
            }
        }

        public void GetNodesByPath(string path, XmlDocument xml)
        {
            XmlNode node = xml.SelectSingleNode(path);
            if (node == null)
                return;

            this.treeNode = node.ChildNodes;
            if (this.treeNode != null && this.treeNode.Count > 0)
            {
                nodeList = new List<XmlNode>();
                foreach (XmlNode item in this.treeNode)
                    nodeList.Add(item);

                FillTree(null,"0");
            }
        }

        public void FillTree(TreeNode parentNode,string parent)
        {
            List<XmlNode> list = GetNodesByParent(parent);
            if (list == null || list.Count <= 0)
                return;

            this.AfterContentMenuClickJumpToEvent -= new AfterContentMenuClickJumpToEventHandler(menu_AfterContentMenuClickJumpToEvent);
            this.AfterContentMenuClickJumpToEvent += new AfterContentMenuClickJumpToEventHandler(menu_AfterContentMenuClickJumpToEvent);

            foreach (XmlNode item in list)
            {
                TreeNode node = new TreeNode();
                node.Text = item.InnerText;
                if (item.InnerText == "-")
                    node.Text = "——";
                node.Tag = item;
                string isLeaf = item.Attributes["IsLeaf"].Value;
                if (isLeaf == "0")
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    if (item.Attributes["Code"].Value.ToString() == "030000")  //add by shenbao on 20150806
                    {
                        node.Expand();
                    }
                }
                else
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    if (item.InnerText != "-")
                    {
                        MenuData me = PubContext.Menus.Find(c => c.Code == item.Attributes["Code"].Value.ToString());
                        if (me != null)
                            node.ContextMenuStrip = CreateContentMenuStrip(me);
                    }
                }
                if (parentNode == null)
                    this.tvMenu.Nodes.Add(node);
                else
                    parentNode.Nodes.Add(node);

                string subParent = item.Attributes["Code"].Value;
                List<XmlNode> temp = GetNodesByParent(subParent);
                FillTree(node, subParent);
            }
        }

        public List<XmlNode> GetNodesByParent(string parent)
        {
            if (nodeList == null)
                return null;

            List<XmlNode> result = new List<XmlNode>();

            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes["Parent"].Value == parent)
                    result.Add(node);
            }

            return result.OrderBy(c => Convert.ToInt32(c.Attributes["Order"].Value.ToString())).ToList();
        }

        /// <summary>
        /// 获取当前组织节点
        /// </summary>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        public static XmlNode GetCurrentOrgNode(string orgCode, XmlDocument xml)
        {
            XmlNode org = null;

            if (xml == null)
                return org;

            XmlNodeList orgNodes = xml.SelectNodes(@"Config/Org");
            if (orgNodes != null && orgNodes.Count > 0)
            {
                foreach (XmlNode item in orgNodes)
                {
                    if (item.Attributes != null && item.Attributes.Count > 0
                        && item.Attributes["Code"] != null && item.Attributes["Code"].Value == orgCode)
                    {
                        org = item;
                        break;
                    }
                }
            }

            return org;
        }

        private void tvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Nodes.Count == 0)
            {
                XmlNode node = e.Node.Tag as XmlNode;
                string fullName = node.Attributes["FullName"].Value;
                string formText = node.InnerText;
                if (AfterMenuTreeClickEvent != null)
                    AfterMenuTreeClickEvent(this, fullName, -1, formText);
            }
        }

        private void tvMenu_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            e.Node.ImageIndex = 0;
        }

        private void tvMenu_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            e.Node.ImageIndex = 1;
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AfterFormCloseEvent != null)
                AfterFormCloseEvent(sender, true);
        }

        public ContextMenuStrip CreateContentMenuStrip(object menuTag)
        {

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem TabPagesToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem WindowsToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator line1 = new ToolStripSeparator();
            ToolStripMenuItem CreateShortCutToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem DeleteShortCutToolStripMenuItem = new ToolStripMenuItem();
            // 
            // TabPagesToolStripMenuItem
            // 
            TabPagesToolStripMenuItem.Name = "TabPagesToolStripMenuItem";
            TabPagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            TabPagesToolStripMenuItem.Tag = menuTag;
            TabPagesToolStripMenuItem.Text = "页签显示";
            //TabPagesToolStripMenuItem.Click += new EventHandler(TabPagesToolStripMenuItem_Click);
            // 
            // WindowsToolStripMenuItem
            // 
            WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem";
            WindowsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            WindowsToolStripMenuItem.Tag = menuTag;
            WindowsToolStripMenuItem.Text = "窗体显示";
            //WindowsToolStripMenuItem.Click += new EventHandler(WindowsToolStripMenuItem_Click);
            // 
            // line1
            // 
            line1.Name = "line1";
            // 
            // CreateShortCutToolStripMenuItem
            // 
            CreateShortCutToolStripMenuItem.Name = "CreateShortCutToolStripMenuItem";
            CreateShortCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            CreateShortCutToolStripMenuItem.Tag = menuTag;
            CreateShortCutToolStripMenuItem.Text = "创建快捷方式";
            CreateShortCutToolStripMenuItem.Click += new EventHandler(CreateShortCutToolStripMenuItem_Click);

            //删除快捷方式
            DeleteShortCutToolStripMenuItem.Name = "DeleteShortCutToolStripMenuItem";
            DeleteShortCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            DeleteShortCutToolStripMenuItem.Tag = menuTag;
            DeleteShortCutToolStripMenuItem.Text = "删除快捷方式";
            DeleteShortCutToolStripMenuItem.Click += new EventHandler(DeleteShortCutToolStripMenuItem_Click);

            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //TabPagesToolStripMenuItem,
            //WindowsToolStripMenuItem,
            //line1,
            CreateShortCutToolStripMenuItem,
            DeleteShortCutToolStripMenuItem});
            contextMenuStrip.Name = "contextMenuStrip";
            return contextMenuStrip;
        }

        void CreateShortCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfterContentMenuClickJumpToEvent(sender, 3);
        }

        private void menu_AfterContentMenuClickJumpToEvent(object sender, int ClickID)
        {
            ToolStripMenuItem menu = ((ToolStripMenuItem)sender);
            if (menu.Tag != null)
            {
                MenuData item = (MenuData)menu.Tag;
                string code = item.Code;
                string FullClassName = item.MenuClassName;
                string FormText = item.Name;
                AfterContentMenuClickEvent(sender, ClickID, code, FullClassName, -1, FormText);

            }
        }

        void DeleteShortCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfterContentMenuClickJumpToEvent(sender, 4);
        }

        private void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Nodes.Count == 0)
            {
                XmlNode node = e.Node.Tag as XmlNode;
                string fullName = node.Attributes["FullName"].Value;
                string formText = node.InnerText;
                if (AfterMenuTreeClickEvent != null)
                    AfterMenuTreeClickEvent(this, fullName, -1, formText);
            }
        }
    }
}
