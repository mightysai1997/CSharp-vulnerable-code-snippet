using System;

class UserData
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    // Other sensitive personal information fields...
}

class Program
{
    static void Main()
    {
        // Simulating a scenario where user data is accessed without proper authorization
        string unauthorizedUsername = "attacker";

        // Fetching user data without proper authorization
        UserData unauthorizedUserData = GetUserInformation(unauthorizedUsername);

        // Displaying unauthorized user data (for educational purposes only)
        Console.WriteLine($"Unauthorized Access: Username - {unauthorizedUserData.Username}, Email - {unauthorizedUserData.Email}");
    }

    static UserData GetUserInformation(string username)
    {
        // In a secure system, proper authentication and authorization checks should be performed here.
        // This is a simplified example for educational purposes only.

        // Simulating fetching user data from a database based on the provided username
        UserData user = new UserData
        {
            Username = "legitimateUser",
            Password = "securePassword123",
            Email = "user@example.com"
            // Other sensitive personal information...
        };

        return user;
    }
}
