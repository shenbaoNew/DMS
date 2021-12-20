using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DMS.Forms;
using DMS.Controls;
using DMS;

namespace MMS.Forms
{
    [Browsable(false)]
    public partial class BaseSettingForm : BaseForm
    {
        private string userId = string.Empty;
        private Hashtable controlTable;
        private BaseSettingControl activeControl;
        public BaseSettingForm()
        {
            InitializeComponent();
            controlTable = new Hashtable();
        }
        public string Title
        {
            set { this.topPanel.Text ="  "+value; }
            get { return this.topPanel.Text; }

        }
        protected virtual bool SaveData()
        {
            bool result = true;
            if (activeControl == null&&this.controlPanel.Controls.Count>0)
            {
                activeControl = this.controlPanel.Controls[0] as BaseSettingControl;
            }
            if (activeControl != null)
            {
                result = activeControl.SaveData();
            }
            return result;
        }
        public void AddItem(BaseSettingControl control, string controlName, string caption)
        {
            if (!controlTable.ContainsKey(controlName))
            {
                this.controlPanel.SuspendLayout();
                control.Name = controlName;
                control.Dock = DockStyle.Fill;
                control.AfterSaveData += new AfterSaveDataEventHandler(control_AfterSaveData);
                this.controlPanel.Controls.Add(control);
                control.SendToBack();
                DevComponents.DotNetBar.ButtonItem btnItem = new DevComponents.DotNetBar.ButtonItem();
                btnItem.Name = "btn" + controlName;
                btnItem.Text ="  "+ caption;
                btnItem.Click += new EventHandler(btnItem_Click);
                ItemTypes.Items.Add(btnItem);
                this.controlPanel.ResumeLayout();
            }
        }

        void btnItem_Click(object sender, EventArgs e)
        {
            string controlName = ((DevComponents.DotNetBar.ButtonItem)sender).Name.Trim();
            controlName = controlName.Remove(0, 3);
            if (this.controlPanel.Controls.ContainsKey(controlName))
            {
                activeControl = this.controlPanel.Controls[controlName] as BaseSettingControl;
                activeControl.Visible = false;
                activeControl.BringToFront();
                activeControl.Visible = true;
            }
        }

        protected virtual void control_AfterSaveData(object sender, bool isSave)
        {

        }
    
        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}