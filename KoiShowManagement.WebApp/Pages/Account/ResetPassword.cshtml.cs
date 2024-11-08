using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiShowManagement.WebApp.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Địa chỉ email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Mật khẩu mới là bắt buộc.")]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Xác nhận mật khẩu mới là bắt buộc.")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }

        public void OnGet()
        {
            // Chạy khi trang được tải lần đầu (GET request)
            // Có thể thêm logic để kiểm tra mã xác nhận từ email nếu cần
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Logic xử lý đặt lại mật khẩu, ví dụ:
                // - Kiểm tra xem email có tồn tại trong hệ thống không
                // - Đặt lại mật khẩu người dùng trong cơ sở dữ liệu

                if (Email == "user@example.com") // Giả lập kiểm tra email
                {
                    // Giả lập đặt lại mật khẩu thành công
                    StatusMessage = "Mật khẩu của bạn đã được đặt lại thành công!";
                    return RedirectToPage("/Account/Login"); // Chuyển hướng tới trang đăng nhập
                }
                else
                {
                    // Nếu email không tồn tại trong hệ thống
                    StatusMessage = "Email không tồn tại trong hệ thống.";
                }
            }
            else
            {
                StatusMessage = "Vui lòng điền đầy đủ thông tin hợp lệ.";
            }

            return Page(); // Trả về trang hiện tại để hiển thị thông báo
        }
    }
}
