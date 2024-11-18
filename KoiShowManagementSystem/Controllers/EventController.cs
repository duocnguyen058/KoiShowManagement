namespace KoiShowManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventsService _eventsService; // Biến sử dụng để gọi các phương thức từ dịch vụ sự kiện

        // Hàm khởi tạo Controller, sử dụng Dependency Injection để nhận IEventsService
        public EventController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        // GET: EventController
        // Trang danh sách sự kiện
        public ActionResult Index()
        {
            var events = _eventsService.GetAllEvents(); // Lấy danh sách tất cả các sự kiện
            return View(events); // Trả về danh sách sự kiện cho View
        }

        // GET: EventController/Details/5
        // Trang chi tiết sự kiện
        public ActionResult Details(int id)
        {
            var eventDetail = _eventsService.GetEventById(id); // Lấy thông tin chi tiết sự kiện theo ID
            if (eventDetail == null) // Kiểm tra sự kiện có tồn tại không
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy
            }

            // Kiểm tra người dùng đã đăng nhập hay chưa
            bool isAuthenticated = User.Identity.IsAuthenticated;
            int? userId = isAuthenticated ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) : (int?)null;

            // Kiểm tra điều kiện đăng ký và trạng thái người dùng
            bool canRegister = _eventsService.CanRegisterToEvent(id); // Xác định sự kiện còn nhận đăng ký
            bool isRegistered = isAuthenticated && _eventsService.IsUserRegisteredToEvent(id, userId.Value); // Kiểm tra người dùng đã đăng ký chưa

            // Lấy danh sách cá Koi đạt giải trong sự kiện
            var koiParticipationList = _eventsService.GetEventKoiParticipations(id);
            var rankedKoiList = koiParticipationList
                .Where(p => new[] { "Grand Champion", "Mature Champion", "Sakuru Champion" }.Contains(p.Category)) // Lọc cá Koi theo danh mục
                .OrderBy(p => p.Category) // Sắp xếp theo danh mục
                .Select(p => new RankedKoiViewModel
                {
                    PhotoPath = p.Kois.PhotoPath, // Ảnh cá Koi
                    KoiName = p.Kois.Name, // Tên cá Koi
                    Category = p.Category, // Danh mục
                    Score = p.Score // Điểm số
                }).ToList();

            // Lấy danh sách cá Koi của người dùng (nếu đã đăng nhập)
            var userKoiList = isAuthenticated ? _eventsService.GetUserKoi(userId.Value) : new List<Koi>();
            ViewBag.UserKoiList = userKoiList;

            // Chuẩn bị dữ liệu cho ViewModel
            var viewModel = new EventDetailsViewModel
            {
                EventDetail = eventDetail,
                CanRegister = isAuthenticated && canRegister && !isRegistered, // Điều kiện để đăng ký
                IsRegistered = isRegistered, // Trạng thái đã đăng ký
                RankedKoiList = rankedKoiList // Danh sách cá Koi đạt giải
            };

            return View(viewModel); // Trả về View cùng với dữ liệu
        }

        // GET: Đăng ký sự kiện (chọn cá Koi)
        [HttpGet]
        public IActionResult Register(int eventId)
        {
            if (!User.Identity.IsAuthenticated) // Kiểm tra người dùng đã đăng nhập chưa
            {
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sự kiện nếu chưa đăng nhập
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); // Lấy ID người dùng từ Claims
            var userKoiList = _eventsService.GetUserKoi(userId); // Lấy danh sách cá Koi của người dùng

            ViewBag.EventId = eventId; // Truyền EventId qua ViewBag
            return View(userKoiList); // Trả về danh sách cá Koi để đăng ký
        }

        // POST: Đăng ký sự kiện với cá Koi
        [HttpPost]
        public IActionResult Register(int eventId, int koiId)
        {
            if (!User.Identity.IsAuthenticated) // Kiểm tra người dùng đã đăng nhập chưa
            {
                return RedirectToAction("Index"); // Chuyển hướng về danh sách sự kiện
            }

            _eventsService.RegisterKoiToEvent(eventId, koiId); // Gọi dịch vụ để đăng ký cá Koi vào sự kiện
            return RedirectToAction("Details", new { id = eventId }); // Quay lại trang chi tiết sự kiện
        }

        // GET: Tạo sự kiện mới
        public ActionResult Create()
        {
            return View(); // Trả về giao diện tạo sự kiện
        }

        // POST: Tạo sự kiện mới
        [HttpPost]
        public ActionResult Create(Events eventModel)
        {
            // Kiểm tra dữ liệu đầu vào
            if (eventModel.StartDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("StartDate", "Ngày bắt đầu phải lớn hơn hoặc bằng ngày hiện tại.");
            }
            if (eventModel.EndDate <= eventModel.StartDate)
            {
                ModelState.AddModelError("EndDate", "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
            }

            if (ModelState.IsValid) // Nếu dữ liệu hợp lệ
            {
                eventModel.Status = DetermineStatus(eventModel.StartDate, eventModel.EndDate); // Xác định trạng thái sự kiện
                _eventsService.CreateEvent(eventModel); // Tạo sự kiện mới
                return RedirectToAction("Index"); // Quay lại danh sách sự kiện
            }

            return View(eventModel); // Nếu lỗi, trả về giao diện cùng thông báo lỗi
        }

        // GET: Chỉnh sửa sự kiện
        public ActionResult Edit(int id)
        {
            var eventModel = _eventsService.GetEventById(id); // Lấy thông tin sự kiện theo ID
            if (eventModel == null) // Nếu không tìm thấy
            {
                return NotFound(); // Trả về lỗi 404
            }
            return View(eventModel); // Trả về giao diện chỉnh sửa sự kiện
        }

        // POST: Cập nhật sự kiện
        [HttpPost]
        public ActionResult Edit(Events eventModel)
        {
            // Kiểm tra dữ liệu đầu vào
            if (eventModel.StartDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("StartDate", "Ngày bắt đầu phải lớn hơn hoặc bằng ngày hiện tại.");
            }
            if (eventModel.EndDate <= eventModel.StartDate)
            {
                ModelState.AddModelError("EndDate", "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
            }

            if (ModelState.IsValid) // Nếu dữ liệu hợp lệ
            {
                eventModel.Status = DetermineStatus(eventModel.StartDate, eventModel.EndDate); // Xác định trạng thái sự kiện
                _eventsService.UpdateEvent(eventModel); // Cập nhật sự kiện
                return RedirectToAction("Index"); // Quay lại danh sách sự kiện
            }

            return View(eventModel); // Nếu lỗi, trả về giao diện cùng thông báo lỗi
        }

        // POST: Xóa sự kiện
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var eventToDelete = _eventsService.GetEventById(id); // Lấy thông tin sự kiện cần xóa
                if (eventToDelete == null) // Nếu không tìm thấy
                {
                    return NotFound(); // Trả về lỗi 404
                }

                _eventsService.DeleteEvent(id); // Xóa sự kiện
                TempData["Message"] = "Sự kiện đã được xóa thành công!"; // Thông báo thành công
                TempData["MessageType"] = "success";
            }
            catch (Exception ex) // Nếu xảy ra lỗi
            {
                TempData["Message"] = "Sự kiện này không thể xóa, vì có ràng buộc dữ liệu liên quan."; // Thông báo lỗi
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("Index"); // Quay lại danh sách sự kiện
        }

        // Phương thức xác định trạng thái sự kiện
        private string DetermineStatus(DateTime startDate, DateTime endDate)
        {
            var today = DateTime.Now.Date;

            if (today < startDate)
            {
                return "Chưa bắt đầu";
            }
            else if (today >= startDate && today <= endDate)
            {
                return "Đang diễn ra";
            }
            else
            {
                return "Đã kết thúc";
            }
        }

        // Tìm kiếm sự kiện
        public ActionResult Search(string keyword)
        {
            var events = _eventsService.SearchEvents(keyword); // Gọi dịch vụ tìm kiếm sự kiện theo từ khóa
            return View("Index", events); // Trả về kết quả tìm kiếm
        }
    }
}
