using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        // Thông tin cần hiển thị trong Dashboard (ví dụ: Số lượng cuộc thi, người dùng)
        public int TotalCompetitions { get; set; }
        public int TotalUsers { get; set; }
        public int OngoingCompetitions { get; set; }

        public void OnGet()
        {
            // Logic để lấy thông tin tổng quan (dữ liệu giả lập)
            TotalCompetitions = 5;  // Thay bằng dữ liệu thực từ cơ sở dữ liệu
            TotalUsers = 100;       // Thay bằng dữ liệu thực từ cơ sở dữ liệu
            OngoingCompetitions = 2; // Thay bằng dữ liệu thực từ cơ sở dữ liệu
        }
    }
}
