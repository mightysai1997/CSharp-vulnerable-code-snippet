using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = null;

        try
        {
            // Set the TcpListener on a specific port.
            int port = 12345;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            Console.WriteLine("Server listening on port " + port);

            while (true)
            {
                // Wait for a client to connect.
                TcpClient client = server.AcceptTcpClient();

                // Get the network stream.
                NetworkStream stream = client.GetStream();

                // Sensitive information (password) sent in cleartext
                string sensitiveInformation = "SuperSecretPassword";

                // Convert the string to bytes and send it.
                byte[] data = Encoding.ASCII.GetBytes(sensitiveInformation);
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent sensitive information to the client.");

                // Clean up the connection.
                stream.Close();
                client.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            // Stop listening for new clients.
            server?.Stop();
        }

        Console.WriteLine("\nServer shutting down...");
    }
}
