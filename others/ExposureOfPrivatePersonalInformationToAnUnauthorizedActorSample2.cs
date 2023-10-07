using System;
using System.Net;
using System.IO;

class DataTransmitter
{
    static void Main(string[] args)
    {
        // Sensitive data to be transmitted
        string sensitiveData = "This is sensitive information.";

        // Destination URL where the data will be sent (without HTTPS)
        string destinationUrl = "http://example.com/api/receive";

        // Create a request object with the destination URL
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);

        // Set the request method to POST
        request.Method = "POST";
        
        // Encode the data to be transmitted
        byte[] data = System.Text.Encoding.UTF8.GetBytes("data=" + sensitiveData);

        // Set the content type and content length headers
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;

        // Get the request stream and write the data to be transmitted
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }

        // Get the response from the server
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // Read the response data
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine("Response from server: " + responseFromServer);
        }
    }
}
