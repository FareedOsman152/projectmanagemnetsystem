using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace;
internal class User
{
    public string ID { get; private set; }
    public string UserName { get; private set; }
    public string HashPassword { get; private set; }

    /// <summary>
    /// Constructor to Create a User 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="passwordHasher"></param>
    /// <param name="userValidator"></param>
    /// <exception cref="ArgumentException"></exception>
    public User(string id, string userName, string hashPassword)
    {
        ID = id;
        UserName = userName;
        HashPassword = hashPassword;
    }

    public User()
    {
            
    }
}