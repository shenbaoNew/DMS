using DMS.DataClass.Pub;
using System;

namespace DMS.Forms {
    public partial class frmCrossKey : BaseForm {
        public frmCrossKey() {
            InitializeComponent();
        }
        private void btnGen_Click(object sender, EventArgs e) {
            //从E10调入DAP需要添加corss_key
            string originKey = this.txtHost.Text + this.txtService.Text; //+ CROSS_KEY;
            if (cbOut.Checked) {
                originKey += ConstHelper.CROSS_KEY;
            }

            this.tbKey.Text = CommonHelper.GenCrossKey(originKey);
        }
    }
}
