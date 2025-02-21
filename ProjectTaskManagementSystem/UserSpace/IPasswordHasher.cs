namespace ProjectTaskManagementSystem.UserSpace;

public interface IPasswordHasher
{
    public string Hash(string password);
}
