using System;

public class User
{
    public string UserName { get; set; }
    public int UserId { get; set; }
}

public class UserManager
{
    public User CreateUser(string userName, int userId)
    {
        User newUser = new User
        {
            UserName = userName,
            UserId = userId
        };

        // You can add additional logic here, e.g., saving the user to a database

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
