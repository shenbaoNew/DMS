using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMS.DataClass.Digiwin
{
    class DigiwinHelper
    {
        //E10当前路径
        private string _locationPath = "";
        public string LocationPath 
        {
            get { return _locationPath; }
            set { _locationPath = value; }
        }

        private License _currentLicense;
        public License CurrentLicense
        {
            get { return _currentLicense; }
        }

        public DigiwinHelper(string path)
        {
            this.LocationPath = path;

            LoadCurrentLicense();
        }
        /// <summary>
        /// 得到当前E10的授权中心
        /// </summary>
        /// <returns></returns>
        public void LoadCurrentLicense()
        {
            License currentLicense = null;
            XmlDocument xml = XmlHelper.GetXmlDocument(LocationPath + "\\Server\\Control\\AccountSetsConfiguration.xml", true);
            if (xml != null)
            {
                currentLicense = new License();
                XmlNode subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/BindToIP");
                if (subNode != null)
                    currentLicense.BindToIP = subNode.InnerText;
                subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/BindToPort");
                if (subNode != null)
                    currentLicense.BindToPort = subNode.InnerText;
                subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/ControlCenterPort");
                if (subNode != null)
                    currentLicense.ControlCenterPort = subNode.InnerText;
            }

            _currentLicense = currentLicense;
        }

        public void ResetAccountSetsConfiguration(License license)
        {
            XmlDocument xml = XmlHelper.GetXmlDocument(LocationPath + "\\Server\\Control\\AccountSetsConfiguration.xml", true);

            if (xml != null)
            {
                XmlNode subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/BindToIP");
                if (subNode != null)
                    subNode.InnerText = license.BindToIP;
                subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/BindToPort");
                if (subNode != null)
                    subNode.InnerText = license.BindToPort;
                subNode = xml.SelectSingleNode(@"AccountSetsConfiguration/LicenseCenter/LicenseCenter/ControlCenterPort");
                if (subNode != null)
                    subNode.InnerText = license.ControlCenterPort;

                xml.Save(LocationPath + "\\Server\\Control\\AccountSetsConfiguration.xml");
                _currentLicense = license;
            }
        }

        public override string ToString()
        {
            if (_currentLicense == null)
                return string.Empty;

            return "BindToIP：" + _currentLicense.BindToIP + "   " + "BindToPort：" + _currentLicense.BindToPort + "   " + "ControlCenterPort：" + _currentLicense.ControlCenterPort;
        }
    }
}
