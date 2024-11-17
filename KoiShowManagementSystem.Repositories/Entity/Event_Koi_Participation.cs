namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho việc tham gia sự kiện của Koi.
    public class Event_Koi_Participation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của bảng, tự động tăng.

        public int EventsId { get; set; } // ID của sự kiện mà Koi tham gia.
        public int KoiId { get; set; } // ID của Koi tham gia sự kiện.

        [Column(TypeName = "nvarchar(100)")]
        public string Category { get; set; } // Hạng mục mà Koi tham gia (ví dụ: kích thước, màu sắc, v.v.).

        public float Score { get; set; } // Điểm số đạt được trong sự kiện.

        public Events Events { get; set; } // Quan hệ với bảng Events.
        public Koi Kois { get; set; } // Quan hệ với bảng Koi.
    }
}
