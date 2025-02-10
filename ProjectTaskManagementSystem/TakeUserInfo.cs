using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;

internal class TakeUserInfo
{
    private readonly IPasswordHasher _iPasswordHasher;
    private readonly IUserValidator _userValidator;

    public TakeUserInfo(IPasswordHasher iPasswordHasher, IUserValidator userValidator)
    {
        _iPasswordHasher = iPasswordHasher;
        _userValidator = userValidator;
    }

    public bool GetUserInfo(out string? username , out string? password)
    {
        username = "unvalid";
        password = "unvalid";

        Console.WriteLine("Enter your username: ");
        username = Console.ReadLine();

        if (!_userValidator.ValidateUsername(username))
        {
            Console.WriteLine("user name must be > 5 " +
                "&& must contain at least one digit and punctuation" +
                "&& must not contain any punctuation ");
            return false;
        }

        Console.WriteLine("Enter your password: ");
        password = Console.ReadLine();

        if (!_userValidator.ValidatePassword(password))
        {
            Console.WriteLine("Password must be > 7 " +
                "&& must contain at least one digit , punctuation , one upper case and one lower case");
            return false;
        }

        return true;

    }
}
