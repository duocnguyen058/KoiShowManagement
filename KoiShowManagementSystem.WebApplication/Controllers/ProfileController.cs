using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Repositories.Entities;
using System.Threading.Tasks;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ProfileController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Lấy thông tin tài khoản của người dùng đang đăng nhập
        [HttpGet]
        public async Task<IActionResult> GetProfileAsync()
        {
            var username = User.Identity.Name;  // Lấy tên người dùng từ context

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Bạn phải đăng nhập trước khi truy cập trang này.");
            }

            var account = await _accountService.GetAccountByUsernameAsync(username);
            if (account == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            return Ok(account);  // Trả về thông tin tài khoản
        }

        // Cập nhật thông tin tài khoản
        [HttpPut]
        public async Task<IActionResult> UpdateProfileAsync([FromBody] Account account)
        {
            var username = User.Identity.Name;  // Lấy tên người dùng từ context

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("Bạn phải đăng nhập trước khi thực hiện thao tác này.");
            }

            if (account == null || account.Username != username)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            var existingAccount = await _accountService.GetAccountByUsernameAsync(username);
            if (existingAccount == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            // Cập nhật thông tin tài khoản
            var result = await _accountService.UpdateAccountAsync(account);
            if (result)
                return NoContent();  // Trả về mã 204 khi cập nhật thành công

            return StatusCode(500, "Đã có lỗi xảy ra khi cập nhật thông tin tài khoản.");
        }
    }
}
