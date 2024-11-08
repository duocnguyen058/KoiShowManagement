using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult CreateCompetition()
    {
        return View();
    }

    public IActionResult ManageUsers()
    {
        return View();
    }

    public IActionResult ViewReports()
    {
        return View();
    }
}
