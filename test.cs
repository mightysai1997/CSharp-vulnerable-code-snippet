using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter sensitive information:");
        string sensitiveData = Console.ReadLine();

        // Vulnerable code: Sending sensitive data over the network without encryption (HTTP instead of HTTPS)
        await TransmitDataInsecurely(sensitiveData);
    }

    static async Task TransmitDataInsecurely(string data)
    {
        try
        {
            // Assume the server URL is properly configured
            string serverUrl = "http://example.com/api/data";

            using (HttpClient client = new HttpClient())
            {
                // Vulnerable code: Sending data over an insecure connection (HTTP)
                HttpResponseMessage response = await client.PostAsync(serverUrl, new StringContent(data));
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data transmitted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to transmit data. Status code: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
