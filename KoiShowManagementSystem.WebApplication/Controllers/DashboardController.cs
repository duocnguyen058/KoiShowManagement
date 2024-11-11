using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.CompetitionService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Judge")]  // Chỉ cho phép người dùng có vai trò "Admin" hoặc "Judge" truy cập
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // Lấy tất cả các dashboard
        [HttpGet]
        public async Task<IActionResult> GetAllDashboardsAsync()
        {
            var dashboards = await _dashboardService.GetAllDashboardsAsync();
            return Ok(dashboards);
        }

        // Lấy dashboard theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDashboardByIdAsync(int id)
        {
            var dashboard = await _dashboardService.GetDashboardByIdAsync(id);
            if (dashboard == null)
                return NotFound("Không tìm thấy bảng điều khiển.");

            return Ok(dashboard);
        }

        // Thêm mới bảng điều khiển
        [HttpPost]
        public async Task<IActionResult> AddDashboardAsync([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _dashboardService.AddDashboardAsync(dashboard);
            if (result)
                return CreatedAtAction(nameof(GetDashboardByIdAsync), new { id = dashboard.DashboardId }, dashboard);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo bảng điều khiển.");
        }

        // Cập nhật bảng điều khiển
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDashboardAsync(int id, [FromBody] Dashboard dashboard)
        {
            if (dashboard == null || id != dashboard.DashboardId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingDashboard = await _dashboardService.GetDashboardByIdAsync(id);
            if (existingDashboard == null)
                return NotFound("Không tìm thấy bảng điều khiển.");

            var result = await _dashboardService.UpdateDashboardAsync(dashboard);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật bảng điều khiển.");
        }

        // Xóa bảng điều khiển theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashboardAsync(int id)
        {
            var existingDashboard = await _dashboardService.GetDashboardByIdAsync(id);
            if (existingDashboard == null)
                return NotFound("Không tìm thấy bảng điều khiển.");

            var result = await _dashboardService.DeleteDashboardAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa bảng điều khiển.");
        }

        // Xóa bảng điều khiển
        [HttpDelete]
        public async Task<IActionResult> DeleteDashboardAsync([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _dashboardService.DeleteDashboardAsync(dashboard);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa bảng điều khiển.");
        }
    }
}
