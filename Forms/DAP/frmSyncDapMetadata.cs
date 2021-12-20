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
using DMS.Helper;
using MySql.Data.MySqlClient;

namespace DMS.Forms
{
    public partial class frmSyncDapMetadata : BaseForm
    {
        private QueryBuilder builder;
        private QueryDesignerControl designerControl;
        private int QueryControlCount = 0;
        private Dictionary<string, QueryBuilder> buildes = new Dictionary<string, QueryBuilder>();
        private string connecFlag = string.Empty;
        private Dictionary<string, List<DataRow>> _tableColumnMetadata = new Dictionary<string, List<DataRow>>();
        private Dictionary<string, DataRow> _tableMetadata = new Dictionary<string, DataRow>();

        public QueryBuilder CurrentBuilder
        {
            get 
            {
                if (buildes.ContainsKey(connecFlag))
                    return buildes[connecFlag];

                return null;
            }
        }

        public frmSyncDapMetadata() {
            InitializeComponent();
        }

        private void CreateConnectNode() {
            StartProgress("正在连接数据库，请稍后...");
            try {
                CreateDBConnection();
                designerControl = new QueryDesignerControl(CurrentBuilder);
                designerControl.AfterSelectFinished += new AfterSelectFinishedItemEventHandler(designerControl_AfterSelectFinished);
                
                SetNodeSeleced();

            } catch {
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
            if (PubContext.MariadbDBConnection == null)
                return;
            UpdateTableTree();
        }
       
        // update SQL statement when query field list changes
        void QueryFields_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateSqlDisplay();
        }
        // update table tree to reflect new connection string
        void UpdateTableTree() {
            // initialize table tree
            if (PubContext.MariadbDBConnection == null)
                return;

            connecFlag = PubContext.MariaDBServer + "(" + PubContext.MariaDBLoginUser + "," + PubContext.MariaDBDataBase + ")";
            TreeNodeCollection firstnodes = _treeTables.Nodes;
            TreeNode onenode = new TreeNode(connecFlag);
            onenode.Tag = new CustSqlConnection(SqlConnectionManager.CurrentConnection);
            firstnodes.Add(onenode);

            TreeNodeCollection nodes = onenode.Nodes;

            TreeNode usSqls = new TreeNode("常用查询", 0, 0);
            GetUserQuery(usSqls);

            var ndTables = new TreeNode("表", 0, 0);
            var ndViews = new TreeNode("视图", 1, 1);

            Dictionary<string, List<string>> tables = GetTableSchema();

            // populate the tree
            _treeTables.BeginUpdate();
            foreach (var key in tables.Keys.OrderBy(c=>c)) {
                // create new node, save table in tag property
                var node = new TreeNode(key);
                node.Tag = "table";

                // add new node to appropriate parent
                ndTables.Nodes.Add(node);
                node.ImageIndex = node.SelectedImageIndex = 0;
                AddDataColumns(node, tables[key]);
            }

            // add non-empty nodes to tree
            foreach (TreeNode nd in new TreeNode[] { usSqls, ndTables, ndViews }) {
                if (nd.Nodes.Count > 0) {
                    nd.Text = string.Format("{0} ({1})", nd.Text, nd.Nodes.Count);
                    nodes.Add(nd);
                }
            }

            // expand tables node
            ndTables.Expand();

            // done
            _treeTables.EndUpdate();
        }

        public Dictionary<string, List<string>> GetTableSchema() {
            string sql = string.Format("SELECT * FROM information_schema.TABLES WHERE TABLE_SCHEMA='{0}' ORDER BY TABLE_NAME ", PubContext.MariaDBDataBase);
            MySQLHelper helper = new MySQLHelper(PubContext.MariadbDBConnection);
            DataTable tables = helper.ExecuteDataTable(sql, new MySql.Data.MySqlClient.MySqlParameter[] { });
            sql = string.Format("SELECT * FROM information_schema.CoLUMNS WHERE TABLE_SCHEMA='{0}'", PubContext.MariaDBDataBase);
            DataTable columns = helper.ExecuteDataTable(sql, new MySql.Data.MySqlClient.MySqlParameter[] { });
            Dictionary<string, List<string>> tableColumns = new Dictionary<string, List<string>>();
            foreach(DataRow item in tables.Rows) {
                _tableMetadata.Add(item["TABLE_NAME"].ToString(), item);
            }
            foreach (DataRow row  in columns.Rows) {
                List<string> cols = null;
                if(!tableColumns.TryGetValue(row["TABLE_NAME"].ToString(),out cols)) {
                    cols = new List<string>();
                    tableColumns.Add(row["TABLE_NAME"].ToString(), cols);
                    _tableColumnMetadata.Add(row["TABLE_NAME"].ToString(), new List<DataRow>());
                }
                cols.Add(row["COLUMN_NAME"].ToString());
                _tableColumnMetadata[row["TABLE_NAME"].ToString()].Add(row);
            }
            return tableColumns;
        }

        public void GetUserQuery(TreeNode node)
        {
            node.Nodes.Add(new TreeNode("查询系统日期", 0, 0));

            node.Nodes[0].Tag = "select now()";
        }

        void AddDataColumns(TreeNode node, List<string> columns)
        {
            foreach (string col in columns)
            {
                var field = node.Nodes.Add(col);
                field.Tag = "column";
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
            if (nd == null) {
                e.Cancel = true;
            }
            this._treeTables.SelectedNode = nd;
            cnstSync.Enabled = nd.Tag != null && (nd.Tag.ToString() == "table"
                || (nd.Parent != null && nd.Parent.Tag != null && nd.Parent.Tag.ToString() == "table"));
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
            this.Sync();
        }

        private void Sync() {
            TreeNode node = this._treeTables.SelectedNode;
            if (node != null && node.Tag != null) {
                if (node.Tag.ToString() == "table"||(node.Parent!=null&&node.Parent.Tag!=null&&node.Parent.Tag.ToString()== "table")) {
                    string tableName = node.Text;
                    if (node.Parent != null && node.Parent.Tag != null && node.Parent.Tag.ToString() == "table") {
                        tableName = node.Parent.Text;
                    }
                    if (!tableName.StartsWith("dw_")
                        && !tableName.StartsWith("qrtz_")) {
                        this.SyncTable(tableName);
                        this.SyncFields(tableName);

                        MessageBox.Show("同步成功");
                    } else {
                        MessageBox.Show("该表不允许同步");
                    }
                }
            }
        }

        private void SyncTable(string tableName) {
            string sql = string.Format("select table_name from dw_rdbms_tables where table_name = '{0}'", tableName);
            DataTable dt = MySQLHelper.ExecuteDataTable(PubContext.MariadbDBConnection, sql,new MySqlParameter[] { });
            if (dt.Rows.Count <= 0) {
                DataRow table = _tableMetadata[tableName];
                string displayName = table["TABLE_COMMENT"].ToString().Trim();
                displayName = displayName == "" ? tableName : displayName;
                sql = string.Format("insert into dw_rdbms_tables(table_name,table_display_name,table_description) values ('{0}','{1}','{2}')"
                    , tableName, displayName, table["TABLE_COMMENT"]);
                MySQLHelper.ExecuteNonQuery(PubContext.MariadbDBConnection, sql, new MySqlParameter[] { });
            } else {
                DataRow table = _tableMetadata[tableName];
                string displayName = table["TABLE_COMMENT"].ToString().Trim();
                displayName = displayName == "" ? tableName : displayName;
                sql = string.Format("update dw_rdbms_tables set table_display_name='{0}',table_description='{1}' where table_name='{2}'"
                                    , displayName, table["TABLE_COMMENT"], tableName);
                MySQLHelper.ExecuteNonQuery(PubContext.MariadbDBConnection, sql, new MySqlParameter[] { });
            }
        }

        private void SyncFields(string tableName) {
            using (MySqlConnection conn = new MySqlConnection(PubContext.MariadbDBConnection)) {
                MySqlTransaction tran = null;
                try {
                    conn.Open();
                    tran = conn.BeginTransaction();

                    //先删除
                    string sql = string.Format("delete from dw_rdbms_fields where TABLE_NAME = '{0}'", tableName);
                    MySQLHelper.ExecuteNonQuery(conn, CommandType.Text, sql, new MySqlParameter[] { });
                    //再新增
                    StringBuilder strb = new StringBuilder();
                    foreach (DataRow row in _tableColumnMetadata[tableName]) {
                        string isKey = row["COLUMN_KEY"].ToString() == "PRI" ? "Y" : "N";
                        string fieldType = row["COLUMN_TYPE"].ToString();
                        fieldType = fieldType.Contains("(") ? fieldType.Substring(0, fieldType.IndexOf("(")) : fieldType;
                        string fieldDisplayName = row["COLUMN_COMMENT"].ToString();
                        fieldDisplayName = fieldDisplayName == "" ? row["COLUMN_NAME"].ToString().Trim() : fieldDisplayName;
                        string statusCode = "Y";
                        string nullAble = row["IS_NULLABLE"].ToString() == "YES" ? "Y" : "N";
                        string isVersion = row["COLUMN_NAME"].ToString() == "version" ? "Y" : "N";
                        string size = fieldType.ToLower() == "varchar" ? row["CHARACTER_MAXIMUM_LENGTH"].ToString() : row["NUMERIC_PRECISION"].ToString();
                        string autoIncrement = row["EXTRA"].ToString() == "auto_increment" ? "Y" : "N";
                        sql = string.Format("insert into dw_rdbms_fields(TABLE_NAME,SEQ,FIELD_NAME,IS_KEY,FIELD_TYPE,STATUS_CODE,FIELD_DISPLAY_NAME,SCALE" +
                            ",NULLABLE,IS_VERSION,SIZE,IS_AUTO_INCREMENT) values ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')"
                            , tableName, row["ORDINAL_POSITION"], row["COLUMN_NAME"], isKey, fieldType, statusCode, fieldDisplayName, row["NUMERIC_SCALE"]
                            , nullAble, isVersion, size, autoIncrement);
                        strb.Append(sql);
                        strb.Append(";");
                        strb.Append(Environment.NewLine);
                    }
                    MySQLHelper.ExecuteNonQuery(conn, CommandType.Text, strb.ToString(), new MySqlParameter[] { });

                    tran.Commit();
                } catch (MySqlException ex) {
                    if (tran != null) tran.Rollback();
                    throw ex;
                }
            }
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
                this.btnSync.Visible = false;
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
                this.btnSync.Visible = true;
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
            frmSetDBServer login = new frmSetDBServer();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                this.CloseConnect(false);
                login_AfterConnected(this, true);
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
            this.CloseConnect(true);
        }

        private void CloseConnect(bool isRefresh) {
            if (_treeTables.Nodes.Count <= 0)
                return;

            _treeTables.Nodes.Remove(_treeTables.Nodes[0]);

            this._tableColumnMetadata.Clear();
            this._tableMetadata.Clear();
            if (!isRefresh) {
                this.connecFlag = string.Empty;
            }
        }

        private void cnstSync_Click(object sender, EventArgs e) {
            this.Sync();
        }

        private void cnstRefresh_Click(object sender, EventArgs e) {
            this.RefreshConn();
        }

        private void RefreshConn() {
            if (this._treeTables.Nodes.Count > 0) {
                this._treeTables.BeginUpdate();
                this.CloseConnect(true);
                this.UpdateTableTree();
                this._treeTables.EndUpdate();

                this._treeTables.Nodes[0].Expand();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            this.RefreshConn();
        }

        private void _treeTables_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            TreeNode nd = e.Node;
            this.btnSync.Enabled = nd.Tag != null && (nd.Tag.ToString() == "table"
               || (nd.Parent != null && nd.Parent.Tag != null && nd.Parent.Tag.ToString() == "table"));
        }
    }
}
