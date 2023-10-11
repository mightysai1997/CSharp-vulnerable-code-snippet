using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        // Sensitive data to be transmitted
        string sensitiveData = "This is my sensitive data.";

        // Destination URL (insecure HTTP)
        string destinationUrl = "http://example.com/receiver";

        try
        {
            // Convert the data to bytes
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(sensitiveData);

            // Create a request object
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);

            // Set the request method to POST
            request.Method = "POST";

            // Set the content type and content length
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataBytes.Length;

            // Get the request stream and write the data to it
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(dataBytes, 0, dataBytes.Length);
            requestStream.Close();

            // Get the response from the server
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Read the response (if needed)
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();

            // Do something with the response (if needed)
            Console.WriteLine("Response from server: " + responseText);

            // Close the response and request streams
            response.Close();
            reader.Close();
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
