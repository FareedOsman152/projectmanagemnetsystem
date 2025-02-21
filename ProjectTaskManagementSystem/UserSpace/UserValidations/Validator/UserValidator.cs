using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;
using ProjectTaskManagementSystem.UserSpace.UserValidations.Password;
using ProjectTaskManagementSystem.UserSpace.UserValidations.UserName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;
/// <summary>
/// User Validator
/// Create Two IEnumerable containing all the rules for username and password validation
/// </summary>
internal class UserValidator : IUserValidator
{
    private readonly ValidationMenager _usernameValidator = new ValidationMenager(new IUserDataValidation[]
    {
        new UserNameLengthRule(),
        new UserNameDigitRule(),
        new UserNamePunctuationRule(),
        new UserNameBlockSlash()
    });

    private readonly ValidationMenager _passwordValidator = new ValidationMenager(new IUserDataValidation[]
    {
        new PasswordLengthRule(),
        new PasswordDigitRule(),
        new PasswordPunctuationRule(),
        new PasswordUpperCaseRule(),
        new PasswordLowerCaseRule()
    });

    public bool ValidateUsername(string? username) =>
        !string.IsNullOrEmpty(username) && _usernameValidator.Validate(username);

    public bool ValidatePassword(string? password) =>
        !string.IsNullOrEmpty(password) && _passwordValidator.Validate(password);

}

