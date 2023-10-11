public BankAccount GetUserBankAccount(string username, string accountNumber)
{
    BankAccount userAccount = null;
    string query = null;
    try
    {
        if (IsAuthorizedUser(username))
        {
            query = "SELECT * FROM accounts WHERE owner = '" + username + "' AND accountID = '" + accountNumber + "'";
            DatabaseManager dbManager = new DatabaseManager();
            SqlConnection conn = dbManager.GetConnection(); // Assuming DatabaseManager.GetConnection() returns SqlConnection
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader queryResult = cmd.ExecuteReader();
            
            if (queryResult.Read())
            {
                // Assuming BankAccount class has appropriate constructor and property names
                userAccount = new BankAccount
                {
                    AccountID = queryResult["accountID"].ToString(),
                    Owner = queryResult["owner"].ToString(),
                    // Set other properties here based on your database schema
                };
            }
            conn.Close();
        }
    }
    catch (SqlException ex)
    {
        string logMessage = "Unable to retrieve account information from database,\nquery: " + query;
        Logger.Log(LogLevel.Error, logMessage, ex);
        // Assuming Logger class has a Log method to handle logging
    }
    return userAccount;
}

public bool IsAuthorizedUser(string username)
{
    // Implement your authorization logic here
    // Return true if the user is authorized, otherwise return false
    return true; // Example: Always returning true for demonstration purposes
}
