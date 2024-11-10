using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System.Threading.Tasks;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ScoreKoiController : Controller
    {
        private readonly IScoreKoiService _scoreKoiService;

        public ScoreKoiController(IScoreKoiService scoreKoiService)
        {
            _scoreKoiService = scoreKoiService;
        }

        // Hiển thị danh sách ScoreKoi
        public async Task<IActionResult> Index()
        {
            var scores = await _scoreKoiService.GetAllScoreKoisAsync();
            return View(scores);
        }

        // Hiển thị form tạo mới ScoreKoi
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý khi tạo mới ScoreKoi
        [HttpPost]
        public async Task<IActionResult> Create(ScoreKoi score)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _scoreKoiService.AddScoreKoiAsync(score);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(score);
        }

        // Hiển thị form chỉnh sửa ScoreKoi
        public async Task<IActionResult> Edit(int id)
        {
            var score = await _scoreKoiService.GetScoreKoiByIdAsync(id);
            return View(score);
        }

        // Xử lý khi chỉnh sửa ScoreKoi
        [HttpPost]
        public async Task<IActionResult> Edit(ScoreKoi score)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await _scoreKoiService.UpdScoreKoiAsync(score);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(score);
        }
    }
}
