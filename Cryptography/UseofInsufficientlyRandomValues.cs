using System;

namespace InsufficientRandomnessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            string password = GeneratePassword(username);
            Console.WriteLine("Your generated password: " + password);
        }

        static string GeneratePassword(string seed)
        {
            // Using a weak source of randomness (DateTime)
            Random random = new Random((int)DateTime.Now.Ticks);
            
            string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 8;
            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = charset[random.Next(charset.Length)];
            }

            return new string(password);
        }
    }
}
