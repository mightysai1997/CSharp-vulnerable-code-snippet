using System;
using System.Configuration;
using System.Web.Security;

public class UserRegistration
{
    public bool RegisterUser()
    {
        try
        {
            // Retrieve credentials from configuration file
            string username = ConfigurationManager.AppSettings["MembershipUsername"];
            string password = ConfigurationManager.AppSettings["MembershipPassword"];

            // Validate input username and password (ensure they are not null or empty)
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }

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
