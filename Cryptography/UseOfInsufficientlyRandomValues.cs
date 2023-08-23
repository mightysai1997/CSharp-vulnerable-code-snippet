using System;

namespace InsufficientRandomnessExample
{
    public class InsecureRandom
    {
        private int seed;

        public InsecureRandom(int seed)
        {
            this.seed = seed;
        }

        public int Next()
        {
            // Insecure random number generation using a linear congruential generator
            seed = (seed * 1664525 + 1013904223) & 0x7FFFFFFF;
            return seed;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            Console.WriteLine("Select an option:\n1. Roll Dice\n2. Generate OTP");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 1)
                {
                    // Simulating a dice roll
                    InsecureRandom random = new InsecureRandom(42);
                    int diceRoll = random.Next() % 6 + 1;
                    Console.WriteLine($"You rolled a {diceRoll}");
                }
                else if (userChoice == 2)
                {
                    // Simulating generation of a one-time password (OTP)
                    InsecureRandom random = new InsecureRandom(1337);
                    int otp = random.Next() % 10000;
                    Console.WriteLine($"Your OTP is: {otp:D4}");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
