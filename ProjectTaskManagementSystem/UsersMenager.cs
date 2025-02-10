using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;

internal class UsersMenager
{
    private readonly IPasswordHasher _iPasswordHasher;
    private readonly IUserValidator _userValidator;
    private readonly List<User> _users = new List<User>();
    private readonly string _path = "F:\\programs\\projects\\C_sharp\\ProjectTaskManagementSystem";
    private readonly string _fileName = "users.txt";
    public UsersMenager(IPasswordHasher iPasswordHasher, IUserValidator userValidator)
    {
        _iPasswordHasher = iPasswordHasher;
        _userValidator = userValidator;
    }

    private string _convertUserToString(User user)
    {
        return $"{user.ID}//{user.UserName}//{user.HashPassword}";
    }

    public void AddUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        string userString = _convertUserToString(user);
        File.AppendAllText(Path.Combine(_path, _fileName), userString);
        //var file = new FileStream(Path.Combine(_path, _fileName), FileMode.Append);
        //try
        //{
        //    file.Position = file.Length;
        //    file.Write(Encoding.UTF8.GetBytes(userString));
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Faild");
        //}
    }

}
