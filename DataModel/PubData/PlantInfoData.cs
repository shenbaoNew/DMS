using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace DMS
{
    class PlantInfoData:LocalDataBase
    {
        private RemoteDataBase remoteDB;

        public PlantInfoData()
        {
            remoteDB = new RemoteDataBase();
        }

        public DataSet GetPlantInfos()
        {
            string sql = "SELECT RTRIM(REPLACE(SAPCode,char(13)+char(10),'')) AS Code,CompanyName "
                    +" FROM DBIMS.DBO.Base_Parameter_Companys"
                    +" WHERE SAPCode IS NOT NULL AND RTRIM(REPLACE(SAPCode,char(13)+char(10),'')) in("
                    +" '9000','8050','7020','8770','9010','8500','7070','8450','8650','8760',"
                    +" '8710','8210','8240','8960','8260','8380','8390','7100','8480','8340',"
                    +" '8980','7080','8190','8540','8320','8990','8780','8510','8650','8280',"
                    +" '8140','7450')";
            remoteDB.ChangeConnectionString(SecurityEnum.IMS, "yrimsadmin", "10.128.0.99", "DBIMS", "JOW[F~SVj^lA4=jzo");

            return remoteDB.ExecuteDataSet(sql);
        }

        public DataTable GetPlantInfoStatic(string[] attrs, string innerName,string xmlName, string path)
        {
            XmlNodeList nodes = XmlHelper.GetNodesByPath(xmlName, path, true);
            DataTable dt = XmlHelper.GetDataTableFromXml(attrs, innerName, xmlName, path);

            DataRow dr = null;
            dr = ChangeDataRow(dt, "中南所有工厂", nodes);
            if(dr!=null)
                dr["code"] = string.Join(",", XmlHelper.GetNodeListByAttr(nodes, "code", "Z").ToArray());
            dr = ChangeDataRow(dt, "东北所有工厂", nodes);
            if (dr != null)
                dr["code"] = string.Join(",", XmlHelper.GetNodeListByAttr(nodes, "code", "D").ToArray());
            dr = ChangeDataRow(dt, "西南所有工厂", nodes);
            if (dr != null)
                dr["code"] = string.Join(",", XmlHelper.GetNodeListByAttr(nodes, "code", "X").ToArray());

            return dt;
        }

        public DataRow ChangeDataRow(DataTable dt, string name, XmlNodeList list)
        {
            if (dt == null)
                return null;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["CompanyName"].ToString() == name)
                    return dr;
            }

            return null;    
        }
    }
}
