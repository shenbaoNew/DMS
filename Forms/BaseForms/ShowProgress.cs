using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms
{
    internal class ShowProgress
    {
        private static ProgressForm _TaskDialogForm = null;
        private ShowProgress()
        {
        }
        public static void Show(String text)
        {
            Show(null, string.Empty, text);
        }
        public static void Show(IWin32Window owner, String text)
        {
            Show(owner, string.Empty, text);
        }
        public static void Show(String title, String text)
        {
            Show(null, title, text);
        }
        public static void Show(IWin32Window owner, String title, String text)
        {
            _TaskDialogForm = new ProgressForm(title, text);
            try
            {
                _TaskDialogForm.Show(owner);
                _TaskDialogForm.Refresh();
                Application.DoEvents();
            }
            catch
            {
                _TaskDialogForm.Dispose();
                _TaskDialogForm = null;
            }
        }
        public static void Stop()
        {
            if (_TaskDialogForm != null)
            {
                _TaskDialogForm.Close();
                _TaskDialogForm.Dispose();
                _TaskDialogForm = null;
            }
        }
      
    }
}