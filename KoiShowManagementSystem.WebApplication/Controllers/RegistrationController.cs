using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // Lấy tất cả các đăng ký
        [HttpGet]
        public async Task<IActionResult> GetAllRegistrationsAsync()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }

        // Lấy thông tin đăng ký theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationByIdAsync(int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);
            if (registration == null)
                return NotFound("Đăng ký không tồn tại.");

            return Ok(registration);
        }

        // Tạo mới đăng ký
        [HttpPost]
        public async Task<IActionResult> AddRegistrationAsync([FromBody] Registration registration)
        {
            if (registration == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _registrationService.AddRegistrationAsync(registration);
            if (result)
                return CreatedAtAction(nameof(GetRegistrationByIdAsync), new { id = registration.RegistrationId }, registration);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo đăng ký.");
        }

        // Cập nhật đăng ký
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistrationAsync(int id, [FromBody] Registration registration)
        {
            if (registration == null || id != registration.RegistrationId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingRegistration = await _registrationService.GetRegistrationByIdAsync(id);
            if (existingRegistration == null)
                return NotFound("Đăng ký không tồn tại.");

            var result = await _registrationService.UpdateRegistrationAsync(registration);
            if (result)
                return NoContent();  // Trả về mã 204 khi cập nhật thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật đăng ký.");
        }

        // Xóa đăng ký theo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationByIdAsync(int id)
        {
            var existingRegistration = await _registrationService.GetRegistrationByIdAsync(id);
            if (existingRegistration == null)
                return NotFound("Đăng ký không tồn tại.");

            var result = await _registrationService.DeleteRegistrationByIdAsync(id);
            if (result)
                return NoContent();  // Trả về mã 204 khi xóa thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa đăng ký.");
        }

        // Xóa đăng ký
        [HttpDelete]
        public async Task<IActionResult> DeleteRegistrationAsync([FromBody] Registration registration)
        {
            if (registration == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _registrationService.DeleteRegistrationAsync(registration);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa đăng ký.");
        }

        // Xóa các đăng ký theo CompetitionId
        [HttpDelete("competition/{competitionId}")]
        public async Task<IActionResult> DeleteRegistrationsByCompetitionIdAsync(int competitionId)
        {
            var result = await _registrationService.DeleteRegistrationsByCompetitionIdAsync(competitionId);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa các đăng ký.");
        }
    }
}
