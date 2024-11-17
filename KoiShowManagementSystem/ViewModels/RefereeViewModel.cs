namespace KoiShowManagementSystem.ViewModels
{
    // Lớp RefereeViewModel đại diện cho thông tin của một trọng tài
    public class RefereeViewModel
    {
        // Thuộc tính UserId lưu mã định danh của người dùng (trọng tài)
        public int UserId { get; set; }

        // Thuộc tính UserName lưu tên của trọng tài
        public string UserName { get; set; }

        // Thuộc tính AssignedEventCount lưu số lượng sự kiện mà trọng tài đã được phân công
        public int AssignedEventCount { get; set; }
    }

    // Lớp AssignJudgeViewModel đại diện cho thông tin cần thiết để phân công trọng tài cho các sự kiện
    public class AssignJudgeViewModel
    {
        // Thuộc tính UserId lưu mã định danh của trọng tài được phân công
        public int UserId { get; set; }

        // Thuộc tính Events lưu danh sách các sự kiện sắp diễn ra hoặc đang diễn ra
        public List<Events> Events { get; set; }

        // Thuộc tính SelectedEventIds lưu danh sách mã định danh của các sự kiện được chọn để phân công
        public List<int> SelectedEventIds { get; set; }

        // Thuộc tính AssignedEventIds lưu danh sách mã định danh của các sự kiện đã được phân công cho trọng tài
        public List<int> AssignedEventIds { get; set; }
    }
}
