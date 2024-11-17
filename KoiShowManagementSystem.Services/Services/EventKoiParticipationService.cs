namespace KoiShowManagementSystem.Services.Services
{
    public interface IEventKoiParticipationService //Định nghĩa các phương thức cần thiết để quản lý sự tham gia của cá koi vào sự kiện.
    {
        void RegisterKoiToEvent(int eventId, int koiId); //Định nghĩa phương thức để đăng ký cá koi vào sự kiện.
        void AssignCategoryToKoi(int eventKoiId, string category); //Định nghĩa phương thức để gán danh mục giải thưởng cho cá koi tham gia sự kiện.
        List<Event_Koi_Participation> GetParticipantsByEvent(int eventId); //Định nghĩa phương thức để lấy danh sách các cá koi tham gia một sự kiện cụ thể.
        List<Event_Koi_Participation> GetKoiByEventId(int eventId); //Định nghĩa phương thức để lấy danh sách tất cả cá koi tham gia vào sự kiện theo ID của sự kiện.
    }

    public class EventKoiParticipationService : IEventKoiParticipationService // Lớp xử lý các logic nghiệp vụ liên quan đến việc quản lý cá koi tham gia sự kiện.
    {
        private readonly IEventKoiParticipationRepository _eventKoiParticipationRepository; //Biến để truy cập các phương thức của repository liên quan đến sự tham gia của cá koi.
        private readonly ApplicationDbContext _dbcontext; //Biến lưu trữ đối tượng, dùng để truy xuất cơ sở dữ liệu.

        public EventKoiParticipationService(IEventKoiParticipationRepository eventKoiParticipationRepository, ApplicationDbContext dbcontext)
        {
            _eventKoiParticipationRepository = eventKoiParticipationRepository;
            _dbcontext = dbcontext;
        }

        public void RegisterKoiToEvent(int eventId, int koiId) //Phương thức này đăng ký một cá koi vào một sự kiện.
        {
            var participation = new Event_Koi_Participation
            {
                EventsId = eventId,
                KoiId = koiId,
                Category = null // Chưa phân hạng lúc đăng ký
            };
            _eventKoiParticipationRepository.Add(participation);
        }

        public void AssignCategoryToKoi(int eventKoiId, string category) //Phương thức này gán danh mục giải thưởng cho một cá koi đã tham gia sự kiện.
        {
            var participation = _eventKoiParticipationRepository.GetById(eventKoiId); //Lấy thông tin tham gia của cá koi từ repository bằng ID 
            if (participation != null)
            {
                participation.Category = category;
                _eventKoiParticipationRepository.Update(participation);
            }
        }

        public List<Event_Koi_Participation> GetParticipantsByEvent(int eventId) //Phương thức này lấy danh sách các cá koi tham gia vào một sự kiện cụ thể.
        {
            return _eventKoiParticipationRepository.GetParticipantsByEvent(eventId);
        }

        public List<Event_Koi_Participation> GetKoiByEventId(int eventId) //Phương thức này lấy danh sách tất cả các cá koi tham gia vào sự kiện theo ID của sự kiện.
        {
            return _dbcontext.Event_Koi_Participations
                           .Where(ep => ep.EventsId == eventId)
                           .ToList();
        }
    }
}
