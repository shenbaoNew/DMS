using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;

namespace DMS.DataClass.DataBase.Sap
{
    public class SapRfcBase
    {
        private IDestinationConfiguration m_ID;

        public SapRfcBase()
        {
            m_ID = new SAPDestinationConfig();
        }

        protected RfcDestination RegisterDestination()
        {
            RfcDestinationManager.RegisterDestinationConfiguration(m_ID);
            RfcDestination rd = RfcDestinationManager.GetDestination("MyToolsConn");

            return rd;
        }

        protected void UnRegisterDestination()
        {
            RfcDestinationManager.UnregisterDestinationConfiguration(m_ID);
        }

        public RfcRepository GetRepository()
        {
            RfcDestination rd = RegisterDestination();
            if (rd != null)
                return rd.Repository;
            else
                return null;
        }
    }

    class SAPDestinationConfig : IDestinationConfiguration
    {
        private static string SysFlag = "ECQ";

        private string serverHost = "";
        private string sysNumber = "";
        private string user = "";
        private string psd = "";
        private string client = "";
        private string language = "";
        private string poolSize = "";
        private string timeOut = "";

        public SAPDestinationConfig()
        {
            if (SysFlag == "ECQ")
            {
                this.serverHost = "10.128.0.211";
                this.client = "390";
                this.user = "20003061";                              
                this.psd = "shenbao";
            }
            else if (SysFlag == "ECD")
            {
                this.serverHost = "10.128.0.201";
                this.client = "220";
                this.user = "chenb";
                this.psd = "shenbao";
            }
            this.sysNumber = "00";
            this.language = "ZH";
            this.poolSize = "5";
            this.timeOut = "60";
        }

        public RfcConfigParameters GetParameters(string desName)
        {
            if (desName == "MyToolsConn")
            {
                RfcConfigParameters paras = new RfcConfigParameters();
                paras[RfcConfigParameters.AppServerHost] = serverHost;
                paras[RfcConfigParameters.SystemNumber] = sysNumber;
                paras[RfcConfigParameters.User] = user;
                paras[RfcConfigParameters.Password] = psd;
                paras[RfcConfigParameters.Client] = client;
                paras[RfcConfigParameters.Language] = language;
                paras[RfcConfigParameters.PoolSize] = poolSize;
                paras[RfcConfigParameters.IdleTimeout] = timeOut;

                return paras;
            }

            return null;
        }

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
    }
}
