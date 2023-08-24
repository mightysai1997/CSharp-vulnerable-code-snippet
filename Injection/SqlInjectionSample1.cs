using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class ExampleClass
{
    public void Foo(DbContext context, string query, string param)
    {
        string sensitiveQuery = string.Concat(query, param);
        context.Database.ExecuteSqlCommand(sensitiveQuery); // Sensitive
        context.Query<User>().FromSql(sensitiveQuery); // Sensitive

        context.Database.ExecuteSqlCommand($"SELECT * FROM mytable WHERE mycol={value}", param); // Sensitive, the FormattableString is evaluated and converted to RawSqlString
        string formattedQuery = $"SELECT * FROM mytable WHERE mycol={param}";
        context.Database.ExecuteSqlCommand(formattedQuery); // Sensitive, the FormattableString has already been evaluated, it won't be converted to a parametrized query.
    }

    public void Bar(SqlConnection connection, string param)
    {
        SqlCommand command;
        string sensitiveQuery = string.Format("INSERT INTO Users (name) VALUES (\"{0}\")", param);
        command = new SqlCommand(sensitiveQuery); // Sensitive

        command.CommandText = sensitiveQuery; // Sensitive

        SqlDataAdapter adapter;
        adapter = new SqlDataAdapter(sensitiveQuery, connection); // Sensitive
    }
}

public class User
{
    // Define User class properties here
}
