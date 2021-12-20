using Digiwin.Designer.Translator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms {
    public partial class frmLangChange : BaseForm {
        public frmLangChange() {
            InitializeComponent();
        }

        private void btnChs2Cht_Click(object sender, EventArgs e) {
            if (!this.rtxt1.Text.Trim().Equals(string.Empty)) {
                this.rtxt2.Text = CHS2CHT.Translate(this.rtxt1.Text);
            }
        }
    }
}
