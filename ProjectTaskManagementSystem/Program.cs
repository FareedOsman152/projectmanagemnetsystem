namespace ProjectTaskManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        new UsersMenager(new PasswordHasher(), new UserValidator()).AddUser(new User("Mohammed12", "ooppRRtt12@$", new PasswordHasher(), new UserValidator()));
    }
   
}
