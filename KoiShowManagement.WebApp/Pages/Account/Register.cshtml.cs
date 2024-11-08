using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiShowManagement.WebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Địa chỉ email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc.")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }

        // Xử lý đăng ký khi form được gửi
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Logic xử lý đăng ký người dùng (có thể bao gồm lưu người dùng vào cơ sở dữ liệu)
                // Ví dụ, kiểm tra nếu người dùng đã tồn tại hoặc mật khẩu không khớp

                if (Username == "admin") // Giả lập kiểm tra người dùng
                {
                    StatusMessage = "Tên đăng nhập đã tồn tại.";
                }
                else
                {
                    // Giả lập đăng ký thành công
                    StatusMessage = "Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.";
                    // Thực hiện chuyển hướng đến trang đăng nhập hoặc trang chính
                }
            }
            else
            {
                StatusMessage = "Vui lòng điền đầy đủ thông tin hợp lệ.";
            }
        }
    }
}
