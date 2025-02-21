namespace ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

internal interface IUserValidator
{
    public bool ValidateUsername(string? username);
    public bool ValidatePassword(string? password);
}


