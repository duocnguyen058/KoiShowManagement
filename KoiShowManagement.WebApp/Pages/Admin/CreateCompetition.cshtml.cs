using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiShowManagement.WebApp.Pages.Admin
{
    public class CreateCompetitionModel : PageModel
    {
        // Thuộc tính để lưu thông tin từ form
        [BindProperty]
        [Required(ErrorMessage = "Tên cuộc thi là bắt buộc.")]
        public string CompetitionName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc.")]
        public string StartDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc.")]
        public string EndDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Địa điểm là bắt buộc.")]
        public string Location { get; set; }

        public string StatusMessage { get; set; }

        // Phương thức OnGet() để xử lý GET request, không cần thực hiện gì ở đây.
        public void OnGet()
        {
        }

        // Phương thức OnPost() để xử lý POST request
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Logic xử lý khi form hợp lệ
                // Ví dụ: Thêm cuộc thi mới vào cơ sở dữ liệu
                // Bạn có thể sử dụng DbContext để lưu thông tin cuộc thi vào cơ sở dữ liệu

                // Giả lập thêm cuộc thi thành công
                StatusMessage = "Cuộc thi đã được tạo thành công!";

                // Sau khi tạo cuộc thi, bạn có thể chuyển hướng tới trang danh sách cuộc thi hoặc trang quản lý cuộc thi.
                return RedirectToPage("/Admin/Competitions"); // Chuyển hướng đến trang danh sách cuộc thi
            }
            else
            {
                StatusMessage = "Vui lòng kiểm tra và điền đầy đủ thông tin hợp lệ.";
            }

            return Page(); // Trả về trang hiện tại để hiển thị thông báo
        }
    }
}
