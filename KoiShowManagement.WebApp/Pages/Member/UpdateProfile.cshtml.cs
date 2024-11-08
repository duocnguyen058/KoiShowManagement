using KoiShowManagement.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Member
{
    public class UpdateProfileModel : PageModel
    {
        [BindProperty]
        public required Profile UserProfile { get; set; }

        // Thông điệp hiển thị cho người dùng
        public string Message { get; set; }

        // Phương thức này sẽ được gọi khi người dùng truy cập trang qua phương thức GET
        public void OnGet()
        {
            // Giả sử bạn lấy dữ liệu người dùng từ cơ sở dữ liệu
            // Ví dụ: UserProfile = _userService.GetUserProfile(userId);

            UserProfile = new Profile
            {
                FullName = "Nguyễn Văn A",
                Email = "nguyenvana@example.com",
                PhoneNumber = "0123456789"
            };
        }

        // Phương thức này sẽ được gọi khi người dùng gửi dữ liệu từ form (POST)
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Xử lý lưu dữ liệu cập nhật hồ sơ vào cơ sở dữ liệu
                // Ví dụ: _userService.UpdateUserProfile(UserProfile);

                Message = "Hồ sơ đã được cập nhật thành công!";
                return Page();
            }

            // Nếu có lỗi trong quá trình gửi, giữ lại form và hiển thị thông báo lỗi
            Message = "Đã xảy ra lỗi khi cập nhật hồ sơ!";
            return Page();
        }
    }
}
