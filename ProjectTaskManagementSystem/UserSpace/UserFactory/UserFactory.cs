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
    private void CheckIsValidUser(string userName, string password)
    {
        if (!_userValidator.ValidateUsername(userName))
        {
            throw new ArgumentException("Invalid User Name");
        }

        if (!_userValidator.ValidatePassword(password))
        {
            throw new ArgumentException("Invalid Password");
        }
    }
    /// <summary>
    /// User Name Rules : more than 5 char && has digit && has punctuation && not contain '/'
    /// Password Rules : more than 7 char && has number && has ponctuation && has upper case && has lower case
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public User CreateNewUser(string userName, string password)
    {
        CheckIsValidUser(userName, password);
        string id = (_lastID.LastUniqueID() + 1).ToString();
        return new User(id, userName, _passwordHasher.Hash(password));
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
        return new User(id, userName, _passwordHasher.Hash(password));
    }
}
