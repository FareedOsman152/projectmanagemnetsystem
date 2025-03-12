using ProjectTaskManagementSystem.UserSpace.UserFactory;
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

namespace ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;

class UserConvertorJson: IConvertor <User>
{
    public User ToObj(string json)
    {
        return JsonSerializer.Deserialize<User>(json);
    }

    public IEnumerable<User> ToObjs(IEnumerable<string> Jsons)
    {
        var users = new List<User>();
        foreach (var Json in Jsons)
        {
            users.Add(ToObj(Json));
        }
        return users;
    }

    public string ToString(User obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public IEnumerable<string> ToStrings(IEnumerable<User> objs)
    {
        var Jsons = new List<string>();
        foreach (var obj in objs)
        {
            Jsons.Add(ToString(obj));
        }
        return Jsons;
    }
}
