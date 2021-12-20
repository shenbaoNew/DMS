using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DMS
{
    public  static class DataBinds
    {
        #region public event
        #region ComboTree
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTree cmb, DataTable table, string displayMembers, string valueMember, string headTexts)
        {
            BindSource(cmb, table, displayMembers, valueMember,  headTexts, -1);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTree cmb, DataTable table, string displayMembers, string valueMember, int defualtIndex)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ColumnsVisible = false;
            cmb.ValueMember = valueMember;
            cmb.SelectedIndex = defualtIndex;
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTree cmb, DataTable table, string displayMembers, string valueMember, string headTexts, int defualtIndex)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ValueMember = valueMember;
            if (string.IsNullOrEmpty(headTexts))
                cmb.ColumnsVisible = false;
            else
                cmb.HeadTexts = headTexts;
            cmb.SelectedIndex = defualtIndex;
        }
        #endregion

        #region ComboTreeBox
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, string.Empty, -1, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts,string.Empty, -1, allowEdit);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember,int defualtIndex, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, string.Empty, -1, allowEdit);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts,string columnWidths)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, columnWidths, -1, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, string columnWidths, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, columnWidths, -1, allowEdit);
        }

        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string columnWidths, int defualtIndex, bool allowEdit)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.AllowEdit = allowEdit;
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ColumnsVisible = false;
            cmb.ValueMember = valueMember;
            cmb.SelectedIndex = defualtIndex;
            if (!string.IsNullOrEmpty(columnWidths))
                cmb.ColumnWidths = columnWidths;
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, int defualtIndex, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, string.Empty,-1, allowEdit);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, string columnWidths, int defualtIndex, bool allowEdit)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.AllowEdit = allowEdit;
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ValueMember = valueMember;
            cmb.FilterMembers = filterMembers;
            if (string.IsNullOrEmpty(headTexts))
                cmb.ColumnsVisible = false;
            else
                cmb.HeadTexts = headTexts;
            cmb.SelectedIndex = defualtIndex;
            if (!string.IsNullOrEmpty(columnWidths))
                cmb.ColumnWidths = columnWidths;
        }
        #endregion

        #region LabelComboBox
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember)
        {
            BindSource(cmb, table, displayMembers, valueMember,string.Empty,-1, false);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, int defualtIndex)
        {
            BindSource(cmb, table, displayMembers, valueMember, string.Empty, defualtIndex, false);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, -1, false);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts,string.Empty,-1, allowEdit);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember,string columnWidths)
        {
            BindSource(cmb, table, displayMembers, valueMember, columnWidths, -1, false);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts,string columnWidths)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, columnWidths, - 1, false);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, string columnWidths, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, columnWidths, - 1, allowEdit);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, int defualtIndex, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember,string.Empty,defualtIndex, allowEdit);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string columnWidths, int defualtIndex, bool allowEdit)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.AllowEdit = allowEdit;
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ValueMember = valueMember;
            cmb.ColumnsVisible = false;
            cmb.SelectedIndex = defualtIndex;
            if (!string.IsNullOrEmpty(columnWidths))
                cmb.ColumnWidths = columnWidths;
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts,  int defualtIndex, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, string.Empty, defualtIndex, allowEdit);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, string columnWidths, int defualtIndex, bool allowEdit)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.AllowEdit = allowEdit;
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ValueMember = valueMember;
            cmb.FilterMembers = filterMembers;
            if (string.IsNullOrEmpty(headTexts))
                cmb.ColumnsVisible = false;
            else
                cmb.HeadTexts = headTexts;
            cmb.SelectedIndex = defualtIndex;
            if (!string.IsNullOrEmpty(columnWidths))
                cmb.ColumnWidths = columnWidths;
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts,  object defualtValue, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, filterMembers, headTexts, string.Empty,-1, allowEdit);
        }
        public static void BindSource(DevComponents.Editors.LabelComboBox cmb, DataTable table, string displayMembers, string valueMember, string filterMembers, string headTexts, string columnWidths, object defualtValue, bool allowEdit)
        {
            try
            {
                DataTable dt = new DataTable();
                if (table != null)
                {
                    dt = table.Copy();
                }
                cmb.AllowEdit = allowEdit;
                cmb.DataSource = dt;
                cmb.DisplayMembers = displayMembers;
                cmb.ValueMember = valueMember;
                cmb.FilterMembers = filterMembers;
                if (string.IsNullOrEmpty(headTexts))
                    cmb.ColumnsVisible = false;
                else
                    cmb.HeadTexts = headTexts;
                if (defualtValue != null)
                    cmb.SelectedValue = defualtValue;
                if (!string.IsNullOrEmpty(columnWidths))
                    cmb.ColumnWidths = columnWidths;
            }
            catch
            { }
        }
        #endregion

        #region ToolStripComboTreeBox
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember)
        {
            BindSource(cmb, table, displayMembers, valueMember, -1, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember,int defualtIndex)
        {
            BindSource(cmb, table, displayMembers, valueMember, defualtIndex, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, -1, allowEdit);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, int defualtIndex, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember,string.Empty,defualtIndex, allowEdit);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember,string columnWidths)
        {
            BindSource(cmb, table, displayMembers, valueMember, columnWidths, - 1, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string columnWidths, int defualtIndex)
        {
            BindSource(cmb, table, displayMembers, valueMember,columnWidths,defualtIndex, false);
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string columnWidths, bool allowEdit)
        {
            BindSource(cmb, table, displayMembers, valueMember, columnWidths,- 1, allowEdit);
        }


        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboTreeBox cmb, DataTable table, string displayMembers, string valueMember, string columnWidths, int defualtIndex, bool allowEdit)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.AllowEdit = allowEdit;
            cmb.DataSource = dt;
            cmb.DisplayMembers = displayMembers;
            cmb.ValueMember = valueMember;
            cmb.SelectedIndex = defualtIndex;
            cmb.ColumnsVisible = false;
            if (!string.IsNullOrEmpty(columnWidths))
                cmb.ColumnWidths = columnWidths;
        }
        #endregion

        #region LabelComboCheckBox

        public static void BindSource(DevComponents.Editors.LabelComboCheckBox cmb, DataTable table, string displayMember, string valueMember)
        {
           BindSource(cmb, table,displayMember,valueMember,"");
        }
        public static void BindSource(DevComponents.Editors.LabelComboCheckBox cmb, DataTable table, string displayMember, string valueMember, string defualtValue)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
            if (!string.IsNullOrEmpty(defualtValue))
                cmb.Value = defualtValue;
        }
        #endregion

        #region ComboCheckBox

        public static void BindSource(DevComponents.DotNetBar.Controls.ComboCheckBox cmb, DataTable table, string displayMember, string valueMember)
        {
            BindSource(cmb, table, displayMember, valueMember, "");
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ComboCheckBox cmb, DataTable table, string displayMember, string valueMember, string defualtValue)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
            if (!string.IsNullOrEmpty(defualtValue))
                cmb.Value = defualtValue;
        }
        #endregion

        #region  ToolStripComboCheckBox

        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboCheckBox cmb, DataTable table, string displayMember, string valueMember)
        {
            BindSource(cmb, table, displayMember, valueMember, "");
        }
        public static void BindSource(DevComponents.DotNetBar.Controls.ToolStripComboCheckBox cmb, DataTable table, string displayMember, string valueMember, string defualtValue)
        {
            DataTable dt = new DataTable();
            if (table != null)
            {
                dt = table.Copy();
            }
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
            if (!string.IsNullOrEmpty(defualtValue))
                cmb.Value = defualtValue;
        }
        #endregion

        #endregion
     
    }
}
