namespace ProjectTaskManagementSystem.UserSpace.PasswordHashing.Interfaces;

public interface IPasswordHasher
{
    public string Hash(string password);
}
