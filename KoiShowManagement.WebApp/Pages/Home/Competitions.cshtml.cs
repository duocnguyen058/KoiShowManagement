using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace KoiShowManagement.WebApp.Pages.Home
{
    public class CompetitionsModel : PageModel
    {
        public List<string> Competitions { get; set; }

        public void OnGet()
        {
            // Dữ liệu giả lập cho danh sách cuộc thi
            Competitions = new List<string>
            {
                "Cuộc thi Cá Koi Đẹp 2023",
                "Koi Show Quốc tế",
                "Giải thi đấu Koi Việt Nam"
            };
        }
    }
}
