using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using System.Threading.Tasks;
using System.Linq;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompetitionService _competitionService;

        public HomeController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        // Trang chủ, hiển thị các cuộc thi đang diễn ra
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "Chưa có cuộc thi nào đang diễn ra.";

            try
            {
                var ongoingCompetitions = await _competitionService.GetOngoingCompetitionsAsync();
                if (ongoingCompetitions != null && ongoingCompetitions.Any())
                {
                    ViewBag.Message = null;
                }

                return View(ongoingCompetitions);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Lỗi khi tải danh sách cuộc thi: {ex.Message}";
                return View(Enumerable.Empty<Competition>());
            }
        }

        // Trang Giới thiệu
        public IActionResult About()
        {
            // Dữ liệu hoặc thông tin tóm tắt về trang giới thiệu
            ViewBag.Title = "Giới thiệu về hệ thống quản lý Koi Show";
            ViewBag.Description = "Hệ thống quản lý Koi Show cung cấp nền tảng tổ chức và quản lý các cuộc thi Koi chuyên nghiệp.";

            return View();
        }
        // Trang Danh sách các cuộc thi
        public async Task<IActionResult> CompetitionList()
        {
            ViewBag.Message = "Chưa có cuộc thi nào trong hệ thống.";

            try
            {
                var allCompetitions = await _competitionService.GetAllCompetitionsAsync();
                if (allCompetitions != null && allCompetitions.Any())
                {
                    ViewBag.Message = null;
                }

                return View(allCompetitions);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Lỗi khi tải danh sách cuộc thi: {ex.Message}";
                return View(Enumerable.Empty<Competition>());
            }
        }

        // Điều hướng đến trang Đăng nhập trong AccountController
        public IActionResult UserLogin()
        {
            return RedirectToAction("UserLogin", "Account");
        }

        // Điều hướng đến trang Đăng ký trong AccountController
        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }
    }
}
