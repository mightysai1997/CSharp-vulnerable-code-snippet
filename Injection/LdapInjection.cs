using System;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;

public class ExampleController : Controller
{
    public IActionResult Authenticate(string user, string pass)
    {
        DirectoryEntry directory  = new DirectoryEntry("LDAP://ou=system");
        DirectorySearcher search  = new DirectorySearcher(directory);

        search.Filter = "(&(uid=" + user + ")(userPassword=" + pass + "))";

        return Json(search.FindOne() != null);
    }
}
