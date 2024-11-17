namespace KoiShowManagementSystem.ViewModels
{
    // Lớp ScoreEventViewModel đại diện cho thông tin của một lượt chấm điểm trong sự kiện
    public class ScoreEventViewModel
    {
        // Thuộc tính ParticipationId lưu mã định danh của lượt tham gia sự kiện
        public int ParticipationId { get; set; }

        // Thuộc tính KoiName lưu tên của chú cá Koi
        public string KoiName { get; set; }

        // Thuộc tính Category lưu loại danh mục mà cá Koi tham gia
        public string Category { get; set; }

        // Thuộc tính CurrentScore lưu điểm số hiện tại của cá Koi
        public float CurrentScore { get; set; }

        // Thuộc tính PhotoPath lưu đường dẫn tới ảnh của cá Koi (có thể null)
        public string? PhotoPath { get; set; }
    }
}
