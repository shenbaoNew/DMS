using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class LocalDataBase:SQLHelper
    {
        protected override string ConnectionString()
        {
            return PubContext.DBConnection;
        }
    }
}
