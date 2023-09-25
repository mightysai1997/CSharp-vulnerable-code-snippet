using System;

public class User
{
    public string UserName { get; set; }
    public int UserId { get; set; }

    public User(string userName, int userId)
    {
        UserName = userName;
        UserId = userId;
    }
}

public class UserManager
{
    public User CreateUser(string userName, int userId)
    {
        // You can add your logic here to create a user with the provided parameters
        User newUser = new User(userName, userId);

        // Example: You can save the user to a database or perform other operations

        return newUser;
    }
}

public class Program
{
    public static void Main()
    {
        UserManager userManager = new UserManager();
        
        string userName = "JohnDoe";
        int userId = 12345;
        
        User newUser = userManager.CreateUser(userName, userId);
        
        Console.WriteLine($"User Created: UserName - {newUser.UserName}, UserID - {newUser.UserId}");
    }
}
