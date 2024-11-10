using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class RefereeController : Controller
    {
        private readonly IRefereeService _refereeService;

        public RefereeController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        public IActionResult Index()
        {
            var referees = _refereeService.GetAllReferees();  // Gọi đúng phương thức trong service
            return View(referees);
        }

        public IActionResult Details(int id)
        {
            var referee = _refereeService.GetRefereeById(id);  // Gọi đúng phương thức trong service
            return View(referee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Referee referee)
        {
            if (ModelState.IsValid)
            {
                _refereeService.AddReferee(referee);  // Sửa từ Add thành AddReferee
                return RedirectToAction("Index");
            }
            return View(referee);
        }
    }
}
