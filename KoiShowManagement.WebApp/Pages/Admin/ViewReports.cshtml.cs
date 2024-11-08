using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Admin
{
    public class ViewReportsModel : PageModel
    {
        public List<Report> Reports { get; set; }

        public void OnGet()
        {
            // Giả sử bạn lấy dữ liệu từ cơ sở dữ liệu
            Reports = new List<Report>
            {
                new Report { Name = "Báo cáo tháng 1", CreationDate = DateTime.Now, Details = "Chi tiết báo cáo 1" },
                new Report { Name = "Báo cáo tháng 2", CreationDate = DateTime.Now, Details = "Chi tiết báo cáo 2" }
            };
        }
    }

    public class Report
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Details { get; set; }
    }
}
