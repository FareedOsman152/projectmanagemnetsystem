using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
using ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;
using ProjectTaskManagementSystem.UserSpace.UserFactory;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;
using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.Files;

namespace ProjectTaskManagementSystem;

class Program
{    
    static void Main(string[]args)
    {
        var folderPath = "D:\\projects\\Csharp\\ProjectTaskManagementSystem";
        var fileName = "users.txt";
        var hasher = new PasswordHasher();
        var userValidator = new UserValidator();
        var fileReader = new FileReader();
        var fileWriter = new FileWriter();

        var getLastIDFromFile = new GetLastIDFromFile(folderPath, fileName, fileReader);
        var userFactory = new UserFactory(hasher, userValidator, getLastIDFromFile);
        var userConverter = new UserConvertor(userFactory);

        UserRepositoryFile repo = new UserRepositoryFile(folderPath,fileName, userConverter,
            fileReader,fileWriter,hasher);
        string userName = "testUserToUpdate12";
        string pass = "testUserToUpdate12@$%";
        User user = userFactory.CreateNewUser(userName, pass);

        repo.AddNewUser(user);

        string newUserName = "NEWtestUserToUpdate12";
        string newPass = "NEWtestUserToUpdate12@#$";

        repo.UpdateUser(userFactory.CreateUpdatedUser(user, newUserName, newPass));


        var user1 = repo.GetUser("testUserToDeleted12", "testUserToDeleted12$%");
        if (user1 is not null)
        {
            repo.DeleteUser(user1);
            Console.WriteLine("user deleted");
        }

        else Console.WriteLine("user not found");


    }
}
