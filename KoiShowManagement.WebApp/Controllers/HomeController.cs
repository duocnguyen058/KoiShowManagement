using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("~/Pages/Home/Index.cshtml");
    }

    public IActionResult About()
    {
        return View("~/Pages/Home/About.cshtml");
    }

    public IActionResult Competitions()
    {
        return View("~/Pages/Home/Competitions.cshtml");
    }

    public IActionResult Search()
    {
        return View("~/Pages/Home/Search.cshtml");
    }
}
