namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository quản lý phân công giám khảo.
    public interface IJudgeAssignmentsRepository : IRepository<JudgeAssignments>
    {
        // Phương thức lấy danh sách các giám khảo được phân công trong sự kiện theo eventId.
        List<JudgeAssignments> GetJudgesByEvent(int eventId);
    }

    // Repository triển khai các phương thức đã định nghĩa trong IJudgeAssignmentsRepository.
    public class JudgeAssignmentsRepository : RepositoryBase<JudgeAssignments>, IJudgeAssignmentsRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public JudgeAssignmentsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        // Phương thức trả về danh sách các giám khảo phân công cho một sự kiện theo eventId.
        public List<JudgeAssignments> GetJudgesByEvent(int eventId)
        {
            // Truy vấn các giám khảo được phân công cho sự kiện có `EventsId` khớp với `eventId`.
            return _dbContext.JudgeAssignments.Where(j => j.EventsId == eventId).ToList();
        }
    }
}
