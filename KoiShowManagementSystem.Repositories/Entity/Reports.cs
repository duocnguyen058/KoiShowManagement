namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho các báo cáo liên quan đến sự kiện.
    public class Reports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của báo cáo, tự động tăng.

        public int EventsId { get; set; } // ID của sự kiện liên quan đến báo cáo.
        public Events Events { get; set; } // Quan hệ với đối tượng Events, thể hiện sự kiện mà báo cáo thuộc về.

        [Column(TypeName = "nvarchar(100)")]
        public string ReportType { get; set; } // Loại báo cáo (ví dụ: Báo cáo kết quả, Báo cáo thống kê,...).

        [Column(TypeName = "nvarchar(100)")]
        public string ReportData { get; set; } // Dữ liệu báo cáo, thông tin chi tiết về báo cáo đó.
    }
}
