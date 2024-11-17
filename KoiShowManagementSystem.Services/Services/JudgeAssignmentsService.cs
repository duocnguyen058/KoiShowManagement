using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace KoiShowManagementSystem.Services.Services
{
    // Interface định nghĩa các phương thức cần có trong dịch vụ phân công giám khảo
    public interface IJudgeAssignmentsService
    {
        string AssignJudgeToEvent(int eventId, int judgeId); // Phân công giám khảo cho sự kiện
        bool IsJudgeAssignedToEvent(int eventId, int judgeId); // Kiểm tra giám khảo đã được phân công cho sự kiện chưa
        List<Events> GetEventsByJudge(int judgeId); // Lấy danh sách sự kiện mà giám khảo đã tham gia
        List<JudgeAssignments> GetEventsByJudgeId(int judgeId); // Lấy danh sách phân công giám khảo
        string RemoveJudgeFromEvent(int eventId, int judgeId); // Hủy phân công giám khảo khỏi sự kiện
    }

    // Lớp thực thi các phương thức trong interface
    public class JudgeAssignmentsService : IJudgeAssignmentsService
    {
        private readonly IJudgeAssignmentsRepository _judgeAssignmentsRepository; // Repository để tương tác với cơ sở dữ liệu
        private readonly ApplicationDbContext _context; // DbContext để truy cập cơ sở dữ liệu

        // Constructor nhận vào repository và dbContext để khởi tạo dịch vụ
        public JudgeAssignmentsService(IJudgeAssignmentsRepository judgeAssignmentsRepository, ApplicationDbContext context)
        {
            _judgeAssignmentsRepository = judgeAssignmentsRepository;
            _context = context;
        }

        // Phương thức phân công giám khảo cho sự kiện
        public string AssignJudgeToEvent(int eventId, int judgeId)
        {
            // Kiểm tra xem giám khảo đã được phân công cho sự kiện chưa
            var existingAssignment = _context.JudgeAssignments
                                              .FirstOrDefault(j => j.EventsId == eventId && j.UsersId == judgeId);

            if (existingAssignment != null)
            {
                // Giám khảo đã được phân công, trả về thông báo
                return $"Giám khảo đã được phân công cho sự kiện {eventId}.";
            }

            // Thêm phân công giám khảo cho sự kiện
            var assignment = new JudgeAssignments
            {
                EventsId = eventId,
                UsersId = judgeId
            };

            _context.JudgeAssignments.Add(assignment); // Thêm vào DbContext
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

            return "Phân công giám khảo thành công."; // Trả về thông báo thành công
        }

        // Kiểm tra xem giám khảo đã được phân công cho sự kiện chưa
        public bool IsJudgeAssignedToEvent(int eventId, int judgeId)
        {
            return _context.JudgeAssignments
                           .Any(j => j.EventsId == eventId && j.UsersId == judgeId); // Trả về true nếu có phân công
        }

        // Lấy danh sách sự kiện mà giám khảo đã tham gia
        public List<Events> GetEventsByJudge(int judgeId)
        {
            return _context.JudgeAssignments
                           .Where(ja => ja.UsersId == judgeId) // Lọc theo giám khảo
                           .Select(ja => ja.Events) // Chọn sự kiện liên quan
                           .ToList(); // Chuyển đổi thành danh sách
        }

        // Lấy danh sách phân công giám khảo
        public List<JudgeAssignments> GetEventsByJudgeId(int judgeId)
        {
            return _context.JudgeAssignments
                           .Where(ja => ja.UsersId == judgeId) // Lọc theo giám khảo
                           .Include(ja => ja.Events) // Bao gồm thông tin sự kiện
                           .ToList(); // Chuyển thành danh sách
        }

        // Phương thức hủy phân công giám khảo khỏi sự kiện
        public string RemoveJudgeFromEvent(int eventId, int judgeId)
        {
            // Kiểm tra xem giám khảo đã được phân công cho sự kiện chưa
            var assignment = _context.JudgeAssignments
                                      .FirstOrDefault(ja => ja.EventsId == eventId && ja.UsersId == judgeId);

            // Nếu không tìm thấy phân công nào, trả về thông báo không có phân công
            if (assignment == null)
            {
                return $"Giám khảo chưa được phân công cho sự kiện {eventId}.";
            }

            // Xóa phân công giám khảo khỏi sự kiện
            _context.JudgeAssignments.Remove(assignment); // Xóa khỏi DbContext

            // Lưu thay đổi và kiểm tra số lượng thay đổi
            int changes = _context.SaveChanges();

            // Nếu có thay đổi, trả về thông báo thành công
            if (changes > 0)
            {
                return "Hủy phân công giám khảo thành công.";
            }
            else
            {
                // Nếu không có thay đổi, trả về thông báo không có thay đổi
                return "Không có thay đổi nào được thực hiện.";
            }
        }
    }
}
