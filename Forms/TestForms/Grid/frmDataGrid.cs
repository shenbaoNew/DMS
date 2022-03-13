using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DMS.Forms
{
    public partial class frmDataGrid : BaseQueryForm
    {
        public Label label2 = new Label();

        public frmDataGrid()
        {
            InitializeComponent();

            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.DataSource = DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workRectangle = Screen.PrimaryScreen.WorkingArea;
            //this.Size = new Size(workRectangle.Width - 20, workRectangle.Height - 20);
            Rectangle bands = Screen.PrimaryScreen.Bounds;

            //Image image = DeskTop.GetImage();

            //this.Location = new Point(10, 5);

            //this.dataGridViewX1.AutoGenerateColumns = false;
            
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell != null)
            {
                dataGridViewX1.Columns[dataGridViewX1.CurrentCell.ColumnIndex].Visible = false;
            }
        }

        private DataTable DataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("DocNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(int)));
            dt.Columns.Add(new DataColumn("Weight", typeof(int)));
            dt.Columns.Add(new DataColumn("Memo", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["DocNo"] = "20150201001";
            dr["Amount"] = 10;
            dr["Weight"] = 100;
            dr["Memo"] = "ss";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["DocNo"] = "20150201002";
            dr["Amount"] = 20;
            dr["Weight"] = 200;
            dr["Memo"] = "dd";
            dt.Rows.Add(dr);

            return dt;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataGridViewColumns form = new frmDataGridViewColumns(this.dataGridViewX1);
            form.ShowNewDialog();
        }

        private void navigationPane1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }

    public class aa { protected int m;}

    public class AA:aa
    {
        private int x = 0;

        public int YY { get { return Y; } }

        private int Y { get; set; }

        public void ss()
        {
            
        }
    }
}
