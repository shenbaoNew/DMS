using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DMS.DataModel.Pub {
    public class LogHelper {
        public static readonly string DEFAULT_LOG_PATH = "";
        static LogHelper() {
            DEFAULT_LOG_PATH = Path.Combine(Environment.CurrentDirectory, "DMS.log");
        }

        public static void WriteLog(string message) {
            WriteLog(DEFAULT_LOG_PATH, message, true, true);
        }

        public static void WriteLog(string logFullName, string message) {
            WriteLog(logFullName, message, true, true);
        }
        public static void WriteLog(string logFullName, string tip, Exception ex) {
            WriteLog(logFullName, tip + "===>" + ex.Message + Environment.NewLine + ex.StackTrace, true, true);
        }
        public static void WriteLog(string logFullName, string message, bool append, bool withTime) {
            try {
                if (withTime) {
                    message = string.Format("{0}[{1}]    {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), Thread.CurrentThread.ManagedThreadId.ToString(), message);
                }
                if (File.Exists(logFullName)) {
                    using (StreamWriter sw = new StreamWriter(logFullName, append)) {
                        sw.WriteLine(message);
                    }
                } else {
                    string path = logFullName.Substring(0, logFullName.LastIndexOf('\\'));
                    DirectoryInfo info = new DirectoryInfo(path);
                    if (!info.Exists)
                        info = Directory.CreateDirectory(path);
                    using (StreamWriter sw = File.CreateText(logFullName)) {
                        sw.WriteLine(message);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
