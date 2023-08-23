using System;
namespace PrivateInfoExposureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "alice";
            string password = "mysecretpassword";

 

            Console.WriteLine("Welcome, " + username + "!");
            Console.WriteLine("Please enter your password: ");
            string userInputPassword = Console.ReadLine();

 

            if (userInputPassword == password)
            {
                Console.WriteLine("Access granted. Your account balance is $1000.");
            }
            else
            {
                Console.WriteLine("Access denied. Invalid password.");
            }
        }
    }
}
