using DMS.Forms.DAP.InitIDE;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMS.Forms.DAP.SelectWindow {
    public partial class frmParameter : BaseForm {
        private string projectPath;
        private List<Control> uiProperties = new List<Control>();
        List<DapParameter> parameters = new List<DapParameter>();
        Dictionary<string, DapParameter> dicParameters = new Dictionary<string, DapParameter>();

        public frmParameter(string path) {
            InitializeComponent();
            this.projectPath = path;
            this.uiProperties.AddRange(new List<Control>{ this.txtAppId, this.txtIamApToken, this.txtDmcUserName, this.txtDmcPwd,
                this.txtDmcBucketName, this.txtEaiUrl, this.chkDbEnabled, this.txtDbUrl, this.txtDbUsername,
                this.txtDbPassword, this.chkTenantEnabled, this.chkMgmtFieldEnabled, this.txtMgmtFieldResolver,
                this.txtMgmtFieldInsertMappings, this.txtMgmtFieldUpdateMappings, this.txtMqUri, this.txtEsp,
                this.txtMdc, this.txtTm, this.txtEoc, this.txtEocUrl, this.txtDmcUrl, this.txtIamUrl,
                this.txtRedisHost,this.txtRedisPort,this.txtRedisPwd
            });
            this.InitUiProperties();
        }

        private void btnSet_Click(object sender, EventArgs e) {
            InitTool init = new InitTool();
            this.BuildParameter();
            init.SaveRunnintParameter(parameters, projectPath);
            MessageBox.Show("设置完成...");
        }

        private void InitUiProperties() {
            InitTool init = new InitTool();
            parameters = init.GetDapParameters();
            foreach (DapParameter parameter in parameters) {
                dicParameters.Add(parameter.Name, parameter);
            }
            foreach (Control control in this.uiProperties) {
                if (control.Tag != null) {
                    string tag = control.Tag.ToString();
                    DapParameter parameter = null;
                    if (dicParameters.TryGetValue(tag, out parameter)) {
                        if (control is CheckBox) {
                            CheckBox box = control as CheckBox;
                            box.Checked = parameter.Value.Equals("true");
                        } else {
                            control.Text = parameter.Value;
                        }
                    }
                }
            }
        }

        private void BuildParameter() {
            foreach (Control control in this.uiProperties) {
                if (control.Tag != null) {
                    string tag = control.Tag.ToString();
                    DapParameter parameter = dicParameters[tag];
                    if (parameter != null) {
                        if (control is CheckBox) {
                            CheckBox box = control as CheckBox;
                            parameter.Value = box.Checked ? "true" : "false";
                        } else {
                            parameter.Value = control.Text;
                        }
                    }
                }
            }
        }
    }
}
