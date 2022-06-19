using DevComponents.DotNetBar.Controls;
using DMS.DataClass.Pub;
using SevenZip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace DMS.Forms.DAP.InitIDE {
    class InitTool {
        private RichTextBoxEx log;
        private string projectPath;
        private string developPath;
        private string version;
        private string patch;
        private string jdkPath;
        private bool first;

        public InitTool(RichTextBoxEx log, string projectPath, string version, string patch, string jdk, bool first) {
            this.log = log;
            this.projectPath = projectPath;
            this.developPath = projectPath + "\\develop";
            this.version = version;
            this.patch = patch;
            this.jdkPath = jdk;
            this.first = first;

            //修改临时文件夹的名称为项目文件夹名称，将来模组会用到项目名
            this.ChangeProjectFolderName();
        }

        public InitTool() {
        }

        private void ChangeProjectFolderName() {
            DirectoryInfo info = new DirectoryInfo(this.projectPath);
            InitParameter.NEW_DAP_RUN_PACKAGE_NAME = info.Name;
        }

        public void InitDapRunEnvironment() {
            this.ClearTempPath();
            bool success = this.DownloadDapRunPackageFromFTP();
            success = success && this.UnZipDapPackage(UnZipDapPackageCallBackOnInit);

            //this.InstallDWThirdPartyProject();
            //this.InstallRunningPackage();
            //this.SettingConfigs();
        }

        public void InstallDWThirdPartyProject() {
            this.AppendText("开始安装第三方Lib模组...");
            string dwThirdpartyProjectPath = Path.Combine(GetTempPath(), InitParameter.NEW_DAP_RUN_PACKAGE_NAME, "tool\\DWThirdPartyLibrary");
            string savePath = Path.Combine(this.developPath, "DWThirdPartyLibrary");
            CommonHelper.CopyDirectory(dwThirdpartyProjectPath, savePath);
            this.AppendText("安装第三方Lib模组完成!");
        }

        public void InstallRunningPackage() {
            this.AppendText(string.Format("开始下载允许包({0})...", patch));
            string url = GetNexusRunningPackage() + patch;
            string fileName = "appBackend.war";
            string savePath = GetRunningPath();
            PubHttp.HttpDownload(url, fileName, savePath);
            this.AppendText("运行包下载完成!");
            this.AppendText("运行包开始解压缩...");
            CommonHelper.UnZip(Path.Combine(savePath, fileName), savePath, null);
            File.Delete(Path.Combine(savePath, fileName));
            this.AppendText("运行包安装完成!");
        }

        public void SetJdkPath() {
            string fileName = Path.Combine(GetRunBatPath(), "run.bat");
            string content = "";
            using (StreamReader sr = new StreamReader(fileName)) {
                content = sr.ReadToEnd();
            }
            content = content.Replace(@"..\develop\jdk\java-1.8.0-openjdk-1.8.0.191-1.b12.redhat.windows.x86_64\bin\java", Path.Combine(jdkPath, "bin\\java"));
            using (StreamWriter sw = File.CreateText(fileName)) {
                sw.WriteLine(content);
            }
            this.AppendText("jdk路径设置完毕");
        }

        public void StartRunBat() {
            this.AppendText("开始初始化系统运行参数...");
            string path = GetRunBatPath();
            Process proc = new Process();
            string targetDir = string.Format(path);

            proc.StartInfo.WorkingDirectory = targetDir;
            proc.StartInfo.FileName = "run.bat";

            proc.Start();
            proc.WaitForExit();
            this.AppendText("系统参数设置完毕");
        }

        public bool StartRunBat(string projectPath) {
            string path = Path.Combine(projectPath, "tool");
            if (File.Exists(Path.Combine(path, "run.bat"))) {
                Process proc = new Process();
                string targetDir = string.Format(path);

                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "run.bat";

                proc.Start();
                proc.WaitForExit();
                return true;
            } else {
                return false;
            }
        }

        public bool DownloadDapRunPackageFromFTP() {
            this.AppendText(string.Format("开始下载dap开发包({0})...", patch));
            FtpWebRequest reqFTP = null;
            FileStream outputStream = null;
            Stream ftpStream = null;
            FtpWebResponse response = null;
            try {
                //下载到本地的文件路径
                string localFileName = GetLocalFileFullName();
                outputStream = new FileStream(localFileName, FileMode.Create);
                //FTP文件路径
                string ftpFileName = GetFtpFileFullName(this.version, this.patch);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpFileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(InitParameter.FTP_USER, InitParameter.FTP_PASSWORD);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount = 0;
                byte[] buffer = new byte[bufferSize];

                while ((readCount = ftpStream.Read(buffer, 0, bufferSize)) > 0) {
                    outputStream.Write(buffer, 0, readCount);
                }
                this.AppendText("开发包下载完毕");
                return true;
            } catch (Exception ex) {
                this.AppendText("开发包下载出错：" + ex.Message);
                return false;
            } finally {
                if (ftpStream != null) {
                    ftpStream.Close();
                }
                if (outputStream != null) {
                    outputStream.Close();
                }
                if (response != null) {
                    response.Close();
                }
            }
        }

        public bool DownLoadPatch(string version, string patch, string path) {
            FtpWebRequest reqFTP = null;
            FileStream outputStream = null;
            Stream ftpStream = null;
            FtpWebResponse response = null;
            try {
                //下载到本地的文件路径
                string localFileName = Path.Combine(path, InitParameter.DAP_PACKAGE_PRIFIX + patch + ".war"); ;
                outputStream = new FileStream(localFileName, FileMode.Create);
                //FTP文件路径
                string ftpFileName = GetFtpFileFullName(version, patch);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpFileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(InitParameter.FTP_USER, InitParameter.FTP_PASSWORD);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount = 0;
                byte[] buffer = new byte[bufferSize];

                while ((readCount = ftpStream.Read(buffer, 0, bufferSize)) > 0) {
                    outputStream.Write(buffer, 0, readCount);
                }
                return true;
            } finally {
                if (ftpStream != null) {
                    ftpStream.Close();
                }
                if (outputStream != null) {
                    outputStream.Close();
                }
                if (response != null) {
                    response.Close();
                }
            }
        }


        public string GetFtpFileFullName(string version, string patch) {
            StringBuilder fileName = new StringBuilder();
            fileName.Append("ftp://" + InitParameter.FTP_SERVER);
            fileName.Append(string.Format("/STS Release/{0}.1000 STS", version));
            if (patch.EndsWith("1000")) {
                fileName.Append("/API平台_API/");
                fileName.Append(InitParameter.DAP_PACKAGE_PRIFIX);
                fileName.Append(patch);
                fileName.Append(".war");
            } else {
                fileName.Append(" Patch");
                fileName.Append("/API平台_API/");
                fileName.Append(patch);
                fileName.Append("/");
                fileName.Append(InitParameter.DAP_PACKAGE_PRIFIX + patch);
                fileName.Append(".war");
            }
            return fileName.ToString();
        }

        private void ClearTempPath() {
            string path = Path.Combine(projectPath, "temp\\");
            if (Directory.Exists(path)) {
                Directory.Delete(path, true);
            }
        }

        public string GetLocalFileFullName() {
            string path = this.GetTempPath();
            return path + InitParameter.DAP_PACKAGE_PRIFIX + patch + ".war";
        }

        public string GetTempPath() {
            //文件下载，解压缩临时路径
            string path = Path.Combine(projectPath, "temp\\");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public string GetNexusRunningPackage() {
            return InitParameter.NEXUS_IP + InitParameter.NEXUS_RUNNING_PACKAGE;
        }

        public string GetRunningPath() {
            string path = Path.Combine(projectPath, "running");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public string GetRunBatPath() {
            string path = Path.Combine(GetTempPath(), InitParameter.NEW_DAP_RUN_PACKAGE_NAME, "tool");
            return path;
        }

        public void AppendText(string msg) {
            this.log.AppendText(msg);
            this.log.AppendText(Environment.NewLine);
        }

        public bool UnZipDapPackage(EventHandler<EventArgs> afterUnZipEvent) {
            this.AppendText("开始解压缩dap开发包...");
            try {
                string fileName = this.GetLocalFileFullName();
                string filePath = this.GetTempPath();
                CommonHelper.UnZip(fileName, filePath, afterUnZipEvent);
                return true;
            } catch (Exception ex) {
                this.AppendText("解压缩dap开发包出错：" + ex.Message);
                return false;
            }
        }

        public void UnZipDapPackageCallBackOnInit(object sender, EventArgs e) {
            string filePath = this.GetTempPath();
            this.AppendText(string.Format("开发包解压完成===>{0}", filePath));
            //修改文件夹名称
            this.ChangeFolderName(filePath);
            //设置jdk路径
            this.SetJdkPath();
            //启动run.bat
            this.StartRunBat();
            //目录复制到项目目录
            this.CopyDirectory();
            //追加appcenter相关pom配置
            this.AppendAppCenterConfig();
            //初始化完毕
            this.Finish();
        }

        private void ChangeFolderName(string filePath) {
            //重命名
            if (InitParameter.DAP_RUN_PACKAGE_NAME != InitParameter.NEW_DAP_RUN_PACKAGE_NAME) {
                Directory.Move(Path.Combine(filePath, InitParameter.DAP_RUN_PACKAGE_NAME), Path.Combine(filePath, InitParameter.NEW_DAP_RUN_PACKAGE_NAME));
            }
        }

        public void CopyDirectory() {
            string source = Path.Combine(GetTempPath(), InitParameter.NEW_DAP_RUN_PACKAGE_NAME);

            if (this.first) {
                CommonHelper.CopyDirectory(source, projectPath);
                CommonHelper.CopyFile(Path.Combine(Environment.CurrentDirectory, "Files\\.gitignore"), projectPath);
            } else {
                CommonHelper.CopyDirectory(Path.Combine(source, ".idea"), Path.Combine(projectPath, ".idea"));
                CommonHelper.CopyDirectory(Path.Combine(source, "running"), Path.Combine(projectPath, "running"));
                CommonHelper.CopyDirectory(Path.Combine(source, "tool"), Path.Combine(projectPath, "tool"));
            }
        }

        public void AppendAppCenterConfig() {
            if (this.first) {
                this.AppendText("配置修改module\\pom.xml(nexus地址配置,公共组件默认版本配置)...");
                this.AppendAppCenterNode(Path.Combine(projectPath, "develop\\module\\pom.xml"));
                this.AppendAppCenterNode(Path.Combine(projectPath, "develop\\DWThirdPartyLibrary\\pom.xml"));
            }
        }

        public void AppendAppCenterNode(string pomPath) {
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load(pomPath);
                string nsUrl = xml.FirstChild.NamespaceURI;
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xml.NameTable);
                nsMgr.AddNamespace("ns", nsUrl);
                XmlNode project = XmlHelper.GetNodeByPath(@"/ns:project", xml, nsMgr);

                //追加nexus.ip,appcenter.verion
                XmlNode properties = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties", xml, nsMgr);
                XmlNode nexusIp = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties/ns:nexus.ip", xml, nsMgr);
                if (nexusIp == null) {
                    nexusIp = xml.CreateElement("nexus.ip", nsUrl);
                    nexusIp.InnerText = "https://repo.digiwincloud.com.cn/maven";
                    properties.AppendChild(nexusIp);
                }
                XmlNode bmVersioin = xml.CreateElement("bm.version", nsUrl);
                bmVersioin.InnerText = this.version + "." + PubContext.BmVersion;
                properties.AppendChild(bmVersioin);

                //追加repository
                XmlNode repositories = XmlHelper.GetNodeByPath(@"/ns:project/ns:repositories", xml, nsMgr);
                if (repositories == null) {
                    repositories = xml.CreateElement("repositories", nsUrl);
                    project.InsertAfter(repositories, properties);
                }
                XmlNode repository = xml.CreateElement("repository", nsUrl);
                repositories.AppendChild(repository);
                //添加id，name，url
                XmlNode id = xml.CreateElement("id", nsUrl);
                id.InnerText = "appcenter";
                repository.AppendChild(id);
                XmlNode name = xml.CreateElement("name", nsUrl);
                name.InnerText = "appcenter Releases Repository";
                repository.AppendChild(name);
                XmlNode url = xml.CreateElement("url", nsUrl);
                url.InnerText = "${nexus.ip}/content/groups/appcenter/";
                repository.AppendChild(url);

                //追加dependences
                XmlNode dependencies = XmlHelper.GetNodeByPath(@"/ns:project/ns:dependencies", xml, nsMgr);
                XmlNode dependency = xml.CreateElement("dependency", nsUrl);
                dependencies.AppendChild(dependency);
                //添加groupId，artifactId，version
                //原有的appcenter配置
                //XmlNode groupId = xml.CreateElement("groupId", nsUrl);
                //groupId.InnerText = "com.digiwin.appcenter";
                //dependency.AppendChild(groupId);
                //XmlNode artifactId = xml.CreateElement("artifactId", nsUrl);
                //artifactId.InnerText = "appcenter-common";
                //dependency.AppendChild(artifactId);
                //XmlNode version = xml.CreateElement("version", nsUrl);
                //version.InnerText = "${appcenter.version}";
                //dependency.AppendChild(version);
                //现有的业务中台配置
                XmlNode groupId = xml.CreateElement("groupId", nsUrl);
                groupId.InnerText = "com.digiwin.bm";
                dependency.AppendChild(groupId);
                XmlNode artifactId = xml.CreateElement("artifactId", nsUrl);
                artifactId.InnerText = "bm-spring-boot-starter";
                dependency.AppendChild(artifactId);
                XmlNode version = xml.CreateElement("version", nsUrl);
                version.InnerText = "${bm.version}";
                dependency.AppendChild(version);

                xml.Save(pomPath);
                //XmlTextWriter xw = new XmlTextWriter(pomPath, null);
                //xw.Formatting = Formatting.Indented;
                //xw.Indentation = 4;
                //xml.Save(xw);
                //xw.Close();
            } catch {
            }
        }

        public void Finish() {
            if (Directory.Exists(Path.Combine(projectPath, "running\\app_backend\\application"))) {
                //删除临时目录
                Directory.Delete(GetTempPath(), true);
                this.AppendText("环境初始化完毕...");
            } else {
                this.AppendText("环境初始化失败...");
            }
        }

        /// <summary>
        /// 获取dap版本对应的patch列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatchList(string version) {
            string path = GetPatchPath(version);
            List<string> list = FtpHelper.GetFileListFromFtp(path);
            list.Insert(0, version + ".1000");
            return list;
        }

        public List<string> GetVersionList() {
            string path = GetVersionPath();
            List<string> list = FtpHelper.GetFileListFromFtp(path);
            List<string> result = new List<string>();
            foreach (string content in list) {
                string version = content.Substring(0, 5);
                if (!result.Contains(version)) {
                    result.Add(version);
                }
            }
            return result;
        }
        private string GetVersionPath() {
            StringBuilder fileName = new StringBuilder();
            fileName.Append("ftp://" + InitParameter.FTP_SERVER);
            fileName.Append("/STS Release/");
            return fileName.ToString();
        }

        private string GetPatchPath(string version) {
            StringBuilder fileName = new StringBuilder();
            fileName.Append("ftp://" + InitParameter.FTP_SERVER);
            fileName.Append(string.Format("/STS Release/{0}.1000 STS", version));
            fileName.Append(" Patch");
            fileName.Append("/API平台_API/");
            return fileName.ToString();
        }

        public List<DapParameter> GetDapParameters() {
            string path = Path.Combine(Environment.CurrentDirectory, "Files\\application.properties");
            List<string> content = CommonHelper.ReadFileContent(path);
            List<DapParameter> parameters = new List<DapParameter>();
            foreach (string data in content) {
                int index = data.IndexOf('=');
                if (index > 0) {
                    DapParameter dapParameter = new DapParameter { Name = data.Substring(0, index), Value = data.Substring(index + 1) };
                    dapParameter.IsPlatform = InitParameter.DAP_PROPERTIES.Contains(dapParameter.Name);
                    parameters.Add(dapParameter);
                }
            }
            return parameters;
        }

        public void SaveRunnintParameter(List<DapParameter> parameters, string projectPath, bool initRedis) {
            string appPath = Path.Combine(projectPath, InitParameter.APP_PROPERTIES_PATH);
            string dapPath = Path.Combine(projectPath, InitParameter.DAP_PROPERTIES_PATH);
            string proPath = Path.Combine(Environment.CurrentDirectory, "Files\\application.properties");
            string appContent = CommonHelper.ReadFile(appPath);
            string dapContent = CommonHelper.ReadFile(dapPath);
            string proContent = CommonHelper.ReadFile(proPath);


            //替换参数
            foreach (DapParameter parameter in parameters) {
                Regex regex = new Regex(parameter.Pattern);
                Match match = null;
                if (parameter.Name.Contains("redis") && !initRedis) {
                    continue;
                }
                if (!parameter.IsPlatform) {
                    match = regex.Match(appContent);
                    if (match != null && match.Groups.Count == 2) {
                        appContent = appContent.Replace(match.Groups[1].Value, parameter.ToString());
                    } else {
                        appContent = appContent + "\r\n" + parameter.ToString();
                    }
                } else {
                    match = regex.Match(dapContent);
                    if (match != null && match.Groups.Count == 2) {
                        dapContent = dapContent.Replace(match.Groups[1].Value, parameter.ToString());
                    }
                }
                match = regex.Match(proContent);
                if (match != null && match.Groups.Count == 2) {
                    proContent = proContent.Replace(match.Groups[1].Value, parameter.ToString());
                }
            }
            appContent += "\r\n";  //补一个空行
            File.WriteAllText(appPath, appContent);
            File.WriteAllText(dapPath, dapContent);
            File.WriteAllText(proPath, proContent);
        }

        #region 版本升级
        public void UpgradeDapRunEnvironment() {
            this.ClearTempPath();
            bool success = this.DownloadDapRunPackageFromFTP();
            success = success && this.UnZipDapPackage(UnZipDapPackageCallBackOnUpgrade);

            //this.InstallDWThirdPartyProject();
            //this.InstallRunningPackage();
            //this.SettingConfigs();
        }

        public void UnZipDapPackageCallBackOnUpgrade(object sender, EventArgs e) {
            string filePath = this.GetTempPath();
            this.AppendText(string.Format("开发包解压完成===>{0}", filePath));
            //修改文件夹名称
            this.ChangeFolderName(filePath);
            //备份配置文件
            this.BulkConfigFile();
            //设置jdk路径
            this.SetJdkPath();
            //升级新版本tool
            this.UpgradeNewTool();
            //启动run.bat
            this.RunUpgradeBat();
            //升级相关pom版本
            this.UpgradePomVersion();
            //还原配置文件内容
            ReductionConfigFile();
            //升级完毕
            this.FinishUpgrade();
        }

        private void BulkConfigFile() {
            string bulkPath = Path.Combine(projectPath, "backup");
            if (!Directory.Exists(bulkPath)) {
                Directory.CreateDirectory(bulkPath);
            }
            this.AppendText(string.Format("备份配置文件===>{0}", bulkPath));
            File.Copy(Path.Combine(projectPath, "running\\app_backend\\application\\conf\\application.properties")
                , Path.Combine(bulkPath, "application.properties"), true);
            File.Copy(Path.Combine(projectPath, "running\\app_backend\\platform\\conf\\platform.properties")
                , Path.Combine(bulkPath, "platform.properties"), true);
        }

        public void UpgradeNewTool() {
            this.AppendText(string.Format("升级新版tool..."));
            string source = Path.Combine(GetTempPath(), InitParameter.NEW_DAP_RUN_PACKAGE_NAME);
            if (Directory.Exists(Path.Combine(projectPath, "backup\\tool"))) {
                Directory.Delete(Path.Combine(projectPath, "backup\\tool"), true);
            }
            Directory.Move(Path.Combine(projectPath, "tool"), Path.Combine(projectPath, "backup\\tool"));
            CommonHelper.CopyDirectory(Path.Combine(source, "tool"), Path.Combine(projectPath, "tool"));
        }

        private void UpgradePomVersion() {
            this.AppendText(string.Format("升级模组版本..."));
            string pomPath = Path.Combine(projectPath, "develop\\module\\pom.xml");
            XmlDocument xml = new XmlDocument();
            try {
                xml.Load(pomPath);
                string nsUrl = xml.FirstChild.NamespaceURI;
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xml.NameTable);
                nsMgr.AddNamespace("ns", nsUrl);
                XmlNode project = XmlHelper.GetNodeByPath(@"/ns:project", xml, nsMgr);

                //追加nexus.ip,appcenter.verion
                XmlNode properties = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties", xml, nsMgr);
                XmlNode apiVersion = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties/ns:api.version", xml, nsMgr);
                if (apiVersion != null) {
                    apiVersion.InnerText = this.patch;
                }

                xml.Save(pomPath);
                //XmlTextWriter xw = new XmlTextWriter(pomPath, null);
                //xw.Formatting = Formatting.Indented;
                //xw.Indentation = 4;
                //xml.Save(xw);
                //xw.Close();
            } catch {
            }
        }

        public void RunUpgradeBat() {
            this.AppendText("开始执行环境升级...");
            string path = Path.Combine(projectPath, "tool");
            Process proc = new Process();
            string targetDir = string.Format(path);

            proc.StartInfo.WorkingDirectory = targetDir;
            proc.StartInfo.FileName = "run.bat";

            proc.Start();
            proc.WaitForExit();
        }

        public void ReductionConfigFile() {
            this.AppendText(string.Format("还原配置文件..."));
            string bulkPath = Path.Combine(projectPath, "backup");
            File.Copy(Path.Combine(bulkPath, "application.properties")
                , Path.Combine(projectPath, "running\\app_backend\\application\\conf\\application.properties")
              , true);
            File.Copy(Path.Combine(bulkPath, "platform.properties")
                , Path.Combine(projectPath, "running\\app_backend\\platform\\conf\\platform.properties")
                , true);
        }

        public void FinishUpgrade() {
            //删除临时目录
            Directory.Delete(GetTempPath(), true);
            this.AppendText("环境升级完毕...");
        }
        #endregion

        #region 读取项目版本
        public static string ReadProjectVersion(string projectPath, string originVersion) {
            XmlDocument xml = new XmlDocument();
            try {
                string pomPath = Path.Combine(projectPath, "develop\\module\\pom.xml");
                xml.Load(pomPath);
                string nsUrl = xml.FirstChild.NamespaceURI;
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(xml.NameTable);
                nsMgr.AddNamespace("ns", nsUrl);
                XmlNode project = XmlHelper.GetNodeByPath(@"/ns:project", xml, nsMgr);

                //追加nexus.ip,appcenter.verion
                XmlNode properties = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties", xml, nsMgr);
                XmlNode apiVersion = XmlHelper.GetNodeByPath(@"/ns:project/ns:properties/ns:api.version", xml, nsMgr);
                if (apiVersion != null) {
                    return apiVersion.InnerText;
                }
            } catch (Exception ex) {
                throw ex;
            }
            return originVersion;
        }
        #endregion
    }
}
