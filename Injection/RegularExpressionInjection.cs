using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

public class ExampleController : Controller
{
    public IActionResult Validate(string regex, string input)
    {
        bool match = Regex.IsMatch(input, regex);

        return Json(match);
    }
}
