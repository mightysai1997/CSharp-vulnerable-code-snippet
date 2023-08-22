using System;
using System.Data.SqlClient;

namespace SQLInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine();

            string connectionString = "Data Source=your_server;Initial Catalog=your_database;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("User found: " + reader["Username"]);
            }

            reader.Close();
            connection.Close();
        }
    }
}
