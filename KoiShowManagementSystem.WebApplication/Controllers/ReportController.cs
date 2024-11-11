using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // Lấy tất cả báo cáo
        [HttpGet]
        public async Task<IActionResult> GetAllReportsAsync()
        {
            var reports = await _reportService.GetAllReportsAsync();
            return Ok(reports);
        }

        // Lấy báo cáo theo ID
        [HttpGet("{reportId}")]
        public async Task<IActionResult> GetReportByIdAsync(int reportId)
        {
            var report = await _reportService.GetReportByIdAsync(reportId);
            if (report == null)
                return NotFound("Báo cáo không tồn tại.");

            return Ok(report);
        }

        // Lấy báo cáo cho cuộc thi
        [HttpGet("competition/{competitionId}")]
        public async Task<IActionResult> GetReportsForCompetitionAsync(int competitionId)
        {
            var reports = await _reportService.GetReportsForCompetitionAsync(competitionId);
            return Ok(reports);
        }

        // Tạo báo cáo mới
        [HttpPost]
        public async Task<IActionResult> CreateReportAsync([FromBody] Report report)
        {
            if (report == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _reportService.CreateReportAsync(report);
            if (result)
                return CreatedAtAction(nameof(GetReportByIdAsync), new { reportId = report.ReportId }, report);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo báo cáo.");
        }

        // Cập nhật báo cáo
        [HttpPut("{reportId}")]
        public async Task<IActionResult> UpdateReportAsync(int reportId, [FromBody] Report report)
        {
            if (report == null || reportId != report.ReportId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingReport = await _reportService.GetReportByIdAsync(reportId);
            if (existingReport == null)
                return NotFound("Báo cáo không tồn tại.");

            var result = await _reportService.UpdateReportAsync(report);
            if (result)
                return NoContent();  // Trả về mã 204 khi cập nhật thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật báo cáo.");
        }

        // Xóa báo cáo
        [HttpDelete("{reportId}")]
        public async Task<IActionResult> DeleteReportAsync(int reportId)
        {
            var existingReport = await _reportService.GetReportByIdAsync(reportId);
            if (existingReport == null)
                return NotFound("Báo cáo không tồn tại.");

            var result = await _reportService.DeleteReportAsync(reportId);
            if (result)
                return NoContent();  // Trả về mã 204 khi xóa thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa báo cáo.");
        }
    }
}
