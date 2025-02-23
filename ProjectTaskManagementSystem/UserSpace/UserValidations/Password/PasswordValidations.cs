using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.UserSpace.UserValidations.Password;

internal class PasswordLengthRule : IUserDataValidation
{
    public bool IsValid(string input) => input.Length > 7;
}

internal class PasswordDigitRule : IUserDataValidation
{
    public bool IsValid(string input) => input.Any(char.IsDigit);
}

internal class PasswordPunctuationRule : IUserDataValidation
{
    public bool IsValid(string input) => input.Any(char.IsPunctuation);
}

internal class PasswordUpperCaseRule : IUserDataValidation
{
    public bool IsValid(string input) => input.Any(char.IsUpper);
}

internal class PasswordLowerCaseRule : IUserDataValidation
{
    public bool IsValid(string input) => input.Any(char.IsLower);
}
