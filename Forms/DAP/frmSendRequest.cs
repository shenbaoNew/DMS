using DMS.DataClass.Pub;
using DMS.DataModel.Pub;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DMS.Forms {
    public partial class frmSendRequest : BaseForm {
        private const string local = "http://127.0.0.1:8085/eai";
        private static string[] EXCEPT_HEADER = { "User-Agent", "Accept", "Cache-Control", "Postman-Token", "Host", "Accept-Encoding", "Content-Length"
                , "Connection", "remoteip" , "host", "content-length","user-agent","accept-encoding" };

        public frmSendRequest() {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            txtReqBody.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("JSON");
        }

        private void btnFormat_Click(object sender, EventArgs e) {
            if (this.txtOriRequest.Text.Trim().Length <= 0) {
                return;
            }
            this.parseRequest();
        }

        private void parseRequest() {
            string request = this.txtOriRequest.Text.Trim();
            string[] arrays = request.Split(Environment.NewLine.ToArray());
            if (chklocal.Checked) {
                this.txtUrl.Text = local;
            } else {
                this.txtUrl.Text = convertUrl(arrays[0].TrimStart("POST".ToCharArray()).Trim());
            }

            StringBuilder strReqHeader = new StringBuilder();
            int index = 2;
            for (; index < arrays.Length; index++) {
                if (!string.IsNullOrEmpty(arrays[index])) {
                    if (this.chklocal.Checked && (arrays[index].StartsWith("x-") || EXCEPT_HEADER.Contains(arrays[index].Split(':')[0]))) {
                        continue;
                    }

                    strReqHeader.Append(arrays[index]);
                    strReqHeader.Append(Environment.NewLine);
                } else {
                    break;
                }
            }
            this.txtReqHeader.Text = strReqHeader.ToString();
            this.setHeaderColor();

            StringBuilder strReqBody = new StringBuilder();
            index++;
            for (; index < arrays.Length; index++) {
                if (!string.IsNullOrEmpty(arrays[index])) {
                    strReqBody.Append(arrays[index]);
                }
            }
            this.txtReqBody.Text = JsonHelper.FormateJson(strReqBody.ToString().Trim());
        }

        private void setHeaderColor() {
            this.SetColor("digi-service", Color.Red);
            this.SetColor("digi-host", Color.Red);
            this.SetColor("token", Color.Red);
            this.SetColor(@"""name"":""[\s\S]+?""", Color.Blue);
            this.SetColor(@"""prod"":""[\s\S]+?""", Color.Blue);
        }


        private void buttonX1_Click(object sender, EventArgs e) {
            if (this.txtReqHeader.Text.Trim().Length <= 0
                || this.txtReqBody.Text.Trim().Length <= 0)
                return;
            try {
                string result = this.SendRequest();
                try {
                    this.txtResponse.Text = JsonHelper.FormateJson(result);
                } catch (Exception ex) {
                    this.txtResponse.Text = result;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                this.txtResponse.Text = "";
            }
        }

        private string SendRequest() {
            string[] arrays = this.txtReqHeader.Text.Trim().Split(Environment.NewLine.ToArray());
            Dictionary<string, string> headers = new Dictionary<string, string>();
            for (int index = 0; index < arrays.Length; index++) {
                if (!string.IsNullOrEmpty(arrays[index])) {
                    this.SetHeaderValue(arrays[index], headers);
                }
            }
            string body = this.txtReqBody.Text;
            string result = PubHttp.HttpPost(this.txtUrl.Text, headers, body);
            return result;
        }

        public string convertUrl(string url) {
            if (url.Contains("http://") && url.Contains("digiwincloudlocal")) {
                return url.Replace("http://", "https://").Replace("digiwincloudlocal", "digiwincloud");
            }
            return url;
        }

        private void SetHeaderValue(string value, Dictionary<string, string> headers) {
            int index = value.IndexOf(':');
            headers.Add(value.Substring(0, index), value.Substring(index + 1));
        }

        private void lblFormat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.txtReqBody.Text = JsonHelper.FormateJson(this.txtReqBody.Text);
        }

        public void SetColor(string text, Color color) {
            Regex regex = new Regex(text);
            MatchCollection matchList = regex.Matches(this.txtReqHeader.Text);
            if (matchList != null) {
                foreach (Match match in matchList) {
                    int index = this.txtReqHeader.Text.IndexOf(match.Value);
                    if (index >= 0) {
                        this.txtReqHeader.Select(index, match.Value.Length);
                        this.txtReqHeader.SelectionColor = color;
                    }
                }
            }
        }

        private void chklocal_CheckedChanged(object sender, EventArgs e) {
            if (this.chklocal.Checked) {
                this.txtUrl.Text = local;
            }
        }

        private void lblKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string headerStr = this.txtReqHeader.Text;
            string digiHost = this.getMatchStr(@"digi-host: ([\s\S]+?\})");
            string digiService = this.getMatchStr(@"digi-service: ([\s\S]+?\})");
            string oriKey = this.getMatchStr(@"digi-key: ([\s\S]+?)\n");
            string key = CommonHelper.GenCrossKey(digiHost + digiService);
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(oriKey)) {
                headerStr = headerStr.Replace(oriKey, key);
                this.txtReqHeader.Text = headerStr;
                this.setHeaderColor();
            }
        }

        private string getMatchStr(string pattern) {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(this.txtReqHeader.Text);
            if (match != null) {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }
    }
}
