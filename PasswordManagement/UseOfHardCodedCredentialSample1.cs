public class DatabaseConnection
{
    private string _username = "myusername";
    private string _password = "mypassword";
    private string _database = "mydatabase";

    public void Connect()
    {
        // Establish a database connection using hardcoded credentials
        string connectionString = $"Server=localhost;Database={_database};User Id={_username};Password={_password};";

        // Connect to the database
        SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
            // Perform database operations
        }
        catch (Exception ex)
        {
            // Handle connection or database errors
        }
        finally
        {
            connection.Close();
        }
    }
}
