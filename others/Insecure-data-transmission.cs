using System;
using System.Net;

class Program
{
    static void Main()
    {
        string sensitiveData = "This is my sensitive information.";

        // Insecure transmission over HTTP (without encryption)
        string insecureUrl = "http://example.com/api";

        // Create a WebClient instance to send the data
        WebClient client = new WebClient();

        // Transmit sensitive data over an insecure connection (HTTP)
        string response = client.UploadString(insecureUrl, sensitiveData);

        // Display the response from the server
        Console.WriteLine("Server Response: " + response);
    }
}
