using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        // Lấy tất cả kết quả
        [HttpGet]
        public async Task<IActionResult> GetAllResultsAsync()
        {
            var results = await _resultService.GetAllResultsAsync();
            return Ok(results);
        }

        // Lấy kết quả theo ID
        [HttpGet("{resultId}")]
        public async Task<IActionResult> GetResultByIdAsync(int resultId)
        {
            var result = await _resultService.GetResultByIdAsync(resultId);
            if (result == null)
                return NotFound("Kết quả không tồn tại.");

            return Ok(result);
        }

        // Lấy kết quả cho cuộc thi
        [HttpGet("competition/{competitionId}")]
        public async Task<IActionResult> GetResultsForCompetitionAsync(int competitionId)
        {
            var results = await _resultService.GetResultsForCompetitionAsync(competitionId);
            return Ok(results);
        }

        // Tạo kết quả mới
        [HttpPost]
        public async Task<IActionResult> CreateResultAsync([FromBody] Result result)
        {
            if (result == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var created = await _resultService.CreateResultAsync(result);
            if (created)
                return CreatedAtAction(nameof(GetResultByIdAsync), new { resultId = result.ResultId }, result);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo kết quả.");
        }

        // Cập nhật kết quả
        [HttpPut("{resultId}")]
        public async Task<IActionResult> UpdateResultAsync(int resultId, [FromBody] Result result)
        {
            if (result == null || resultId != result.ResultId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingResult = await _resultService.GetResultByIdAsync(resultId);
            if (existingResult == null)
                return NotFound("Kết quả không tồn tại.");

            var updated = await _resultService.UpdateResultAsync(result);
            if (updated)
                return NoContent(); // Trả về mã 204 khi cập nhật thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật kết quả.");
        }

        // Xóa kết quả
        [HttpDelete("{resultId}")]
        public async Task<IActionResult> DeleteResultAsync(int resultId)
        {
            var existingResult = await _resultService.GetResultByIdAsync(resultId);
            if (existingResult == null)
                return NotFound("Kết quả không tồn tại.");

            var deleted = await _resultService.DeleteResultAsync(resultId);
            if (deleted)
                return NoContent(); // Trả về mã 204 khi xóa thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa kết quả.");
        }
    }
}
