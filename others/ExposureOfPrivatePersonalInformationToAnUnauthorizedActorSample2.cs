using System;
using System.IO;

public class PasswordLogger
{
    private StreamWriter dbmsLog;

    public PasswordLogger(string logFilePath)
    {
        dbmsLog = new StreamWriter(logFilePath, true);
    }

    public void LogPassword(int id, string type, DateTime timestamp)
    {
        string pass = GetPassword(); // Call your GetPassword() function to retrieve the password

        // Log the information to the database log
        dbmsLog.WriteLine(id + ":" + pass + ":" + type + ":" + timestamp);
        dbmsLog.Flush(); // Ensure the log is written immediately

        // Other processing using the retrieved password, if needed
    }

    private string GetPassword()
    {
        // Implement your logic to retrieve the password here
        // For example, you might query a database or read from a secure source
        // For demonstration purposes, returning a hardcoded password
        return "SamplePassword123";
    }

    public void CloseLog()
    {
        // Close the log file when done logging
        dbmsLog.Close();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string logFilePath = "log.txt"; // Specify the path to your log file
        PasswordLogger passwordLogger = new PasswordLogger(logFilePath);

        int userId = 1; // Example user ID
        string userType = "admin"; // Example user type
        DateTime timestamp = DateTime.Now; // Example timestamp

        // Log password and other information
        passwordLogger.LogPassword(userId, userType, timestamp);

        // Close the log file
        passwordLogger.CloseLog();
    }
}
