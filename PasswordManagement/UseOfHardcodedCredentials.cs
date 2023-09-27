using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    // Add other user properties as needed
}

public class UserManager
{
    private List<User> users = new List<User>();

    public User CreateUser(string username)
    {
        // Check if the username already exists
        if (UserExists(username))
        {
            throw new InvalidOperationException("Username already exists.");
        }

        // Hardcoded password for the user
        string hardcodedPassword = "password123";

        // Create a new user and add it to the list
        var newUser = new User
        {
            Username = username,
            Password = hardcodedPassword,
            // Initialize other user properties here
        };

        users.Add(newUser);

        return newUser;
    }

    public bool UserExists(string username)
    {
        // Check if a user with the given username already exists
        return users.Any(u => u.Username == username);
    }

    // Add other methods for managing users, such as GetUserById, UpdateUser, DeleteUser, etc.
}

class Program
{
    static void Main()
    {
        var userManager = new UserManager();

        try
        {
            // Attempt to create a new user
            var newUser = userManager.CreateUser("john_doe");

            // Check if the user was created successfully
            if (newUser != null)
            {
                Console.WriteLine("User created successfully.");
                Console.WriteLine($"Username: {newUser.Username}");
                Console.WriteLine($"Password: {newUser.Password}");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
