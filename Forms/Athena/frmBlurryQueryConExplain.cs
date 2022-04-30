using DMS.DataModel.Model.Athena;
using DMS.DataModel.Pub;
using DMS.Forms.Common;
using System;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms {
    public partial class frmBlurryQueryConExplain : BaseForm {
        public frmBlurryQueryConExplain() {
            InitializeComponent();
        }

        private void lblFormat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.txtJson.Text = JsonHelper.FormateJson(this.txtJson.Text);
        }

        private void btnParse_Click(object sender, EventArgs e) {
            this.txtCon.Text = "";
            if (string.IsNullOrEmpty(this.txtJson.Text)) {
                return;
            }
            try {
                this.txtCon.Text = BuildDynamicCondition();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        public String BuildDynamicCondition() {
            Parameter parameter = Newtonsoft.Json.JsonConvert.DeserializeObject<Parameter>(this.txtJson.Text);
            if (parameter.Conditions == null || parameter.Conditions.Count <= 0) {
                return "";
            }
            //按order排序
            parameter.Conditions.Sort((c1, c2) => c1.GetOrder().CompareTo(c2.GetOrder()));
            StringBuilder conditions = new StringBuilder();
            parameter.Conditions.ForEach(c => conditions.Append(c.ToString()));
            return conditions.ToString();
        }

        private void btnCase_Click(object sender, EventArgs e) {
            frmCommonWindow commonWindow = new frmCommonWindow("范例json", jsonCase);
            DialogResult result = commonWindow.ShowDialog();
            if (result == DialogResult.OK) {
                this.txtJson.Text = commonWindow.Message;
            }
        }

        private string jsonCase = "{\r\n" +
                "  \"search_info\": [\r\n" +
                "    {\r\n" +
                "      \"order\": 1,\r\n" +
                "      \"bracket\": \"(\",\r\n" +
                "      \"logic\": \"AND\",\r\n" +
                "      \"search_field\": \"code\",\r\n" +
                "      \"search_operator\": \"equal\",\r\n" +
                "      \"search_value\": [\"10001\"]\r\n" +
                "    },\r\n" +
                "    {\r\n" +
                "      \"order\": 2,\r\n" +
                "      \"bracket\": \")\",\r\n" +
                "      \"logic\": \"OR\",\r\n" +
                "      \"search_field\": \"status\",\r\n" +
                "      \"search_operator\": \"equal\",\r\n" +
                "      \"search_value\": [\"Y\"]\r\n" +
                "    },\r\n" +
                "    {\r\n" +
                "      \"order\": 3,\r\n" +
                "      \"bracket\": \"(\",\r\n" +
                "      \"logic\": \"AND\",\r\n" +
                "      \"search_field\": \"name\",\r\n" +
                "      \"search_operator\": \"like\",\r\n" +
                "      \"search_value\": [\"机台\"]\r\n" +
                "    },\r\n" +
                "    {\r\n" +
                "      \"order\": 4,\r\n" +
                "      \"bracket\": \")\",\r\n" +
                "      \"logic\": \"\",\r\n" +
                "      \"search_field\": \"status\",\r\n" +
                "      \"search_operator\": \"equal\",\r\n" +
                "      \"search_value\": [\"Y\"]\r\n" +
                "    }\r\n" +
                "  ]\r\n" +
                "}";
    }
}
