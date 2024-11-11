using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Judge, User")]  // Chỉ cho phép người dùng có vai trò "Admin", "Judge" hoặc "User" truy cập
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        // Lấy tất cả các cuộc thi
        [HttpGet]
        public async Task<IActionResult> GetAllCompetitionsAsync()
        {
            var competitions = await _competitionService.GetAllCompetitionsAsync();
            return Ok(competitions);
        }

        // Lấy cuộc thi theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitionByIdAsync(int id)
        {
            var competition = await _competitionService.GetCompetitionByIdAsync(id);
            if (competition == null)
                return NotFound("Không tìm thấy cuộc thi.");

            return Ok(competition);
        }

        // Tìm kiếm cuộc thi theo từ khóa và ngày
        [HttpGet("search")]
        public async Task<IActionResult> SearchCompetitionsAsync([FromQuery] string searchQuery, [FromQuery] DateTime? date)
        {
            var competitions = await _competitionService.SearchCompetitionsAsync(searchQuery, date);
            return Ok(competitions);
        }

        // Thêm mới cuộc thi
        [HttpPost]
        public async Task<IActionResult> CreateCompetitionAsync([FromBody] Competition competition)
        {
            if (competition == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _competitionService.CreateCompetitionAsync(competition);
            if (result)
                return CreatedAtAction(nameof(GetCompetitionByIdAsync), new { id = competition.CompetitionId }, competition);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo cuộc thi.");
        }

        // Cập nhật thông tin cuộc thi
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitionAsync(int id, [FromBody] Competition competition)
        {
            if (competition == null || id != competition.CompetitionId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingCompetition = await _competitionService.GetCompetitionByIdAsync(id);
            if (existingCompetition == null)
                return NotFound("Không tìm thấy cuộc thi.");

            var result = await _competitionService.UpdateCompetitionAsync(competition);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật cuộc thi.");
        }

        // Xóa cuộc thi
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitionAsync(int id)
        {
            var existingCompetition = await _competitionService.GetCompetitionByIdAsync(id);
            if (existingCompetition == null)
                return NotFound("Không tìm thấy cuộc thi.");

            var result = await _competitionService.DeleteCompetitionAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa cuộc thi.");
        }

        // Thêm giám khảo vào cuộc thi
        [HttpPost("{competitionId}/addjudge/{judgeId}")]
        public async Task<IActionResult> AddJudgeToCompetitionAsync(int competitionId, int judgeId)
        {
            var result = await _competitionService.AddJudgeToCompetitionAsync(competitionId, judgeId);
            if (result)
                return Ok("Giám khảo đã được thêm vào cuộc thi.");

            return BadRequest("Không thể thêm giám khảo vào cuộc thi.");
        }

        // Xóa giám khảo khỏi cuộc thi
        [HttpPost("{competitionId}/removejudge/{judgeId}")]
        public async Task<IActionResult> RemoveJudgeFromCompetitionAsync(int competitionId, int judgeId)
        {
            var result = await _competitionService.RemoveJudgeFromCompetitionAsync(competitionId, judgeId);
            if (result)
                return Ok("Giám khảo đã được xóa khỏi cuộc thi.");

            return BadRequest("Không thể xóa giám khảo khỏi cuộc thi.");
        }

        // Lấy kết quả của cuộc thi
        [HttpGet("{id}/results")]
        public async Task<IActionResult> GetResultsForCompetitionAsync(int id)
        {
            var results = await _competitionService.GetResultsForCompetitionAsync(id);
            if (results == null)
                return NotFound("Không tìm thấy kết quả cho cuộc thi.");

            return Ok(results);
        }

        // Lấy điểm của cuộc thi
        [HttpGet("{id}/scores")]
        public async Task<IActionResult> GetScoresForCompetitionAsync(int id)
        {
            var scores = await _competitionService.GetScoresForCompetitionAsync(id);
            if (scores == null)
                return NotFound("Không tìm thấy điểm cho cuộc thi.");

            return Ok(scores);
        }

        // Lấy các cuộc thi đang diễn ra
        [HttpGet("ongoing")]
        public async Task<IActionResult> GetOngoingCompetitionsAsync()
        {
            var ongoingCompetitions = await _competitionService.GetOngoingCompetitionsAsync();
            return Ok(ongoingCompetitions);
        }

        // Kiểm tra trạng thái của cuộc thi
        [HttpGet("{id}/status")]
        public IActionResult CheckCompetitionStatus(int id)
        {
            var competition = _competitionService.GetCompetitionByIdAsync(id).Result;
            if (competition == null)
                return NotFound("Không tìm thấy cuộc thi.");

            bool isActive = _competitionService.IsCompetitionActive(competition);
            return Ok(isActive ? "Cuộc thi đang diễn ra." : "Cuộc thi đã kết thúc.");
        }
    }
}
