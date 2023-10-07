using System;
using System.IO;
using System.Net;
using System.Text;

public class DataTransmitter
{
    public static void Main(string[] args)
    {
        try
        {
            // Source data to be transmitted
            string sourceData = "This is the data to be transmitted.";

            // Destination URL where the data will be sent
            string destinationUrl = "https://example.com/api/receive";

            // Create a request object with the destination URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);

            // Set the request method to POST
            request.Method = "POST";

            // Set the content type and content length headers
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.UTF8.GetBytes("data=" + sourceData);
            request.ContentLength = byteArray.Length;

            // Get the request stream and write the data to be transmitted
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            // Get the response from the server
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Read the response data
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Console.WriteLine("Response from server: " + responseFromServer);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
