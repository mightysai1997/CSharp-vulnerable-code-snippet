using System;

class Program
{
    static void Main()
    {
        // Sample input data
        string username = "john_doe";
        string email = "john.doe@example.com";

        // Call the CreateUser function with two parameters
        CreateUser(username, email);

        // Rest of your code...
    }

    // Define the CreateUser function with two parameters
    static void CreateUser(string username, string email)
    {
        // Your logic for creating a user goes here
        Console.WriteLine($"Creating user with username: {username} and email: {email}");
        
        // For example, you can make an API call or perform database operations here
    }
}
