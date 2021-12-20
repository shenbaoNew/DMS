using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace DMS
{
    class XmlHelper
    {
        public static XmlDocument GetXmlDocument(string path, bool ignoreComments)
        {
            XmlDocument xml = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = ignoreComments;
            string strPath = path;

            try
            {
                XmlReader reader = XmlReader.Create(strPath, settings);

                xml.Load(reader);

                return xml;
            }
            catch { }

            return null;
        }

        public static XmlNode GetNodeByPath(string path, XmlDocument xml)
        {
            XmlNode node = null;
            try
            {
                node = xml.SelectSingleNode(path);
            }
            catch 
            { 
                return null; 
            }
            
            return node;
        }

        public static XmlNodeList GetNodesByPath(string path, XmlDocument xml)
        {
            XmlNodeList nodes = null;
            try
            {
                nodes = xml.SelectNodes(path);
            }
            catch
            {
                return null;
            }

            return nodes;
        }

        public static XmlNode GetNodeByPath(string xmlName,string path, bool ignoreComments)
        {
            XmlDocument xml = GetXmlDocument(xmlName, ignoreComments);
            XmlNode node = null;
            try
            {
                node = xml.SelectSingleNode(path);
            }
            catch
            {
                return null;
            }

            return node;
        }

        public static XmlNodeList GetNodesByPath(string xmlName, string path, bool ignoreComments)
        {
            XmlDocument xml = GetXmlDocument(xmlName, ignoreComments);
            XmlNodeList nodes = null;
            try
            {
                nodes = xml.SelectNodes(path);
            }
            catch
            {
                return null;
            }

            return nodes;
        }

        public static List<XmlNode> XmlNodeListToList(XmlNodeList list)
        {
            if (list == null)
                return null;
            List<XmlNode> result=new List<XmlNode>();

            foreach (XmlNode node in list)
                result.Add(node);

            return result;
        }

        /// <summary>
        /// 根据XML元素属性attrs来创建DataTable
        /// </summary>
        /// <param name="attrs">XML属性名称</param>
        /// <param name="inner"></param>
        /// <returns></returns>
        public static DataTable XmlNodesToDataTable(string[] attrs,XmlNodeList list,string innerName)
        {
            if (attrs == null || attrs.Length <= 0)
                return null;
            List<XmlNode> myList = XmlNodeListToList(list);

            DataColumn[] dcs = new DataColumn[attrs.Length + 1];
            for (int i = 0; i < attrs.Length; i++)
                dcs[i] = new DataColumn(attrs[i], typeof(string));
            dcs[attrs.Length] = new DataColumn(innerName);

            DataTable dt = PubHelper.CreateTable("Plant", dcs);
            foreach (XmlNode node in list)
            {
                DataRow dr = dt.NewRow();
                int i = 0;
                for (; i < attrs.Length; i++)
                    dr[attrs[i]] = node.Attributes[i].Value;
                dr[innerName] = node.InnerText;

                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 根据传入的xml节点路径来创建DataTable对象
        /// 要求path节点的子节点的子节点的节点（为具体的列）顺序要一致
        /// </summary>
        /// <param name="subNodeNames">创建的列名称集合</param>
        /// <param name="xml">xml文档</param>
        /// <param name="path">节点路径</param>
        /// <returns></returns>
        public static DataTable XmlNodesToDataTable(string[] subNodeNames, XmlDocument xml,string path)
        {
            XmlNode parentNode = GetNodeByPath(path, xml);
            if (parentNode == null)
                return null;

            DataTable dt = new DataTable();
            for (int i = 0; i < subNodeNames.Length; i++)
            {
                dt.Columns.Add(new DataColumn(subNodeNames[i], typeof(string)));
            }

            foreach (XmlNode item in parentNode.ChildNodes)
            {
                DataRow dr = dt.NewRow();
                for(int i=0;i<item.ChildNodes.Count;i++)
                {
                    dr[subNodeNames[i]] = item.ChildNodes[i].InnerText;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static DataTable GetDataTableFromXml(string[] attrs, string innerName, string xmlName, string path)
        {
            DataTable dt = null;
            try
            {
                XmlNodeList nodes = GetNodesByPath(xmlName, path, true);
                return XmlNodesToDataTable(attrs, nodes, innerName);
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetNodeListByAttr(XmlNodeList list,string attrA, string attrB)
        {
            if (list == null)
                return null;

            List<string> result = new List<string>();
            foreach (XmlNode node in list)
            {
                if (node.Attributes["flag"] != null &&
                    node.Attributes["flag"].Value.ToString() == attrB &&
                    node.Attributes[attrA].Value != null &&
                    !result.Contains(node.Attributes[attrA].Value.ToString()))
                    result.Add(node.Attributes[attrA].Value.ToString());
            }

            return result;
        }
    }
}
