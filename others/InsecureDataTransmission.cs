using System;
using System.Net.Http;

public class SecureDataTransmission
{
    public static void Main(string[] args)
    {
        // Replace these values with your actual API endpoint and sensitive data
        string apiUrl = "https://example.com/api/data";
        string sensitiveData = "This is my sensitive data.";

        // Create a HttpClient instance to make the secure request
        using (HttpClient client = new HttpClient())
        {
            // Use TLS for secure communication
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Convert sensitive data to bytes
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(sensitiveData);

            // Use ByteArrayContent to send data in the request body
            ByteArrayContent content = new ByteArrayContent(dataBytes);

            // Send a POST request to the API endpoint
            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

            // Check the response status
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data transmitted securely.");
            }
            else
            {
                Console.WriteLine("Failed to transmit data securely. Status code: " + response.StatusCode);
            }
        }
    }
}
