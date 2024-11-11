using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Services.Interface;
using System;
using KoiShowManagementSystem.Services;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IKoiFishService _koiFishService;
        private readonly ICompetitionService _competitionService;
        private readonly IResultService _resultService;

        public SearchController(IKoiFishService koiFishService,
                                ICompetitionService competitionService,
                                IResultService resultService)
        {
            _koiFishService = koiFishService;
            _competitionService = competitionService;
            _resultService = resultService;
        }

        // Tìm kiếm koi fish theo tên, giống, kích cỡ, tuổi
        [HttpGet("koiFish")]
        public async Task<IActionResult> SearchKoiFishAsync(string name = null, string variety = null, double? size = null, int? age = null)
        {
            try
            {
                var koiFishes = await _koiFishService.SearchKoiFishAsync(name, variety, size, age);
                if (koiFishes == null || koiFishes.Count == 0)
                    return NotFound("Không tìm thấy koi fish theo yêu cầu.");

                return Ok(koiFishes);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }

        // Tìm kiếm cuộc thi theo tên
        [HttpGet("competition")]
        public async Task<IActionResult> SearchCompetitionsAsync(string name = null)
        {
            try
            {
                var competitions = await _competitionService.SearchCompetitionsAsync(name, null); // Chỉ tìm theo tên
                if (competitions == null || !competitions.Any())  // Kiểm tra nếu competitions là null hoặc danh sách trống
                    return NotFound("Không tìm thấy kết quả theo yêu cầu.");

                return Ok(competitions);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }

        // Tìm kiếm kết quả theo koi fish hoặc cuộc thi
        [HttpGet("result")]
        public async Task<IActionResult> SearchResultsAsync(int? koiFishId = null, int? competitionId = null)
        {
            try
            {
                var results = await _resultService.SearchResultsAsync(koiFishId, competitionId);
                if (results == null || results.Count == 0)
                    return NotFound("Không tìm thấy kết quả theo yêu cầu.");

                return Ok(results);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }
    }
}
