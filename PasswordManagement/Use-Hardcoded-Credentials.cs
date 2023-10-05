using System;
using System.Web.Security;

public class UserRegistration
{
    public bool RegisterUser(string username, string password)
    {
        try
        {
            // Check if the username already exists
            if (Membership.GetUser(username) != null)
            {
                // User already exists
                return false;
            }

            // Attempt to create the user using Membership.CreateUser method
            MembershipCreateStatus status;
            MembershipUser newUser = Membership.CreateUser(username, password, null, null, null, true, out status);

            if (status == MembershipCreateStatus.Success && newUser != null)
            {
                // User registration successful
                return true;
            }
            else
            {
                // User registration failed, handle the specific status if needed
                Console.WriteLine("Registration failed: " + status.ToString());
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
