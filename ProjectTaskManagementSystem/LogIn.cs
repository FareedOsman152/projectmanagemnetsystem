using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.UserSpace.Service;


namespace ProjectTaskManagementSystem;

internal class Login
{
    private readonly IUserService _userService;
    public Login(IUserService userService)
    {
        _userService = userService;
    }
    /// <summary>
    /// login with username and password
    /// </summary>
    /// <returns>
    /// 
    /// </returns>
    public User LoginAction()
    {
        while (true)
        {
            Console.WriteLine("Enter your username: ");
            string? username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string? password = Console.ReadLine();

            bool isValidInfo = _userService.isValideUserInfo(username!, password!);

            if (!isValidInfo)
            {
                Console.WriteLine("Invalid username or password\ntry again");
                continue;
            }

            var user = _userService.FindUser(username!);

            if (user is null)
            {
                Console.WriteLine("User not found\ntry again");
                continue;
            }
            Console.WriteLine($"\nWelcome :) { user.UserName}");
            return user;
        }
        
    }
}
