namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho người dùng trong hệ thống.
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của người dùng, tự động tăng.

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [StringLength(100, ErrorMessage = "Tên đăng nhập không được vượt quá 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; } // Tên đăng nhập của người dùng.

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; } // Mật khẩu của người dùng.

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } // Địa chỉ email của người dùng.

        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; } // Vai trò của người dùng (ví dụ: Giám khảo, Admin, Người sở hữu Koi,...).
    }
}
