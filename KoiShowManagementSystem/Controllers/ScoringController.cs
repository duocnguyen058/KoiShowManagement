namespace KoiShowManagementSystem.Controllers
{
    public class ScoringController : Controller
    {
        // Các service sử dụng trong controller
        private readonly IScoresService _scoresService; // Xử lý logic liên quan đến điểm số
        private readonly IUserService _userService; // Xử lý thông tin người dùng
        private readonly IKoiService _koiService; // Quản lý thông tin cá Koi
        private readonly IEventKoiParticipationService _eventKoiParticipationService; // Quản lý thông tin tham gia của cá Koi trong sự kiện
        private readonly IJudgeAssignmentsService _judgeAssignmentsService; // Quản lý các sự kiện được gán cho giám khảo

        // Constructor: Inject các service cần thiết thông qua Dependency Injection
        public ScoringController(
            IScoresService scoresService,
            IUserService userService,
            IEventKoiParticipationService eventKoiParticipationService,
            IJudgeAssignmentsService judgeAssignmentsService,
            IKoiService koiService)
        {
            _scoresService = scoresService;
            _userService = userService;
            _eventKoiParticipationService = eventKoiParticipationService;
            _judgeAssignmentsService = judgeAssignmentsService;
            _koiService = koiService;
        }

        // Phương thức hiển thị danh sách các sự kiện mà giám khảo hiện tại được gán
        public async Task<IActionResult> Index()
        {
            // Lấy ID của người dùng hiện tại từ Claim
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Lấy danh sách sự kiện của giám khảo
            var judgeAssignments = _judgeAssignmentsService.GetEventsByJudgeId(currentUserId);

            return View(judgeAssignments); // Trả về danh sách sự kiện
        }

        // Phương thức hiển thị thông tin các cá Koi tham gia sự kiện để chấm điểm
        public IActionResult ScoreEvent(int eventId)
        {
            // Lấy danh sách các tham gia (Event_Koi_Participation) dựa trên eventId
            var eventKoiParticipations = _eventKoiParticipationService.GetKoiByEventId(eventId);

            // Lấy danh sách các KoiId từ các tham gia
            var koiIds = eventKoiParticipations.Select(ep => ep.KoiId).ToList();

            // Lấy thông tin chi tiết của các cá Koi
            var koiDetails = _koiService.GetAllKoi().Where(k => koiIds.Contains(k.Id)).ToList();

            // Tạo danh sách ViewModel để hiển thị thông tin cá Koi trong sự kiện
            var viewModel = eventKoiParticipations.Select(ep => new ScoreEventViewModel
            {
                ParticipationId = ep.Id, // ID tham gia
                KoiName = koiDetails.FirstOrDefault(k => k.Id == ep.KoiId)?.Name ?? "Không rõ", // Tên cá Koi
                Category = ep.Category, // Danh mục thi đấu
                CurrentScore = ep.Score, // Điểm hiện tại
                PhotoPath = koiDetails.FirstOrDefault(k => k.Id == ep.KoiId)?.PhotoPath ?? "Không có ảnh" // Đường dẫn ảnh
            }).ToList();

            return View(viewModel); // Trả về view với danh sách thông tin cá Koi
        }

        // Phương thức xử lý chấm điểm (Submit Score) cho một cá Koi trong sự kiện
        [HttpPost]
        public async Task<IActionResult> SubmitScore(int eventKoiParticipationId, float shapeScore, float colorScore, float patternScore)
        {
            // Lấy ID của người dùng hiện tại từ Claim
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Lấy thông tin người dùng hiện tại
            var currentUser = await _userService.GetUserById(currentUserId);

            // Kiểm tra nếu người dùng không tồn tại
            if (currentUser == null)
            {
                TempData["Error"] = "Người dùng không tồn tại."; // Lưu thông báo lỗi tạm thời
                return RedirectToAction("Index"); // Chuyển hướng về danh sách sự kiện
            }

            try
            {
                // Thêm điểm mới cho cá Koi
                _scoresService.AddScore(eventKoiParticipationId, currentUser.Id, shapeScore, colorScore, patternScore);

                // Trả về kết quả thành công dưới dạng JSON
                return Json(new { success = true, message = "Lưu điểm thành công!" });
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message; // Lưu thông báo lỗi tạm thời
            }

            return RedirectToAction("Index"); // Quay lại trang danh sách sự kiện
        }
    }
}
