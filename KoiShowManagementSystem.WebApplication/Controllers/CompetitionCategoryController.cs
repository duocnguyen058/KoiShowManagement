using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]  // Chỉ cho phép người dùng có vai trò "Admin" truy cập
    public class CompetitionCategoryController : ControllerBase
    {
        private readonly ICompetitionCategoryService _competitionCategoryService;

        public CompetitionCategoryController(ICompetitionCategoryService competitionCategoryService)
        {
            _competitionCategoryService = competitionCategoryService;
        }

        // Lấy tất cả danh mục cuộc thi
        [HttpGet]
        public async Task<IActionResult> GetAllCompetitionCategoriesAsync()
        {
            var categories = await _competitionCategoryService.GetAllCompetitionCategoriesAsync();
            return Ok(categories);
        }

        // Lấy danh mục cuộc thi theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitionCategoryByIdAsync(int id)
        {
            var category = await _competitionCategoryService.GetCompetitionCategoryByIdAsync(id);
            if (category == null)
                return NotFound("Danh mục cuộc thi không tồn tại.");

            return Ok(category);
        }

        // Thêm danh mục cuộc thi mới
        [HttpPost]
        public async Task<IActionResult> CreateCompetitionCategoryAsync([FromBody] CompetitionCategory category)
        {
            if (category == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _competitionCategoryService.CreateCompetitionCategoryAsync(category);
            if (result)
                return CreatedAtAction(nameof(GetCompetitionCategoryByIdAsync), new { id = category.CategoryId }, category);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo danh mục cuộc thi.");
        }

        // Cập nhật danh mục cuộc thi
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitionCategoryAsync(int id, [FromBody] CompetitionCategory category)
        {
            if (category == null || id != category.CategoryId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingCategory = await _competitionCategoryService.GetCompetitionCategoryByIdAsync(id);
            if (existingCategory == null)
                return NotFound("Danh mục cuộc thi không tồn tại.");

            var result = await _competitionCategoryService.UpdateCompetitionCategoryAsync(category);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật danh mục cuộc thi.");
        }

        // Xóa danh mục cuộc thi
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitionCategoryAsync(int id)
        {
            var existingCategory = await _competitionCategoryService.GetCompetitionCategoryByIdAsync(id);
            if (existingCategory == null)
                return NotFound("Danh mục cuộc thi không tồn tại.");

            var result = await _competitionCategoryService.DeleteCompetitionCategoryAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa danh mục cuộc thi.");
        }
    }
}
