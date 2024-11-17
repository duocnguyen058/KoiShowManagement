namespace KoiShowManagementSystem.ViewModels
{
    // Lớp RankedKoiViewModel đại diện cho thông tin của một chú cá Koi đã được xếp hạng
    public class RankedKoiViewModel
    {
        // Thuộc tính KoiName lưu tên của chú cá Koi
        public string KoiName { get; set; }

        // Thuộc tính Category lưu loại danh mục mà cá Koi tham gia
        public string Category { get; set; }

        // Thuộc tính Score lưu điểm số mà cá Koi đạt được
        public float Score { get; set; }
    }
}
