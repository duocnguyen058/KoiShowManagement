using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Formats.Asn1.AsnWriter;

namespace KoiShowManagementSystem.Services.Services
{
    public interface IEventsService //Các phương thức cần thiết để quản lý sự kiện trong hệ thống (tạo, cập nhật, xóa, tìm kiếm sự kiện, và các chức năng liên quan).

    {
        List<Events> GetAllEvents(); //Lấy danh sách tất cả các sự kiện.
        Events GetEventById(int eventId); //Lấy thông tin chi tiết của một sự kiện theo ID.
        void CreateEvent(Events events); //Tạo một sự kiện mới.
        void UpdateEvent(Events events); //Cập nhật thông tin sự kiện.
        void DeleteEvent(int eventId); //Xóa một sự kiện theo ID.
        void RegisterKoiToEvent(int eventId, int koiId); //Đăng ký một cá koi tham gia sự kiện.
        List<Events> SearchEvents(string keyword); //Tìm kiếm các sự kiện theo từ khóa (tên hoặc mô tả sự kiện).
        List<Koi> GetUserKoi(int userId); // Lấy danh sách các cá koi của người dùng.
        bool CanRegisterToEvent(int eventId); // Phương thức để kiểm tra trạng thái sự kiện
        bool IsUserRegisteredToEvent(int eventId, int userId); // Kiểm tra người dùng đã đăng ký chưa
        List<Event_Koi_Participation> GetParticipantsByEvent(int eventId);
        List<Scores> GetScoresByEvent(int eventId); //Lấy danh sách các cá koi tham gia sự kiện.
        List<JudgeAssignments> GetJudgesByEvent(int eventId); //Lấy danh sách điểm số của các cá koi trong sự kiện.
        IEnumerable<Event_Koi_Participation> GetEventKoiParticipations(int eventId); //Lấy thông tin tham gia của cá koi trong sự kiện.
    }
    public class EventsService : IEventsService //Chịu trách nhiệm xử lý các logic nghiệp vụ liên quan đến sự kiện và cá koi tham gia.
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IKoiRepository _koiRepository;
        private readonly IEventKoiParticipationRepository _eventKoiParticipationRepository;
        private readonly IScoresRepository _scoresRepository;
        private readonly IJudgeAssignmentsRepository _judgeAssignmentsRepository;

        public EventsService(
            IEventsRepository eventsRepository,
            IKoiRepository koiRepository,
            IEventKoiParticipationRepository eventKoiParticipationRepository,
            IScoresRepository scoresRepository,
            IJudgeAssignmentsRepository judgeAssignmentsRepository)
        {
            _eventsRepository = eventsRepository;
            _koiRepository = koiRepository;
            _eventKoiParticipationRepository = eventKoiParticipationRepository;
            _scoresRepository = scoresRepository;
            _judgeAssignmentsRepository = judgeAssignmentsRepository;
        }
        public List<Koi> GetUserKoi(int userId) //Lấy danh sách cá koi của người dùng
        {
            return _koiRepository.GetAllKoi().Where(k => k.UsersId == userId).ToList(); //Truy vấn tất cả cá koi và lọc ra các cá koi của người dùng có ID tương ứng.
        }
        public bool CanRegisterToEvent(int eventId) //Kiểm tra trạng thái sự kiện để quyết định người dùng có thể đăng ký hay không.
        {
            var eventDetails = _eventsRepository.GetById(eventId);
            return eventDetails.Status == "Chưa bắt đầu" || eventDetails.Status == "Đang diễn ra";
        }
        //Lấy tất cả các sự kiện từ repository.
        public List<Events> GetAllEvents() 
        {
            return _eventsRepository.GetEvents(); //Trả về danh sách các sự kiện.
        }
        //Lấy thông tin chi tiết của một sự kiện.
        public Events GetEventById(int eventId)
        {
            return _eventsRepository.GetById(eventId); //Trả về sự kiện từ repository.
        }
        //Tạo một sự kiện mới.
        public void CreateEvent(Events events)
        {
            _eventsRepository.Add(events); //Thêm sự kiện vào cơ sở dữ liệu thông qua repository.
        }
        //Cập nhật thông tin sự kiện.
        public void UpdateEvent(Events events)
        {
            _eventsRepository.Update(events); //Cập nhật sự kiện trong cơ sở dữ liệu.
        }
        //Xóa một sự kiện.
        public void DeleteEvent(int eventId)
        {
            var eventToDelete = _eventsRepository.GetById(eventId);
            if (eventToDelete != null)
            {
                _eventsRepository.Delete(eventToDelete);
            }
        }
        //Đăng ký một cá koi tham gia sự kiện.
        public void RegisterKoiToEvent(int eventId, int koiId)
        {
            // Lấy thông tin cá Koi từ ID
            var koi = _koiRepository.GetById(koiId);
            if (koi == null)
            {
                throw new ArgumentException("Cá Koi không tồn tại.");
            }

            // Tự động xác định hạng mục thi đấu dựa trên Size và Age
            string category;
            if (koi.Size >= 25)
            {
                category = "Grand Champion";
            }
            else if (koi.Age >= 5)
            {
                category = "Mature Champion";
            }
            else
            {
                category = "Sakuru Champion";
            }

            // Tạo mới một bản ghi tham gia sự kiện với hạng mục đã xác định
            var participation = new Event_Koi_Participation
            {
                EventsId = eventId,
                KoiId = koiId,
                Category = category,
                Score = 0
            };

            // Lưu vào cơ sở dữ liệu
            _eventKoiParticipationRepository.Add(participation);
        }
        public List<Events> SearchEvents(string keyword) //Tìm kiếm các sự kiện theo từ khóa.
        {
            return _eventsRepository.GetEvents()
                .Where(e => e.EventName.Contains(keyword) || e.Description.Contains(keyword))
                .ToList();
        }
        public bool IsUserRegisteredToEvent(int eventId, int userId) //Kiểm tra xem người dùng đã đăng ký tham gia sự kiện chưa.
        {
            var userKoiList = _koiRepository.GetAllKoi().Where(k => k.UsersId == userId).Select(k => k.Id).ToList();
            return _eventKoiParticipationRepository.GetParticipantsByEvent(eventId)
                                                   .Any(p => userKoiList.Contains(p.KoiId));
        }
        public List<Event_Koi_Participation> GetParticipantsByEvent(int eventId) //Lấy danh sách các cá koi tham gia sự kiện từ repository.
        {
            return _eventKoiParticipationRepository.GetParticipantsByEvent(eventId);
        }
        public List<Scores> GetScoresByEvent(int eventId) //Lấy danh sách điểm số của các cá koi tham gia sự kiện.
        {
            return _scoresRepository.GetScoresByEvent(eventId);
        }
        public List<JudgeAssignments> GetJudgesByEvent(int eventId) //Lấy danh sách giám khảo tham gia vào sự kiện.
        {
            return _judgeAssignmentsRepository.GetJudgesByEvent(eventId);
        }
        public IEnumerable<Event_Koi_Participation> GetEventKoiParticipations(int eventId) //Lấy thông tin tham gia của các cá koi trong sự kiện.
        {
            return _eventKoiParticipationRepository.GetEventKoiParticipations(eventId);
        }
    }
}
