using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Randomly generated password: " + GenerateWeakPassword());
    }

    static string GenerateWeakPassword()
    {
        // Vulnerable code: Using DateTime.Now.Ticks as a random seed
        Random random = new Random((int)DateTime.Now.Ticks);

        // Simulating a password generation algorithm
        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] password = new char[8];

        for (int i = 0; i < 8; i++)
        {
            password[i] = characters[random.Next(characters.Length)];
        }

        return new string(password);
    }
}
