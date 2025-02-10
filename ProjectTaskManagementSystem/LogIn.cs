using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;

internal class LogIn
{
    private readonly IPasswordHasher _iPasswordHasher;
    private readonly IUserValidator _userValidator;

    public LogIn(IPasswordHasher iPasswordHasher, IUserValidator userValidator)
    {
        _iPasswordHasher = iPasswordHasher;
        _userValidator = userValidator;
    }    
    public User GetValidUser()
    {
        TakeUserInfo takeUserInfo = new TakeUserInfo(_iPasswordHasher, _userValidator);
        while (true)
        {
            bool validInfo = takeUserInfo.GetUserInfo(out string? username, out string? password);
            if (validInfo) return new User(username!, password!, _iPasswordHasher, _userValidator);
        }
    }


}
