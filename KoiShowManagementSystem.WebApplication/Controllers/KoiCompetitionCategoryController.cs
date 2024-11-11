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
    public class KoiCompetitionCategoryController : ControllerBase
    {
        private readonly IKoiCompetitionCategoryService _koiCompetitionCategoryService;

        public KoiCompetitionCategoryController(IKoiCompetitionCategoryService koiCompetitionCategoryService)
        {
            _koiCompetitionCategoryService = koiCompetitionCategoryService;
        }

        // Lấy tất cả các thể loại cuộc thi cá Koi
        [HttpGet]
        public async Task<IActionResult> GetAllKoiCompetitionCategoriesAsync()
        {
            var koiCompetitionCategories = await _koiCompetitionCategoryService.GetAllKoiCompetitionCategoriesAsync();
            return Ok(koiCompetitionCategories);
        }

        // Lấy thể loại cuộc thi cá Koi theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKoiCompetitionCategoryByIdAsync(int id)
        {
            var koiCompetitionCategory = await _koiCompetitionCategoryService.GetKoiCompetitionCategoryByIdAsync(id);
            if (koiCompetitionCategory == null)
                return NotFound("Không tìm thấy thể loại cuộc thi.");

            return Ok(koiCompetitionCategory);
        }

        // Thêm thể loại cuộc thi cá Koi
        [HttpPost]
        public async Task<IActionResult> AddKoiCompetitionCategoryAsync([FromBody] KoiCompetitionCategory koiCompetitionCategory)
        {
            if (koiCompetitionCategory == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _koiCompetitionCategoryService.AddKoiCompetitionCategoryAsync(koiCompetitionCategory);
            if (result)
                return CreatedAtAction(nameof(GetKoiCompetitionCategoryByIdAsync), new { id = koiCompetitionCategory.KoiCompetitionCategoryId }, koiCompetitionCategory);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo thể loại cuộc thi.");
        }

        // Cập nhật thể loại cuộc thi cá Koi
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKoiCompetitionCategoryAsync(int id, [FromBody] KoiCompetitionCategory koiCompetitionCategory)
        {
            if (koiCompetitionCategory == null || id != koiCompetitionCategory.KoiCompetitionCategoryId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingCategory = await _koiCompetitionCategoryService.GetKoiCompetitionCategoryByIdAsync(id);
            if (existingCategory == null)
                return NotFound("Không tìm thấy thể loại cuộc thi.");

            var result = await _koiCompetitionCategoryService.UpdateKoiCompetitionCategoryAsync(koiCompetitionCategory);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật thể loại cuộc thi.");
        }

        // Xóa thể loại cuộc thi cá Koi theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoiCompetitionCategoryAsync(int id)
        {
            var existingCategory = await _koiCompetitionCategoryService.GetKoiCompetitionCategoryByIdAsync(id);
            if (existingCategory == null)
                return NotFound("Không tìm thấy thể loại cuộc thi.");

            var result = await _koiCompetitionCategoryService.DeleteKoiCompetitionCategoryAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa thể loại cuộc thi.");
        }

        // Xóa thể loại cuộc thi cá Koi
        [HttpDelete]
        public async Task<IActionResult> DeleteKoiCompetitionCategoryAsync([FromBody] KoiCompetitionCategory koiCompetitionCategory)
        {
            if (koiCompetitionCategory == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _koiCompetitionCategoryService.DeleteKoiCompetitionCategoryAsync(koiCompetitionCategory);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa thể loại cuộc thi.");
        }
    }
}
