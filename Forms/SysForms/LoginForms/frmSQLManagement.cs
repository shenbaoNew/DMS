using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMS.Controls;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;


namespace DMS.Forms
{
    public partial class frmSQLManagement : BaseForm
    {
        private QueryBuilder builder;
        private QueryDesignerControl designerControl;
        private int QueryControlCount = 0;
        private Dictionary<string, QueryBuilder> buildes = new Dictionary<string, QueryBuilder>();
        private string connecFlag = string.Empty;

        public QueryBuilder CurrentBuilder
        {
            get 
            {
                if (buildes.ContainsKey(connecFlag))
                    return buildes[connecFlag];

                return null;
            }
        }

        public frmSQLManagement()
        {
            InitializeComponent();
            connecFlag = SqlConnectionManager.CurrentFlag;
            CreateConnectNode();
        }

        private void CreateConnectNode()
        {
            if (string.IsNullOrEmpty(connecFlag))
                return;

            StartProgress("正在连接数据库，请稍后...");
            try
            {
                connecFlag = SqlConnectionManager.CurrentFlag;
                if (!buildes.ContainsKey(connecFlag))
                {
                    builder = new QueryBuilder(new OleDbSchema());
                    buildes.Add(SqlConnectionManager.CurrentFlag, builder);
                    CurrentBuilder.GroupBy = false;
                    CurrentBuilder.QueryFields.ListChanged += QueryFields_ListChanged;
                    CreateDBConnection();
                    designerControl = new QueryDesignerControl(CurrentBuilder);
                    designerControl.AfterSelectFinished += new AfterSelectFinishedItemEventHandler(designerControl_AfterSelectFinished);
                }

                EndProgress();
                SetNodeSeleced();
                
            }
            catch
            {
                EndProgress();
            }
        }

        private void SetNodeSeleced()
        {
            foreach (TreeNode node in _treeTables.Nodes)
                if (node.Text == connecFlag)
                {
                    _treeTables.SelectedNode = node;
                    _treeTables.SelectedNode.Checked = true;
                    break;
                }
        }

        private void CreateDBConnection()
        {
            if (SqlConnectionManager.CurrentConnection == null)
                return;
            CurrentBuilder.ConnectionString = SqlConnectionManager.CurrentConnection.ConnectionString;
            UpdateTableTree();
        }
       
        // update SQL statement when query field list changes
        void QueryFields_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateSqlDisplay();
        }
        // update table tree to reflect new connection string
        void UpdateTableTree()
        {
            // initialize table tree
            if (SqlConnectionManager.CurrentConnection == null)
                return;

            TreeNodeCollection firstnodes = _treeTables.Nodes;
            TreeNode onenode = new TreeNode(SqlConnectionManager.CurrentFlag);
            onenode.Tag = new CustSqlConnection(SqlConnectionManager.CurrentConnection);
            firstnodes.Add(onenode);

            TreeNodeCollection nodes = onenode.Nodes;

            TreeNode usSqls = new TreeNode("常用查询", 0, 0);
            GetUserQuery(usSqls);

            var ndTables = new TreeNode("表", 0, 0);
            var ndViews = new TreeNode("视图", 1, 1);

            // populate using current schema
            if (CurrentBuilder.Schema != null)
            {
                // populate the tree
                _treeTables.BeginUpdate();
                foreach (DataTable dt in CurrentBuilder.Schema.Tables)
                {
                    // create new node, save table in tag property
                    var node = new TreeNode(dt.TableName);
                    node.Tag = dt;

                    // add new node to appropriate parent
                    switch (OleDbSchema.GetTableType(dt))
                    {
                        case TableType.Table:
                            ndTables.Nodes.Add(node);
                            node.ImageIndex = node.SelectedImageIndex = 0;
                            AddDataColumns(node, dt);
                            break;
                        case TableType.View:
                            ndViews.Nodes.Add(node);
                            node.ImageIndex = node.SelectedImageIndex = 1;
                            AddDataColumns(node, dt);
                            break;
                    }
                }

                // add non-empty nodes to tree
                foreach (TreeNode nd in new TreeNode[] { usSqls, ndTables, ndViews })
                {
                    if (nd.Nodes.Count > 0)
                    {
                        nd.Text = string.Format("{0} ({1})", nd.Text, nd.Nodes.Count);
                        nodes.Add(nd);
                    }
                }

                // expand tables node
                ndTables.Expand();

                // done
                _treeTables.EndUpdate();
            }
        }

        public void GetUserQuery(TreeNode node)
        {
            node.Nodes.Add(new TreeNode("查询菜单名称", 0, 0));
            node.Nodes.Add(new TreeNode("新增价格组", 0, 0));
            node.Nodes.Add(new TreeNode("新增损耗标准", 0, 0));
            node.Nodes.Add(new TreeNode("备份数据库", 0, 0));
            node.Nodes.Add(new TreeNode("修改CRM公司区域", 0, 0));
            node.Nodes.Add(new TreeNode("修改标识列", 0, 0));
            node.Nodes.Add(new TreeNode("初始化MMS admin密码", 0, 0));
            node.Nodes.Add(new TreeNode("查询月度收购汇总", 0, 0));
            node.Nodes.Add(new TreeNode("查询备份丢失数据", 0, 0));

            node.Nodes[0].Tag = SqlConnectionManager.SearchMenuName;
            node.Nodes[1].Tag = SqlConnectionManager.AddPriceGroup;
            node.Nodes[2].Tag = SqlConnectionManager.AddLossStandard;
            node.Nodes[3].Tag = SqlConnectionManager.BackUpDatabase;
            node.Nodes[4].Tag = SqlConnectionManager.UpdateCompanyArea;
            node.Nodes[5].Tag = SqlConnectionManager.UpdateIdentityColumn;
            node.Nodes[6].Tag = SqlConnectionManager.ResetMMSPassword;
            node.Nodes[7].Tag = SqlConnectionManager.SearchMonthPurchase;
            node.Nodes[8].Tag = SqlConnectionManager.SearchLossAppend;
        }

        void AddDataColumns(TreeNode node, DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                var field = node.Nodes.Add(col.ColumnName);
                field.Tag = col;
                field.ImageIndex = 2;
                field.SelectedImageIndex = 2;
            }
        }

        //// update state of the grid columns
        void UpdateGridColumns()
        {
            designerControl.UpdateGridColumns();
        }

        // replace grid columns with ones with better editors
        void FixGridColumns()
        {
            designerControl.FixGridColumns();
        }

        // add tables or columns to the sql statement
        void AddField(object element)
        {
            var dt = element as DataTable;
            if (dt != null)
            {
                AddTable(dt);
            }
            var dc = element as DataColumn;
            if (dc != null)
            {
                AddColumn(dc);
            }
        }
        void AddTable(DataTable dt)
        {
            var field = new QueryField(dt);
            CurrentBuilder.QueryFields.Add(field);
            SelectField(field);
        }
        void AddColumn(DataColumn dc)
        {
            var field = new QueryField(dc);
            CurrentBuilder.QueryFields.Add(field);
            SelectField(field);
        }

        // select a field on the grid
        void SelectField(QueryField field)
        {
            designerControl.SelectField(field);
        }

        // find a node on the tree
        TreeNode FindNode(string text)
        {
            return FindNode(_treeTables.Nodes, text);
        }
        TreeNode FindNode(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                // check this node
                var dt = node.Tag as DataTable;
                if (dt != null && dt.TableName == text)
                {
                    return node;
                }

                // and check child nodes
                var child = FindNode(node.Nodes, text);
                if (child != null)
                {
                    return child;
                }
            }

            // not found...
            return null;
        }

        // update SQL display
        void UpdateSqlDisplay()
        {
            if (designerControl != null)
            {

                designerControl.UpdateSqlDisplay();
                designerControl.UpdateGridColumns();
            }
        }

        //------------------------------------------------------------------------------
        #region ** tree context-menu event handlers

        void _mnuTree_Opening(object sender, CancelEventArgs e)
        {
            // get node that was clicked
            Point pt = _treeTables.PointToClient(Control.MousePosition);
            TreeNode nd = _treeTables.GetNodeAt(pt);
            DataTable dt = nd == null ? null : nd.Tag as DataTable;

            // select node
            if (nd != null)
            {
                _treeTables.SelectedNode = nd;
            }

            // make sure this is a table node
            if (dt == null)
            {
                e.Cancel = true;
                return;
            }

            // populate related tables menu
            _mnuRelatedTables.DropDownItems.Clear();
            if (nd != null && nd.Tag is DataTable)
            {
                var list = new List<string>();
                foreach (DataRelation dr in CurrentBuilder.Schema.Relations)
                {
                    if (dr.ParentTable == dt && !list.Contains(dr.ChildTable.TableName))
                    {
                        list.Add(dr.ChildTable.TableName);
                    }
                    else if (dr.ChildTable == dt && !list.Contains(dr.ParentTable.TableName))
                    {
                        list.Add(dr.ParentTable.TableName);
                    }
                }
                list.Sort();
                foreach (string tableName in list)
                {
                    if (FindNode(tableName) != null)
                    {
                        _mnuRelatedTables.DropDownItems.Add(tableName);
                    }
                }
            }
        }
        void _mnuHideThisTable_Click(object sender, EventArgs e)
        {
            var node = _treeTables.SelectedNode;
            if (node != null)
            {
                _treeTables.Nodes.Remove(node);
            }
        }
        void _mnuRelatedTables_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var node = FindNode(e.ClickedItem.Text);
            if (node != null)
            {
                _treeTables.SelectedNode = node;
                node.Expand();
            }
        }

        #endregion

        private void _mnuShowAllTables_Click(object sender, EventArgs e)
        {
            UpdateTableTree();
        }

        private void _mnuRelatedTables_Click(object sender, EventArgs e)
        {

        }

        private void btnNewDesigner_Click(object sender, EventArgs e)
        {
            CreateDesignerControl();
        }

        private void CreateDesignerControl()
        {
            DevComponents.DotNetBar.SuperTabControlPanel controlPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            DevComponents.DotNetBar.SuperTabItem item = new DevComponents.DotNetBar.SuperTabItem();

            controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            controlPanel.Name = "DesignerControl";
            controlPanel.TabItem = item;
            controlPanel.Padding = new System.Windows.Forms.Padding(2);
            controlPanel.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(248)))));
            item.AttachedControl = controlPanel;
            item.GlobalItem = false;
            item.Name = "DesignerControl";
            item.Text = "设计查询条件";
            if (!this.superTabControl.Tabs.Contains("DesignerControl"))
            {
                if (designerControl.IsDisposed)
                {
                    CurrentBuilder.QueryFields.Clear();
                    designerControl = new QueryDesignerControl(CurrentBuilder);
                    designerControl.AfterSelectFinished += new AfterSelectFinishedItemEventHandler(designerControl_AfterSelectFinished);
                }
                designerControl.Dock = DockStyle.Fill;
                designerControl.QueryBuilder = CurrentBuilder;
                controlPanel.Controls.Add(designerControl);
                this.superTabControl.Controls.Add(controlPanel);
                this.superTabControl.Tabs.Add(item);
                this.superTabControl.SelectedTab = item;
                this.btnNewDesigner.Visible = false;
            }
        }

        void designerControl_AfterSelectFinished(object sender, bool isSave, string tobeKillDate,bool isExcute)
        {
            if (!string.IsNullOrEmpty(tobeKillDate))
            {
                QueryControlCount++;
                string controlName = "QueryControl" + QueryControlCount.ToString();
                string caption = "查询" + QueryControlCount.ToString();
                string connectionString = this.CurrentBuilder.ConnectionString;
                CreateQueryControl(controlName, caption, connectionString, tobeKillDate,isExcute);
            }
        }
        private void CreateQueryControl(string controlName, string caption, string connectionString, string sqlString,bool isExcute)
        {
            DevComponents.DotNetBar.SuperTabControlPanel controlPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            DevComponents.DotNetBar.SuperTabItem item = new DevComponents.DotNetBar.SuperTabItem();
            QueryResultControl resultControl = new QueryResultControl(connectionString, sqlString,isExcute);
            controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            controlPanel.Name = controlName;
            controlPanel.TabItem = item;
            controlPanel.Padding = new System.Windows.Forms.Padding(2);
            controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(248)))));
         
            item.AttachedControl = controlPanel;
            item.GlobalItem = false;
            item.Name = controlName;
            item.Text = caption;
            if (!this.superTabControl.Tabs.Contains(controlName))
            {
                resultControl.Dock = DockStyle.Fill;
                resultControl.DisplayText = SqlConnectionManager.SQLConnList[connecFlag].DisplayText;
                controlPanel.Controls.Add(resultControl);
                this.superTabControl.Controls.Add(controlPanel);
                this.superTabControl.Tabs.Add(item);
                this.superTabControl.SelectedTab = item;
            }
        }
        private void CreateSqlCompressControl(string controlName, string caption)
        {
            SqlCompressControl resultControl = new SqlCompressControl();
            CreateTableControl(controlName, caption, resultControl);
        }
        private void CreateRemoveHistoryDataControl(string controlName, string caption)
        {
            RemoveHistoryDataControl resultControl = new RemoveHistoryDataControl();
            CreateTableControl(controlName, caption, resultControl);
        }
        private void CreateDBReIndexControl(string controlName, string caption)
        {
            CreateDBReIndexControl resultControl = new CreateDBReIndexControl();
            CreateTableControl(controlName, caption, resultControl);
        }
        private void CreateTableControl(string controlName, string caption, Control resultControl)
        {
            if (!this.superTabControl.Tabs.Contains(controlName))
            {
                DevComponents.DotNetBar.SuperTabControlPanel controlPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
                DevComponents.DotNetBar.SuperTabItem item = new DevComponents.DotNetBar.SuperTabItem();
                controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                controlPanel.Name = controlName;
                controlPanel.TabItem = item;
                controlPanel.Padding = new System.Windows.Forms.Padding(2);
                controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(248)))));
         
                item.AttachedControl = controlPanel;
                item.GlobalItem = false;
                item.Name = controlName;
                item.Text = caption;

                resultControl.Dock = DockStyle.Fill;
                controlPanel.Controls.Add(resultControl);
                this.superTabControl.Controls.Add(controlPanel);
                this.superTabControl.Tabs.Add(item);
                this.superTabControl.SelectedTab = item;
            }
        }
        private void _treeTables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == _treeTables.SelectedNode &&
               e.Node.Tag is DataColumn)
            {
                AddField(e.Node.Tag);
            }
        }
        private void selectTop1000MenuItem_Click(object sender, EventArgs e)
        {
            string tableName = _treeTables.SelectedNode.Text.Trim();
            if (!string.IsNullOrEmpty(tableName))
            {
                QueryControlCount++;
                string controlName = "QueryControl" + QueryControlCount.ToString();
                string caption = "查询" + QueryControlCount.ToString();
                string connectionString = this.CurrentBuilder.ConnectionString;
                CreateQueryControl(controlName, caption, connectionString, "SELECT TOP(1000) * FROM " + tableName,true);
            }
        }
        private void superTabControl_TabRemoved(object sender, DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs e)
        {
            if (e.Tab.Name.Trim() == "DesignerControl")
            {
                this.btnNewDesigner.Visible = true;
            }
        }

        private void btnNewQuery_Click(object sender, EventArgs e)
        {
            if (_treeTables.SelectedNode != null)
            {
                string tableName = _treeTables.SelectedNode.Text.Trim();
                string sqlString = "SELECT TOP(1000) * FROM " + tableName;
                QueryControlCount++;
                string controlName = "QueryControl" + QueryControlCount.ToString();
                string caption = "查询" + QueryControlCount.ToString();
                string connectionString = this.CurrentBuilder.ConnectionString;
                if (_treeTables.SelectedNode.Level > 0)
                {
                    if (_treeTables.SelectedNode.Tag == null)
                        CreateQueryControl(controlName, caption, connectionString, string.Empty, false);
                    else
                    {
                        if (_treeTables.SelectedNode.Tag is DataTable)
                            CreateQueryControl(controlName, caption, connectionString, sqlString, true);
                        else// if (_treeTables.SelectedNode.Tag is string)
                            CreateQueryControl(controlName, caption, connectionString, _treeTables.SelectedNode.Tag.ToString(), false);
                    }
                }
                else
                {
                    CreateQueryControl(controlName, caption, connectionString, string.Empty, false);
                }
            }
        }

        private void SqlCompressMenuItem_Click(object sender, EventArgs e)
        {
            string controlName = "SqlCompressControl";
            string caption = "压缩数据库";
            CreateSqlCompressControl(controlName, caption);
        }

        private void ReCreateDBReIndexMenuItem_Click(object sender, EventArgs e)
        {
            string controlName = "CreateDBReIndexControl";
            string caption = "重建数据库索引";
            CreateDBReIndexControl(controlName, caption);
        }

        private void RemoveHistoryDataMenuItem_Click(object sender, EventArgs e)
        {
            string controlName = "RemoveHistoryDataControl";
            string caption = "转移历史数据";
            CreateRemoveHistoryDataControl(controlName, caption);
        }

        private void TSM_AddNewConn_Click(object sender, EventArgs e)
        {
            frmSqlLogin login = new frmSqlLogin();
            login.AfterConnected += new AfterConfirmEventHandler(login_AfterConnected);
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                if (login.AfterConnected != null)
                {
                    login.AfterConnected(login, true);
                }
            }
            
        }

        void login_AfterConnected(object serder, bool flag)
        {
            if (flag)
            {
                CreateConnectNode();
            }
        }

        private void _treeTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_treeTables.SelectedNode != null)
            {
                TreeNode parentNode = SelectParentNode(_treeTables.SelectedNode, 0);
                if (parentNode != null)
                {
                    CustSqlConnection conn = parentNode.Tag as CustSqlConnection;
                    if (conn != null)
                    {
                        connecFlag = conn.ConnecFlag;
                    }
                }
            }
        }

        private TreeNode SelectParentNode(TreeNode node, int level)
        {
            if (node == null || node.Level == level)
                return node;

            else
                return SelectParentNode(node.Parent, level);
        }

        private void TSM_CloseNewConn_Click(object sender, EventArgs e)
        {
            if (_treeTables.Nodes.Count <= 0)
                return;
            if (_treeTables.SelectedNode == null)
                return;

            TreeNode node = SelectParentNode(_treeTables.SelectedNode, 0);
            if (node != null)
            {
                _treeTables.Nodes.Remove(node);
                SqlConnectionManager.RemoveConnection(node.Text);

                if (buildes.ContainsKey(node.Text))
                    buildes.Remove(node.Text);
            }
        }
    }
}
