using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms
{
    public partial class BaseForm : DevComponents.DotNetBar.BaseContentsForm,ISupportInitialize
    {
        private System.Windows.Forms.ToolStripButton CloseMenuItem;
        public BaseForm()
        {
            InitializeComponent();
            base.EnableGlass = false;
            CloseMenuItem = new ToolStripButton("退出");
            CloseMenuItem.Name = "CloseMenuItem";
            CloseMenuItem.Click += new EventHandler(CloseMenuItem_Click);
        }
        void CloseMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //避免子窗体闪屏
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual System.Windows.Forms.ContextMenuStrip GetContextMenuStrip()
        {
            return new System.Windows.Forms.ContextMenuStrip();
        }
        public  void StartProgress(string title)
        {
            ShowProgress.Show(this, title);
        }
        protected override void OnClosed(EventArgs e)
        {
            ShowProgress.Stop();
            base.OnClosed(e);
        }
        public void EndProgress()
        {
            ShowProgress.Stop();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                foreach (Control col in this.Controls)
                {
                    if (col is System.Windows.Forms.ToolStrip)
                    {
                        System.Windows.Forms.ToolStrip tool = col as System.Windows.Forms.ToolStrip;
                        tool.Items.Add(CloseMenuItem);
                        this.ContextMenuStrip = YY.Methods.Converter.ToContextMenuStrip(tool);
                        break;
                    }
                    else
                    {
                        foreach (Control subCol in col.Controls)
                        {
                            if (subCol is System.Windows.Forms.ToolStrip)
                            {
                                System.Windows.Forms.ToolStrip subTool = subCol as System.Windows.Forms.ToolStrip;
                                this.ContextMenuStrip = YY.Methods.Converter.ToContextMenuStrip(subTool);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void RefreshToolStrip()
        {
            foreach (Control col in this.Controls)
            {
                if (col is System.Windows.Forms.ToolStrip)
                {
                    System.Windows.Forms.ToolStrip tool = col as System.Windows.Forms.ToolStrip;
                    System.Windows.Forms.ContextMenuStrip contextMeu = GetContextMenuStrip();
                    this.ContextMenuStrip = YY.Methods.Converter.ToContextMenuStrip(tool, contextMeu);
                    break;
                }
                else
                {
                    foreach (Control subCol in col.Controls)
                    {
                        if (subCol is System.Windows.Forms.ToolStrip)
                        {
                            System.Windows.Forms.ToolStrip subTool = subCol as System.Windows.Forms.ToolStrip;
                            System.Windows.Forms.ContextMenuStrip contextMeu = GetContextMenuStrip();
                            this.ContextMenuStrip = YY.Methods.Converter.ToContextMenuStrip(subTool, contextMeu);
                            break;
                        }
                    }
                }
            }
        }
        public override void Refresh()
        {
            base.Refresh();
        }
        #endregion

        #region 判断是否含有该子窗体
        /// <summary> 
        /// 判断是否含有该子窗体 
        /// </summary> 
        /// <param name="_ChildFormName">子窗体名称</param> 
        /// <returns>bool</returns> 
        public  bool IsExistChildForm(string ChildFormName)
        {

            bool IsExist = false;
            if (this.DockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.SystemMdi)
            {
                foreach (Form form in this.MdiChildren)
                {
                    if (string.Compare(form.Name, ChildFormName, true) == 0)
                    {
                        form.BringToFront();
                        IsExist = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (DevComponents.DotNetBar.IDockContent document in this.DockPanel.Contents)
                {
                    if (string.Compare(document.DockHandler.Form.Name, ChildFormName, true) == 0)
                    {
                        IsExist = true;
                        document.DockHandler.Activate();
                        break;
                    }

                }
            }
            return IsExist;
        }

        #endregion

        private void BaseForm_Load(object sender, EventArgs e)
        {
           
        }
        public bool CanShowSecondScreen
        {
            get { return Screen.AllScreens.Length > 1; }
        }

        #region ISupportInitialize
        /// <summary>
        /// This member supports the .NET Framework infrastructure and is not intended to be
        /// used directly from your code.
        /// </summary>
        public void BeginInit()
        {
            // this.BeginUpdate();
        }

        /// <summary>
        /// This member supports the .NET Framework infrastructure and is not intended to be
        /// used directly from your code.
        /// </summary>
        public void EndInit()
        {
            // this.EndUpdate();
        }
        #endregion
       

    }
}
