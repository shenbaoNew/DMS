using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YY.Methods;

namespace DMS.Forms
{
    public partial class BaseQueryForm : BaseForm
    {
        private YY.Methods.ToolStripExportButton ExportMenuItem;
        private string exportTitle = string.Empty;
        private string exportSubTitle = string.Empty;
        private string exportColumns = string.Empty;
        public BaseQueryForm()
        {
            if (!this.DesignMode)
            {
                Image image = global::DMS.Properties.Resources.export;

                ExportMenuItem = new YY.Methods.ToolStripExportButton("数据导出");
                ExportMenuItem.Image = image;
                ExportMenuItem.Buttons = ((YY.Methods.ExportButtons)(YY.Methods.ExportButtons.To2003Excel));
                ExportMenuItem.Visible = false;
                ExportMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                ExportMenuItem.SelectedExportButton += new ExportEventHandler(ExportMenuItem_SelectedExportButton);

            }
        }

        #region Properties
        public bool ExportButtonVisible
        {
            get
            {
                if (ExportMenuItem != null)
                    return ExportMenuItem.Visible;
                else return false;
            }
            set
            {
                if (ExportMenuItem != null)
                    ExportMenuItem.Visible = value;
              
            }
        }

        public string ExportTitle
        {
            get
            {
                if (ExportMenuItem != null)
                    return ExportMenuItem.ExportTitle;
                else return string.Empty;
            }
            set { if (ExportMenuItem != null)ExportMenuItem.ExportTitle = value; }
        }
        public string ExportSubTitle
        {
            get
            {
                if (ExportMenuItem != null)
                    return ExportMenuItem.ExportSubTitle;
                else return string.Empty;
            }
            set { if (ExportMenuItem != null)ExportMenuItem.ExportSubTitle = value; }
        }
        public string ExportColumns
        {
            get
            {
                if (ExportMenuItem != null)
                    return ExportMenuItem.ExportColumns;
                else return string.Empty;
            }
            set { if (ExportMenuItem != null)ExportMenuItem.ExportColumns = value; }
        }
        public object ExportDataSource
        {
            get
            {
                if (ExportMenuItem != null)
                    return ExportMenuItem.ExportDataSource;
                else return false;
            }
            set { if (ExportMenuItem != null)ExportMenuItem.ExportDataSource = value; }
        }
        #endregion

        #region Private Methods
        void ExportMenuItem_SelectedExportButton(object sender, ExportEventArgs e)
        {
           
        }
      
        #endregion

        #region protected Methods
        /// <summary>
        /// This method is called when the export starts.
        /// </summary>
        protected virtual void Start()
        {
        }

        /// <summary>
        /// This method is called when the export is finished.
        /// </summary>
        protected virtual void Finish()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void ExecuteDataSet()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual bool ExecuteNonQuery()
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void Export()
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string MessageText()
        {
            return "是否保存?";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShowSuccessMessageText()
        {
            return false;
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
                        int xcount = tool.Items.Count-1;
                        if (xcount>-1)
                        tool.Items.Insert(xcount,ExportMenuItem);
                        else
                            tool.Items.Add(ExportMenuItem);
                        //if (this.Name != "frmMessageMain")
                        //{
                        //    tool.Items.Add(QAMenuItem);
                        //}
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
                                subTool.Items.Add(ExportMenuItem);
                                //if (this.Name != "frmMessageMain")
                                //{
                                //    subTool.Items.Add(QAMenuItem);
                                //}
                                this.ContextMenuStrip = YY.Methods.Converter.ToContextMenuStrip(subTool);
                                break;
                            }
                        }
                    }
                }
                Export();
            }
        }
        #endregion

        #region public Methods
        /// <summary>
        /// 
        /// </summary>
        public void QueryData()
        {
            Start();

            try
            {
                ExecuteDataSet();
            }
            finally
            {
                Finish();
                RefreshToolStrip();
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public bool SaveData()
        {
            bool result = true;

            DialogResult dialog = DialogBox.ShowQuestion(MessageText());
            if (dialog == DialogResult.Yes)
            {
                Start();
                try
                {
                    result = ExecuteNonQuery();
                }
                finally
                {
                    Finish();
                    RefreshToolStrip();
                    EndProgress();
                    if (ShowSuccessMessageText())
                    {
                        if(result)
                            DialogBox.ShowInformation("数据已保存成功！");
                        else
                            DialogBox.ShowInformation("数据保存失败或未有任何影响！");
                    }
                }
            }
         return   result;
        }
       

   
        public string ToMoneyUpper(decimal value)
        {
            return YY.Methods.Converter.ToMoneyUpper(value);
        }
        public void GridBuffered(DataGridView grid, bool autoCreateCol)
        {
            PubHelper.SetDoubleBuffered(grid, true, autoCreateCol);
        }
        public void GridBuffered(DevComponents.DotNetBar.Controls.DataGridViewX grid, bool autoCreateCol)
        {
            PubHelper.SetDoubleBuffered(grid, true, autoCreateCol);
        }
       
        #endregion

       
    }
}
