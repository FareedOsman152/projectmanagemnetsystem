using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interface;

namespace ProjectTaskManagementSystem.UserSpace;



internal class UsersMenager
{
    private readonly IPasswordHasher _iPasswordHasher;
    private readonly IUserValidator _userValidator;
    private readonly string _path;
    private readonly string _fileName;

    public UsersMenager(IPasswordHasher iPasswordHasher, IUserValidator userValidator, string path, string fileName)
    {
        _iPasswordHasher = iPasswordHasher;
        _userValidator = userValidator;
        _path = path;
        _fileName = fileName;
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

internal interface UserAction
{
    public bool action(User user, IPasswordHasher iPasswordHasher, IUserValidator userValidator,
                        string path, string fileName);
}

internal class AddUserAction : UserAction
{
    public bool action(User user, IPasswordHasher iPasswordHasher, IUserValidator userValidator,
                        string path, string fileName)
    {

    }
}

internal class DeleteUserAction : UserAction
{
    public bool action(User user, IPasswordHasher iPasswordHasher, IUserValidator userValidator,
                        string path, string fileName)
    {

    }
}

internal class UpdateUserAction : UserAction
{
    public bool action(User user, IPasswordHasher iPasswordHasher, IUserValidator userValidator,
                        string path, string fileName)
    {
    }
}

internal class FindUserAction : UserAction
{
    public bool action(User user, IPasswordHasher iPasswordHasher, IUserValidator userValidator,
                        string path, string fileName)
    {
    }
}

