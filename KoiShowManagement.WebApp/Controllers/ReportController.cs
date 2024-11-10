using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var reports = _reportService.GetAllReports();  // Gọi đúng phương thức trong service
            return View(reports);
        }

        public IActionResult Details(int id)
        {
            var report = _reportService.GetReportById(id);  // Gọi đúng phương thức trong service
            return View(report);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _reportService.AddReport(report);  // Sửa từ Add thành AddReport
                return RedirectToAction("Index");
            }
            return View(report);
        }
    }
}
