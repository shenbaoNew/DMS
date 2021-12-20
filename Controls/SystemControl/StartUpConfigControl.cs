using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMS.Properties;
using System.Xml;
using YY.Methods;
using DMS.DataClass.Systems.User;

namespace DMS.Controls.SystemControl
{
    public partial class StartUpConfigControl : BaseSettingControl
    {
        public StartUpConfigControl()
        {
            InitializeComponent();
            BindData();
            InitData();
        }

        private void InitData()
        {
            this.cmbMenu.SelectedValue = PubContext.CurrentUser.FormModule;
            this.cmbDesk.SelectedValue = PubContext.CurrentUser.ShortCutStyle;
            this.cmbUIStyle.SelectedValue = PubContext.CurrentUser.UIStyleID;
            string color = PubContext.CurrentUser.UIStyleColor;
            if (color.IndexOf(',') > -1)
            {
                string[] colors = color.Split(',');
                if (colors.Length >= 4)
                {
                    int A = Functions.FormatInt(colors[0]);
                    int R = Functions.FormatInt(colors[1]);
                    int G = Functions.FormatInt(colors[2]);
                    int B = Functions.FormatInt(colors[3]);
                    this.cmbColor.SelectedColor = Color.FromArgb(A, R, G, B);
                }
            }
        }

        private void BindData()
        {
            DataTable table = Functions.CreateDataTable("ID:Int;Name:String", "0:菜单栏(默认);1:普通;2:菜单条");
            DataBinds.BindSource(this.cmbMenu, table, "Name", "ID", 0, false);
            table = Functions.CreateDataTable("ID:Int;Name:String", "0:关闭;1:左边;2:右边;3:底部");
            DataBinds.BindSource(this.cmbDesk, table, "Name", "ID", 0, false);
            BindUIStyle();
        }

        private void BindUIStyle()
        {
            DataTable table = Functions.CreateDataTable("ID:Int;Name:String");
            DataRow newRow = table.NewRow();
            newRow["ID"] = -1;
            newRow["Name"] = "无";
            table.Rows.Add(newRow);

            foreach (DevComponents.DotNetBar.eStyle c in (DevComponents.DotNetBar.eStyle[])Enum.GetValues(typeof(DevComponents.DotNetBar.eStyle)))
            {
                newRow = table.NewRow();
                newRow["ID"] = (int)c;
                newRow["Name"] = c.ToString();
                table.Rows.Add(newRow);
            }
            DataBinds.BindSource(this.cmbUIStyle, table, "Name", "ID", 0, false);
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIdex = Functions.FormatInt(cmbMenu.SelectedValue);
            switch (selectIdex)
            {
                case 0:
                    pictureBox.Image = Properties.Resources.explorerform;
                    break;
                case 1:
                    pictureBox.Image = Properties.Resources.menuform0;
                    break;
                case 2:
                    pictureBox.Image = Resources.menuform;
                    break;
            }
        }

        public override bool SaveData()
        {
            bool result = false;
            string formModule = this.cmbMenu.SelectedValue.ToString();
            string desk = this.cmbDesk.SelectedValue.ToString();
            string styleId = this.cmbUIStyle.SelectedValue.ToString();
            Color selectColor = this.cmbColor.SelectedColor;
            string color = selectColor.A.ToString() + "," + selectColor.R.ToString() + "," + selectColor.G.ToString() + "," + selectColor.B.ToString();

            XmlDocument xml = new XmlDocument();
            xml.Load("menu.xml");
            XmlNode node = XmlHelper.GetNodeByPath(@"DMS/Users/User/FormModule", xml);
            node.InnerText = formModule;
            node = XmlHelper.GetNodeByPath(@"DMS/Users/User/UIStyleID", xml);
            node.InnerText = styleId;
            node = XmlHelper.GetNodeByPath(@"DMS/Users/User/ShortCut/Style", xml);
            node.InnerText = desk;
            node = XmlHelper.GetNodeByPath(@"DMS/Users/User/UIStyleColor", xml);
            node.InnerText = color;
            xml.Save("menu.xml");

            DialogBox.ShowInformation("新的配置已生效，请重启系统，启用新的配置！");

            return result;
        }
    }
}
