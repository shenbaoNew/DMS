using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace DMS.Forms
{
    public partial class frmDataGridViewColumns : BaseForm
    {
        private DataGridViewX dgv;
        private DataTable dtc;
        private BindingSource bs;

        public frmDataGridViewColumns()
        {
            InitializeComponent();

            this.dgvDisplay.AutoGenerateColumns = false;
            this.dtc = CreateColumns();
            this.bs = new BindingSource();
            this.bs.DataSource = this.dtc;
            this.dgvDisplay.DataSource = this.bs;
        }

        public frmDataGridViewColumns(DataGridViewX dgvx)
        {
            InitializeComponent();

            this.dgvDisplay.AutoGenerateColumns = false;
            this.dgv = dgvx;
            this.dtc = CreateColumns();
            this.bs = new BindingSource();
            this.bs.DataSource = this.dtc;
            this.dgvDisplay.DataSource = this.bs;
        }

        public DataGridViewX DataGridViewX {

            get { return this.dgv; }
            set { this.dgv = value; }
        }

        public DataTable CreateColumns()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("HeaderName", typeof(string)), 
                new DataColumn("Visiable", typeof(bool)),
                new DataColumn("Name", typeof(string))});
            if (this.dgv != null)
            {
                DataGridViewColumnCollection dcs = this.dgv.Columns;

                if (dcs != null && dcs.Count > 0)
                {
                    foreach (DataGridViewColumn dc in dcs)
                    {
                        DataRow dr = dt.NewRow();
                        dr["HeaderName"] = dc.HeaderText;
                        dr["Name"] = dc.Name;
                        dr["Visiable"] = dc.Visible;
                        dt.Rows.Add(dr);
                    }
                }
            }

            return dt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (DataRow dr in this.dtc.Rows)
            {   
                this.dgv.Columns[dr["Name"].ToString()].Visible = (bool)dr["Visiable"];
                this.dgv.Columns[dr["Name"].ToString()].DisplayIndex = index++;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (this.dgvDisplay != null && this.dtc.Rows.Count > 0 && this.dgvDisplay.CurrentCell != null)
            {
                DataRowView dv = this.bs.Current as DataRowView;
                DataRow dr = this.dtc.NewRow();
                dr["Name"] = dv["Name"];
                dr["HeaderName"] = dv["HeaderName"];
                dr["Visiable"] = dv["Visiable"];

                this.dtc.Rows.RemoveAt(this.dgvDisplay.CurrentRow.Index);
                this.dtc.Rows.InsertAt(dr, 0);

                this.bs.Position = 0;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (this.dgvDisplay != null && this.dtc.Rows.Count > 0 && this.dgvDisplay.CurrentCell != null)
            {
                DataRowView dv = this.bs.Current as DataRowView;
                DataRow dr = this.dtc.NewRow();
                dr["Name"] = dv["Name"];
                dr["HeaderName"] = dv["HeaderName"];
                dr["Visiable"] = dv["Visiable"];

                this.dtc.Rows.RemoveAt(this.dgvDisplay.CurrentRow.Index);
                this.dtc.Rows.Add(dr);

                this.bs.Position = this.dtc.Rows.Count - 1;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.dgvDisplay != null && this.dtc.Rows.Count > 0 && this.dgvDisplay.CurrentCell != null)
            {
                if (this.dgvDisplay.CurrentRow.Index == 0 || this.dtc.Rows.Count <= 1)
                    return;
                int index = this.dgvDisplay.CurrentRow.Index;

                DataRow dr1 = this.dtc.NewRow();
                dr1["Name"] = this.dtc.Rows[index]["Name"];
                dr1["HeaderName"] = this.dtc.Rows[index]["HeaderName"];
                dr1["Visiable"] = this.dtc.Rows[index]["Visiable"];

                DataRow dr2 = this.dtc.NewRow();
                dr2["Name"] = this.dtc.Rows[index - 1]["Name"];
                dr2["HeaderName"] = this.dtc.Rows[index - 1]["HeaderName"];
                dr2["Visiable"] = this.dtc.Rows[index - 1]["Visiable"];

                this.dtc.Rows.RemoveAt(index);
                this.dtc.Rows.RemoveAt(index - 1);

                this.dtc.Rows.InsertAt(dr2, index - 1);
                this.dtc.Rows.InsertAt(dr1, index - 1);

                this.bs.Position = index - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.dgvDisplay != null && this.dtc.Rows.Count > 0 && this.dgvDisplay.CurrentCell != null)
            {
                if (this.dtc.Rows.Count <= 1 || this.dgvDisplay.CurrentRow.Index == (this.dtc.Rows.Count - 1))
                    return;
                int index = this.dgvDisplay.CurrentRow.Index;

                DataRow dr1 = this.dtc.NewRow();
                dr1["Name"] = this.dtc.Rows[index]["Name"];
                dr1["HeaderName"] = this.dtc.Rows[index]["HeaderName"];
                dr1["Visiable"] = this.dtc.Rows[index]["Visiable"];

                DataRow dr2 = this.dtc.NewRow();
                dr2["Name"] = this.dtc.Rows[index + 1]["Name"];
                dr2["HeaderName"] = this.dtc.Rows[index + 1]["HeaderName"];
                dr2["Visiable"] = this.dtc.Rows[index + 1]["Visiable"];

                this.dtc.Rows.RemoveAt(index);
                this.dtc.Rows.RemoveAt(index);

                this.dtc.Rows.InsertAt(dr1, index);
                this.dtc.Rows.InsertAt(dr2, index);

                this.bs.Position = index + 1;
            }
        }

        private void ResetFocusRows()
        {
            DataGridViewSelectedRowCollection dcs = this.dgvDisplay.SelectedRows;
            if (dcs != null && dcs.Count > 0)
                foreach (DataGridViewRow dr in dcs)
                    dr.Selected = false;
        }

        public void ShowNewDialog()
        {
            if (this.dgv == null)
                return;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(this.dgv.RectangleToScreen(new Rectangle()).Location.X + 160,
                this.dgv.RectangleToScreen(new Rectangle()).Location.Y + 80);
            this.ShowInTaskbar = false;
            this.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
        }
    }
}
