using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            // Connect to the server.
            TcpClient client = new TcpClient("127.0.0.1", 12345);

            // Get the network stream.
            NetworkStream stream = client.GetStream();

            // Receive the data from the server.
            byte[] data = new byte[256];
            int bytesRead = stream.Read(data, 0, data.Length);
            string sensitiveInformation = Encoding.ASCII.GetString(data, 0, bytesRead);

            Console.WriteLine("Received sensitive information from the server: " + sensitiveInformation);

            // Clean up the connection.
            stream.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        Console.WriteLine("\nClient shutting down...");
    }
}
