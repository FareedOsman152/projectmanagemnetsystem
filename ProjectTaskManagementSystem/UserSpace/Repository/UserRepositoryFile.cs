namespace ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;
using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
internal class UserRepositoryFile : IUserRepository
{
    private string _Path;
    private string _fileName;
    private IConvertor<User> _userConverter;
    private IFileReadre _fileReadre;
    private IFileWriter _fileWriter;    
    private IPasswordHasher _passwordHasher;
    /// <summary>
    /// menage file repo
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="userConverter"></param>
    /// <param name="fileReadre"></param>
    /// <param name="fileWriter"></param>
    /// <param name="passwordHasher"></param>
    public UserRepositoryFile(string path, string fileName, IConvertor<User> userConverter,
        IFileReadre fileReadre, IFileWriter fileWriter, IPasswordHasher passwordHasher)
    {
        _Path = path;
        _fileName = fileName;
        _userConverter = userConverter;
        _fileReadre = fileReadre;
        _fileWriter = fileWriter;
        _passwordHasher = passwordHasher;
    }

    public void AddNewUser(User user)=>
        _fileWriter.writeOneLine(_Path, _fileName, _userConverter.ToString(user));

    public void DeleteUser(User user)
    {
        var users = GetAllUsers().ToList();

        for (int i = 0; i < users.Count; i++)
        {
            if(users[i].ID == user.ID)
            {
                users.RemoveAt(i);
                break;
            }
        }
        _fileWriter.updateFile(_Path, _fileName, _userConverter.ToStrings(users));
    }

    public IEnumerable<User> GetAllUsers()
    {
        string[] lines = _fileReadre.getAllLines(_Path, _fileName);
        return _userConverter.ToObjs(lines).ToList();
    }

    public User GetUser(string username)
    {
        var users = GetAllUsers().ToList();
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].UserName == username)
            {
                return users[i];
            }
        }        
        return null;
    }

    public void UpdateUser(User user)
    {
        var users = GetAllUsers().ToList();

        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].ID == user.ID)
            {
                users[i]= user;
                break;
            }
        }
        _fileWriter.updateFile(_Path, _fileName, _userConverter.ToStrings(users));
    }

}