using ProjectTaskManagementSystem.UserSpace;
using System.Runtime.CompilerServices;
namespace ProjectTaskManagementSystem.Files.ObjectsConverter;

internal interface IConvertor <T> where T : class
{
    public T ToObj(string line);
    public IEnumerable<T> ToObjs(IEnumerable<string> lines);
    public string ToString(T obj);
    public IEnumerable<string> ToStrings(IEnumerable<T> objs);
}
