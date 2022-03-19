using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YY.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DMS
{
    internal class SQLHelper
    {
        public SQLHelper()
        {
        }
        protected virtual string ConnectionString()
        {
            return "";
        }

        protected virtual string ConnectionString(string user,string server,string db,string psd)
        {
            return "Server= " + server + ";Network Library=DBMSSOCN;Database=" + db + ";uid=" + user + ";pwd=" + psd + ";";
        }

        public YY.Data.Sql.SqlDatabase SqlDatabase
        {
            get
            {
                YY.Data.Sql.SqlDatabase db = null;
                string connectionString = this.ConnectionString();
                if (!string.IsNullOrEmpty(connectionString))
                {
                    db = new YY.Data.Sql.SqlDatabase(connectionString);
                }
                return db;
            }
        }
        public DataSet ExecuteDataSet(string sqlCommand, string tableName)
        {
            DataSet outDataSet = new DataSet();
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.LoadDataSet(dbCommand, outDataSet, tableName);
                }
                catch
                { }

            }
            return outDataSet;
        }
        public DataSet ExecuteDataSet(string sqlCommand)
        {
            DataSet DataDataSet = new DataSet();
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);
                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                    DataDataSet = db.ExecuteDataSet(dbCommand);
                }
                catch
                {

                }

            }
            return DataDataSet;
        }
        public DataSet ExecuteDataSet(string sqlCommand, string[] tableNames)
        {
            DataSet tmpDataSet = new DataSet();

            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    db.LoadDataSet(dbCommand, tmpDataSet, tableNames);
                }
                catch
                {

                }
            }
            return tmpDataSet;
        }
        public DataSet ExecuteDataSet(string[] sqlCommands, string[] tableNames)
        {
            string sqlCommand = string.Empty;
            DataSet tmpDataSet = new DataSet();
            if (sqlCommands.Length > 0)
            {
                foreach (string str in sqlCommands)
                {
                    sqlCommand = str + ";" + sqlCommand;
                }
                if (string.Empty != sqlCommand)
                {
                    try
                    {
                        string connectionString = this.ConnectionString();
                        YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                        db.LoadDataSet(dbCommand, tmpDataSet, tableNames);
                    }
                    catch
                    {

                    }
                }
            }
            return tmpDataSet;
        }
        public DataSet ExecuteTranDataSet(string[] sqlCommands)
        {
            string sqlCommand = string.Empty;
            DataSet tmpds = new DataSet();
            string connectionString = this.ConnectionString();
            YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    //foreach (string sqlCommand in sqlCommands)
                    //{
                    //    if (string.Empty != sqlCommand)
                    //    {
                    //        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    //     DataSet singelds = db.ExecuteDataSet(dbCommand, transaction);
                    //     if (singelds!=null&&singelds.Tables.Count > 0)
                    //     {
                    //         foreach (DataTable table in singelds.Tables)
                    //         {
                    //             tmpds.Tables.Add(table.Copy());
                    //         }
                    //     }

                    //    }
                    //}
                    for (int i = 0; i < sqlCommands.Length; i++)
                    {
                        if (string.Empty == sqlCommand)
                            sqlCommand = sqlCommands[i];
                        else

                            sqlCommand = sqlCommand + ";" + sqlCommands[i];
                    }

                    if (string.Empty != sqlCommand)
                    {
                        DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                        tmpds = db.ExecuteDataSet(dbCommand, transaction);

                    }
                    transaction.Commit();

                }
                catch
                {
                    // Rollback transaction 
                    transaction.Rollback();
                }
                connection.Close();
            }
            return tmpds;
        }
        public bool ExecuteNonQuery(string sqlCommand)
        {
            bool result = false;
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    int count = db.ExecuteNonQuery(dbCommand);
                    if (count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public bool ExecuteNonQuery(string sqlCommand, string server, string uid, string pwd)
        {
            bool result = false;
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string tmpstring = "Database=DBMMS;Server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";";

                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(tmpstring);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    int count = db.ExecuteNonQuery(dbCommand);
                    if (count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public bool OpenServerTest(string server,string dbName,string uid, string pwd)
        {
            bool result = false;
            string tmpstring = "Database="+dbName+";Server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";";

            SqlConnection myCn = new SqlConnection(tmpstring);

            try
            {
                myCn.Open();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                myCn.Close();
            }
            return result;
        }
        public DataSet ExecuteDataSet(string sqlCommand, string server, string dbName, string uid, string pwd)
        {
            DataSet DataDataSet = new DataSet();
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string tmpstring = "Database=" + dbName + ";Server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";";

                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(tmpstring);
                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    DataDataSet = db.ExecuteDataSet(dbCommand);
                }
                catch
                {

                }

            }
            return DataDataSet;
        }
        public bool ExecuteNonQuery(string sqlCommand, string server, string dbName, string uid, string pwd)
        {
            bool result = false;
            if (string.Empty != sqlCommand)
            {
                try
                {
                    string tmpstring = "Database=" + dbName + ";Server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";";

                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(tmpstring);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                    int count = db.ExecuteNonQuery(dbCommand);
                    if (count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public bool ExecuteTranQuery(string[] sqlCommands)
        {
            bool result = false;
            string connectionString = this.ConnectionString();
            YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (string sqlCommand in sqlCommands)
                    {

                        if (!string.IsNullOrEmpty(sqlCommand))
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);

                            db.ExecuteNonQuery(dbCommand, transaction);
                        }

                    }

                    transaction.Commit();

                    result = true;
                }
                catch
                {
                    // Rollback transaction 
                    transaction.Rollback();
                    result = false;
                }
                connection.Close();
            }
            return result;
        }
        public bool ExecuteTranQuery(DbCommand[] dbCommands)
        {
            bool result = false;
            string connectionString = this.ConnectionString();
            YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (DbCommand dbCommand in dbCommands)
                    {

                        db.ExecuteNonQuery(dbCommand, transaction);

                    }

                    transaction.Commit();

                    result = true;
                }
                catch
                {
                    // Rollback transaction 
                    transaction.Rollback();
                    result = false;
                }
                connection.Close();
            }
            return result;
        }
        public IDataReader ExecuteReader(string sqlCommand)
        {

            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);
                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                    IDataReader ExecuteReaders = db.ExecuteReader(dbCommand);

                    dbCommand.Dispose();
                    return ExecuteReaders;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public object ExecuteScalar(string sqlCommand)
        {

            if (string.Empty != sqlCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                    DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                    return db.ExecuteScalar(dbCommand);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public object ExecuteScalar(DbCommand dbCommand)
        {

            if (null != dbCommand)
            {
                try
                {
                    string connectionString = this.ConnectionString();
                    YY.Data.Sql.SqlDatabase db = new YY.Data.Sql.SqlDatabase(connectionString);

                    return db.ExecuteScalar(dbCommand);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public DataColumn AddColumn(string DataType, string sColumnName, string sCaption)
        {
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType(DataType);
            column.ColumnName = sColumnName;
            column.AutoIncrement = false;
            column.Caption = sCaption;
            column.ReadOnly = false;
            column.Unique = false;
            return column;
        }
        private SqlTran tran;
        public  SqlTran Tran
        {
            get
            {
                if (tran == null)
                {
                    string connectionString = this.ConnectionString();
                    tran = new SqlTran(connectionString);
                }
                return tran;
            }
        }
        internal class SqlTran
        {
            private  DbConnection connection;
            private  DbTransaction transaction;
            private  YY.Data.Sql.SqlDatabase db;
            private static bool result=true;
            public SqlTran(string connectionString)
            {
                db = new YY.Data.Sql.SqlDatabase(connectionString);
                connection = db.CreateConnection();
            }
            public void Begin()
            {
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            public int ExecuteNonQuery(string sqlCommand)
            {
                if (string.Empty != sqlCommand)
                {
                    try
                    {
                        if (result)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                            return db.ExecuteNonQuery(dbCommand, transaction);
                        }
                    }
                    catch
                    {
                        result = false;
                    }
                }
                return 0;
            }
            public object ExecuteScalar(string sqlCommand)
            {
                if (string.Empty != sqlCommand)
                {
                    try
                    {
                        if (result)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                            return db.ExecuteScalar(dbCommand, transaction);
                        }
                    }
                    catch
                    {
                        result = false;
                    }
                }
                return null;
            }
            public DataSet ExecuteDataSet(string sqlCommand)
            {
                DataSet DataDataSet = new DataSet();
                if (string.Empty != sqlCommand)
                {
                    try
                    {
                        if (result)
                        {
                            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                            DataDataSet = db.ExecuteDataSet(dbCommand, transaction);
                        }
                    }
                    catch
                    {
                        result = false;
                    }
                }
                return DataDataSet;
            }
            public bool Result
            {
                get { return result; }
            }
            public void End()
            {
                if (result)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
        }
    }
    
}
