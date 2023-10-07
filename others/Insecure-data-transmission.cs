using System;
using System.Net.Sockets;
using System.Text;

public class PlainTextDataTransmitter
{
    public static void Main(string[] args)
    {
        string sensitiveData = "ThisIsSensitiveData123";

        // Insecure: Sending sensitive data over plain text using Socket
        using (TcpClient client = new TcpClient("example.com", 12345)) // Replace example.com and port with the actual server details
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = Encoding.UTF8.GetBytes(sensitiveData);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Data sent over plain text.");
            }
        }
    }
}
