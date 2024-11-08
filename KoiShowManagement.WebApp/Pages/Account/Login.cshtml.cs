using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace KoiShowManagement.WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; }

        // Thêm thuộc tính StatusMessage để chứa thông báo trạng thái
        public string StatusMessage { get; set; }

        // Phương thức xử lý đăng nhập
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra thông tin đăng nhập (bạn có thể thay thế với cơ chế xác thực thực tế)
                if (Username == "admin" && Password == "password")
                {
                    // Tạo Claims cho người dùng (dữ liệu xác thực)
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Đăng nhập người dùng vào hệ thống
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Chuyển hướng người dùng về trang chính sau khi đăng nhập thành công
                    return RedirectToPage("/Home/Index");
                }
                else
                {
                    // Đăng nhập thất bại
                    StatusMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            else
            {
                StatusMessage = "Vui lòng nhập đầy đủ thông tin!";
            }

            // Trả lại trang login với thông báo lỗi
            return Page();
        }
    }
}
