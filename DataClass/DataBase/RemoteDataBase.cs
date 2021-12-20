using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class RemoteDataBase:SQLHelper
    {
        protected override string ConnectionString()
        {
            return PubContext.RemoteDBConnection;
        }

        public void ChangeConnectionString(SecurityEnum flag,string user = "", string server = "",
            string db = "", string psd = "")
        {
            if (!string.IsNullOrEmpty(user))
                PubContext.RemoteDBLoginUser = user;
            if (!string.IsNullOrEmpty(server))
                PubContext.RemoteDBServer = server;
            if (!string.IsNullOrEmpty(db))
                PubContext.RemoteDBDataBase = db;
            if (!string.IsNullOrEmpty(psd))
                PubContext.RemoteDBPsd = Security.Decrypt(psd, flag);

            PubContext.RemoteDBConnection = ConnectionString(PubContext.RemoteDBLoginUser, PubContext.RemoteDBServer, PubContext.RemoteDBDataBase, PubContext.RemoteDBPsd);
        }
    }
}
