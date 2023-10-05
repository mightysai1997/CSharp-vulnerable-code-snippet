using System;
using System.Web.Security;

public class UserRegistration
{
    public static void Main(string[] args)
    {
        string username = "exampleUser"; // Replace with the desired username
        string password = "examplePassword"; // Replace with the desired password

        try
        {
            // Attempt to create the user using Membership.CreateUser method
            MembershipUser newUser = CreateUser(username, password);

            if (newUser != null)
            {
                Console.WriteLine("User registration successful!");
            }
            else
            {
                Console.WriteLine("User registration failed.");
            }
        }
        catch (MembershipCreateUserException ex)
        {
            // Handle specific exceptions if needed
            Console.WriteLine("User registration failed. Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., database connection issues, etc.)
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static MembershipUser CreateUser(string username, string password)
    {
        try
        {
            // Attempt to create the user using Membership.CreateUser method
            return Membership.CreateUser(username, password);
        }
        catch (MembershipCreateUserException)
        {
            // Handle specific exceptions if needed
            throw;
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., database connection issues, etc.)
            throw;
        }
    }
}
