using System;
using System.Data.SqlClient;
using System.Web;

class Program
{
    static void Main()
    {
        // Example: Accept user input
        string userInput = "<script>alert('XSS Attack');</script>";
        
        // Sanitize and validate user input
        string sanitizedInput = SanitizeInput(userInput);

        // Use the sanitized input in a SQL query (always use parameterized queries to prevent SQL injection)
        using (SqlConnection connection = new SqlConnection("your_connection_string"))
        {
            connection.Open();
            string sql = "SELECT * FROM Users WHERE Username = @Username";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Use parameterized query to prevent SQL injection
                command.Parameters.AddWithValue("@Username", sanitizedInput);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Username"]);
                }
            }
        }

        // Display sanitized input on a web page (HTML escaping)
        HttpContext.Current.Response.Write(HttpUtility.HtmlEncode(sanitizedInput));
    }

    // Sanitize user input (example: remove HTML tags)
    static string SanitizeInput(string input)
    {
        // Remove HTML tags using a regular expression
        string sanitizedInput = System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", String.Empty);

        // You can add more sanitation steps as needed, depending on your application's requirements

        return sanitizedInput;
    }
}
