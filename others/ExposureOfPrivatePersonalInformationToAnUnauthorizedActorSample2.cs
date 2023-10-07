using System;

public class UserProfile
{
    private string username;
    private string password;

    public UserProfile(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public void DisplayUserProfile()
    {
        Console.WriteLine("Username: " + username);
        Console.WriteLine("Password: " + password);
    }
}

public class UnauthorizedAccess
{
    public static void Main(string[] args)
    {
        // Simulating a scenario where a user's profile is accessed without proper authorization.
        string unauthorizedUsername = "hacker";
        string unauthorizedPassword = "password123";

        // Assume userProfile is an instance of the UserProfile class, holding private user information.
        UserProfile userProfile = new UserProfile("legitimateUser", "securePassword");

        // Unauthorized actor accesses and displays the user's profile.
        if (unauthorizedUsername.Equals(userProfile.Username, StringComparison.OrdinalIgnoreCase) && unauthorizedPassword.Equals(userProfile.Password))
        {
            userProfile.DisplayUserProfile(); // Vulnerability: Unauthorized access to sensitive information
        }
        else
        {
            Console.WriteLine("Unauthorized access: Invalid credentials.");
        }
    }
}
