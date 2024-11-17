namespace KoiShowManagementSystem.Models
{
    // Lớp ErrorViewModel đại diện cho thông tin lỗi cần hiển thị
    public class ErrorViewModel
    {
        // Thuộc tính RequestId lưu trữ mã định danh của yêu cầu (request), có thể null
        public string? RequestId { get; set; }

        // Thuộc tính ShowRequestId xác định xem có hiển thị RequestId hay không
        // Giá trị trả về là true nếu RequestId không rỗng hoặc null
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
