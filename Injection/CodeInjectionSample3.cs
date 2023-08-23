using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    public class MessageController : Controller
    {
        private const string MessageFile = "messages.out";

        [HttpGet]
        public IActionResult NewMessage(string name, string message)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(message))
            {
                using (StreamWriter writer = System.IO.File.AppendText(MessageFile))
                {
                    writer.WriteLine($"<b>{name}</b> says '{message}'<hr>");
                }

                ViewBag.Message = "Message Saved!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewMessages()
        {
            string content = System.IO.File.ReadAllText(MessageFile);
            return Content(content, "text/html");
        }
    }
}
