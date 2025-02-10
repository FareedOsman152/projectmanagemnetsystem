using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;

internal interface IUserValidator
{
    public bool ValidateUsername(string? username);
    public bool ValidatePassword(string? password);
}

internal class UserValidator : IUserValidator
{
    private readonly ValidationMenager _usernameValidator = new ValidationMenager(new IUserDateValidation[]
    {
        new UserNameLengthRule(),
        new UserNameDigitRule(),
        new UserNamePunctuationRule()
    });

    private readonly ValidationMenager _passwordValidator = new ValidationMenager(new IUserDateValidation[]
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

internal class ValidationMenager
{
    private readonly List<IUserDateValidation> _rules = new List<IUserDateValidation>();

    public ValidationMenager(IEnumerable<IUserDateValidation> rules)
    {
        _rules = rules.ToList();
    }

    public void AddRule(IUserDateValidation rule) => _rules.Add(rule);
    public bool Validate(string? input) => _rules.All(rule => rule.IsValid(input));
}


internal interface IUserDateValidation
{
    public bool IsValid(string? input);
}

internal class UserNameLengthRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Length > 5;
}

internal class UserNameDigitRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Any(char.IsDigit);
}

internal class UserNamePunctuationRule : IUserDateValidation
{
    public bool IsValid(string input) => !input.Any(char.IsPunctuation);
}

internal class PasswordLengthRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Length > 7;
}

internal class PasswordDigitRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Any(char.IsDigit);
}

internal class PasswordPunctuationRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Any(char.IsPunctuation);
}

internal class PasswordUpperCaseRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Any(char.IsUpper);
}

internal class PasswordLowerCaseRule : IUserDateValidation
{
    public bool IsValid(string input) => input.Any(char.IsLower);
}


