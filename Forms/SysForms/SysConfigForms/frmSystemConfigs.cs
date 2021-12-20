using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMS.Forms;
using DMS.Controls.SystemControl;

namespace DMS.Forms
{
    public partial class frmSystemConfigs : BaseSettingForm
    {
        public frmSystemConfigs()
        {
            InitializeComponent();

            this.Name = "frmSystemConfigs";
            this.Title = "个人选项";
            AddItem();
        }

        private void AddItem()
        {
            base.AddItem(new StartUpConfigControl(), "StartUpConfigControl", "系统主界面");
        }
    }
}
