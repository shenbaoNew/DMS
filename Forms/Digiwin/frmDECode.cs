using Digiwin.Common.Torridity;
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
    public partial class frmDECode : BaseForm
    {
        public frmDECode()
        {
            InitializeComponent();
        }

        private void btnDECode_Click(object sender, EventArgs e)
        {
            if (richTextBoxEx1.Text.Trim() == string.Empty)
                return;

            richTextBoxEx2.Text = Maths.DECode(richTextBoxEx1.Text.Trim());
        }
    }
}
