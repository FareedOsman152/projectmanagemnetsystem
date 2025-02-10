namespace ProjectTaskManagementSystem;

internal class Program
{
    string _path = "F:\\programs\\projects\\C_sharp\\ProjectTaskManagementSystem";
    string _fileName = "users.txt";
    static void Main(string[] args)
    {
        Console.WriteLine("kk");
        new UsersMenager(new PasswordHasher(), new UserValidator()).AddUser(new User("Mohammed12", "ooppRRtt12@$", new PasswordHasher(), new UserValidator()));
    }
   
}
