using System;
using System.Net.Http;
using System.Text;

class Program
{
    static void Main()
    {
        string sensitiveData = "ThisIsSensitiveData123";

        using (HttpClient client = new HttpClient())
        {
            // Insecure HTTP URL (http:// instead of https://)
            string insecureApiUrl = "http://example.com/api/data";

            // Convert sensitive data to JSON
            string jsonData = $"{{ \"data\": \"{sensitiveData}\" }}";

            // Create StringContent with JSON data
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Send data over an insecure connection (HTTP)
            HttpResponseMessage response = client.PostAsync(insecureApiUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data sent successfully over an insecure connection.");
            }
            else
            {
                Console.WriteLine("Failed to send data over an insecure connection.");
            }
        }

        Console.ReadLine();
    }
}
