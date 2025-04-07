using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using ProjectTaskManagementSystem.UserSpace;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectTaskManagementSystem.Files.ObjectsConverter;

class ObjConvertorJson <T>: IConvertor <T> where T : class
{
    public T ToObj(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }

    public IEnumerable<T> ToObjs(IEnumerable<string> Jsons)
    {
        var objs = new List<T>();
        foreach (var Json in Jsons)
        {
            objs.Add(ToObj(Json));
        }
        return objs;
    }

    public string ToString(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public IEnumerable<string> ToStrings(IEnumerable<T> objs)
    {
        var Jsons = new List<string>();
        foreach (var obj in objs)
        {
            Jsons.Add(ToString(obj));
        }
        return Jsons;
    }
}
