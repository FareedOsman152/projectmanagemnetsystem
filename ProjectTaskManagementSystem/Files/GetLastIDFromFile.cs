using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.Files.ObjectsConverter;
using ProjectTaskManagementSystem.UserSpace;

namespace ProjectTaskManagementSystem.Files;

internal class GetLastIDFromFile : IGetLastID
{
    private readonly string _path;
    private readonly string _fileName;
    private readonly IFileReadre _fileReader;
    private readonly IConvertor<User> _userConvertor;

    public GetLastIDFromFile(string path, string fileName, 
        IFileReadre fileReader ,IConvertor<User> userConverter)
    {
        _path = path;
        _fileName = fileName;
        _fileReader = fileReader;
        _userConvertor = userConverter;
    }

    public int LastUniqueID()
    {
        if (!File.Exists(Path.Combine(_path, _fileName)))
        {
            return -1;
        }

        var line = _fileReader.getLastLine(_path, _fileName);
        if (string.IsNullOrEmpty(line)) return -1;

        var ID = _userConvertor.ToObj(line).ID;
        return int.Parse(ID);
    }
}
