using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository liên quan đến sự kiện và tham gia Koi.
    public interface IEventKoiParticipationRepository : IRepository<Event_Koi_Participation>
    {
        // Phương thức lấy danh sách các người tham gia (Koi) trong sự kiện.
        List<Event_Koi_Participation> GetParticipantsByEvent(int eventId);

        // Phương thức lấy thông tin tham gia sự kiện của Koi, bao gồm thông tin về Koi.
        IEnumerable<Event_Koi_Participation> GetEventKoiParticipations(int eventId);
    }

    // Repository triển khai các phương thức đã định nghĩa trong IEventKoiParticipationRepository.
    public class EventKoiParticipationRepository : RepositoryBase<Event_Koi_Participation>, IEventKoiParticipationRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public EventKoiParticipationRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        // Phương thức trả về danh sách các tham gia Koi trong sự kiện theo eventId.
        public List<Event_Koi_Participation> GetParticipantsByEvent(int eventId)
        {
            // Truy vấn các tham gia sự kiện có `EventsId` khớp với `eventId` và trả về danh sách.
            return _dbContext.Event_Koi_Participations.Where(p => p.EventsId == eventId).ToList();
        }

        // Phương thức trả về danh sách tham gia sự kiện của Koi, bao gồm thông tin về Koi.
        public IEnumerable<Event_Koi_Participation> GetEventKoiParticipations(int eventId)
        {
            // Truy vấn các tham gia sự kiện có `EventsId` khớp với `eventId`, và bao gồm thông tin về Koi.
            return _dbContext.Event_Koi_Participations
                           .Where(ep => ep.EventsId == eventId)
                           .Include(ep => ep.Kois) // Bao gồm thông tin về Koi.
                           .ToList();
        }
    }
}
