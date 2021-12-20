using DMS.Forms.DAP.InitIDE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DMS.DataClass.Pub {
    class FtpHelper {
        public static List<string> GetFileListFromFTP(string ftpPath) {
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
    }
}
