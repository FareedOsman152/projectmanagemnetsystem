using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.Repository;
using ProjectTaskManagementSystem.UserSpace.UserFactory;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;
using ProjectTaskManagementSystem.Files;
using ProjectTaskManagementSystem.UserSpace.Service;
using ProjectTaskManagementSystem.UserSpace;
using ProjectTaskManagementSystem.Files.ObjectsConverter;

namespace ProjectTaskManagementSystem;

class Program
{    
    static void Main(string[]args)
    {
        // not used dreictly 
        var folderPath = @"D:\projects\Csharp\ProjectTaskManagementSystem\Data";
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

    }
}
