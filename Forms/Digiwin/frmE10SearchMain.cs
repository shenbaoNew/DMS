using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KMSearchTools;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace DMS.Forms
{
    public partial class frmE10SearchMain : BaseForm
    {
        static string _hostname;
        static string _sNodeIP;
        static string _sNodeOSDesc;
        static bool _KMWebLogin = false;
        static bool _E10WebLogin = false;
        static bool _SpecWebLogin = false;
        static WebBrowser _webBrowser = null;
        static private SettingPara databasePara = null;
        static public void SetKMUser(string sUser, string sPW) {
            if (databasePara != null) {
                databasePara.KMUser = sUser;
                databasePara.KMPW = KMSearchTools.Security.EncryptDES(sPW);

                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["username"].Value = databasePara.KMUser;
                cfa.AppSettings.Settings["userPW"].Value = databasePara.KMPW;
                cfa.Save();

            }
        }
        static public SettingPara FSettingPara {
            get {
                if (databasePara == null) {
                    databasePara = new SettingPara();
                    databasePara.TabPage = ConfigurationManager.AppSettings["TabPage"];
                    databasePara.DatabaseIP = ConfigurationManager.AppSettings["DatabaseIP"];
                    databasePara.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
                    databasePara.DatabaseUser = ConfigurationManager.AppSettings["DatabaseUser"];
                    databasePara.DatabasePW = ConfigurationManager.AppSettings["DatabasePW"];
                    databasePara.KMUser = ConfigurationManager.AppSettings["username"];
                    databasePara.KMPW = ConfigurationManager.AppSettings["userPW"];
                }
                return databasePara;
            }
            set {
                databasePara.DatabaseIP = value.DatabaseIP;
                databasePara.DatabaseName = value.DatabaseName;
                databasePara.DatabaseUser = value.DatabaseUser;
                databasePara.DatabasePW = value.DatabasePW;
            }
        }
        public frmE10SearchMain()
        {
            InitializeComponent();
            _hostname = System.Net.Dns.GetHostName();
            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(_hostname);
            _sNodeIP = ipEntry.AddressList[1].ToString();
            _sNodeOSDesc = System.Environment.OSVersion.VersionString;
            //panel1.Height = 27;
            int iTab = 0;
            string sTab= FSettingPara.TabPage;
            if (!string.IsNullOrEmpty(sTab))
            {
                if (sTab.Length > 0 && char.IsDigit(sTab[0]))
                    iTab = int.Parse(sTab[0].ToString());
                if (iTab > 5)
                    iTab = 0;
            }
            else
                iTab = 0;

            SelectedIndexChanged();
            SearchData(-1,true);
            //if (_UserName.ToLower() != "admin") {
            //    btnSetting.Visible = false;
                //btnLogSearch.Visible = false;
            //}

            if (string.IsNullOrEmpty( FSettingPara.KMUser))
                iTab = 0;
            tabControlSearch.SelectedTabIndex = iTab;

        }

        private void button1_Click(object sender, EventArgs e) {
            if (!LoginOne())
                return;
            SearchData(-1,false);//tabControlSearch.SelectedTabIndex);
        }
        public static SqlConnection GetConnection() {
           string txtIP = FSettingPara.DatabaseIP;
           string  txtDB = FSettingPara.DatabaseName;
           string  txtUser = FSettingPara.DatabaseUser;
            string sPW = FSettingPara.DatabasePW;
            string txtPW = KMSearchTools.Security.DecryptDES(sPW);

            //string MyConn = ConfigurationManager.ConnectionStrings["KMSearchTools.Properties.Settings.KMSearchConnectionString"].ToString();
            string MyConn = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtIP, txtDB, txtUser, txtPW);
            SqlConnection MyConnection = new SqlConnection(MyConn);
            return MyConnection;
        } 
         
        private void SearchData(int iPage,bool bFirst) {
            string sText = txtSearch.Text;
            if (iPage == -1 || iPage == 0) {
                string sKMText = HttpUtility.UrlEncode(sText);
                //string sKMText = HttpUtility.UrlEncodeUnicode(sText);
                string sKM = @"http://ikmcn.digiwin.biz/SmartKMS/search/DocumentSearch.action?form.allText=" + sKMText + "&form.categoryIds=51400";
                if (bFirst)
                    sKM = "http://ikmcn.digiwin.biz/SmartKMS/LoginPage.action";
                webBrowserKM.Navigate(sKM);
            }
            if (iPage == -1 || iPage == 1) {

                string sMars = @"http://172.16.1.91:8092/search.html?SearchText=" + sText;
                webBrowserMars.Navigate(sMars);
            }
            if (iPage == -1 || iPage == 2) {
                string sE10Text = HttpUtility.UrlEncode(sText, Encoding.GetEncoding("GB2312"));
                string sE10 = @"http://172.16.1.91:8091/search?word=" + sE10Text + "&lm=1&sort=1";
                webBrowserE10.Navigate(sE10);
            }
            if (iPage == -1 || iPage == 3) {

                string sFileText = HttpUtility.UrlEncode(sText);
                string sFile = @"http://172.16.1.91:8093/?search=" + sFileText;
                webBrowserFile.Navigate(sFile);
            }

            if (iPage == -1 || iPage == 4) {
                string sE10Text = HttpUtility.UrlEncode(sText, Encoding.GetEncoding("GB2312"));
                string sE10 = @"http://192.168.9.92:8091/search?word=" + sE10Text + "&lm=1&sort=1";
                webBrowserSpec.Navigate(sE10);
            }
            if (iPage == -1 || iPage == 5) {

                string sFileText = HttpUtility.UrlEncode(sText);
                string sFile = @"http://192.168.9.92:8093/?search=" + sFileText;
                webBrowserSpFile.Navigate(sFile);
            }
            //if (iPage != -1 )
                 WriteSearchLog(txtSearch.Text);
        }
        private void WriteSearchLog(string sSearchKey) {
            if (string.IsNullOrEmpty(sSearchKey))
                return;
            string sType = "ALL";
            if (tabControlSearch.SelectedTabIndex == 0)
                sType = "KM";
            else if (tabControlSearch.SelectedTabIndex == 1)
                sType = "Mars";
            else if (tabControlSearch.SelectedTabIndex == 2)
                sType = "E10";
            else if (tabControlSearch.SelectedTabIndex == 3)
                sType = "File";
            else if (tabControlSearch.SelectedTabIndex == 4)
                sType = "Spec";
            else if (tabControlSearch.SelectedTabIndex == 5)
                sType = "SpFi";
            SqlConnection MyConnection = GetConnection();
            string sSql = "insert into tbSearchLog(SearchType,SearchTime,SearchKey,username,IPAdress,Machinename) values("
                + "'" + sType + "',GETDATE(),'" + sSearchKey + "','" + FSettingPara.KMUser + "','" + _sNodeIP + "','" + _hostname + "')";
            SqlCommand MyCommand = new SqlCommand(sSql, MyConnection);
            try {
                MyConnection.Open();
                MyCommand.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("数据库连接错误，请点设置按钮，设置正确的数据连接,详情：" + ex.Message);
            } finally {
                MyConnection.Close();
            }
        }
       
        private void KMLogin() {
            if (webBrowserKM.Document == null)
                return;
            //HtmlElement btnSubmit = webBrowser1.Document.All["button"];
            HtmlElement tbUserid = webBrowserKM.Document.All["loginUser.account"];
            HtmlElement tbPasswd = webBrowserKM.Document.All["loginUser.password"];

            if (tbUserid == null || tbPasswd == null )
                return;

            tbUserid.SetAttribute("value", FSettingPara.KMUser);
            tbPasswd.SetAttribute("value", KMSearchTools.Security.DecryptDES(FSettingPara.KMPW));

            HtmlElement formLogin = webBrowserKM.Document.Forms["theForm"];
            formLogin.InvokeMember("submit");
            //btnSubmit.InvokeMember("click");
        }
        private void E10Login(WebBrowser webBrowser) {
            if (webBrowser.Document == null)
                return;
            HtmlElement btnSubmit = webBrowser.Document.All["button"];
            HtmlElement tbUserid = webBrowser.Document.All["username"];
            HtmlElement tbPasswd = webBrowser.Document.All["password"];

            if (tbUserid == null || tbPasswd == null || btnSubmit == null)
                return;

            tbUserid.SetAttribute("value","pr");
            tbPasswd.SetAttribute("value","123456");

            btnSubmit.InvokeMember("click");
        }


        private void webBrowserKM_BeforeNewWindow(object sender, WebBrowserExtendedNavigatingEventArgs e) {
            e.Cancel = true;
            ((ExtendedWebBrowser)sender).Navigate(e.Url);
        }

        private void webBrowserKM_Navigating(object sender, WebBrowserNavigatingEventArgs e) {

        }

        private void webBrowserKM_NewWindow(object sender, CancelEventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            E10Login(webBrowserE10);
            E10Login(webBrowserSpec);
            KMLogin();
        }

        private void FrmMain_Shown(object sender, EventArgs e) {
            //timer1.Enabled = true;

        }


        private void FrmMain_Load(object sender, EventArgs e) {

           
        }

        private void webBrowserKM_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (!_KMWebLogin) {
                _KMWebLogin = true;
                KMLogin();
            }
            DocumentCompleted(sender as WebBrowser);
        }

        private void webBrowserE10_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (!_E10WebLogin) {
                _E10WebLogin = true;
                E10Login(webBrowserE10);
            }

            DocumentCompleted(sender as WebBrowser);
        }
        private void webBrowserSpec_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (!_SpecWebLogin) {
                _SpecWebLogin = true;
                E10Login(webBrowserSpec);
            }

            DocumentCompleted(sender as WebBrowser);

        }

       private void webBrowserMars_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            DocumentCompleted(sender as WebBrowser);
        }

       private void DocumentCompleted(WebBrowser webBrowser) {
           HtmlDocument htmlDoc = webBrowser.Document;
           foreach (HtmlElement formElement in htmlDoc.Forms) {
               formElement.AttachEventHandler("onsubmit", new EventHandler(HtmlForm_Submit));
           }
           btnGoBack.Enabled = _webBrowser.CanGoBack;
           btnGoForward.Enabled = _webBrowser.CanGoForward;

           string sUrl = _webBrowser.Url.AbsoluteUri;
           txtUrl.Text = sUrl;
       }
       private void webBrowserFile_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
           DocumentCompleted(sender as WebBrowser);
       }
       
        private bool LoginOne() {
           if (webBrowserKM.Document == null)
               return false;
           HtmlElement tbUserid = webBrowserKM.Document.All["loginUser.account"];
           HtmlElement tbPasswd = webBrowserKM.Document.All["loginUser.password"];

           if (tbUserid != null && tbPasswd != null) {
               MessageBox.Show("请先在KM中登录一次，以后无需手动登录，会自动登录！");
               tabControlSearch.SelectedTabIndex = 0;
               return false;
           }

           return true;
       }

       private void HtmlForm_Submit(object sender, EventArgs e) {
           //查找搜索文本，记日志
           string sWord = "";
           if (tabControlSearch.SelectedTabIndex == 0) {

               HtmlElement tbUserid = webBrowserKM.Document.All["loginUser.account"];
               HtmlElement tbPasswd = webBrowserKM.Document.All["loginUser.password"];

               if (tbUserid != null && tbPasswd != null) {

                 string sUser=  tbUserid.GetAttribute("value");
                 string sPW=  tbPasswd.GetAttribute("value");
                 SetKMUser(sUser, sPW);
               } else {

                   HtmlElement htmlWord = _webBrowser.Document.All["form.allText"];
                   if (htmlWord != null)
                       sWord = htmlWord.GetAttribute("value");
                   htmlWord = _webBrowser.Document.All["form.title"];
                   if (htmlWord != null)
                       sWord += htmlWord.GetAttribute("value");

               }

           } else if (tabControlSearch.SelectedTabIndex == 1) {
               HtmlElement htmlWord = _webBrowser.Document.All["word"];
               if (htmlWord != null)
                   sWord = htmlWord.GetAttribute("value");

           } else if (tabControlSearch.SelectedTabIndex == 2) {
               HtmlElement htmlWord = _webBrowser.Document.All["txtSearchText"];
               if (htmlWord != null)
                   sWord = htmlWord.GetAttribute("value");
           } else if (tabControlSearch.SelectedTabIndex == 3) {
               HtmlElement htmlWord = _webBrowser.Document.All["search"];
               if (htmlWord != null)
                   sWord = htmlWord.GetAttribute("value");
           } else if (tabControlSearch.SelectedTabIndex == 4) {
               HtmlElement htmlWord = _webBrowser.Document.All["word"];
               if (htmlWord != null)
                   sWord = htmlWord.GetAttribute("value");
           } else if (tabControlSearch.SelectedTabIndex == 5) {
               HtmlElement htmlWord = _webBrowser.Document.All["search"];
               if (htmlWord != null)
                   sWord = htmlWord.GetAttribute("value");
           } 
           WriteSearchLog(sWord);
       }


        private void btnGoBack_Click(object sender, EventArgs e) {
            _webBrowser.GoBack();        
        }

        private void btnGoForward_Click(object sender, EventArgs e) {
            _webBrowser.GoForward();
        }

        private void tabControlSearch_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedIndexChanged();
 
        }

        private void SelectedIndexChanged() {
            if (tabControlSearch.SelectedTabIndex == 0)
                _webBrowser = webBrowserKM;
            else if (tabControlSearch.SelectedTabIndex == 1)
                _webBrowser = webBrowserMars;
            else if (tabControlSearch.SelectedTabIndex == 2)
                _webBrowser = webBrowserE10;
            else if (tabControlSearch.SelectedTabIndex == 3)
                _webBrowser = webBrowserFile;
            else if (tabControlSearch.SelectedTabIndex == 4)
                _webBrowser = webBrowserSpec;
            else if (tabControlSearch.SelectedTabIndex == 5)
                _webBrowser = webBrowserSpFile;

            btnGoBack.Enabled = _webBrowser.CanGoBack;
            btnGoForward.Enabled = _webBrowser.CanGoForward;
            if (_webBrowser.Url != null) {
                string sUrl = _webBrowser.Url.AbsoluteUri;
                txtUrl.Text = sUrl;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e) {
            using (FrmSetting frm = new FrmSetting()) {
                frm.ShowDialog();
            }
        }

        private void btnLogSearch_Click(object sender, EventArgs e) {

        }

        private void btnGO_Click(object sender, EventArgs e) {
            UrlNavigate();
        }

        private void UrlNavigate() {
            string sUrl = txtUrl.Text;
            _webBrowser.Navigate(sUrl);
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e) {
            //if (e.KeyCode==Keys.Enter)
            //    UrlNavigate();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["TabPage"].Value = tabControlSearch.SelectedTabIndex.ToString() ;
            cfa.Save();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void tabControlSearch_Deselecting(object sender, TabControlCancelEventArgs e) {
            if (tabControlSearch.SelectedTabIndex == 0 && !LoginOne())
                e.Cancel = true;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e) {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.H)
            {
                //if (panel1.Height != 57)
                //    panel1.Height = 57;
                //else
                //    panel1.Height = 27;
            }
        }

        private void webBrowserFile_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode != Keys.Enter)
                return;
            string sKey="search";
            if (tabControlSearch.SelectedTabIndex == 2 || tabControlSearch.SelectedTabIndex == 4)
                sKey = "word";

            HtmlElement htmlWord = _webBrowser.Document.All[sKey];
            string sWord = null;
            if (htmlWord != null)
                sWord = htmlWord.GetAttribute("value");
            if (!string.IsNullOrEmpty(sWord))
                txtSearch.Text = sWord;
        }
    }
}
