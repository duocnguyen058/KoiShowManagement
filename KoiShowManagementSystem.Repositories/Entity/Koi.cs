namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho đối tượng Koi trong hệ thống.
    public class Koi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của Koi, tự động tăng.

        public int UsersId { get; set; } // ID của người sở hữu Koi (liên kết với bảng Users).
        public string Name { get; set; } // Tên của Koi.

        [Column(TypeName = "nvarchar(100)")]
        public string Variety { get; set; } // Giống của Koi (ví dụ: Koi Nhật, Koi Việt,...).

        public float Size { get; set; } // Kích thước của Koi (tính bằng cm hoặc inch).

        public int Age { get; set; } // Tuổi của Koi.

        [Column(TypeName = "nvarchar(100)")]
        public string RegistrationStatus { get; set; } // Trạng thái đăng ký (ví dụ: Đã đăng ký, Chưa đăng ký,...).

        public Users? Users { get; set; } // Tham chiếu đến đối tượng `Users` (người sở hữu Koi).

        public string? PhotoPath { get; set; } // Đường dẫn đến ảnh của Koi (nếu có).
    }
}
