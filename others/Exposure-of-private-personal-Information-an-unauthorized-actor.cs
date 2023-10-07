using System;
using System.IO;

public class CredentialWriter
{
    public static void Main(string[] args)
    {
        WriteCredentials();
        Console.WriteLine("Credentials written to file.");
    }

    public static void WriteCredentials()
    {
        string password = "cleartext password";
        string filePath = "credentials.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // BAD: Writing password to disk in cleartext
                writer.WriteLine(password);

                // Alternatively, you can hash the password before storing it
                // string hashedPassword = HashFunction(password);
                // writer.WriteLine(hashedPassword);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // HashFunction is a placeholder for a secure hashing algorithm
    // For example, you can use SHA-256 hashing
    public static string HashFunction(string password)
    {
        using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
