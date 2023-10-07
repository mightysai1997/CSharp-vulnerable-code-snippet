using System;
using System.Security;
using System.Security.Cryptography;
using System.Web.Security;

class PasswordGenerator
{
    public static void Main(string[] args)
    {
        string generatedPassword = GeneratePassword();

        // Store or use the generated password securely here
        Console.WriteLine("Generated Password: " + generatedPassword);
    }

    static string GeneratePassword()
    {
        string password;
        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            byte[] randomBytes = new byte[sizeof(int)];
            crypto.GetBytes(randomBytes);
            password = "mypassword" + BitConverter.ToInt32(randomBytes);
        }

        return password;
    }

    // Securely convert a string to a SecureString
    static SecureString ToSecureString(string input)
    {
        SecureString secureString = new SecureString();
        foreach (char c in input)
        {
            secureString.AppendChar(c);
        }
        secureString.MakeReadOnly();
        return secureString;
    }
}
