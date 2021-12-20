namespace DMS.Forms
{
    partial class frmSyncDapMetadata {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncDapMetadata));
            this.SqlCompressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReCreateDBReIndexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveHistoryDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDo = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSM_AddNewConn = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_CloseNewConn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSync = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._treeTables = new System.Windows.Forms.TreeView();
            this._mnuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cnstSync = new System.Windows.Forms.ToolStripMenuItem();
            this.cnstRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this._imgList = new System.Windows.Forms.ImageList(this.components);
            this.superTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._mnuTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // SqlCompressMenuItem
            // 
            this.SqlCompressMenuItem.Name = "SqlCompressMenuItem";
            this.SqlCompressMenuItem.Size = new System.Drawing.Size(146, 22);
            this.SqlCompressMenuItem.Text = "压缩数据库";
            this.SqlCompressMenuItem.Click += new System.EventHandler(this.SqlCompressMenuItem_Click);
            // 
            // ReCreateDBReIndexMenuItem
            // 
            this.ReCreateDBReIndexMenuItem.Name = "ReCreateDBReIndexMenuItem";
            this.ReCreateDBReIndexMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ReCreateDBReIndexMenuItem.Text = "重建SQL索引";
            this.ReCreateDBReIndexMenuItem.Click += new System.EventHandler(this.ReCreateDBReIndexMenuItem_Click);
            // 
            // RemoveHistoryDataMenuItem
            // 
            this.RemoveHistoryDataMenuItem.Name = "RemoveHistoryDataMenuItem";
            this.RemoveHistoryDataMenuItem.Size = new System.Drawing.Size(146, 22);
            this.RemoveHistoryDataMenuItem.Text = "转移历史数据";
            this.RemoveHistoryDataMenuItem.Click += new System.EventHandler(this.RemoveHistoryDataMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDo,
            this.toolStripDropDownButton1,
            this.btnSync,
            this.toolStripButton1,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDo
            // 
            this.btnDo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SqlCompressMenuItem,
            this.ReCreateDBReIndexMenuItem,
            this.RemoveHistoryDataMenuItem});
            this.btnDo.Image = global::DMS.Properties.Resources.db;
            this.btnDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(96, 22);
            this.btnDo.Text = "操作数据库";
            this.btnDo.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_AddNewConn,
            this.TSM_CloseNewConn});
            this.toolStripDropDownButton1.Image = global::DMS.Properties.Resources.db;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(96, 22);
            this.toolStripDropDownButton1.Text = "数据库操作";
            // 
            // TSM_AddNewConn
            // 
            this.TSM_AddNewConn.Name = "TSM_AddNewConn";
            this.TSM_AddNewConn.Size = new System.Drawing.Size(122, 22);
            this.TSM_AddNewConn.Text = "新建连接";
            this.TSM_AddNewConn.Click += new System.EventHandler(this.TSM_AddNewConn_Click);
            // 
            // TSM_CloseNewConn
            // 
            this.TSM_CloseNewConn.Name = "TSM_CloseNewConn";
            this.TSM_CloseNewConn.Size = new System.Drawing.Size(122, 22);
            this.TSM_CloseNewConn.Text = "关闭连接";
            this.TSM_CloseNewConn.Click += new System.EventHandler(this.TSM_CloseNewConn_Click);
            // 
            // btnSync
            // 
            this.btnSync.Image = global::DMS.Properties.Resources.db1;
            this.btnSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(51, 22);
            this.btnSync.Text = "同步";
            this.btnSync.ToolTipText = "同步";
            this.btnSync.Click += new System.EventHandler(this.btnNewDesigner_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = global::DMS.Properties.Resources.excel;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton1.Text = "导出Excel";
            this.toolStripButton1.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::DMS.Properties.Resources.export;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(51, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._treeTables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(858, 415);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 2;
            // 
            // _treeTables
            // 
            this._treeTables.ContextMenuStrip = this._mnuTree;
            this._treeTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeTables.ImageIndex = 0;
            this._treeTables.ImageList = this._imgList;
            this._treeTables.Location = new System.Drawing.Point(0, 0);
            this._treeTables.Margin = new System.Windows.Forms.Padding(2);
            this._treeTables.Name = "_treeTables";
            this._treeTables.SelectedImageIndex = 0;
            this._treeTables.Size = new System.Drawing.Size(285, 415);
            this._treeTables.TabIndex = 1;
            this._treeTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._treeTables_AfterSelect);
            this._treeTables.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeTables_NodeMouseClick);
            this._treeTables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeTables_NodeMouseDoubleClick);
            // 
            // _mnuTree
            // 
            this._mnuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnstSync,
            this.cnstRefresh});
            this._mnuTree.Name = "_mnuTree";
            this._mnuTree.Size = new System.Drawing.Size(101, 48);
            this._mnuTree.Opening += new System.ComponentModel.CancelEventHandler(this._mnuTree_Opening);
            // 
            // cnstSync
            // 
            this.cnstSync.Name = "cnstSync";
            this.cnstSync.Size = new System.Drawing.Size(100, 22);
            this.cnstSync.Text = "同步";
            this.cnstSync.Click += new System.EventHandler(this.cnstSync_Click);
            // 
            // cnstRefresh
            // 
            this.cnstRefresh.Name = "cnstRefresh";
            this.cnstRefresh.Size = new System.Drawing.Size(100, 22);
            this.cnstRefresh.Text = "刷新";
            this.cnstRefresh.Click += new System.EventHandler(this.cnstRefresh_Click);
            // 
            // _imgList
            // 
            this._imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgList.ImageStream")));
            this._imgList.TransparentColor = System.Drawing.Color.Red;
            this._imgList.Images.SetKeyName(0, "Table.png");
            this._imgList.Images.SetKeyName(1, "View.png");
            this._imgList.Images.SetKeyName(2, "Field.png");
            // 
            // superTabControl
            // 
            this.superTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(248)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl.ControlBox.CloseBox.Name = "";
            this.superTabControl.ControlBox.CloseBox.Visible = true;
            // 
            // 
            // 
            this.superTabControl.ControlBox.MenuBox.Name = "";
            this.superTabControl.ControlBox.Name = "";
            this.superTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl.ControlBox.MenuBox,
            this.superTabControl.ControlBox.CloseBox});
            this.superTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl.Location = new System.Drawing.Point(0, 0);
            this.superTabControl.Name = "superTabControl";
            this.superTabControl.ReorderTabsEnabled = true;
            this.superTabControl.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl.SelectedTabIndex = 0;
            this.superTabControl.Size = new System.Drawing.Size(569, 415);
            this.superTabControl.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl.TabIndex = 0;
            this.superTabControl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl.Text = "superTabControl1";
            this.superTabControl.TabRemoved += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs>(this.superTabControl_TabRemoved);
            // 
            // frmSyncDapMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 440);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "frmSyncDapMetadata";
            this.Text = "frmSQLManagementSudio";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this._mnuTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _treeTables;
        private System.Windows.Forms.ContextMenuStrip _mnuTree;
        private System.Windows.Forms.ImageList _imgList;
        private System.Windows.Forms.ToolStripButton btnSync;
        private DevComponents.DotNetBar.SuperTabControl superTabControl;
        private System.Windows.Forms.ToolStripMenuItem SqlCompressMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReCreateDBReIndexMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveHistoryDataMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btnDo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem TSM_AddNewConn;
        private System.Windows.Forms.ToolStripMenuItem TSM_CloseNewConn;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem cnstSync;
        private System.Windows.Forms.ToolStripMenuItem cnstRefresh;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}