using System;
using System.Text;
using System.Web;

public class PrivateInformationHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext ctx)
    {
        string address = ctx.Request.QueryString["Address1"];
        logger.Info("User has address: " + address);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
