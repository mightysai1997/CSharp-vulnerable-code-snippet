using System;
using System.Web;

public class StackTraceHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext ctx)
    {
        try
        {

            doSomeWork();
        }
        catch (Exception ex)
        {

            ctx.Response.Write(ex.ToString());
            return; 
        }

        try
        {
            // Perform some other work that may throw an exception
            doSomeWork();
        }
        catch (Exception ex)
        {
            // GOOD: Log the stack trace and send back a non-revealing response
            log("Exception occurred", ex);
            ctx.Response.Write("Exception occurred");
            return; // Ensure to exit after writing the response
        }
    }

    // Method to perform some work that may throw an exception
    private void doSomeWork()
    {
        // Code for the work goes here
    }

    // Method to log an exception
    private void log(string message, Exception ex)
    {
        // Code for logging the exception goes here
    }

    public bool IsReusable => false; // Indicate that the handler instance is not reusable
}
