using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using YY.Methods;
using DMS.DataClass.Pub;
using DMS.DataClass.Systems.User;

namespace DMS.Forms
{
    public partial class frmManageShorCut : BaseForm
    {
        public event AfterConfirmUnMatchEventHandler AfterSaveDataEvent;       
        private Hashtable hashTreeTable;
        private DataTable sortTreeMenus;
        private BindingSource bs;
        private List<MenuData> shortCutMenus;
        private UserData user = new UserData();

        public frmManageShorCut(List<MenuData> fullMenus, List<MenuData> rightMenus, List<MenuData> shortCutMenus)
        {
            InitializeComponent();
            this.shortCutGrid.AutoGenerateColumns = false;
            this.shortCutMenus = shortCutMenus;
            bs = new BindingSource();
            CreateTree(fullMenus, rightMenus, shortCutMenus);
            this.Menutree.ExpandAll();
        }

        #region 动态创建菜单

        private void CreateTree(List<MenuData> fullMenus, List<MenuData> rightMenus, List<MenuData> shortCutMenus)
        {
            if (PubContext.IsAdmin)
            {
                CreateTree(this.Menutree, fullMenus);
            }
            else
            {
                CreateTree(this.Menutree, rightMenus, fullMenus);
            }
            bs.DataSource = this.shortCutMenus;
            this.shortCutGrid.DataSource = bs;
            ResetControl();
        }

        private void ResetControl()
        {
            if (this.Menutree.Nodes.Count > 0)
            {
                btnToRight.Enabled = true;
            }
            else
            {
                btnToRight.Enabled = false;
            }
            if (bs.Count > 0)
            {
                btnToLeft.Enabled = true;
            }
            else
            {
                btnToLeft.Enabled = false;
            }
        }
        /// <summary>
        /// 动态创建树
        /// </summary>
        private void CreateTree(TreeView treeView, List<MenuData> treeData)
        {
            if ((null != treeData) && (treeData.Count > 0))
            {
                int rowCount = treeData.Count;
                treeView.BeginUpdate();
                hashTreeTable = new Hashtable(rowCount);
                treeView.Nodes.Clear();
                if (rowCount > 0)
                {
                    foreach (MenuData row in treeData)
                    {
                        string parentCode = row.ParentCode.ToString().Trim();
                        TreeNode parentNode = FindParentNode(parentCode);
                        if (parentNode != null)
                        {
                            parentNode.ImageIndex = 0;
                            parentNode.SelectedImageIndex = 0;

                            TreeNode newTreeNode = new TreeNode();
                            string showContent = row.Name.Trim();
                            if ("-" != showContent)
                            {
                                newTreeNode.Text = showContent;
                                newTreeNode.ImageIndex = 2;
                                newTreeNode.SelectedImageIndex = 2;
                                newTreeNode.Tag = row;
                                parentNode.Nodes.Add(newTreeNode);
                                string code = row.Code.Trim();
                                hashTreeTable.Add(code, newTreeNode);
                            }
                            else
                            {
                                newTreeNode.Text = "——";
                                newTreeNode.ImageIndex = 2;
                                newTreeNode.SelectedImageIndex = 2;
                                newTreeNode.Tag = null;
                                parentNode.Nodes.Add(newTreeNode);
                                string code = row.Code.Trim();
                                hashTreeTable.Add(code, newTreeNode);
                            }
                        }
                        else
                        {
                            if (parentCode == "0")
                            {
                                TreeNode newTreeNode = new TreeNode();
                                string showContent = row.Name.Trim();
                                if ("-" != showContent)
                                {
                                    newTreeNode.Text = showContent;
                                    newTreeNode.ImageIndex = 2;
                                    newTreeNode.SelectedImageIndex = 2;
                                    newTreeNode.Tag = row;
                                    treeView.Nodes.Add(newTreeNode);
                                    string code = row.Code.Trim();
                                    hashTreeTable.Add(code, newTreeNode);
                                }
                            }
                        }
                    }
                    treeView.EndUpdate();

                }
                else
                {

                }
            }

        }

        private void CreateTree(TreeView rightTree, List<MenuData> fullMenus, List<MenuData> rightsMenus)
        {
            rightTree.Nodes.Clear();
            hashTreeTable = new Hashtable(fullMenus.Count);
            sortTreeMenus = CreateSortTable();
            foreach (MenuData row in rightsMenus)
            {
                string code = row.Code.Trim();
                string text = row.Name.Trim();
                string parentCode = row.ParentCode.Trim();
                string showOrder = row.Order.ToString().Trim();
                DataRow sortRow = sortTreeMenus.NewRow();
                sortRow["Code"] = code;
                sortRow["ParentCode"] = parentCode;
                sortRow["ShowOrder"] = showOrder;
                sortTreeMenus.Rows.Add(sortRow);

                TreeNode newTreeNode = new TreeNode();
                if (text == "-")
                    text = "——";
                newTreeNode.Text = text;
                newTreeNode.ImageIndex = 2;
                newTreeNode.SelectedImageIndex = 2;
                newTreeNode.Tag = row;
                if (!hashTreeTable.ContainsKey(code))
                    hashTreeTable.Add(code, newTreeNode);

                CreateParentNode(rightTree, newTreeNode, parentCode, fullMenus, hashTreeTable);

            }
        }

        private void CreateParentNode(TreeView rightTree, TreeNode node, string parentCode, List<MenuData> fullMenus, Hashtable hashTable)
        {
            List<MenuData> list = fullMenus.Where(c => c.ParentCode == parentCode).ToList();
            if (list.Count > 0)
            {
                MenuData row = list[0];
                TreeNode parentNode = FindParentNode(parentCode, hashTable);
                if (parentNode == null)
                {
                    string text = row.Name.Trim();
                    string code = row.Code.Trim();
                    string parentID = row.ParentCode.Trim();
                    string showOrder = row.Order.ToString().Trim();
                    DataRow sortRow = sortTreeMenus.NewRow();
                    sortRow["Code"] = code;
                    sortRow["ParentCode"] = parentID;
                    sortRow["ShowOrder"] = showOrder;
                    sortTreeMenus.Rows.Add(sortRow);

                    TreeNode newTreeNode = new TreeNode();

                    if (text == "-")
                        text = "——";
                    newTreeNode.Text = text;
                    newTreeNode.ImageIndex = 2;
                    newTreeNode.SelectedImageIndex = 2;
                    newTreeNode.Tag = row;
                    newTreeNode.Nodes.Add(node);
                    hashTable.Add(parentCode, newTreeNode);
                    CreateParentNode(rightTree, newTreeNode, parentID, fullMenus, hashTable);
                }
                else
                {
                    parentNode.ImageIndex = 0;
                    parentNode.SelectedImageIndex = 0;
                    parentNode.ContextMenuStrip = null;
                    InsertChildNode(parentNode, node);
                    string parentID = row.ParentCode.Trim();
                    CreateParentNode(rightTree, parentNode, parentID, fullMenus, hashTable);
                }
            }
            else
            {
                InsertChildNode(rightTree, node);

            }
        }
        private TreeNode FindParentNode(string parentID, Hashtable hashTable)
        {
            TreeNode node = null;
            try
            {
                node = (TreeNode)hashTable[parentID];
            }
            catch
            {

            }
            return node;
        }
        private TreeNode FindParentNode(string parentCode)
        {
            TreeNode node = null;
            try
            {
                node = (TreeNode)hashTreeTable[parentCode];
            }
            catch
            {

            }
            return node;
        }
        private void FindParentNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Expand();
                FindParentNode(node.Parent);
            }
        }
        private void InsertChildNode(TreeNode parentNode, TreeNode childNode)
        {
            if (!parentNode.Nodes.Contains(childNode))
            {
                MenuData childRow = (MenuData)childNode.Tag;
                string parentId = childRow.ParentCode;
                string showOrder = childRow.Order.ToString();
                DataView view = sortTreeMenus.Copy().DefaultView;
                view.RowFilter = "ParentCode=\"" + parentId + "\" AND  ShowOrder<" + showOrder + "";
                int index = view.Count;
                parentNode.Nodes.Insert(index, childNode);
            }
        }
        private void InsertChildNode(TreeView parentNode, TreeNode childNode)
        {
            if (!parentNode.Nodes.Contains(childNode))
            {
                childNode.ContextMenuStrip = null;
                DataRow childRow = (DataRow)childNode.Tag;
                string showOrder = childRow["ShowOrder"].ToString().Trim();
                DataView view = sortTreeMenus.Copy().DefaultView;
                view.RowFilter = "ParentCode=\"0\" AND  ShowOrder<" + showOrder + "";
                int index = view.Count;
                parentNode.Nodes.Insert(index, childNode);

            }
        }
        private DataTable CreateSortTable()
        {
            DataTable tmpdt = new DataTable("SortTable");
            DataColumn column = new DataColumn("Code", System.Type.GetType("System.String"));
            tmpdt.Columns.Add(column);
            column = new DataColumn("ParentCode", System.Type.GetType("System.String"));
            tmpdt.Columns.Add(column);
            column = new DataColumn("ShowOrder", System.Type.GetType("System.Int32"));
            tmpdt.Columns.Add(column);
            return tmpdt;
        }
        #endregion

        private void ToRight()
        {
            TreeNode node = this.Menutree.SelectedNode;
            if (node != null && node.Nodes.Count == 0)
            {
                if (node.Tag != null)
                {
                    try
                    {
                        MenuData row = (MenuData)node.Tag;
                        string menuCode = row.Code.Trim();
                        List<MenuData> list = shortCutMenus.Where(c => c.Code == menuCode).ToList();
                        if (list.Count == 0)
                        {
                            MenuData shortCutRow = new MenuData();
                            shortCutRow.Code = row.Code;
                            shortCutRow.Name = row.Name;
                            shortCutRow.MenuDesc = row.MenuDesc;
                            shortCutRow.MenuClassName = row.MenuClassName;
                            shortCutRow.Order = row.Order;
                            shortCutMenus.Add(shortCutRow);
                            bs.DataSource = null;
                            bs.DataSource = shortCutMenus;
                            shortCutGrid.DataSource = bs;
                        }
                        else
                        {
                            DialogBox.ShowError("该菜单快捷方式已经存在。");
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                DialogBox.ShowError("父级菜单不能创建快捷方式。");
            }
            ResetControl();
        }
        private void ToLeft()
        {
            if (bs != null && bs.DataSource != null)
            {
                bs.RemoveCurrent();
            }
            ResetControl();
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            ToRight();
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            ToLeft();
        }

        private void Menutree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ToRight();
        }
        private void SaveData()
        {
            bool result = user.InsertShortCust(shortCutMenus);
            if (result)
            {
                if (AfterSaveDataEvent != null)
                {
                    AfterSaveDataEvent(this, true, shortCutMenus);
                }
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void shortCutGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ToLeft();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
