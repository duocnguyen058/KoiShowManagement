using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Services.Interface;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.WebApp.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var staffList = _staffService.GetAllStaffs();
            return View(staffList);
        }

        public IActionResult Details(int id)
        {
            var staff = _staffService.GetStaffById(id);
            return View(staff);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                // Sử dụng phương thức AddStaff thay vì Add
                _staffService.AddStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        public IActionResult Edit(int id)
        {
            var staff = _staffService.GetStaffById(id);
            return View(staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _staffService.UpdStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }
    }
}
