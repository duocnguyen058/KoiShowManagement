namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho việc phân công giám khảo cho một sự kiện.
    public class JudgeAssignments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của phân công giám khảo, tự động tăng.

        public int UsersId { get; set; } // ID của giám khảo (tương ứng với bảng Users).
        public Users? Users { get; set; } // Giám khảo (quan hệ với bảng Users).

        public int EventsId { get; set; } // ID của sự kiện mà giám khảo được phân công.
        public Events? Events { get; set; } // Sự kiện (quan hệ với bảng Events).
    }
}
