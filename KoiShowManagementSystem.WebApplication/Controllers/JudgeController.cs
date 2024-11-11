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
    [Authorize(Roles = "Admin")]  // Chỉ cho phép người dùng có vai trò "Admin" truy cập
    public class JudgeController : ControllerBase
    {
        private readonly IJudgeService _judgeService;

        public JudgeController(IJudgeService judgeService)
        {
            _judgeService = judgeService;
        }

        // Lấy tất cả giám khảo
        [HttpGet]
        public async Task<IActionResult> GetAllJudgesAsync()
        {
            var judges = await _judgeService.GetAllJudgesAsync();
            return Ok(judges);
        }

        // Lấy giám khảo theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJudgeByIdAsync(int id)
        {
            var judge = await _judgeService.GetJudgeByIdAsync(id);
            if (judge == null)
                return NotFound("Không tìm thấy giám khảo.");

            return Ok(judge);
        }

        // Thêm mới giám khảo
        [HttpPost]
        public async Task<IActionResult> AddJudgeAsync([FromBody] Judge judge)
        {
            if (judge == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _judgeService.AddJudgeAsync(judge);
            if (result)
                return CreatedAtAction(nameof(GetJudgeByIdAsync), new { id = judge.JudgeId }, judge);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo giám khảo.");
        }

        // Cập nhật giám khảo
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJudgeAsync(int id, [FromBody] Judge judge)
        {
            if (judge == null || id != judge.JudgeId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingJudge = await _judgeService.GetJudgeByIdAsync(id);
            if (existingJudge == null)
                return NotFound("Không tìm thấy giám khảo.");

            var result = await _judgeService.UpdateJudgeAsync(judge);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật giám khảo.");
        }

        // Xóa giám khảo theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudgeAsync(int id)
        {
            var existingJudge = await _judgeService.GetJudgeByIdAsync(id);
            if (existingJudge == null)
                return NotFound("Không tìm thấy giám khảo.");

            var result = await _judgeService.DeleteJudgeAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa giám khảo.");
        }

        // Xóa giám khảo
        [HttpDelete]
        public async Task<IActionResult> DeleteJudgeAsync([FromBody] Judge judge)
        {
            if (judge == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _judgeService.DeleteJudgeAsync(judge);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa giám khảo.");
        }
    }
}
