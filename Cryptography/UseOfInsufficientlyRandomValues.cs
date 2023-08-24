using System;
using System.Security.Cryptography;
using System.Text;

public class Example
{
    public static string GenerateForgotPasswordToken(string username)
    {
        var time = DateTime.Now;
        var input = time.Hour + ":" + time.Minute + username;

        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            string hashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashHex;
        }
    }

    public static void Main()
    {
        string username = "example_user";
        string token = GenerateForgotPasswordToken(username);
        Console.WriteLine("Generated Token: " + token);
    }
}
