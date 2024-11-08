using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace KoiShowManagement.WebApp.Pages.Home
{
    public class SearchModel : PageModel
    {
        public string Query { get; set; } // Từ khóa tìm kiếm của người dùng
        public List<string> Results { get; set; } // Danh sách kết quả tìm kiếm
        public bool SearchPerformed { get; set; } = false; // Kiểm tra nếu người dùng đã thực hiện tìm kiếm

        public void OnGet(string query)
        {
            Query = query;
            SearchPerformed = !string.IsNullOrEmpty(Query);

            if (SearchPerformed)
            {
                // Dữ liệu giả lập cho tìm kiếm
                var allItems = new List<string>
                {
                    "Cuộc thi Cá Koi Đẹp 2023",
                    "Koi Show Quốc tế",
                    "Giải thi đấu Koi Việt Nam",
                    "Sự kiện Koi Show Nhật Bản"
                };

                // Tìm kiếm từ khóa trong danh sách cuộc thi
                Results = allItems.Where(item => item.Contains(Query)).ToList();
            }
            else
            {
                Results = new List<string>(); // Trả về danh sách rỗng nếu không có từ khóa
            }
        }
    }
}
