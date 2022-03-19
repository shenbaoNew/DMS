using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public class ShowMessage
    {
        public static void ShowInformation(string txt)
        {
            MessageBox.Show(txt, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string txt)
        {
            return MessageBox.Show(txt, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void ShowError(string txt)
        {
            MessageBox.Show(txt, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }
    }
}
