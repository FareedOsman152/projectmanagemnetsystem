using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace.UserFactory;

internal class UserFactory
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserValidator _userValidator;
    private readonly IGetLastID _lastID;
    public UserFactory(IPasswordHasher passwordHasher, IUserValidator userValidator, IGetLastID lastID)
    {
        _passwordHasher = passwordHasher;
        _userValidator = userValidator;
        _lastID = lastID;
    }
    public User CreateNewUser(string userName, string password)
    {
        string id = (_lastID.LastUniqueID() + 1).ToString();
        return new User(id, userName, password, _passwordHasher, _userValidator);
    }
    /// <summary>
    /// create user with id from file
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public User CreateUserFromFile(string id, string userName, string password)
    {
        return new User(id, userName, password, _passwordHasher, _userValidator);
    }
}
