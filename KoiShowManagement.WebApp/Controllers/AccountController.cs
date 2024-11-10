using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System.Threading.Tasks;

namespace KoiShowManagement.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            // Use the asynchronous login method
            if (await _userService.LoginAsync(user))
            {
                return RedirectToAction("Index", "Home");
            }
            // If login fails, return the view with the user object to show error message
            return View(user);
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            // Use the asynchronous register method
            if (await _userService.RegisterAsync(user))
            {
                return RedirectToAction("Login");
            }
            // If registration fails, return the view with the user object to show errors
            return View(user);
        }
    }
}
