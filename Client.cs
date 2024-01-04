using System;
using System.Collections.Generic;

class Program
{
    // Vulnerable code: Storing and retrieving personal information without proper access controls
    static Dictionary<string, string> personalInformation = new Dictionary<string, string>();

    static void Main()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your sensitive information:");
        string sensitiveInfo = Console.ReadLine();

        SavePersonalInformation(name, sensitiveInfo);

        // Simulate an unauthorized actor attempting to access personal information
        UnauthorizedAccessAttempt();
    }

    static void SavePersonalInformation(string name, string sensitiveInfo)
    {
        // Vulnerable code: Storing personal information without proper access controls
        personalInformation[name] = sensitiveInfo;
        Console.WriteLine("Personal information saved successfully.");
    }

    static void UnauthorizedAccessAttempt()
    {
        Console.WriteLine("Unauthorized actor attempting to access personal information:");

        // Simulating an unauthorized actor attempting to access personal information
        foreach (var entry in personalInformation)
        {
            Console.WriteLine($"Name: {entry.Key}, Sensitive Information: {entry.Value}");
        }
    }
}
