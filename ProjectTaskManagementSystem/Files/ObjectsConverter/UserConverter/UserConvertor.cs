using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;
namespace ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;

internal class UserConvertor : IConvertor<User>
{    
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserValidator _userValidator;

    public UserConvertor(IPasswordHasher passwordHasher, IUserValidator userValidator)
    {
        _passwordHasher = passwordHasher;
        _userValidator = userValidator;
    }
        
    public string ToString(User user)
    {
        return $"{user.ID}//{user.UserName}//{user.HashPassword}";
    }

    /// <summary>
    /// Convert an Array of User objects to ann Araay of strings
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string[] ToStrings(User[] user)
    {
        string[] result = new string[user.Length];
        for (int i = 0; i < user.Length; i++)
        {
            result[i] = ToString(user[i]);
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

        return User.CreateUserFromFile(parts[0], parts[1], parts[2],_passwordHasher,_userValidator);   
    }

    /// <summary>
    /// Convert an Array of strings to an Array of User objects
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public User[] ToObjs(string[] lines )
    {
        var resultUsers = new User[lines.Length];
       
        for (int i = 0; i < lines.Length; i++)
        {
            resultUsers[i] = ToObj(lines[i]);
        }
        return resultUsers;
    }  
   
}