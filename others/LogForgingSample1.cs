using System.Web;
using System.Web.Mvc;

public class ExampleController : Controller
{
    private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    [HttpGet]
    public void Log(string data)
    {
        if (data != null)
        {
            _logger.Info("Log: " + data); // Noncompliant
        }
    }
}
