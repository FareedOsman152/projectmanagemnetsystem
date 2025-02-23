using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.UserSpace.UserFactory;
namespace ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;

internal class UserConvertor : IConvertor<User>
{    
    
    private readonly UserFactory _userFactory;

    public UserConvertor( UserFactory userFactory)
    {
        _userFactory = userFactory;
    }
        
    public string ToString(User user)
    {
        return $"{user.ID}//{user.UserName}//{user.HashPassword}";
    }

    /// <summary>
    /// Convert an IEnumerable of User objects to ann IEnumerable of strings
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public IEnumerable<string> ToStrings(IEnumerable<User> users)
    {
        string[] result = new string[users.Count()];
        for (int i = 0; i < users.Count(); i++)
        {
            result[i] = ToString(users.ElementAt(i));
        }
        return result;
    }

    /// <summary>
    /// Convert a string to a User object
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public User ToObj(string line)
    {
        if(string.IsNullOrEmpty(line))
        {
            throw new ArgumentNullException(nameof(line));
        }

        string[] parts = line.Split("//");

        if(parts.Length != 3)
        {
            throw new ArgumentException("Invalid line format");
        }

        return _userFactory.CreateUserFromFile(parts[0], parts[1], parts[2]);   
    }

    /// <summary>
    /// Convert an IEnumerable of strings to an IEnumerable of User objects
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public IEnumerable<User> ToObjs(IEnumerable<string> lines )
    {
        var resultUsers = new List<User>(lines.Count());
       
        for (int i = 0; i < lines.Count(); i++)
        {
            resultUsers[i] = ToObj(lines.ElementAt(i));
        }
        return resultUsers;
    }  
   
}