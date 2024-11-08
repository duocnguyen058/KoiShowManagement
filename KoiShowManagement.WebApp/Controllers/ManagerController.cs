using Microsoft.AspNetCore.Mvc;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
