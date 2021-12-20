using SevenZip;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DMS.DataClass.Pub {
    class CommonHelper {
        public static string GenCrossKey(string originalKey) {
            string cl = originalKey;
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++) {
                pwd = pwd + s[i].ToString("X2", CultureInfo.CurrentCulture);
            }
            return pwd;
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="fileName">目标文件名称</param>
        /// <param name="desPath">解压路径</param>
        public static void UnZip(string fileName, string desPath, EventHandler<EventArgs> finishedEvent) {
            SevenZipExtractor se = new SevenZipExtractor(fileName);
            if (finishedEvent != null) {
                se.ExtractionFinished += finishedEvent;
            }
            se.BeginExtractArchive(desPath);
        }

        /// <summary>
        /// 复制子目录
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void CopyDirectory(string sourcePath, string targetPath) {
            DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
            DirectoryInfo targetDir = new DirectoryInfo(targetPath);
            if (!targetDir.Exists) {
                targetDir.Create();
            }
            FileInfo[] files = sourceDir.GetFiles();
            foreach (FileInfo file in files) {
                file.CopyTo(Path.Combine(targetDir.FullName, file.Name), true); //复制目录中所有文件
            }
            DirectoryInfo[] dirs = sourceDir.GetDirectories();
            foreach (DirectoryInfo dir in dirs) {
                string destinationDir = Path.Combine(targetDir.FullName, dir.Name);
                CopyDirectory(dir.FullName, destinationDir); //复制子目录
            }
        }

        public static void CopyFile(string sourceFile, string targetDir) {
            DirectoryInfo destDirectory = new DirectoryInfo(targetDir);
            string fileName = Path.GetFileName(sourceFile);
            if (!File.Exists(sourceFile)) {
                return;
            }

            if (!destDirectory.Exists) {
                destDirectory.Create();
            }

            File.Copy(sourceFile, destDirectory.FullName + @"\" + fileName, true);
        }

        public static List<string> ReadFileContent(string path) {
            List<string> fileContent = new List<string>();
            using (StreamReader sr = File.OpenText(path)) {
                string data = string.Empty;
                while ((data = sr.ReadLine()) != null) {
                    fileContent.Add(data);
                }
            }
            return fileContent;
        }

        public static string ReadFile(string path) {
            string content = string.Empty;
            using (StreamReader sr = File.OpenText(path)) {
                content = sr.ReadToEnd();
            }
            return content;
        }
    }
}
