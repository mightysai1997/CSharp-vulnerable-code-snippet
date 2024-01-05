using System;
using System.IO;
using System.Web;

public class Global : HttpApplication
{
    void Application_Error(object sender, EventArgs e)
    {
        // Get the last error that occurred
        Exception exception = Server.GetLastError();

        // Log the error (this is just an example; in a real-world scenario, use a proper logging mechanism)
        LogError(exception);

        // Clear the error to avoid further processing
        Server.ClearError();

        // Redirect the user to a generic error page
        Response.Redirect("~/ErrorPage.aspx");
    }

    private void LogError(Exception ex)
    {
        // Log the error to a file (this is just an example; use a proper logging library in production)
        string logFilePath = Server.MapPath("~/App_Data/ErrorLog.txt");
        File.AppendAllText(logFilePath, $"[{DateTime.Now}] {ex.ToString()}{Environment.NewLine}");
    }
}
