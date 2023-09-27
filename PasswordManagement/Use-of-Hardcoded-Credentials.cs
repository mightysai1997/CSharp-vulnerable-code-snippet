using System;

class User
{
    public string Username { get; set; }
    public string Email { get; set; }
}

class UserService
{
    // Hypothetical CreateUser method that requires two input parameters
    public User CreateUser(string username, string email)
    {
        // Create a new User object with the provided parameters
        User newUser = new User
        {
            Username = username,
            Email = email
        };

        // Perform any additional logic or operations here (e.g., database insertion)

        // Return the created user
        return newUser;
    }
}

class Program
{
    static void Main()
    {
        // Sample input data
        string username = "john_doe";
        string email = "john.doe@example.com";

        // Create an instance of the UserService
        UserService userService = new UserService();

        // Call the CreateUser method with two parameters
        User createdUser = userService.CreateUser(username, email);

        // Print the created user's information
        Console.WriteLine($"Created User: Username = {createdUser.Username}, Email = {createdUser.Email}");
    }
}
