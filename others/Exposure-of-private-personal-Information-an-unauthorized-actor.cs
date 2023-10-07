using System;
using System.Net;

public class DataTransmitter
{
    public static void Main(string[] args)
    {
        string sensitiveData = "ThisIsSensitiveData123";

        // Vulnerable: Sending sensitive data over HTTP (cleartext)
        WebClient client = new WebClient();
        string response = client.UploadString("http://example.com/submit", sensitiveData);
        Console.WriteLine("Server Response: " + response);
    }
}
