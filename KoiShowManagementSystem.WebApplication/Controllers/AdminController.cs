using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Repositories.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ cho phép người dùng có vai trò "Admin"
    public class AdminController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICompetitionService _competitionService;

        public AdminController(IAccountService accountService, ICompetitionService competitionService)
        {
            _accountService = accountService;
            _competitionService = competitionService;
        }

        #region ** Account Management **

        // Lấy tất cả tài khoản
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // Xóa tài khoản
        [HttpDelete("accounts/{id}")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {
            var existingAccount = await _accountService.GetAccountByIdAsync(id);
            if (existingAccount == null)
                return NotFound("Tài khoản không tồn tại.");

            var result = await _accountService.DeleteAccountAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa tài khoản.");
        }

        // Cập nhật thông tin tài khoản
        [HttpPut("accounts/{id}")]
        public async Task<IActionResult> UpdateAccountAsync(int id, [FromBody] Account account)
        {
            if (account == null || id != account.AccountId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingAccount = await _accountService.GetAccountByIdAsync(id);
            if (existingAccount == null)
                return NotFound("Tài khoản không tồn tại.");

            var result = await _accountService.UpdateAccountAsync(account);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật tài khoản.");
        }

        #endregion

        #region ** Competition Management **

        // Lấy tất cả cuộc thi
        [HttpGet("competitions")]
        public async Task<IActionResult> GetAllCompetitionsAsync()
        {
            var competitions = await _competitionService.GetAllCompetitionsAsync();
            return Ok(competitions);
        }

        // Tạo cuộc thi mới
        [HttpPost("competitions")]
        public async Task<IActionResult> CreateCompetitionAsync([FromBody] Competition competition)
        {
            if (competition == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = await _competitionService.CreateCompetitionAsync(competition);
            if (result)
                return CreatedAtAction(nameof(GetAllCompetitionsAsync), new { id = competition.CompetitionId }, competition);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo cuộc thi.");
        }

        // Cập nhật cuộc thi
        [HttpPut("competitions/{id}")]
        public async Task<IActionResult> UpdateCompetitionAsync(int id, [FromBody] Competition competition)
        {
            if (competition == null || id != competition.CompetitionId)
                return BadRequest("Dữ liệu không hợp lệ.");

            var existingCompetition = await _competitionService.GetCompetitionByIdAsync(id);
            if (existingCompetition == null)
                return NotFound("Cuộc thi không tồn tại.");

            var result = await _competitionService.UpdateCompetitionAsync(competition);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật cuộc thi.");
        }

        // Xóa cuộc thi
        [HttpDelete("competitions/{id}")]
        public async Task<IActionResult> DeleteCompetitionAsync(int id)
        {
            var existingCompetition = await _competitionService.GetCompetitionByIdAsync(id);
            if (existingCompetition == null)
                return NotFound("Cuộc thi không tồn tại.");

            var result = await _competitionService.DeleteCompetitionAsync(id);
            if (result)
                return NoContent();

            return StatusCode(500, "Đã có lỗi xảy ra khi xóa cuộc thi.");
        }

        #endregion
    }
}
