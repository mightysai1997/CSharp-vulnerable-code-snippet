using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();

        // Vulnerable code: Sending password over the network without encryption
        SendPasswordOverNetwork(password);
    }

    static void SendPasswordOverNetwork(string password)
    {
        try
        {
            // Assume server IP and port are properly configured
            string serverIp = "127.0.0.1";
            int port = 12345;

            TcpClient client = new TcpClient(serverIp, port);
            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(password);
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Password sent to the server.");

            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

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
