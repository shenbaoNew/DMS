using DMS.Forms.DAP.InitIDE;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMS.Forms.DAP.SelectWindow {
    public partial class frmSelectDapVersion : BaseForm {
        public string SelectPatch {
            get {
                return this.lsbPatch.SelectedItem != null ?
                    this.lsbPatch.SelectedItem.ToString() : string.Empty;
            }
        }

        public frmSelectDapVersion(string from) {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            if (from == "toolbar") {
                this.btnOK.Visible = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            this.lsbVersion.DataSource = new List<string>();
            this.lsbPatch.DataSource = new List<string>();

            InitTool initTool = new InitTool();
            List<string> versionList = initTool.GetVersionList();
            this.lsbVersion.DataSource = versionList;
        }

        private void btnLoadPatch_Click(object sender, EventArgs e) {
            object version = this.lsbVersion.SelectedItem;
            if (version != null) {
                InitTool initTool = new InitTool();
                this.lsbPatch.DataSource = initTool.GetPatchList(version.ToString());
            }
        }

        private void frmSelectDapVersion_Load(object sender, EventArgs e) {
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
