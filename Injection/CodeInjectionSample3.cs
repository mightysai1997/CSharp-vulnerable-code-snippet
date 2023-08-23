using System;

namespace CodeInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            string command = "echo Hello, " + name;
            ExecuteCommand(command);
        }

        static void ExecuteCommand(string cmd)
        {
            System.Diagnostics.Process.Start("cmd", "/c " + cmd);
        }
    }
}
