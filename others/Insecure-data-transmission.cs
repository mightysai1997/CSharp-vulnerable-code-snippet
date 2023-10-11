using System;
using System.Net;
using System.IO;

class Program
{
    static void Main()
    {
        string username = "myUsername";
        string password = "myPassword";

        // Insecure URL (HTTP instead of HTTPS)
        string url = "http://example.com/login";

        // Create a request object to send the data
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        
        // Set the request method to POST
        request.Method = "POST";

        // Prepare the data to be sent
        string postData = $"username={username}&password={password}";
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
        
        // Set the content type of the request
        request.ContentType = "application/x-www-form-urlencoded";

        // Get the request stream and write the data to it
        using (Stream dataStream = request.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }

        // Get the response from the server
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        // Read the response data
        using (Stream responseStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(responseStream);
            string responseString = reader.ReadToEnd();
            Console.WriteLine("Response: " + responseString);
        }

        // Close the response and response stream
        response.Close();
    }
}
