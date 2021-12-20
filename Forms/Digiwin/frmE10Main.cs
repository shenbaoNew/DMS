using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DMS.DataClass.Digiwin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace DMS.Forms
{
    public partial class frmE10Main : BaseForm
    {
        private string _applicationServerName;
        private string _applicationClientName;
        private string _ooqlName;
        private string _cmName;
        private int _waitTime = 10;

        private List<string> CustomerSource = new List<string>();
        private List<string> OOQLCustomerSource = new List<string>();
        private List<string> CMCustomerSource = new List<string>();
        private List<string> E10SrcCustomerSource = new List<string>();

        DigiwinHelper _digiwinHelper;

        private string ServerStartModule { get; set; }
        private string ClientStartModule { get; set; }

        public frmE10Main()
        {
            InitializeComponent();

            this.subItem0.Click += subItemServer_Click;
            this.subItem1.Click += subItemServer_Click;
            this.subItem2.Click += subItemServer_Click;
            this.subItem3.Click += subItemServer_Click;

            this.subItem4.Click += subItemClient_Click;
            this.subItem5.Click += subItemClient_Click;
            this.subItem6.Click += subItemClient_Click;

            this.txtPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtPath.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtOOQL.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtOOQL.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtCM.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtCM.AutoCompleteSource = AutoCompleteSource.CustomSource;

            this.txtSrcPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtSrcPath.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ReadRecentInfos("E10Items");
            ReadRecentInfos("OOQLItems");
            ReadRecentInfos("CMItems");
            ReadRecentInfos("E10SrcItems");

            InitComboxDataSource();
        }

        #region E10

        private void subItemClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                return;

            _applicationClientName = txtPath.Text.Trim() + @"\DeployServer\Shared\Digiwin.Mars.ClientStart.exe";
            this.ClientStartModule = (sender as ButtonItem).Tag.ToString();

            StartClient();
        }

        void subItemServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                return;

            _applicationServerName = txtPath.Text.Trim() + @"\Server\Control\Digiwin.Mars.ServerStart.exe";
            this.ServerStartModule = (sender as ButtonItem).Tag.ToString();

            StartServer();
            SetCurrentLicense();
        }

        private void btnPathClear_Click(object sender, EventArgs e) {
            ClearRecentInfos("E10Items");
            ReadRecentInfos("E10Items");
        }

        /// <summary>
        /// 启动服务端
        /// </summary>
        private void StartServer()
        {
            if (string.IsNullOrEmpty(_applicationServerName))
                return;
            if (!File.Exists(_applicationServerName))
                return;
            WriteRecentInfos(" " + txtPath.Text.Trim(),"E10Items");

            Process p = new Process();
            p.StartInfo.FileName = _applicationServerName;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = true;
            if (!string.IsNullOrEmpty(ServerStartModule))
                p.StartInfo.Arguments = ServerStartModule;
            p.Start();
        }

        /// <summary>
        /// 启动客户端
        /// </summary>
        private void StartClient()
        {
            if (string.IsNullOrEmpty(_applicationClientName))
                return;
            if (!File.Exists(_applicationClientName))
                return;
            WriteRecentInfos(" " + txtPath.Text.Trim(), "E10Items");

            Process p = new Process();
            p.StartInfo.FileName = _applicationClientName;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = true;
            if (!string.IsNullOrEmpty(ClientStartModule))
                p.StartInfo.Arguments = ClientStartModule;
            p.Start();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                return;

            if (Directory.Exists(txtPath.Text.Trim()))
            {
                Process.Start("Explorer.exe", txtPath.Text.Trim());
            }
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
        }

        private void btnSetE10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
                return;

            ReplaceFile("AccountSetsConfiguration.xml");
        }

        private void ReplaceFile(string fileName)
        {
            XmlDocument xml = XmlHelper.GetXmlDocument(txtPath.Text.Trim() + @"\Server\Control\" + fileName, true);
            string text = xml.InnerXml;
            Regex regex = new Regex(@"((([1-9]?|1\d)\d|2([0-4]\d|5[0-5]))\.){3}(([1-9]?|1\d)\d|2([0-4]\d|5[0-5]))");

            MatchCollection mc = regex.Matches(text);

            string newTest = regex.Replace(text, "127.0.0.1");
        }

        #endregion

        #region OOQL

        private void btnOOQL_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOOQL.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnStartOOQL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOOQL.Text.Trim()))
                return;

            _ooqlName = txtOOQL.Text.Trim() + @"\OOQLDesigner.exe";

            if (string.IsNullOrEmpty(_ooqlName))
                return;
            if (!File.Exists(_ooqlName))
                return;
            WriteRecentInfos(" " + txtOOQL.Text.Trim(), "OOQLItems");

            Process p = new Process();
            p.StartInfo.FileName = _ooqlName;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        private void btnSubOOQL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOOQL.Text.Trim()))
                return;

            if (Directory.Exists(txtOOQL.Text.Trim()))
            {
                Process.Start("Explorer.exe", txtOOQL.Text.Trim());
            }
        }

        private void btnOOQLClear_Click(object sender, EventArgs e) {
            ClearRecentInfos("OOQLItems");
            ReadRecentInfos("OOQLItems");
        }

        #endregion

        #region Licence

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cmbBox1.SelectedNode == null)
                return;

            DataRowView dr = cmbBox1.SelectedNode.DataKey as DataRowView;
            DataClass.Digiwin.License license = new DataClass.Digiwin.License()
            {
                BindToIP = dr["BindToIP"].ToString(),
                BindToPort = dr["BindToPort"].ToString(),
                ControlCenterPort = dr["ControlCenterPort"].ToString()
            };

            _digiwinHelper.ResetAccountSetsConfiguration(license);
            this.lblLicense.Text = _digiwinHelper.ToString();

            MessageBox.Show("设置成功","系统提示",MessageBoxButtons.OK);
        }

        private void InitComboxDataSource()
        {
            XmlDocument xml = XmlHelper.GetXmlDocument("recent.xml", true);

            DataTable dt = XmlHelper.XmlNodesToDataTable(new string[] { "BindToIP", "BindToPort", "ControlCenterPort" }, xml, @"DMS/LicenseCenter");
            this.cmbBox1.DataSource = dt;

            this.cmbBox1.DisplayMembers = "BindToIP,BindToPort,ControlCenterPort";
            this.cmbBox1.FilterMembers = "BindToIP,BindToPort,ControlCenterPort";
            this.cmbBox1.ColumnWidths = "40%,30%,30%";
            this.cmbBox1.HeadTexts = "BindToIP,BindToPort,ControlCenterPort";
        }

        private void SetCurrentLicense()
        {
            if (this.txtPath.Text.Trim() == string.Empty)
                return;

            if (_digiwinHelper == null || _digiwinHelper.LocationPath != this.txtPath.Text.Trim())
            {
                _digiwinHelper = new DigiwinHelper(this.txtPath.Text.Trim());
                _digiwinHelper.LoadCurrentLicense();
                this.lblLicense.Text = _digiwinHelper.ToString();
                if (_digiwinHelper.CurrentLicense != null)
                {
                    foreach (Node item in cmbBox1.Nodes)
                    {
                        DataRowView dr = item.DataKey as DataRowView;

                        if (dr["BindToIP"].ToString() == _digiwinHelper.CurrentLicense.BindToIP &&
                            dr["BindToPort"].ToString() == _digiwinHelper.CurrentLicense.BindToPort &&
                            dr["ControlCenterPort"].ToString() == _digiwinHelper.CurrentLicense.ControlCenterPort)
                        {
                            cmbBox1.SelectedNode = item;
                            break;
                        }
                    }
                }
            }
            else
                this.lblLicense.Text = _digiwinHelper.ToString();
        }

        #endregion

        #region CM

        private void btnCM_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtCM.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSubCM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCM.Text.Trim()))
                return;

            if (Directory.Exists(txtCM.Text.Trim()))
            {
                Process.Start("Explorer.exe", txtCM.Text.Trim());
            }
        }

        private void btnStartCM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCM.Text.Trim()))
                return;

            _cmName = txtCM.Text.Trim() + @"\Digiwin.Mars.ClientStart.exe";

            if (string.IsNullOrEmpty(_cmName))
                return;
            if (!File.Exists(_cmName))
                return;
            WriteRecentInfos(" " + txtCM.Text.Trim(), "CMItems");

            Process p = new Process();
            p.StartInfo.FileName = _cmName;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        private void btnCMClear_Click(object sender, EventArgs e) {
            ClearRecentInfos("CMItems");
            ReadRecentInfos("CMItems");
        }

        #endregion

        #region E10Src

        private void btnSrcSelect_Click(object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                txtSrcPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSrcOpenPath_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtSrcPath.Text.Trim()))
                return;

            if (Directory.Exists(txtSrcPath.Text.Trim())) {
                Process.Start("Explorer.exe", txtSrcPath.Text.Trim());
            }
        }

        private void btnCopyAll_Click(object sender, EventArgs e) {
            KillApp(true, true);
            Copy(true, true);
            subItemServer_Click(this.subItem1, EventArgs.Empty);
        }

        private void btnCopyClient_Click(object sender, EventArgs e) {
            KillApp(true, false);
            Copy(true, false);
            subItemClient_Click(this.subItem5, EventArgs.Empty);
        }

        private void btnCopyServer_Click(object sender, EventArgs e) {
            KillApp(true, true);
            Copy(false, true);
            subItemServer_Click(this.subItem1, EventArgs.Empty);
        }

        private void btnSrcClear_Click(object sender, EventArgs e) {
            ClearRecentInfos("E10SrcItems");
            ReadRecentInfos("E10SrcItems");
        }

        private void Copy(bool isClient,bool isServer) {
            if (string.IsNullOrEmpty(txtSrcPath.Text))
                return;
            int index = txtSrcPath.Text.LastIndexOf('\\');
            if (index < 0)
                return;
            string subStr = txtSrcPath.Text.Substring(index + 1);
            WriteRecentInfos(" " + txtSrcPath.Text.Trim(), "E10SrcItems");
            if (subStr.Contains("Digiwin.ERP.")) {
                string typeKey = subStr.Substring(subStr.LastIndexOf('.') + 1);
                List<string> accembleList = SearchAllAssembly(txtSrcPath.Text.Trim());

                CopyDll(accembleList, isClient, isServer);
            }
        }

        private void KillApp(bool isClient, bool isServer) {
            KillAutoBuildCmd();
            if (isServer) {
                KillClient();
                KillServer();
            } else if (isClient) {
                KillClient();
            }
        }

        private void KillClient() {
            Process[] processes = Process.GetProcessesByName("Digiwin.Mars.ClientStart");
            if (processes != null && processes.Length > 0) {
                foreach (Process item in processes) {
                    string fileName = item.MainModule.FileName;
                    if (fileName.Contains(txtPath.Text.Trim()))
                        item.Kill();
                }
            }
        }

        private void KillServer() {
            Process[] processes = Process.GetProcessesByName("Digiwin.Mars.ServerStart");
            if (processes != null && processes.Length > 0) {
                processes[0].Kill();
            }
        }

        private void KillAutoBuildCmd() {
            Process[] processes = Process.GetProcessesByName("cmd");
            if (processes != null && processes.Length > 0) {
                foreach (Process item in processes)
                    item.Kill();
            }
        }

        private List<string> SearchAllAssembly(string path) {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] allFiles = dir.GetFiles("*.csproj", SearchOption.AllDirectories);
            XmlDocument doc = new XmlDocument();
            List<string> accembleList = new List<string>();
            foreach (FileInfo item in allFiles) {
                doc.Load(item.FullName);
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
                nsMgr.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");
                XmlNode node = doc.SelectSingleNode("/ns:Project/ns:PropertyGroup/ns:AssemblyName", nsMgr);
                if (node != null && !accembleList.Contains(node.InnerText + ".dll"))
                    accembleList.Add(node.InnerText + ".dll");
            }

            //资源文件dll
            List<string> resDlls = new List<string>();
            foreach (string dll in accembleList) {
                string recDll = dll.Insert(dll.LastIndexOf('.'), ".resources");
                resDlls.Add(recDll);
            }
            accembleList.AddRange(resDlls);

            return accembleList;
        }

        private void CopyDll(List<string> dllList,bool isClient,bool isServer) {
            DirectoryInfo dir = new DirectoryInfo(txtSrcPath.Text.Trim());
            List<string> clientDll = dllList.Where(c => c.EndsWith(".Business.dll")
                || c.EndsWith(".UI.dll")
                || c.EndsWith(".UI.Implement.dll")).ToList();
            List<string> serverDll = dllList.Where(c => c.EndsWith(".Business.dll")
                || c.EndsWith(".Business.Implement.dll")).ToList();

            List<string> clientResDll = dllList.Where(c => c.EndsWith(".Business.resources.dll")
                || c.EndsWith(".UI.resources.dll")
                || c.EndsWith(".UI.Implement.resources.dll")).ToList();

            List<string> serverResDll = dllList.Where(c => c.EndsWith(".Business.resources.dll")
                || c.EndsWith(".Business.Implement.resources.dll")).ToList();

            try {
                if (File.Exists(dir.Parent.FullName + "\\AutoBuild.bat")) {
                    File.Delete(dir.Parent.FullName + "\\AutoBuild.bat");
                }

                using (StreamWriter sw = File.CreateText(dir.Parent.FullName + "\\AutoBuild.bat")) {
                    sw.WriteLine("echo beging copy dll to E10");
                    sw.WriteLine();

                    #region 业务
                    //Client端
                    if (isClient) {
                        foreach (string item in clientDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\" + item + "  " + txtPath.Text.Trim() + "\\DeployServer\\Shared\\Programs";
                            sw.WriteLine(str);
                        }
                    }

                    //Server端
                    if (isServer) {
                        foreach (string item in serverDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\" + item + "  " + txtPath.Text.Trim() + "\\Server\\Application\\Programs";
                            sw.WriteLine(str);
                        }
                    }
                    #endregion

                    /*
                    #region zh-CHT
                    sw.WriteLine("echo beging copy zh-CHT resources dll to E10");
                    //Client端
                    if (isClient) {
                        foreach (string item in clientResDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\zh-CHT\\" + item + "  " + txtPath.Text.Trim() + "\\DeployServer\\Shared\\Programs\\zh-CHT";
                            sw.WriteLine(str);
                        }
                    }

                    //Server端
                    if (isServer) {
                        foreach (string item in serverResDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\zh-CHT\\" + item + "  " + txtPath.Text.Trim() + "\\Server\\Application\\Programs\\zh-CHT";
                            sw.WriteLine(str);
                        }
                    }
                    #endregion

                    #region en-US
                    sw.WriteLine("echo beging copy en-US resources dll to E10");
                    //Client端
                    if (isClient) {
                        foreach (string item in clientResDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\en-US\\" + item + "  " + txtPath.Text.Trim() + "\\DeployServer\\Shared\\Programs\\en-US";
                            sw.WriteLine(str);
                        }
                    }

                    //Server端
                    if (isServer) {
                        foreach (string item in serverResDll) {
                            string str = "copy " + dir.Parent.FullName + "\\Export\\en-US\\" + item + "  " + txtPath.Text.Trim() + "\\Server\\Application\\Programs\\en-US";
                            sw.WriteLine(str);
                        }
                    }
                    #endregion
                    */
                     
                    sw.WriteLine("echo buid end");
                    sw.WriteLine("pause");
                }

                Process proc = new Process();
                proc.StartInfo.FileName = dir.Parent.FullName + "\\AutoBuild.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
            } catch { }
        }

        #endregion

        #region 自定义方法
        public void WriteRecentInfos(string message, string itemName)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("recent.xml");

                XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/" + itemName, xml);
                if (parent == null)
                    return;

                XmlNodeList list = parent.ChildNodes;
                List<XmlNode> nodes = XmlHelper.XmlNodeListToList(list);
                if (nodes == null)
                    return;
                XmlNode node = nodes.FirstOrDefault(c => c.InnerText == message);
                if (node != null)
                    return;

                XmlNode newNode = xml.CreateNode("element", "Item", "");
                newNode.InnerText = message;
                (newNode as XmlElement).SetAttribute("time", DateTime.Now.ToString());
                parent.AppendChild(newNode);
                xml.Save("recent.xml");

                ReadRecentInfos(itemName);
            }
            catch
            { }
        }

        public void ReadRecentInfos(string itemName)
        {
            try
            {
                XmlDocument xml = XmlHelper.GetXmlDocument("recent.xml",true);

                if (itemName == "E10Items")
                    CustomerSource.Clear();
                else if (itemName == "OOQLItems")
                    OOQLCustomerSource.Clear();
                else if (itemName == "CMItems")
                    CMCustomerSource.Clear();
                else if (itemName == "E10SrcItems")
                    E10SrcCustomerSource.Clear();

                XmlNode node = XmlHelper.GetNodeByPath(@"DMS/" + itemName, xml);
                if (node == null)
                    return;
                List<XmlNode> list = XmlHelper.XmlNodeListToList(node.ChildNodes);
                var tmp = list.OrderBy(c => Convert.ToDateTime(c.Attributes["time"].Value.ToString())).ToList();

                foreach (XmlNode item in tmp)
                {
                    if (itemName == "E10Items")
                        CustomerSource.Add(item.InnerText);
                    else if (itemName == "OOQLItems")
                        OOQLCustomerSource.Add(item.InnerText);
                    else if (itemName == "CMItems")
                        CMCustomerSource.Add(item.InnerText);
                    else if (itemName == "E10SrcItems")
                        E10SrcCustomerSource.Add(item.InnerText);
                }

                if (itemName == "E10Items") {
                    this.txtPath.AutoCompleteCustomSource.Clear();
                    this.txtPath.AutoCompleteCustomSource.AddRange(CustomerSource.ToArray());
                } else if (itemName == "OOQLItems") {
                    this.txtOOQL.AutoCompleteCustomSource.Clear();
                    this.txtOOQL.AutoCompleteCustomSource.AddRange(OOQLCustomerSource.ToArray());
                } else if (itemName == "CMItems") {
                    this.txtCM.AutoCompleteCustomSource.Clear();
                    this.txtCM.AutoCompleteCustomSource.AddRange(CMCustomerSource.ToArray());
                } else if (itemName == "E10SrcItems") {
                    this.txtSrcPath.AutoCompleteCustomSource.Clear();
                    this.txtSrcPath.AutoCompleteCustomSource.AddRange(E10SrcCustomerSource.ToArray());
                }
            }
            catch
            { }
        }

        public void ClearRecentInfos(string itemName) {
            try {
                XmlDocument xml = new XmlDocument();
                xml.Load("recent.xml");

                XmlNode parent = XmlHelper.GetNodeByPath(@"DMS/" + itemName, xml);
                if (parent == null)
                    return;

                parent.RemoveAll();
                xml.Save("recent.xml");
            } catch { }
        }

        #endregion
    }
}
