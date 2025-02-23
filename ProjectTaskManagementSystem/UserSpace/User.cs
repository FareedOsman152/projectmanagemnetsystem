using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace;


internal class User
{
    private string _id;
    private string _userName;
    private string _hashPassword;
    //private readonly IPasswordHasher _passwordHasher;
    //private readonly IUserValidator _userValidator;
    public string ID => _id;
    public string UserName => _userName;
    public string HashPassword => _hashPassword;
    //private void CheckIsValidUser(string userName, string password)
    //{
    //    if (!_userValidator.ValidateUsername(userName))
    //    {
    //        throw new ArgumentException("Invalid User Name");
    //    }

    //    if (!_userValidator.ValidatePassword(password))
    //    {
    //        throw new ArgumentException("Invalid Password");
    //    }
    //}
    public User()
    {

    }
    /// <summary>
    /// Constructor to Create a User 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="passwordHasher"></param>
    /// <param name="userValidator"></param>
    /// <exception cref="ArgumentException"></exception>
    public User(string id, string userName, string hashPassword)
    {
        //_userValidator = userValidator;

        //CheckIsValidUser(userName, password);

        _id = id;
        _userName = userName;
        _hashPassword = hashPassword;
        //_hashPassword = _passwordHasher.Hash(password);
    }

    //override public string ToString()
    //{
    //    return $"{_id}//{_userName}//{_hashPassword}";
    //}
    //public override bool Equals(object? obj)
    //{
    //    if (obj == null || obj is not User)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        User user = obj as User;
    //        return user.ID == _id;
    //    }
    //}


}