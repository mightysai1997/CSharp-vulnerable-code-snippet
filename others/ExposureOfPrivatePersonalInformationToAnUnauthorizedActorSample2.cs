using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string pass = GetPassword();
        // ...

        int id = 123;       // Example value
        string type = "A";  // Example value
        DateTime tstamp = DateTime.Now;  // Example timestamp

        using (StreamWriter dbmsLog = File.AppendText("log.txt"))
        {
            dbmsLog.WriteLine(id + ":" + pass + ":" + type + ":" + tstamp);
        }
    }

    static string GetPassword()
    {
        // Example: Retrieve the password from a secure source
        return "securePassword123";
    }
}
