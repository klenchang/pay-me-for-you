using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PayMeForYou.Utility
{
    public static class XmlUtility
    {
        public static string SerializeXmlDocToXmlString(XmlDocument xmldoc, Encoding encodingType)
        {
            var xmlString = "";
            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms))
            {
                xmldoc.Save(sw);
                xmlString = encodingType.GetString(ms.ToArray());
            }
            return xmlString;
        }
        public static XmlDocument ConvertDictToXmlDoc(Dictionary<string, string> dicObject, string rootName)
        {
            var doc = new XmlDocument();
            var root = doc.CreateElement(rootName);
            foreach (var kv in dicObject)
            {
                var ele = doc.CreateElement(kv.Key);
                ele.InnerText = kv.Value;
                root.AppendChild(ele);
            }
            doc.AppendChild(root);
            return doc;
        }
        public static T Deserialize<T>(string xmlString)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xmlString));
        }
    }
}
