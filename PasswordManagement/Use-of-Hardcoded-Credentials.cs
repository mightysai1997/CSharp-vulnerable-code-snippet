using System;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    // Other user properties
}

public class UserRepository
{
    // Simulated user repository
    public void CreateUser(User user)
    {
        // Simulate user creation logic (e.g., save to a database)
        Console.WriteLine($"User created with Username: {user.Username}");
    }
}

class Program
{
    static void Main()
    {
        // Hard-coded user credentials
        var newUser = new User
        {
            Username = "john_doe",
            Password = "password123",
            // Set other user properties here
        };

        var userRepository = new UserRepository();
        userRepository.CreateUser(newUser);

        // Rest of your code...
    }
}
