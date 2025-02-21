using System.Runtime.CompilerServices;
namespace ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;

internal interface IConvertor <T> where T : class
{
    public T ToObj(string line);
    public T[] ToObjs(string[] line);
    public string ToString(T obj);
    public string[] ToStrings(T[] obj);
}
