using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.UserSpace.UserValidations.UserName
{
    internal class UserNameLengthRule : IUserDataValidation
    {
        public bool IsValid(string input) => input.Length > 5;
    }
    internal class UserNameDigitRule : IUserDataValidation
    {
        public bool IsValid(string input) => input.Any(char.IsDigit);
    }
    internal class UserNamePunctuationRule : IUserDataValidation
    {
        public bool IsValid(string input) => !input.Any(char.IsPunctuation);
    }
    internal class UserNameBlockSlash : IUserDataValidation
    {
        public bool IsValid(string input) => !input.Any(c => c=='/'|| c== '\\');
    }

}
