using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem;

internal class OpenningScreen
{
    private userChoice getUserChoice()
    {
        while (true)
        {
            Console.WriteLine("1-Login\n2-Sign Up");

            bool validInput = int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 2;

            if (validInput) return (userChoice)choice;
        }
    }
    enum userChoice
    {
        Login =1,
        SignUp = 2
    }

    public OpenningScreen()
    {
        userChoice currentUserChoice = getUserChoice();
        switch (currentUserChoice)
        {
            case userChoice.Login:
                
                LogIn logIn = new LogIn(new PasswordHasher(),new UserValidator());
                //logIn.LogInUser();
                break;
            case userChoice.SignUp:
                break;
            default:
                break;
        }
    }
}
