using KoiShowManagement.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Referee
{
    public class ScoreKoiModel : PageModel
    {
        private ScoreKoi score;

        // Thuộc tính để lưu điểm số của cá koi
        public ScoreKoi GetScore()
        {
            return score;
        }

        // Thuộc tính để lưu điểm số của cá koi
        public void SetScore(ScoreKoi value)
        {
            score = value ?? throw new ArgumentNullException(nameof(value));
        }

        // Dữ liệu này sẽ được sử dụng để hiển thị các điểm số trên trang
        public string Message { get; set; }
        public ScoreKoi Score { get => score; set => score = value; }

        // Phương thức này sẽ được gọi khi người dùng truy cập trang qua phương thức GET
        public void OnGet()
        {
            // Giả sử bạn muốn lấy một điểm số mặc định hoặc dữ liệu từ cơ sở dữ liệu
            SetScore(new ScoreKoi
            {
                FishId = 1,
                ScoreValue = 85,
                JudgeName = "Trọng Tài A"
            });

            Message = "Thông tin điểm số cá koi:";
        }

        // Phương thức này sẽ được gọi khi người dùng gửi dữ liệu từ form (POST)
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Xử lý điểm số cá koi (lưu vào cơ sở dữ liệu, v.v...)
                Message = $"Điểm số của cá koi {GetScore().FishId} đã được lưu thành công!";
                return Page();
            }

            // Nếu có lỗi, giữ lại form và hiển thị thông báo lỗi
            Message = "Đã xảy ra lỗi khi lưu điểm số!";
            return Page();
        }
    }
}
