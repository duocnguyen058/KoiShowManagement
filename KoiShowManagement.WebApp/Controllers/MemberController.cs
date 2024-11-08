using Microsoft.AspNetCore.Mvc;

public class MemberController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult UpdateProfile()
    {
        return View();
    }
}
