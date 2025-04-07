using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectTaskManagementSystem.Files.ObjectsConverter;

class ObjConvertorXml <T> : IConvertor<T> where T : class
{
    public T ToObj(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using (TextReader stringReader = new StringReader(xml))
        {
            return (T)xmlSerializer.Deserialize(stringReader);
        }

    }

    public IEnumerable<T> ToObjs(IEnumerable<string> xmls)
    {
        var objs = new List<T>();
        foreach (var xml in xmls)
        {
            objs.Add(ToObj(xml));
        }
        return objs;
    }

    public string ToString(T obj)
    {
        string result;
        var xmlSerlaizer = new XmlSerializer(obj.GetType());
        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true}))
            {
                xmlSerlaizer.Serialize(xmlWriter, obj);
                result = stringWriter.ToString();
            }
        }
        return result;
    }

    public IEnumerable<string> ToStrings(IEnumerable<T> objs)
    {
        var xmls = new List<string>();
        foreach (var obj in objs)
        {
            xmls.Add(ToString(obj));
        }
        return xmls;
    }
}
