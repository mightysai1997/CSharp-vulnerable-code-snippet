using System;
using System.Text;
using System.Web;
using System.Web.Security;

public class CleartextStorageHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext ctx)
    {
        // Get the "AccountName" parameter from the query string
        string accountName = ctx.Request.QueryString["AccountName"];

        // Store the original account name in a cookie named "AccountName"
        ctx.Response.Cookies["AccountName"].Value = accountName;

        // Protect the account name using the Protect method and store it in the same cookie
        // string protectedAccountName = Protect(accountName, "Account name");
        ctx.Response.Cookies["AccountName"].Value = Protect(accountName, "Account name");
    }

    public string Protect(string value, string type)
    {
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);
        byte[] protectedBytes = MachineKey.Protect(valueBytes, type);
        return Encoding.UTF8.GetString(MachineKey.Protect(Encoding.UTF8.GetBytes(value), type));
    }

    public bool IsReusable => false; // Indicate that the handler instance is not reusable
}
