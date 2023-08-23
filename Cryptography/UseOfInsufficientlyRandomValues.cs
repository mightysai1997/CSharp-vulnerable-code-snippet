using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static string GenerateForgotPasswordToken(string username)
    {
        DateTime time = DateTime.Now;
        string input = time.Hour + ":" + time.Minute + username;

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }

    static void Main(string[] args)
    {
        string username = "exampleUsername";
        string token = GenerateForgotPasswordToken(username);
        Console.WriteLine("Generated Token: " + token);
    }
}
