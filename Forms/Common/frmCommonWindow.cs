using System.Windows.Forms;

namespace DMS.Forms.Common {
    public partial class frmCommonWindow : Form {
        public frmCommonWindow() {
            InitializeComponent();
        }

        public frmCommonWindow(string caption, string message) {
            InitializeComponent();
            this.Text = caption;
            this.txtMessage.Text = message;
        }
    }
}
