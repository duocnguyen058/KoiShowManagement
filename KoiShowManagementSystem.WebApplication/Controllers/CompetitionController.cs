using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.Interface;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Loại bỏ [Authorize] ở cấp độ controller để không yêu cầu đăng nhập cho tất cả các phương thức
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        // Lấy tất cả các cuộc thi (Cho phép Guest)
        [HttpGet]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
        public async Task<IActionResult> GetAllCompetitionsAsync()
        {
            var competitions = await _competitionService.GetAllCompetitionsAsync();
            return Ok(competitions);
        }

        // Lấy cuộc thi theo ID (Cho phép Guest)
        [HttpGet("{id}")]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
        public async Task<IActionResult> GetCompetitionByIdAsync(int id)
        {
            var competition = await _competitionService.GetCompetitionByIdAsync(id);
            if (competition == null)
                return NotFound("Không tìm thấy cuộc thi.");

            return Ok(competition);
        }

        // Tìm kiếm cuộc thi theo từ khóa và ngày (Cho phép Guest)
        [HttpGet("search")]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
        public async Task<IActionResult> SearchCompetitionsAsync([FromQuery] string searchQuery, [FromQuery] DateTime? date)
        {
            var competitions = await _competitionService.SearchCompetitionsAsync(searchQuery, date);
            return Ok(competitions);
        }

        // Thêm mới cuộc thi (Chỉ cho phép Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]  // Chỉ cho phép Admin tạo cuộc thi
        public async Task<IActionResult> CreateCompetitionAsync([FromBody] Competition competition)
        {
            if (competition == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _competitionService.CreateCompetitionAsync(competition);
            if (result)
                return CreatedAtAction(nameof(GetCompetitionByIdAsync), new { id = competition.CompetitionId }, competition);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo cuộc thi.");
        }

        // Cập nhật thông tin cuộc thi (Chỉ cho phép Admin)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]  // Chỉ cho phép Admin cập nhật cuộc thi
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

        // Xóa cuộc thi (Chỉ cho phép Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]  // Chỉ cho phép Admin xóa cuộc thi
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

        // Lấy kết quả của cuộc thi (Cho phép Guest)
        [HttpGet("{id}/results")]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
        public async Task<IActionResult> GetResultsForCompetitionAsync(int id)
        {
            var results = await _competitionService.GetResultsForCompetitionAsync(id);
            if (results == null)
                return NotFound("Không tìm thấy kết quả cho cuộc thi.");

            return Ok(results);
        }

        // Lấy điểm của cuộc thi (Chỉ cho phép Admin, Judge)
        [HttpGet("{id}/scores")]
        [Authorize(Roles = "Admin, Judge")]  // Chỉ cho phép Admin và Judge lấy điểm cuộc thi
        public async Task<IActionResult> GetScoresForCompetitionAsync(int id)
        {
            var scores = await _competitionService.GetScoresForCompetitionAsync(id);
            if (scores == null)
                return NotFound("Không tìm thấy điểm cho cuộc thi.");

            return Ok(scores);
        }

        // Lấy các cuộc thi đang diễn ra (Cho phép Guest)
        [HttpGet("ongoing")]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
        public async Task<IActionResult> GetOngoingCompetitionsAsync()
        {
            try
            {
                var ongoingCompetitions = await _competitionService.GetOngoingCompetitionsAsync();
                if (ongoingCompetitions == null || !ongoingCompetitions.Any())
                    return NotFound("Không có cuộc thi nào đang diễn ra.");

                return Ok(ongoingCompetitions);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết
                return StatusCode(500, "Đã có lỗi xảy ra khi truy vấn cuộc thi: " + ex.Message);
            }
        }

        // Kiểm tra trạng thái của cuộc thi (Cho phép Guest)
        [HttpGet("{id}/status")]
        [AllowAnonymous]  // Chỉ định cho phép truy cập mà không cần đăng nhập
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
