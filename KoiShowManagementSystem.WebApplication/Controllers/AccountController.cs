using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Repositories.Entities;
using System.Threading.Tasks;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Hiển thị trang đăng ký
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();  // Hiển thị form đăng ký
        }

        // Xử lý đăng ký tài khoản
        [HttpPost("register")]
        public async Task<IActionResult> Register(Account account)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _accountService.IsAccountExistAsync(account.Username);
                if (isExist)
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại.");
                    return View(account);
                }

                var result = await _accountService.CreateAccountAsync(account);
                if (result)
                {
                    // Thông báo đăng ký thành công
                    TempData["SuccessMessage"] = "Đăng ký tài khoản thành công! Vui lòng đăng nhập.";
                    return RedirectToAction("Login");  // Đổi route nếu cần
                }
                ModelState.AddModelError(string.Empty, "Đã có lỗi xảy ra khi tạo tài khoản.");
            }

            return View(account);
        }

        // Hiển thị trang đăng nhập cho người dùng
        [HttpGet("login")]
        public IActionResult UserLogin()
        {
            return View();  // Hiển thị form đăng nhập người dùng
        }

        // Xử lý đăng nhập cho người dùng
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(AccountLoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var account = await _accountService.ValidateAccountAsync(loginRequest.Username, loginRequest.Password);

                if (account != null)
                {
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chủ người dùng
                }
                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(loginRequest);
        }

        // Hiển thị trang đăng nhập cho quản trị viên
        [HttpGet("admin/login")]
        public IActionResult AdminLogin()
        {
            return View();  // Hiển thị form đăng nhập quản trị viên
        }

        // Xử lý đăng nhập cho quản trị viên
        [HttpPost("admin/login")]
        public async Task<IActionResult> AdminLogin(AccountLoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var account = await _accountService.ValidateAccountAsync(loginRequest.Username, loginRequest.Password);

                if (account != null && account.Role == "Admin")
                {
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Admin"); // Chuyển hướng đến trang quản trị
                }

                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(loginRequest);
        }
    }

    // Model yêu cầu cho việc đăng nhập
    public class AccountLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
