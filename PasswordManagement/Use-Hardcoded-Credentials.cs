using System;
using System.Web.Security;

public class UserRegistration
{
    public bool RegisterUser(string username, string password)
    {
        try
        {
            // Attempt to create the user using Membership.CreateUser method
            MembershipUser newUser = Membership.CreateUser(username, password);

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
        catch (MembershipCreateUserException ex)
        {
            // Handle specific exceptions if needed
            Console.WriteLine("User registration failed. Error: " + ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., database connection issues, etc.)
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}
