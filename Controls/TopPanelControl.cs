using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS.Controls
{
    public partial class TopPanelControl : UserControl
    {
        public TopPanelControl()
        {
            InitializeComponent();
        }

        public new string Text
        {
            set
            {
                label2.Text = "辅助开发管理系统   " + value + "    ";
            }
            get
            {
                return label2.Text;
            }
        }
    }
}
