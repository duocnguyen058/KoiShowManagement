namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository quản lý sự kiện.
    public interface IEventsRepository : IRepository<Events>
    {
        // Phương thức lấy danh sách tất cả các sự kiện.
        List<Events> GetEvents();
    }

    // Repository triển khai các phương thức đã định nghĩa trong IEventsRepository.
    public class EventsRepository : RepositoryBase<Events>, IEventsRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public EventsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Phương thức trả về danh sách tất cả các sự kiện.
        public List<Events> GetEvents()
        {
            // Truy vấn và trả về tất cả các sự kiện trong bảng `Events`.
            return _dbContext.Events.ToList();
        }
    }
}
