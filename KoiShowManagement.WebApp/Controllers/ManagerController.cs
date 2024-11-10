using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Services.Interface;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // Đảm bảo sử dụng await để chờ kết quả trả về từ phương thức bất đồng bộ
        public async Task<IActionResult> Index()
        {
            var managers = await _managerService.GetAllManagersAsync();  // Sử dụng await
            return View(managers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var manager = await _managerService.GetManagerByIdAsync(id);  // Sử dụng await
            return View(manager);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _managerService.GetManagerByIdAsync(id);  // Sử dụng await
            return View(manager);
        }
    }
}

