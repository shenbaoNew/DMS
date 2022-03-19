using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DMS {
    class PubHttp {
        private static string[] DEFAULT_HEADER = { "User-Agent", "Accept", "Cache-Control", "Postman-Token", "Host", "Accept-Encoding", "Content-Length"
                , "Connection", "remoteip" , "host", "content-length","user-agent","accept-encoding" };

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="headers">头部参数</param>
        /// <param name="body">body参数</param>
        /// <returns></returns>
        public static string HttpPost(string url, Dictionary<string, string> headers, string body) {
            if (url.Contains("https://")) {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            }
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            string contentType = "application/json;charset=utf-8";
            foreach (var item in headers) {
                if (PubHttp.DEFAULT_HEADER.Contains(item.Key) || item.Key.StartsWith("x-")) {
                    continue;
                }
                if (item.Key.ToLower() == "content-type") {
                    contentType = item.Value;
                } else {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
            request.ContentType = contentType;
            using (Stream output = request.GetRequestStream()) {
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                output.Write(bytes, 0, bytes.Length);
            }

            using (WebResponse response = request.GetResponse()) {
                if (response == null) {
                    new Exception("Response is null");
                }

                //不能有这个header(accept-encoding)，这个是压缩的，
                Stream input = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(input)) {
                    string returnValue = reader.ReadToEnd();
                    return returnValue;
                }
            }
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public static void HttpDownload(string url, string fileName, string path) {
            string tempFile = Path.Combine(path, fileName);
            if (System.IO.File.Exists(tempFile)) {
                System.IO.File.Delete(tempFile);    //存在则删除
            }
            FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            //Stream stream = new FileStream(tempFile, FileMode.Create);
            byte[] bArr = new byte[4096];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0) {
                //stream.Write(bArr, 0, size);
                fs.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            //stream.Close();
            fs.Close();
            responseStream.Close();
        }
    }
}
