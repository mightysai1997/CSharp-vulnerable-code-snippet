using System;
using System.Web.Security;

public class UserRegistration
{
    public bool RegisterUser(string username, string password)
    {
        try
        {
            // Check if the username already exists
            if (!Membership.GetUser(username) == null)
            {
                // User already exists
                return false;
            }

            // Generate a unique user ID (optional, based on your requirements)
            Guid userId = Guid.NewGuid();

            // Create a MembershipUser instance with the provided username and user ID
            MembershipUser newUser = Membership.CreateUser(username, password, null);

            if (newUser != null)
            {
                // User registration successful
                return true;
            }
            else
            {
                // User registration failed
                return false;
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., database connection issues, etc.)
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}
