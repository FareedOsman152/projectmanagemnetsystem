//using ProjectTaskManagementSystem.Files.Interfaces;
//using ProjectTaskManagementSystem.Files.ObjectsConverter.UserConverter;
//using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
//using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

//namespace ProjectTaskManagementSystem.UserSpace.UserFactory.UserFactory;

//internal class GetLastUniqueID : IGetLastID
//{
//    private readonly IFileReadre _fileReader;
//    private readonly IFileWriter _fileWriter;
//    private readonly IPasswordHasher _passwordHasher;
//    private readonly IUserValidator _userValidator;
//    private readonly string _folderPath;
//    private readonly string _fileName;

//    public GetLastUniqueID(string folderPath, string fileName)
//    {
//        _fileReader = fileReader;
//        //_fileWriter = fileWriter;
//        //_passwordHasher = passwordHasher;
//        //_userValidator = userValidator;
//        _folderPath = folderPath;
//        _fileName = fileName;
//    }

//    public int LastUniqueID()
//    {
//        string lastUser = _fileReader.getLastLine(_folderPath, _fileName);
//        if (lastUser is null) return 100;
        
        
//        if (user is null) return 100;

//        return int.Parse(user.ID);
//    }
//}