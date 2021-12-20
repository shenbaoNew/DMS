using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Forms;
using System.Windows.Forms;

namespace DMS
{
    public class PrograssManager
    {
        private static frmSqlLogin form = null;

        public void Show(IWin32Window owner, AfterConfirmEventHandler eventHandler)
        {
            form = new frmSqlLogin();
            try
            {
                form.Show(owner);
                form.AfterConnected += new AfterConfirmEventHandler(eventHandler);
                form.Refresh();
                Application.DoEvents();
            }
            catch
            {
                form.Dispose();
                form = null;
            }
        }

        static void form_AfterConnected(object serder, bool flag)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            if (form != null)
            {
                form.Close();
                form.Dispose();
                form = null;
            }
        }
    }
}
