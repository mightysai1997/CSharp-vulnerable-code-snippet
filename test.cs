// Source: DebugInfoProvider.cs
public class DebugInfoProvider
{
    public static string GetSensitiveInformation()
    {
        // Simulate fetching sensitive information from a database or other source
        string sensitiveData = "This is sensitive information.";
        
        // In a real-world scenario, you would perform additional checks and validations
        
        #if DEBUG
            // Log the sensitive information only in debug mode
            Console.WriteLine("Debug Log: " + sensitiveData);
        #endif

        return sensitiveData;
    }
}

// Sink: HomeController.cs
public class HomeController : Controller
{
    public ActionResult Index()
    {
        // Retrieve sensitive information from the source
        string sensitiveData = DebugInfoProvider.GetSensitiveInformation();

        // Use the sensitive information (in this case, just returning it as part of the view)
        return View((object)sensitiveData);
    }
}
