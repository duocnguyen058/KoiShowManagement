using System.Diagnostics; // Thư viện hỗ trợ ghi lỗi ra cửa sổ Output
using System.Security.Claims; // Thư viện hỗ trợ tạo và xử lý Claims
using Microsoft.AspNetCore.Authentication; // Thư viện hỗ trợ xác thực (Authentication)
using Microsoft.AspNetCore.Mvc; // Thư viện cơ bản để xây dựng Controller
using KoiShowManagementSystem.Repositories.Entity; // Namespace của mô hình "Users"
using KoiShowManagementSystem.Services; // Namespace của dịch vụ quản lý người dùng

namespace KoiShowManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService; // Biến dùng để gọi các phương thức trong IUserService

        // Hàm khởi tạo Controller, nhận IUserService thông qua Dependency Injection
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        // Trang chủ
        public IActionResult Index()
        {
            return View(); // Trả về giao diện mặc định của trang chủ
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Trả về giao diện đăng ký
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu đầu vào có hợp lệ không
            {
                // Kiểm tra mật khẩu phải có ít nhất 6 ký tự
                if (user.Password.Length < 6)
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải có ít nhất 6 ký tự."); // Thêm lỗi vào ModelState
                    return View(user); // Trả về giao diện cùng thông báo lỗi
                }

                // Gọi phương thức đăng ký người dùng trong IUserService
                var result = await _userService.RegisterUserAsync(user);
                if (result) // Nếu đăng ký thành công
                {
                    TempData["SuccessMessage"] = "Đăng ký thành công. Bạn có thể đăng nhập ngay bây giờ."; // Thông báo thành công
                    return RedirectToAction("Login"); // Chuyển hướng đến trang đăng nhập
                }

                // Nếu tên đăng nhập đã tồn tại
                ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
            }
            else
            {
                // Ghi lỗi vào cửa sổ Output của Visual Studio
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Debug.WriteLine($"Lỗi ở {state.Key}: {error.ErrorMessage}");
                    }
                }
            }

            return View(user); // Trả về giao diện đăng ký cùng thông báo lỗi
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Trả về giao diện đăng nhập
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu đầu vào hợp lệ
            {
                // Gọi phương thức xác thực người dùng trong IUserService
                var user = await _userService.AuthenticateUserAsync(username, password);
                if (user != null) // Nếu xác thực thành công
                {
                    // Tạo danh sách Claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ID người dùng
                        new Claim(ClaimTypes.Name, user.Username), // Tên người dùng
                        new Claim(ClaimTypes.Role, user.Role) // Vai trò của người dùng
                    };

                    // Tạo ClaimsIdentity để xác thực
                    var claimsIdentity = new ClaimsIdentity(claims, "UserAuth");
                    await HttpContext.SignInAsync("UserAuth", new ClaimsPrincipal(claimsIdentity)); // Đăng nhập vào hệ thống

                    // Thêm thông báo đăng nhập thành công
                    TempData["SuccessMessage"] = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chủ
                }

                // Nếu đăng nhập thất bại
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(); // Trả về giao diện đăng nhập cùng thông báo lỗi
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng khỏi hệ thống
            await HttpContext.SignOutAsync("UserAuth");

            // Thêm thông báo đăng xuất thành công
            TempData["SuccessMessage"] = "Đăng xuất thành công!";

            return RedirectToAction("Login"); // Chuyển hướng đến trang đăng nhập
        }
        // Trang Privacy Policy
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        // Trang Điều Khoản Sử Dụng
        public IActionResult TermsOfService()
        {
            return View();
        }
    }
}
