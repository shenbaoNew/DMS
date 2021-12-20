using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMS;

namespace DMS.Controls
{
    public partial class BaseSettingControl : UserControl
    {
        public event AfterSaveDataEventHandler AfterSaveData;
        public virtual bool SaveData()
        {
            return true;
        }
        /// <summary>
        /// Raises the AfterSaveData( event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data. </param>
        protected virtual void OnAfterSaveData(bool isSave)
        {
            AfterSaveDataEventHandler handler = AfterSaveData;
            if (handler != null)
            {
                handler(this, isSave);
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseSettingControl
            // 
            this.Name = "BaseSettingControl";
            this.Size = new System.Drawing.Size(277, 156);
            this.ResumeLayout(false);

        }
    }
}

