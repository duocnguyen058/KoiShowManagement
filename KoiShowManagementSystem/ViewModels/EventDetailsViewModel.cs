namespace KoiShowManagementSystem.ViewModels
{
    // Lớp EventDetailsViewModel đại diện cho thông tin chi tiết của một sự kiện
    public class EventDetailsViewModel
    {
        // Thuộc tính EventDetail chứa thông tin chi tiết về sự kiện
        public Events EventDetail { get; set; }

        // Thuộc tính CanRegister xác định xem người dùng có thể đăng ký tham gia sự kiện hay không
        public bool CanRegister { get; set; }

        // Thuộc tính IsRegistered xác định xem người dùng đã đăng ký tham gia sự kiện hay chưa
        public bool IsRegistered { get; set; }

        // Thuộc tính RankedKoiList chứa danh sách các Koi đã được xếp hạng trong sự kiện
        public List<RankedKoiViewModel> RankedKoiList { get; set; }
    }
}
