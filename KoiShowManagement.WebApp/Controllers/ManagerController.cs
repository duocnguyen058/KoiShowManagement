using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            var managers = _managerService.GetAll();
            return View(managers);
        }

        public IActionResult Details(int id)
        {
            var manager = _managerService.GetById(id);
            return View(manager);
        }

        public IActionResult Edit(int id)
        {
            var manager = _managerService.GetById(id);
            return View(manager);
        }
    }
}
