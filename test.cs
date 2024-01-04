using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generated weak random number: " + GenerateWeakRandomNumber());
    }

    static int GenerateWeakRandomNumber()
    {
        // Vulnerable code: Using DateTime.Now.Ticks as a random seed
        Random random = new Random((int)DateTime.Now.Ticks);

        // Simulating the use of a random number
        return random.Next();
    }
}
