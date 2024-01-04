using System;
using System.Collections.Generic;

public class UserInfo
{
    public string Name { get; set; }
    public string SensitiveInfo { get; set; }
}

public class UserRepository
{
    // Vulnerable code: Storing user information without proper access controls
    private static List<UserInfo> userDatabase = new List<UserInfo>();

    public static void SaveUserInformation(string name, string sensitiveInfo)
    {
        UserInfo user = new UserInfo { Name = name, SensitiveInfo = sensitiveInfo };
        userDatabase.Add(user);
        Console.WriteLine("User information saved successfully.");
    }

    public static void DisplayAllUsers()
    {
        Console.WriteLine("Displaying all users (Simulating unauthorized access):");

        // Simulating an unauthorized actor attempting to access personal information
        foreach (var user in userDatabase)
        {
            Console.WriteLine($"Name: {user.Name}, Sensitive Information: {user.SensitiveInfo}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your sensitive information:");
        string sensitiveInfo = Console.ReadLine();

        // Simulate saving user information
        UserRepository.SaveUserInformation(name, sensitiveInfo);

        // Simulate an unauthorized actor attempting to access personal information
        UserRepository.DisplayAllUsers();
    }
}
