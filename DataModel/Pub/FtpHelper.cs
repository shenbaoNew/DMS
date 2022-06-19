using DMS.Forms.DAP.InitIDE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DMS.DataClass.Pub {
    class FtpHelper {
        public static List<string> GetFileListFromFtp(string ftpPath) {
            FtpWebRequest reqFTP = null;
            FileStream outputStream = null;
            StreamReader reader = null;
            FtpWebResponse response = null;
            List<string> list = new List<string>();
            try {
                //FTP文件路径
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Credentials = new NetworkCredential(InitParameter.FTP_USER, InitParameter.FTP_PASSWORD);
                response = (FtpWebResponse)reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null) {
                    if (!line.Contains("<DIR>")) {
                        list.Add(line);
                    }
                    line = reader.ReadLine();
                }
                return list;
            }  finally {
                if (reader != null) {
                    reader.Close();
                }
                if (outputStream != null) {
                    outputStream.Close();
                }
                if (response != null) {
                    response.Close();
                }
            }
        }

        public static bool DownLoadFileFromFtp(string ftpServer, string ftpUser, string ftpPwd
            , string ftpFileName, string localFileName) {
            FtpWebRequest reqFTP = null;
            FileStream outputStream = null;
            Stream ftpStream = null;
            FtpWebResponse response = null;
            try {
                //下载到本地的文件路径
                localFileName = Path.Combine(localFileName);
                outputStream = new FileStream(localFileName, FileMode.Create);
                //FTP文件路径
                ftpFileName = "ftp://" + ftpServer + ftpFileName;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpFileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPwd);
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

        public static List<string> GetFileListFromFtp(string ftpServer, string ftpUser, string ftpPwd
            , string ftpPath,string preFix) {
            FtpWebRequest reqFTP = null;
            FileStream outputStream = null;
            StreamReader reader = null;
            FtpWebResponse response = null;
            List<string> list = new List<string>();
            try {
                //FTP文件路径
                ftpPath = "ftp://" + ftpServer + ftpPath;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath));
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPwd);
                reqFTP.UsePassive = false;
                response = (FtpWebResponse)reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null) {
                    if (!line.Contains("<DIR>")
                         && line.StartsWith(preFix)) {
                        list.Add(line);
                    }
                    line = reader.ReadLine();
                }
                return list;
            } finally {
                if (reader != null) {
                    reader.Close();
                }
                if (outputStream != null) {
                    outputStream.Close();
                }
                if (response != null) {
                    response.Close();
                }
            }
        }
    }
}
