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

        var userConverter = new UserConvertor(null!);
        var getLastIDFromFile = new GetLastIDFromFile(folderPath, fileName, fileReader, userConverter);
        var userFactory = new UserFactory(hasher, userValidator, getLastIDFromFile);
        userConverter.setUserFactory(userFactory);

        UserRepositoryFile repo = new UserRepositoryFile(folderPath,fileName, userConverter,
            fileReader,fileWriter,hasher);
        repo.AddNewUser(userFactory.CreateNewUser("testUserToDeleted12", "testUserToDeleted12$%"));

        var user = new User();
        if (repo.GetUser("testUserToDeleted12", "testUserToDeleted12$%", out user))
        {
            repo.DeleteUser(user);
            Console.WriteLine("user deleted");
        }

        else Console.WriteLine("user not found");


    }
}
