using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generated weak random number: " + GenerateWeakRandomNumber());
    }

    static int GenerateWeakRandomNumber()
    {
        // True positive: Using a weak source (DateTime.Now.Ticks) for randomness
        Random random = new Random((int)DateTime.Now.Ticks);

        // Simulating the use of a random number in a security context
        // This might represent, for example, generating a temporary authentication token
        int token = random.Next();

        // Assume that the generated token is used for security-sensitive purposes
        // ...

        return token;
    }
}
