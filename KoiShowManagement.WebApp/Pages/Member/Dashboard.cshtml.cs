using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShowManagement.WebApp.Models; // Đảm bảo bạn có mô hình dữ liệu thích hợp
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KoiShowManagement.WebApp.Pages.Member
{
    public class DashboardModel : PageModel
    {
        // Dữ liệu người dùng (ví dụ: có thể lấy từ cơ sở dữ liệu)
        public required Profile UserProfile { get; set; }

        // Danh sách các sự kiện hoặc thông báo cho người dùng
        public List<string> RecentActivities { get; set; }

        public void OnGet()
        {
            // Lấy thông tin người dùng (Ví dụ từ cơ sở dữ liệu)
            // Ví dụ: UserProfile = _userService.GetUserProfile(userId);
            UserProfile = new Profile
            {
                Name = "Nguyễn Văn A",
                Email = "nguyenvana@example.com"
            };

            // Lấy các hoạt động gần đây của người dùng
            RecentActivities = new List<string>
            {
                "Đã tham gia cuộc thi Koi Show tháng 10",
                "Cập nhật hồ sơ cá koi vào ngày 01/11",
                "Nhận thông báo từ ban tổ chức"
            };
        }
    }
}
