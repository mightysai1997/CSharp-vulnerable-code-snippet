using System;
using System.Collections.Generic;

public class UserData
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    // Other sensitive personal information fields...
}

public class InsecureDatabase
{
    // Simulating an insecure storage mechanism for user data
    private static List<UserData> userDataStorage = new List<UserData>();

    public static void SaveUserData(UserData user)
    {
        // Insecurely storing user data without encryption or proper security measures
        userDataStorage.Add(user);
    }

    public static List<UserData> GetAllUserData()
    {
        // In a secure system, this method should have proper access controls.
        // This is a simulated insecure scenario for educational purposes only.
        return userDataStorage;
    }
}

public class Program
{
    public static void Main()
    {
        // Simulating a scenario where an unauthorized actor retrieves all user data
        List<UserData> allUsersData = InsecureDatabase.GetAllUserData();

        // Displaying all user data (for educational purposes only)
        Console.WriteLine("Unauthorized Access: All User Data");
        foreach (var user in allUsersData)
        {
            Console.WriteLine($"Username - {user.Username}, Email - {user.Email}");
            // Displaying other sensitive personal information...
        }
    }
}
