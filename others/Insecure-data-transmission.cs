using System;
using System.IO;
using System.Net;

public class DataTransmitter
{
    public static void Main(string[] args)
    {
        string sensitiveData = "ThisIsSensitiveData123";

        // Insecure: Sending sensitive data over HTTP (cleartext)
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/submit");
        request.Method = "POST";
        request.ContentType = "text/plain";

        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(sensitiveData);
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string result = reader.ReadToEnd();
            Console.WriteLine("Server Response: " + result);
        }
    }
}
