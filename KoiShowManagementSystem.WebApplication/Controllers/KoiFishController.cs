using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services;
using KoiShowManagementSystem.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiFishController : ControllerBase
    {
        private readonly IKoiFishService _koiFishService;

        public KoiFishController(IKoiFishService koiFishService)
        {
            _koiFishService = koiFishService;
        }

        // Lấy tất cả cá Koi
        [HttpGet]
        public async Task<IActionResult> GetAllKoiFishAsync()
        {
            var koiFishes = await _koiFishService.GetAllKoiFishAsync();
            if (koiFishes == null || koiFishes.Count == 0)
                return NotFound("Không có cá Koi nào.");

            return Ok(koiFishes);
        }

        // Lấy cá Koi theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKoiFishByIdAsync(int id)
        {
            var koiFish = await _koiFishService.GetKoiFishByIdAsync(id);
            if (koiFish == null)
                return NotFound($"Cá Koi với ID {id} không tồn tại.");

            return Ok(koiFish);
        }

        // Thêm mới cá Koi
        [HttpPost]
        public async Task<IActionResult> AddKoiFishAsync([FromBody] KoiFish koiFish)
        {
            if (koiFish == null)
                return BadRequest("Dữ liệu cá Koi không hợp lệ.");

            var result = await _koiFishService.AddKoiFishAsync(koiFish);
            if (result)
                return CreatedAtAction(nameof(GetKoiFishByIdAsync), new { id = koiFish.KoiFishId }, koiFish);

            return StatusCode(500, "Đã có lỗi xảy ra khi thêm cá Koi.");
        }

        // Cập nhật thông tin cá Koi
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKoiFishAsync(int id, [FromBody] KoiFish koiFish)
        {
            if (koiFish == null || id != koiFish.KoiFishId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingKoiFish = await _koiFishService.GetKoiFishByIdAsync(id);
            if (existingKoiFish == null)
                return NotFound($"Cá Koi với ID {id} không tồn tại.");

            var result = await _koiFishService.UpdateKoiFishAsync(koiFish);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật cá Koi.");
        }

        // Xóa cá Koi theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoiFishAsync(int id)
        {
            var existingKoiFish = await _koiFishService.GetKoiFishByIdAsync(id);
            if (existingKoiFish == null)
                return NotFound($"Cá Koi với ID {id} không tồn tại.");

            var result = await _koiFishService.DeleteKoiFishByIdAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa cá Koi.");
        }

        // Xóa cá Koi theo đối tượng (optional - có thể bỏ nếu không cần thiết)
        [HttpDelete]
        public async Task<IActionResult> DeleteKoiFishByObjectAsync([FromBody] KoiFish koiFish)
        {
            if (koiFish == null)
                return BadRequest("Dữ liệu cá Koi không hợp lệ.");

            var result = await _koiFishService.DeleteKoiFishAsync(koiFish);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa cá Koi.");
        }

        // Tìm kiếm cá Koi
        [HttpGet("search")]
        public async Task<IActionResult> SearchKoiFishAsync([FromQuery] string searchQuery, [FromQuery] string variety, [FromQuery] double? size, [FromQuery] int? age)
        {
            var koiFishes = await _koiFishService.SearchKoiFishAsync(searchQuery, variety, size, age);
            if (koiFishes == null || koiFishes.Count == 0)
                return NotFound("Không có cá Koi phù hợp với yêu cầu tìm kiếm.");

            return Ok(koiFishes);
        }
    }
}
