namespace KoiShowManagementSystem.Controllers
{
    public class JudgeAssignmentsController : Controller
    {
        private readonly IUserService _userService; // Dịch vụ để xử lý thông tin người dùng
        private readonly IJudgeAssignmentsService _judgeAssignmentsService; // Dịch vụ để xử lý việc phân công giám khảo
        private readonly IEventsService _eventsService; // Dịch vụ để xử lý thông tin sự kiện
        private readonly ILogger<JudgeAssignmentsController> _logger; // Công cụ ghi log để theo dõi và xử lý lỗi

        // Constructor nhận các dịch vụ cần thiết từ Dependency Injection
        public JudgeAssignmentsController(IUserService userService, IJudgeAssignmentsService judgeAssignmentsService, IEventsService eventsService, ILogger<JudgeAssignmentsController> logger)
        {
            _userService = userService;
            _judgeAssignmentsService = judgeAssignmentsService;
            _eventsService = eventsService;
            _logger = logger;
        }

        // GET: /JudgeAssignments/
        // Trang hiển thị danh sách giám khảo và số lượng sự kiện đã được phân công
        public IActionResult Index()
        {
            // Lấy danh sách giám khảo có vai trò "REFEREE"
            var referees = _userService.GetUsersByRole("REFEREE");

            // Duyệt qua từng giám khảo và tính số sự kiện mà giám khảo đó đã được phân công
            var refereeAssignments = referees.Select(referee => new RefereeViewModel
            {
                UserId = referee.Id,
                UserName = referee.Username,
                AssignedEventCount = _judgeAssignmentsService.GetEventsByJudge(referee.Id).Count() // Đếm số lượng sự kiện
            }).ToList();

            return View(refereeAssignments); // Trả về view cùng dữ liệu
        }

        // GET: /JudgeAssignments/AssignJudge
        // Hiển thị giao diện phân công giám khảo cho sự kiện
        [Route("JudgeAssignments/AssignJudge")]
        public IActionResult AssignJudge(int userId)
        {
            try
            {
                // Kiểm tra xem giám khảo có tồn tại không
                var user = _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound("Giám khảo không tồn tại"); // Trả về lỗi nếu không tìm thấy giám khảo
                }

                // Lấy danh sách các sự kiện chưa bắt đầu hoặc đang diễn ra
                var upcomingEvents = _eventsService.GetAllEvents()
                    .Where(e => e.Status == "Chưa bắt đầu" || e.Status == "Đang diễn ra")
                    .ToList();

                // Nếu không có sự kiện nào phù hợp, trả về thông báo lỗi
                if (!upcomingEvents.Any())
                {
                    return NotFound("Không có sự kiện nào sắp diễn ra hoặc đang diễn ra.");
                }

                // Chuẩn bị dữ liệu cho giao diện phân công
                var assignViewModel = new AssignJudgeViewModel
                {
                    UserId = userId,
                    Events = upcomingEvents,
                };

                return PartialView("_AssignJudgeModal", assignViewModel); // Trả về modal hiển thị giao diện phân công
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi vào log và trả về lỗi cho người dùng
                _logger.LogError(ex, "Error loading assign judge modal for user {UserId}.", userId);
                return StatusCode(500, "Đã xảy ra lỗi khi tải modal phân công.");
            }
        }

        // POST: /JudgeAssignments/AssignJudge
        // Xử lý việc phân công hoặc hủy phân công giám khảo cho sự kiện
        [HttpPost]
        [Route("JudgeAssignments/AssignJudge")]
        public IActionResult AssignJudge(AssignJudgeViewModel model, string action)
        {
            if (model.SelectedEventIds != null && model.SelectedEventIds.Any()) // Kiểm tra nếu người dùng đã chọn sự kiện
            {
                foreach (var eventId in model.SelectedEventIds)
                {
                    string message = string.Empty;

                    if (action == "Assign") // Nếu hành động là phân công
                    {
                        message = _judgeAssignmentsService.AssignJudgeToEvent(eventId, model.UserId);
                    }
                    else if (action == "Unassign") // Nếu hành động là hủy phân công
                    {
                        message = _judgeAssignmentsService.RemoveJudgeFromEvent(eventId, model.UserId);
                    }

                    // Kiểm tra thông báo lỗi hoặc cảnh báo
                    if (message.Contains("Giám khảo đã được phân công") || message.Contains("Giám khảo chưa được phân công"))
                    {
                        TempData["ErrorMessage"] = message; // Lưu thông báo lỗi vào TempData
                        return RedirectToAction("Index"); // Quay lại trang danh sách
                    }
                }
            }

            // Lưu thông báo thành công vào TempData
            TempData["SuccessMessage"] = (action == "Assign") ? "Phân công giám khảo thành công." : "Hủy phân công giám khảo thành công.";
            return RedirectToAction("Index"); // Quay lại trang danh sách
        }
    }
}
