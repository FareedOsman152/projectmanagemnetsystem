using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;
using ProjectTaskManagementSystem.UserSpace.UserFactory;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;
using ProjectTaskManagementSystem.Files;
using ProjectTaskManagementSystem.UserSpace.Service;
using ProjectTaskManagementSystem.UserSpace;

namespace ProjectTaskManagementSystem;

class Program
{    
    static void Main(string[]args)
    {
        // not used dreictly 
        var folderPath = "D:\\projects\\Csharp\\ProjectTaskManagementSystem";
        var fileName = "users.txt";
        var hasher = new PasswordHasher();
        var userValidator = new UserValidator();
        var fileReader = new FileReader();
        var fileWriter = new FileWriter();

        var userConverter = new ObjConvertorJson<User>();
        var getLastIDFromFile = new GetLastIDFromFile(folderPath, fileName, fileReader, userConverter); ;
        var userFactory = new UserFactory(hasher, userValidator, getLastIDFromFile);

        var repo = new UserRepositoryFile(folderPath,fileName, userConverter,
            fileReader,fileWriter,hasher);

        // used directly
        var userService = new UserService(repo, userValidator);

        var logger = new Login(userService);

        //var user = logger.LoginAction();
        //if (user is not null)
        //{
        //    Console.WriteLine("Welcome");
        //}
        //else
        //{
        //    Console.WriteLine("faild");
        //}

        string userName = "testuser2";
        string pass = "passtest2";
        User user = userFactory.CreateNewUser(userName, pass);

        repo.AddNewUser(user);

        //string newUserName = "NEWtestUserToUpdate12";
        //string newPass = "NEWtestUserToUpdate12@#$";

        //repo.UpdateUser(userFactory.CreateUpdatedUser(user, newUserName, newPass));


        var user1 = repo.GetUser("testuser1");
        if (user1 is not null)
        {
            repo.DeleteUser(user1);
            Console.WriteLine("user deleted");
        }

        else Console.WriteLine("user not found");


    }
}
