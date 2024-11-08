using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiShowManagement.WebApp.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        public string StatusMessage { get; set; }

        // Xử lý POST để gửi liên kết đặt lại mật khẩu
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Logic gửi email với liên kết đặt lại mật khẩu
                StatusMessage = "Một liên kết đặt lại mật khẩu đã được gửi đến email của bạn nếu địa chỉ email hợp lệ.";
            }
            else
            {
                StatusMessage = "Vui lòng nhập một địa chỉ email hợp lệ.";
            }
        }
    }
}
