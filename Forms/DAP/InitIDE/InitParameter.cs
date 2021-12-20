using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DMS.Forms.DAP.InitIDE {
    class InitParameter {
        public const string FTP_SERVER = "172.16.101.198";
        public const string FTP_USER = "e10_sts";
        public const string FTP_PASSWORD = ">M_P0j";
        public const string DAP_PACKAGE_PRIFIX = "dwapiplatform-appbackend-dev-";
        public const string DAP_RUN_PACKAGE_NAME = "app_backend_dev";
        public const string NEXUS_IP = "https://repo.digiwincloud.com.cn/maven";
        public const string NEXUS_RUNNING_PACKAGE = "/service/rest/v1/search/assets/download?repository=releases&group=com.digiwin&name=dwapiplatform-appbackend&maven.extension=war&version=";
        public const string APP_PROPERTIES_PATH = @"running\app_backend\application\conf\application.properties";
        public const string DAP_PROPERTIES_PATH = @"running\app_backend\platform\conf\platform.properties";
        public static readonly List<string> DAP_PROPERTIES = new List<string> { "dbEnabled", "tenantEnabled", "iamUrl" };
    }
}
