namespace DMS.Forms
{
    partial class frmHelpMain
    {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("CSS中文完全参考手册");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("CSS3.0（语法）");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CSS", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Javascipt语言手册");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("jQuery");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("JavaScrip", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("HTML5（W3CSchool版）");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Html", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Http");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("正则表达式系统教程");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("正则表达式", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelpMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tocTree = new HtmlHelp.UIComponents.TocTree();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tocTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(740, 421);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 2;
            // 
            // tocTree
            // 
            this.tocTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tocTree.Location = new System.Drawing.Point(0, 0);
            this.tocTree.Name = "tocTree";
            this.tocTree.Padding = new System.Windows.Forms.Padding(2);
            this.tocTree.Size = new System.Drawing.Size(246, 421);
            this.tocTree.TabIndex = 1;
            this.tocTree.TocSelected += new HtmlHelp.UIComponents.TocSelectedEventHandler(this.tocTree_TocSelected);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(490, 421);
            this.webBrowser.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(740, 501);
            this.splitContainer2.SplitterDistance = 76;
            this.splitContainer2.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "CssCnaShouCe";
            treeNode1.Text = "CSS中文完全参考手册";
            treeNode2.Name = "CssYuFa";
            treeNode2.Text = "CSS3.0（语法）";
            treeNode3.Name = "节点0";
            treeNode3.Text = "CSS";
            treeNode4.Name = "JavasciptShouCe";
            treeNode4.Text = "Javascipt语言手册";
            treeNode5.Name = "jQuery111";
            treeNode5.Text = "jQuery";
            treeNode6.Name = "节点1";
            treeNode6.Text = "JavaScrip";
            treeNode7.Name = "Html5W3cSchool";
            treeNode7.Text = "HTML5（W3CSchool版）";
            treeNode8.Name = "节点2";
            treeNode8.Text = "Html";
            treeNode9.Name = "节点3";
            treeNode9.Text = "Http";
            treeNode10.Name = "Regex1";
            treeNode10.Text = "正则表达式系统教程";
            treeNode11.Name = "Regex";
            treeNode11.Text = "正则表达式";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8,
            treeNode9,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(740, 76);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // frmHelpMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 501);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHelpMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "BaseForm";
            this.Text = "帮助文档";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private HtmlHelp.UIComponents.TocTree tocTree;
        public System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
    }
}