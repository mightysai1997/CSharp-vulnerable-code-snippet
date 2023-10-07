using System;
using System.Net.Http;
using System.Threading.Tasks;

public class DataTransmissionExample
{
    public static async Task Main(string[] args)
    {
        // URL of the API endpoint
        string apiUrl = "https://api.example.com/data";

        // Data to be transmitted
        string sensitiveData = "This is sensitive data that needs to be transmitted securely.";

        // Creating HttpClient with SSL/TLS enabled
        using (HttpClient httpClient = new HttpClient())
        {
            // Sending data securely using HTTPS
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, new StringContent(sensitiveData));

            // Handling the response
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data transmitted securely!");
            }
            else
            {
                Console.WriteLine("Failed to transmit data securely. Status code: " + response.StatusCode);
            }
        }
    }
}
