using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace;
internal class User
{
    private string _id;
    private string _userName;
    private string _hashPassword;
    public string ID => _id;
    public string UserName => _userName;
    public string HashPassword => _hashPassword;
    public User() { }
    
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
        _id = id;
        _userName = userName;
        _hashPassword = hashPassword;
    }

}