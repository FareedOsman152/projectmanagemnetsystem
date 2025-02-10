using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;


internal class User
{
    static int uniqueID = 100;
    private string _id;
    private string _userName;
    private string _hashPassword;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserValidator _userValidator;

    public string ID => _id;
    public string UserName => _userName;
    public string HashPassword => _hashPassword;
    public User( string userName, string password , IPasswordHasher passwordHasher , IUserValidator userValidator)
    {
        _userValidator = userValidator;
        if (!_userValidator.ValidateUsername(userName))
        {
            throw new ArgumentException("Invalid User Name");
        }

        if (!_userValidator.ValidatePassword(password))
        {
            throw new ArgumentException("Invalid Password");
        }

        ++uniqueID;
        this._id = uniqueID.ToString();
        this._userName = userName;
        this._passwordHasher = passwordHasher;
        this._hashPassword = _passwordHasher.Hash(password);
    }
           
}

public interface IPasswordHasher
{
    public string Hash(string password);
}

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
