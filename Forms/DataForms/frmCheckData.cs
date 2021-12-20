using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading;

namespace DMS.Forms
{
    public partial class frmCheckData : BaseQueryForm
    {
        //线程查找数据
        Thread thread = null;
        private object obj = new object();

        PlantInfoData planInfoData;
        DataMonitorData monitorData;

        DataTable topTable;
        BindingSource topBs;

        public string[] areaZN = { "8990", "8480", "8710", "8770", "9010", "8340", "8210", "8280", "7450" };
        public string[] areaDB = { "9000", "8190", "8050", "8540", "8450", "8650", "8651", "8760", "8260", "8380", "8390", "8320", "7100", "7020", "7190" };
        public string[] areaXN = { "8960", "8240", "8980", "8780", "8140", "8510", "8500", "7080", "7070", "8430" };

        int plantCount = 1;
        int returnCount = 0;

        public frmCheckData()
        {
            InitializeComponent();

            planInfoData = new PlantInfoData();
            monitorData = new DataMonitorData();

            topBs = new BindingSource();
            this.TopGrid.AutoGenerateColumns = false;
        }

        private void frmCheckData_Load(object sender, EventArgs e)
        {
            InitUIData();
        }

        public void InitUIData()
        {
            cmbPlant.DataSource = planInfoData.GetPlantInfoStatic(new string[] { "code" }, "CompanyName", "plant.xml", @"DMS/Plants/plant");
            cmbPlant.DisplayMember = "CompanyName";
            cmbPlant.ValueMember = "Code";
        }

        public void InitUIDataBak()
        {
            DataSet ds = planInfoData.GetPlantInfos();
            TopGrid.DataSource = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                cmbPlant.DataSource = GetCmbDataSource(ds.Tables[0]);
                cmbPlant.DisplayMember = "CompanyName";
                cmbPlant.ValueMember = "Code";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDataOnThread();
        }

        public class DataArgument
        {
            public string start;
            public string end;
            public string code;
            public string name;

            public DataTable plant;

            public DataArgument(string start,string end,string code,string name,DataTable plant)
            {
                this.start = start;
                this.end = end; 
                this.code = code;
                this.name = name;

                this.plant = plant;
            }
        }

        private DataTable GetCmbDataSource(DataTable dt)
        {
            DataTable result = PubHelper.CreateTable("CmbPlant", new DataColumn[]{
                new DataColumn("Code",typeof(string)),
                new DataColumn("CompanyName",typeof(string))
            });

            DataRow newd = result.NewRow();
            newd["Code"] = string.Join(",", areaZN);
            newd["CompanyName"] = "中南所有工厂";
            result.Rows.Add(newd);

            newd = result.NewRow();
            newd["Code"] = string.Join(",", areaDB);
            newd["CompanyName"] = "东北所有工厂";
            result.Rows.Add(newd);

            newd = result.NewRow();
            newd["Code"] = string.Join(",", areaXN);
            newd["CompanyName"] = "西南所有工厂";
            result.Rows.Add(newd);

            result.Merge(GetDataTable(dt, "中南"));
            result.Merge(GetDataTable(dt, "东北"));
            result.Merge(GetDataTable(dt, "西南"));

            return result;
        }

        public DataTable GetDataTable(DataTable dt, string area)
        {
            bool flag = false;
            DataTable result = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow newd = result.NewRow();
                if (dr["Code"].ToString() != string.Empty && dr["Code"].ToString() != "-1")
                {
                    if ((area == "中南" && areaZN.Contains(dr["Code"].ToString()))
                        || (area == "东北" && areaDB.Contains(dr["Code"].ToString()))
                        || (area == "西南" && areaXN.Contains(dr["Code"].ToString())))
                    {
                        if (!flag)
                        {
                            newd = result.NewRow();
                            newd["Code"] = "-1";
                            if (area == "中南")
                                newd["CompanyName"] = "======中南片区工厂======";
                            else if (area == "东北")
                                newd["CompanyName"] = "======东北片区工厂======";
                            else if (area == "西南")
                                newd["CompanyName"] = "======西南片区工厂======";
                            result.Rows.Add(newd);

                            newd = result.NewRow();
                            newd["Code"] = dr["Code"].ToString().Trim();
                            newd["CompanyName"] = dr["CompanyName"].ToString().Trim();
                            result.Rows.Add(newd);

                            flag = true;
                        }
                        else
                        {
                            newd = result.NewRow();
                            newd["Code"] = dr["Code"].ToString().Trim();
                            newd["CompanyName"] = dr["CompanyName"].ToString().Trim();
                            result.Rows.Add(newd);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 多线程处理数据库查询
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadGetData(object obj)
        {
            DataArgument dg = obj as DataArgument;
            if (dg == null)
                return;
            if (dg.code == "-1" || dg.code == string.Empty)
                return;
            if (dg.plant == null)
                return;

            string name = string.Empty;
            string[] codes = dg.code.Split(',');

            try
            {
                foreach (string code in codes)
                {
                    if (code != "")
                    {
                        DataView dv = dg.plant.Copy().DefaultView;

                        if (dv == null)
                            name = code;
                        else
                        {
                            dv.RowFilter = "Code='" + code + "'";
                            if (dv.Count > 0)
                                name = dv[0]["CompanyName"].ToString();
                            else
                                name = code;
                        }
                        DataSet ds = monitorData.GetMonitorData(dg.start, dg.end, code, name);
                        OperDataResult(ds);
                    }
                }

                this.Invoke(new Action(DisplayData));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action<Exception>(OperExcetion), ex);
            }
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="exMsg"></param>
        private void OperExcetion(Exception ex)
        {
            this.btnSearch.Enabled = true;
            this.btnCancel.Enabled = false;
            this.timer.Enabled = false;
            this.lbl_Status.Text = "查询已完成";
            if (ex is ThreadAbortException)
            {
                this.lbl_Status.Text = "执行已取消";
                OperPicture("search.jpg");
                return;
            }
            else if (!ex.Message.Contains("正在中止线程") && !ex.Message.Contains("Thread was being aborted"))
                MessageBox.Show("执行查询出现异常，异常信息为：" + ex.Message);

            OperPicture("complete.jpg");
        }

        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="fileName"></param>
        private void OperPicture(string fileName)
        {
            try
            {
                Bitmap img = new Bitmap(fileName);
                this.pic_Status.Image = img;
            }
            catch
            { }
        }

        public void OperDataResult(DataSet ds)
        {
            DataTable tmp;
            if (ds != null && ds.Tables.Count > 0)
            {
                tmp = ds.Tables[0];
                DataView dv = tmp.DefaultView;
                dv.RowFilter = "用户>''";
                DataTable tmpTable = dv.ToTable();
                if (topTable != null)
                    topTable.Merge(tmpTable);
                else
                    topTable = tmpTable.Copy();
            }
        }

        public void DisplayData()
        {
            this.topBs.DataSource = topTable;
            TopGrid.DataSource = topBs;

            this.btnSearch.Enabled = true;
            this.btnCancel.Enabled = false;
            this.timer.Enabled = false;
            this.lbl_Status.Text = "查询已完成";
            OperPicture("complete.jpg");

            if (topTable != null && topTable.Rows.Count > 0)
                ExportButtonVisible = true;
            else
                ExportButtonVisible = false;

            RefreshToolStrip();
        }

        public void SearchDataOnThread()
        {
            string start = dtStart.Value.ToString("yyyy-MM-dd");
            string end = dtEnd.Value.ToString("yyyy-MM-dd");
            topTable = null;
            topBs.DataSource = null;

            if (cmbPlant.DataSource != null || cmbPlant.SelectedItem != null)
            {
                DataRowView drv = cmbPlant.SelectedItem as DataRowView;

                string code = drv["Code"].ToString();
                string name = drv["CompanyName"].ToString();

                if (code == "-1" || code == string.Empty)
                    MessageBox.Show("请选择公司", "系统提示");
                else
                {
                    this.lbl_Time.Text = "用时(秒)：1";
                    this.TopPanel.TitleText = name;
                    this.btnSearch.Enabled = false;
                    this.btnCancel.Enabled = true;
                    this.timer.Enabled = true;
                    this.lbl_Status.Text = "正在执行……";
                    this.TopPanel.TitleText = name;
                    OperPicture("loader.gif");

                    try
                    {
                        DataArgument data = new DataArgument(start, end, code, name, cmbPlant.DataSource as DataTable);
                        ParameterizedThreadStart para = new ParameterizedThreadStart(ThreadGetData);
                        thread = new Thread(para);

                        thread.Start(data);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("执行存储过程出错，错误信息为：" + ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("请选择公司", "系统提示");

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterValue = txtFilter.Text.Trim();
            if (topTable != null)
            {
                topBs.DataSource = PubHelper.FilterDataTable(topTable, "工厂编码,工厂名称,用户", filterValue);
                this.TopGrid.DataSource = topBs;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            thread.Abort();

            this.btnSearch.Enabled = true;
            this.btnCancel.Enabled = false;
            this.timer.Enabled = false;

            this.lbl_Status.Text = "用户已取消";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int value = int.Parse(this.lbl_Time.Text.Split('：')[1]);
            this.lbl_Time.Text = "用时(秒)：" + (value + 1).ToString();
            this.lbl_Time.TextAlign = ContentAlignment.MiddleRight;
        }

        protected override void Export()
        {
            if (this.cmbPlant.SelectedItem == null)
                return;

            DataRowView drv = this.cmbPlant.SelectedItem as DataRowView;
            ExportTitle = "数据监控-" + drv["CompanyName"];
            ExportDataSource = this.TopGrid;
        }

        #region BAK
        public void SearchDataBak(string start, string end, string code, string name)
        {
            try
            {
                DataSet ds = monitorData.GetMonitorData(start, end, code, name);
                TopGrid.DataSource = null;
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataView dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "用户>''";
                    DataTable tmp = dv.ToTable();
                    TopGrid.DataSource = tmp;
                }
            }
            catch { }
        }

        public void SearchData()
        {
            string start = dtStart.Value.ToString("yyyy-MM-dd");
            string end = dtEnd.Value.ToString("yyyy-MM-dd");
            topTable = null;
            topBs.DataSource = null;

            if (cmbPlant.DataSource == null || cmbPlant.SelectedItem != null)
            {
                DataRowView drv = cmbPlant.SelectedItem as DataRowView;

                string codes = drv["Code"].ToString();
                string name = drv["CompanyName"].ToString();

                if (codes == "-1" || codes == string.Empty)
                    return;
                else
                {
                    string[] codess = codes.Split(',');
                    this.btnSearch.Enabled = false;
                    plantCount = codess.Where(c => c != string.Empty).Count();
                    foreach (string code in codess)
                    {
                        if (code != "")
                        {
                            DataView dv = (cmbPlant.DataSource as DataTable).Copy().DefaultView;

                            if (dv == null)
                                name = code;
                            else
                            {
                                dv.RowFilter = "Code='" + code + "'";
                                if (dv.Count > 0)
                                    name = dv[0]["CompanyName"].ToString();
                                else
                                    name = code;
                            }
                            SearchData(start, end, code, name);
                        }
                    }
                }
            }
            else
                MessageBox.Show("请选择公司", "系统提示");
        }

        private void SetFooterItems()
        {
            if (this.TopGrid.DataSource != null)
            {
                if (this.TopGrid.Columns.Contains("操作日期"))
                {
                    DataColumn dc = new DataColumn("操作日期");
                    SummaryItem item = new SummaryItem();
                    item.ColumnName = "操作日期";
                    item.Caption = "总记录";
                    item.SummaryMode = SummaryMode.Count;

                    TopGrid.ColumnFootersItems.Add(item);
                }
            }
        }



        private void SearchData(string start, string end, string code, string name)
        {
            DataArgument dg = new DataArgument(start, end, code, name, null);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync(dg);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable tmp = null;

            lock (obj)
            {
                returnCount++;

                if (returnCount < plantCount)
                    this.btnSearch.Enabled = false;
                else
                {
                    this.btnSearch.Enabled = true;
                    SetFooterItems();
                    returnCount = 0;
                }

                if (e.Result != null)
                {
                    DataSet ds = e.Result as DataSet;
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        tmp = ds.Tables[0];
                        DataView dv = tmp.DefaultView;
                        dv.RowFilter = "用户>''";
                        DataTable tmpTable = dv.ToTable();
                        if (topTable != null)
                        {
                            topTable.Merge(tmpTable);
                            topBs.DataSource = topTable;
                        }
                        else
                        {
                            topTable = tmpTable.Clone();
                            topBs.DataSource = topTable;
                            TopGrid.DataSource = topBs;
                        }
                    }
                }
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DataArgument dg = e.Argument as DataArgument;
            e.Result = monitorData.GetMonitorData(dg.start, dg.end, dg.code, dg.name);
        }

        #endregion
    }
}
