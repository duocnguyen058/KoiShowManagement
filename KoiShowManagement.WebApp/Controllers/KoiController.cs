using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System.Threading.Tasks;

namespace KoiShowManagement.WebApp.Controllers
{
    public class KoiController : Controller
    {
        private readonly IKoiService _koiService;

        public KoiController(IKoiService koiService)
        {
            _koiService = koiService;
        }

        public IActionResult Index()
        {
            var koiList = _koiService.GetAllKoisAsync();
            return View(koiList);
        }

        public IActionResult Details(int id)
        {
            var koi = _koiService.GetKoiByIdAsync(id);
            return View(koi);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Koi koi)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _koiService.AddKoiAsync(koi);  // Dùng await vì AddKoi đã là Task<bool>
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(koi);
        }
    }
}
