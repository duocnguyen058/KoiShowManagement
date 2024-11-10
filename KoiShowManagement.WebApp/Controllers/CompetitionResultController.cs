using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System.Threading.Tasks;

namespace KoiShowManagement.WebApp.Controllers
{
    public class CompetitionResultController : Controller
    {
        private readonly ICompetitionResultService _competitionResultService;

        public CompetitionResultController(ICompetitionResultService competitionResultService)
        {
            _competitionResultService = competitionResultService;
        }

        // Hiển thị tất cả kết quả thi đấu
        public async Task<IActionResult> Index()
        {
            var results = await _competitionResultService.GetAllCompetitionResults();
            return View(results);
        }

        // Chi tiết kết quả thi đấu
        public async Task<IActionResult> Details(int id)
        {
            var result = await _competitionResultService.GetCompetitionResultById(id);
            return View(result);
        }

        // Mở form tạo kết quả thi đấu mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý form tạo kết quả thi đấu
        [HttpPost]
        public async Task<IActionResult> Create(CompetitionResult result)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _competitionResultService.AddCompetitionResult(result);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(result);
        }

        // Xử lý xóa kết quả thi đấu
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _competitionResultService.GetCompetitionResultById(id);
            if (result != null)
            {
                bool isDeleted = await _competitionResultService.DelCompetitionResult(result);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        // Xử lý chỉnh sửa kết quả thi đấu
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _competitionResultService.GetCompetitionResultById(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompetitionResult result)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await _competitionResultService.UpdCompetitionResult(result);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(result);
        }
    }
}
