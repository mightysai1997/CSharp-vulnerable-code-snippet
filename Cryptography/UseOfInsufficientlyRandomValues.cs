using System;

class RandomKeyGenerator
{
    static void Main(string[] args)
    {
        string insecureKey = GenerateInsecureKey();
        
        // Using the insecure key for encryption or other security operations
        Console.WriteLine("Insecure Key: " + insecureKey);
    }

    static string GenerateInsecureKey()
    {
        Random random = new Random();
        int randomNumber = random.Next(100000, 999999); // Generate a random 6-digit number
        string insecureKey = "KEY_" + randomNumber.ToString();
        return insecureKey;
    }
}
