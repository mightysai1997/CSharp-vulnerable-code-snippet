using System;
using System.Text;
using System.Web;

public class PrivateInformationHandler : IHttpHandler
{
    private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public void ProcessRequest(HttpContext ctx)
    {
        string address = ctx.Request.QueryString["Address1"];

        // Log the private information (address) - Ensure proper security measures are in place
        logger.Info("User has address: " + address);

        // Perform other processing based on the address if needed

        // Send response to the client
        ctx.Response.ContentType = "text/plain";
        ctx.Response.Write("Address information received and logged successfully.");
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
