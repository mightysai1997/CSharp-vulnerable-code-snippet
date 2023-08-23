using System;

namespace UserAuthentication
{
    public class UserController
    {
        public string AuthenticateUser(string username, string password)
        {
            // Simplified authentication logic
            if (username == "admin" && password == "admin123")
            {
                return "Welcome, admin!";
            }
            else
            {
                return "Login failed";
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

            string authenticationResult = userController.AuthenticateUser(username, password);
            Console.WriteLine(authenticationResult);
        }
    }
}
