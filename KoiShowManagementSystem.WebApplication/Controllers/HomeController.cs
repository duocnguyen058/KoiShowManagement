using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KoiShowManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompetitionService _competitionService;
        private readonly IAccountService _accountService;

        public HomeController(ICompetitionService competitionService, IAccountService accountService)
        {
            _competitionService = competitionService;
            _accountService = accountService;
        }

        // Trang chủ, hiển thị danh sách các cuộc thi đang diễn ra
        public async Task<IActionResult> Index()
        {
            try
            {
                var ongoingCompetitions = await _competitionService.GetOngoingCompetitionsAsync();
                return View(ongoingCompetitions);
            }
            catch (Exception ex)
            {
                // Log lỗi
                return View("Error", new { message = "Có lỗi khi lấy thông tin cuộc thi." });
            }
        }

        // Tìm kiếm cuộc thi
        [HttpPost]
        public async Task<IActionResult> SearchCompetitions(string searchQuery, DateTime? date = null)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var searchResults = await _competitionService.SearchCompetitionsAsync(searchQuery, date);
                return View("Index", searchResults);
            }
            catch (Exception ex)
            {
                // Log lỗi
                return View("Error", new { message = "Có lỗi khi tìm kiếm cuộc thi." });
            }
        }

        // Đăng ký tài khoản
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isExist = await _accountService.IsAccountExistAsync(account.Username);
                    if (isExist)
                    {
                        ModelState.AddModelError("", "Tài khoản đã tồn tại.");
                        return View(account);
                    }

                    var isRegistered = await _accountService.CreateAccountAsync(account);
                    if (isRegistered)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    ModelState.AddModelError("", "Đăng ký không thành công.");
                }
                catch (Exception ex)
                {
                    // Log lỗi
                    ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình đăng ký.");
                }
            }
            return View(account);
        }

        // Đăng nhập
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return View();
            }

            try
            {
                var account = await _accountService.ValidateAccountAsync(username, password);
                if (account == null)
                {
                    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không đúng.");
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                    new Claim(ClaimTypes.Role, account.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Profile", "Account", new { id = account.AccountId });
            }
            catch (Exception ex)
            {
                // Log lỗi
                ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình đăng nhập.");
                return View();
            }
        }

        // Đăng xuất
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction(nameof(Login));
        }

        // Hiển thị thông tin hồ sơ người dùng đã đăng nhập
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return RedirectToAction(nameof(Login));
                }

                var account = await _accountService.GetAccountByIdAsync(int.Parse(userId));
                return View(account);
            }
            catch (Exception ex)
            {
                // Log lỗi
                return View("Error", new { message = "Có lỗi khi lấy thông tin hồ sơ người dùng." });
            }
        }

        // Trang lỗi chung
        public IActionResult Error(string message)
        {
            ViewData["ErrorMessage"] = message;
            return View();
        }
    }
}
