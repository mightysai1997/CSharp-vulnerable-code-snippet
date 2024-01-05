using System;

class Program
{
    static void Main()
    {
        // Vulnerable code: Using DateTime.Ticks as a source of randomness
        long insufficientlyRandomValue = DateTime.Now.Ticks;

        // Simulate a cryptographic operation where this value is used
        string key = GenerateKey(insufficientlyRandomValue);

        // Attacker can predict the key if they know or can guess the approximate time of execution
        Console.WriteLine($"Generated Key: {key}");
    }

    static string GenerateKey(long seed)
    {
        // This is a simplified example; in a real-world scenario, use a proper cryptographic RNG
        Random random = new Random((int)seed);

        // Generate a key (not secure in this context)
        byte[] keyBytes = new byte[16];
        random.NextBytes(keyBytes);

        return BitConverter.ToString(keyBytes).Replace("-", "");
    }
}
