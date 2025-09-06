using Microsoft.AspNetCore.Mvc;

namespace EDU.Controllers;

public class StateController : Controller
{
    public IActionResult SetSession (string name)
    {
        HttpContext.Session.SetString("Name" , name);

        HttpContext.Session.SetInt32("Age", 21);

        return Content("Data Added in Session Successfuly");
    }
    public IActionResult GetSession()
    {
        string? Name = HttpContext.Session.GetString("Name");
        int? Age = HttpContext.Session.GetInt32("Age");


        return Content($"Name -> {Name} Age -> {Age}");
    }

    public IActionResult SetCookie(string name)
    {
        HttpContext.Response.Cookies.Append("Name", name);

        HttpContext.Response.Cookies.Append("Age", "21");
        return Content("Cokkie Saved");
    }

    public IActionResult GetCookie()
    {
        string? name = HttpContext.Request.Cookies["Name"];
        string? Age = HttpContext.Request.Cookies["Age"];

        return Content($"name={name} Age={Age}");
    }
}
