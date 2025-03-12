using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.UserSpace.UserFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;

class UserConvertorXml : IConvertor<User>
{
    public User ToObj(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(User));
        using (TextReader stringReader = new StringReader(xml))
        {
            return (User)xmlSerializer.Deserialize(stringReader);
        }

    }

    public IEnumerable<User> ToObjs(IEnumerable<string> xmls)
    {
        var users = new List<User>();
        foreach (var xml in xmls)
        {
            users.Add(ToObj(xml));
        }
        return users;
    }

    public string ToString(User obj)
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

    public IEnumerable<string> ToStrings(IEnumerable<User> objs)
    {
        var xmls = new List<string>();
        foreach (var obj in objs)
        {
            xmls.Add(ToString(obj));
        }
        return xmls;
    }
}
