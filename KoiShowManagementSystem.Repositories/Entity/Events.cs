namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho các sự kiện trong hệ thống Koi Show.
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của sự kiện, tự động tăng.

        [Required(ErrorMessage = "Vui lòng nhập tên sự kiện")]
        [Column(TypeName = "nvarchar(max)")]
        public string EventName { get; set; } // Tên của sự kiện.

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        public DateTime StartDate { get; set; } // Ngày bắt đầu của sự kiện.

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        public DateTime EndDate { get; set; } // Ngày kết thúc của sự kiện.

        [Required(ErrorMessage = "Vui lòng nhập địa điểm")]
        [Column(TypeName = "nvarchar(max)")]
        public string Location { get; set; } // Địa điểm tổ chức sự kiện.

        [Required(ErrorMessage = "Vui lòng nhập miêu tả")]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } // Miêu tả chi tiết về sự kiện.

        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; } = "Upcoming"; // Trạng thái sự kiện (ví dụ: Upcoming, Ongoing, Finished).
    }
}
