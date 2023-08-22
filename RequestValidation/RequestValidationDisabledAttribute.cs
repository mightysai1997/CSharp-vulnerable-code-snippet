public class TestController
{
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult ControllerMethod(string input) {
        return f(input);
    }
}
