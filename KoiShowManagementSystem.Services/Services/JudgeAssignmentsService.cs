using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace KoiShowManagementSystem.Services.Services
{
    public interface IJudgeAssignmentsService
    {
        string AssignJudgeToEvent(int eventId, int judgeId);
        bool IsJudgeAssignedToEvent(int eventId, int judgeId); // Kiểm tra giám khảo đã được phân công chưa
        List<Events> GetEventsByJudge(int judgeId); // Lấy danh sách sự kiện mà giám khảo đã tham gia
        List<JudgeAssignments> GetEventsByJudgeId(int judgeId);
        string RemoveJudgeFromEvent(int eventId, int judgeId); // Hủy phân công giám khảo khỏi sự kiện
    }

    public class JudgeAssignmentsService : IJudgeAssignmentsService
    {
        private readonly IJudgeAssignmentsRepository _judgeAssignmentsRepository;
        private readonly ApplicationDbContext _context;

        public JudgeAssignmentsService(IJudgeAssignmentsRepository judgeAssignmentsRepository, ApplicationDbContext context)
        {
            _judgeAssignmentsRepository = judgeAssignmentsRepository;
            _context = context;
        }

        public string AssignJudgeToEvent(int eventId, int judgeId)
        {
            // Kiểm tra xem giám khảo đã được phân công cho sự kiện chưa
            var existingAssignment = _context.JudgeAssignments
                                              .FirstOrDefault(j => j.EventsId == eventId && j.UsersId == judgeId);

            if (existingAssignment != null)
            {
                return $"Giám khảo đã được phân công cho sự kiện {eventId}.";
            }

            // Thêm phân công giám khảo vào sự kiện
            var assignment = new JudgeAssignments
            {
                EventsId = eventId,
                UsersId = judgeId
            };

            _context.JudgeAssignments.Add(assignment);
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

            return "Phân công giám khảo thành công.";
        }

        public bool IsJudgeAssignedToEvent(int eventId, int judgeId)
        {
            return _context.JudgeAssignments
                           .Any(j => j.EventsId == eventId && j.UsersId == judgeId);
        }

        public List<Events> GetEventsByJudge(int judgeId)
        {
            return _context.JudgeAssignments
                           .Where(ja => ja.UsersId == judgeId)
                           .Select(ja => ja.Events)
                           .ToList();
        }

        public List<JudgeAssignments> GetEventsByJudgeId(int judgeId)
        {
            return _context.JudgeAssignments
                           .Where(ja => ja.UsersId == judgeId)
                           .Include(ja => ja.Events)
                           .ToList();
        }

        // Phương thức để hủy phân công giám khảo khỏi sự kiện
        public string RemoveJudgeFromEvent(int eventId, int judgeId)
        {
            // Kiểm tra xem giám khảo đã được phân công cho sự kiện chưa
            var assignment = _context.JudgeAssignments
                                      .FirstOrDefault(ja => ja.EventsId == eventId && ja.UsersId == judgeId);

            // Nếu không tìm thấy phân công giám khảo cho sự kiện
            if (assignment == null)
            {
                return $"Giám khảo chưa được phân công cho sự kiện {eventId}.";
            }

            // Xóa phân công giám khảo khỏi sự kiện
            _context.JudgeAssignments.Remove(assignment);

            // Lưu thay đổi vào cơ sở dữ liệu và kiểm tra số lượng thay đổi
            int changes = _context.SaveChanges();

            // Kiểm tra xem có thay đổi nào được lưu không
            if (changes > 0)
            {
                return "Hủy phân công giám khảo thành công.";
            }
            else
            {
                return "Không có thay đổi nào được thực hiện.";
            }
        }
    }
}
