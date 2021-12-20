using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace DMS.Forms
{
    internal partial class ProgressForm : Form
    {
      private  const int WS_EX_NOACTIVATE = 0x08000000;
        private void ProgressForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Gray, 2))
            {
                p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(p, DisplayRectangle);
            }
        }
      
        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            lblProgress.Width = Width - lblProgress.Left * 2;
        }
        public ProgressForm(String title, String text)
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            if (!string.IsNullOrEmpty(title))
                this.topPanel.TitleText = title;
            this.lblProgress.Text = text;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            //if (Owner != null)
            //    Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
            //        Owner.Location.Y + Owner.Height / 2 - Height / 2 - 14);
            OperPicture("loader.gif");
        }

        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="fileName"></param>
        private void OperPicture(string fileName)
        {
            try
            {
                Bitmap img = new Bitmap(fileName);
                this.pic_Status.Image = img;
            }
            catch
            { }
        }
        //protected override CreateParams CreateParams
        //{

        //    get
        //    {
        //        CreateParams cp = base.CreateParams;

        //        cp.ExStyle |= WS_EX_NOACTIVATE;

        //        return cp;

        //    }

        //}

    }
}
