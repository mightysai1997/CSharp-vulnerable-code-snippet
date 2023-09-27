using System;

namespace UserAuthentication
{
    public class UserController
    {
        public string CreateUser(string username, string password)
        {
            // Simulated user creation logic
            if (username == "admin" && password == "admin123")
            {
                return "User created successfully!";
            }
            else
            {
                return "User creation failed";
            }
        }
    }

    public class MainApp
    {
        public static void Main(string[] args)
        {
            UserController userController = new UserController();
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string creationResult = userController.CreateUser(username, password);
            Console.WriteLine(creationResult);
        }
    }
}
