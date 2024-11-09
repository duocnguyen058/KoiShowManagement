using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Trang chủ"; // Gán tiêu đề
        return View("~/Pages/Home/Index.cshtml"); // Đường dẫn đến file Razor Page
    }

    public IActionResult About()
    {
        ViewData["Title"] = "Giới thiệu"; // Gán tiêu đề
        return View("~/Pages/Home/About.cshtml"); // Đường dẫn đến file Razor Page
    }

    public IActionResult Competitions()
    {
        ViewData["Title"] = "Cuộc thi"; // Gán tiêu đề
        return View("~/Pages/Home/Competitions.cshtml"); // Đường dẫn đến file Razor Page
    }

    public IActionResult Search()
    {
        ViewData["Title"] = "Tìm kiếm"; // Gán tiêu đề
        return View("~/Pages/Home/Search.cshtml"); // Đường dẫn đến file Razor Page
    }
}
