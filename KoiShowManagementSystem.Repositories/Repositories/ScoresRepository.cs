namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository quản lý điểm số (Scores).
    public interface IScoresRepository : IRepository<Scores>
    {
        // Phương thức lấy danh sách điểm số của một sự kiện theo eventId.
        List<Scores> GetScoresByEvent(int eventId);

        // Phương thức lấy điểm số của cá Koi tham gia sự kiện và giám khảo theo eventKoiId và judgeId.
        Scores GetScoreByEventKoiAndJudge(int eventKoiId, int judgeId);
    }

    // Repository triển khai các phương thức đã định nghĩa trong IScoresRepository.
    public class ScoresRepository : RepositoryBase<Scores>, IScoresRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public ScoresRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        // Phương thức trả về danh sách điểm số của một sự kiện theo eventId.
        public List<Scores> GetScoresByEvent(int eventId)
        {
            // Truy vấn các điểm số của sự kiện có `EventsId` khớp với `eventId`.
            return _dbContext.Scores
                .Include(s => s.Event_Koi_Participations) // Bao gồm thông tin về sự tham gia của Koi.
                .Where(s => s.Event_Koi_Participations.EventsId == eventId)
                .ToList();
        }

        // Phương thức trả về điểm số của cá Koi tham gia sự kiện và giám khảo theo eventKoiId và judgeId.
        public Scores GetScoreByEventKoiAndJudge(int eventKoiId, int judgeId)
        {
            // Truy vấn điểm số của sự tham gia của Koi và giám khảo tương ứng.
            return _dbContext.Scores
                .FirstOrDefault(s => s.Event_Koi_ParticipationId == eventKoiId && s.UsersId == judgeId);
        }
    }
}
