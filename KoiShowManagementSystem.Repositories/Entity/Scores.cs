namespace KoiShowManagementSystem.Repositories.Entity
{
    // Lớp đại diện cho điểm số của Koi trong một sự kiện.
    public class Scores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // ID của điểm số, tự động tăng.

        public int Event_Koi_ParticipationId { get; set; } // Khóa ngoại liên kết với bảng `Event_Koi_Participation`.
        public Event_Koi_Participation Event_Koi_Participations { get; set; } // Tham chiếu đến đối tượng `Event_Koi_Participation`.

        public int UsersId { get; set; } // Khóa ngoại liên kết với bảng `Users`, đại diện cho giám khảo chấm điểm.
        public Users Users { get; set; } // Tham chiếu đến đối tượng `Users` (giám khảo).

        public float ShapeScore { get; set; } // Điểm về hình dạng của Koi (chiếm 50% tổng điểm).
        public float ColorScore { get; set; } // Điểm về màu sắc của Koi (chiếm 30% tổng điểm).
        public float PatternScore { get; set; } // Điểm về họa tiết của Koi (chiếm 20% tổng điểm).

        public float TotalScore { get; set; } // Tổng điểm của Koi, được tính từ các điểm thành phần.
    }
}
