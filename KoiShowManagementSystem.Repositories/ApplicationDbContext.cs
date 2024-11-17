namespace KoiShowManagementSystem.Repositories
{
    // Lớp đại diện cho ngữ cảnh cơ sở dữ liệu của ứng dụng, chứa các bảng (DbSet) trong cơ sở dữ liệu.
    public class ApplicationDbContext : DbContext
    {
        // Constructor nhận đối số options để cấu hình kết nối cơ sở dữ liệu.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Các DbSet đại diện cho các bảng trong cơ sở dữ liệu.
        public DbSet<Users> Users { get; set; } // Bảng Users, lưu trữ thông tin người dùng.
        public DbSet<Scores> Scores { get; set; } // Bảng Scores, lưu trữ điểm số của Koi trong sự kiện.
        public DbSet<Reports> Reports { get; set; } // Bảng Reports, lưu trữ thông tin báo cáo của sự kiện.
        public DbSet<Koi> Kois { get; set; } // Bảng Kois, lưu trữ thông tin về Koi.
        public DbSet<JudgeAssignments> JudgeAssignments { get; set; } // Bảng JudgeAssignments, lưu trữ thông tin phân công giám khảo.
        public DbSet<Events> Events { get; set; } // Bảng Events, lưu trữ thông tin sự kiện.
        public DbSet<Event_Koi_Participation> Event_Koi_Participations { get; set; } // Bảng Event_Koi_Participations, lưu trữ thông tin tham gia sự kiện của Koi.
    }
}
