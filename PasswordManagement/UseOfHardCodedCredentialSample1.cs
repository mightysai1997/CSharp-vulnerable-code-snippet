using System;

namespace UserAuthentication
{
    public class UserController
    {
        // Simulated database to store user data
        private static readonly Dictionary<string, string> userDatabase = new Dictionary<string, string>
        {
            { "admin", "admin123" },
            { "user1", "password1" },
            { "user2", "password2" },
        };

        public string CreateUser(string username, string password)
        {
            // Check if the username already exists
            if (userDatabase.ContainsKey(username))
            {
                return "Username already exists. User creation failed.";
            }

            // Hardcoded user creation (insecure for demonstration purposes)
            userDatabase[username] = password;
            
            return "User created successfully.";
        }

        public string AuthenticateUser(string username, string password)
        {
            // Simplified authentication logic
            if (userDatabase.ContainsKey(username) && userDatabase[username] == password)
            {
                return $"Welcome, {username}!";
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

            // Create a user with hardcoded credentials
            string createUsername = "newuser";
            string createPassword = "newpassword";
            string createUserResult = userController.CreateUser(createUsername, createPassword);
            Console.WriteLine(createUserResult);

            // Authenticate a user with hardcoded credentials
            string authUsername = "admin";
            string authPassword = "admin123";
            string authResult = userController.AuthenticateUser(authUsername, authPassword);
            Console.WriteLine(authResult);
        }
    }
}
