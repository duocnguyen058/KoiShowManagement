using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Repositories.Entities;
using System.Threading.Tasks;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Lấy thông tin tài khoản theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountByIdAsync(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound("Tài khoản không tồn tại.");

            return Ok(account);
        }

        // Lấy thông tin tài khoản theo Username
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetAccountByUsernameAsync(string username)
        {
            var account = await _accountService.GetAccountByUsernameAsync(username);
            if (account == null)
                return NotFound("Tài khoản không tồn tại.");

            return Ok(account);
        }

        // Lấy tất cả tài khoản
        [HttpGet]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // Tạo mới tài khoản
        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync([FromBody] Account account)
        {
            if (account == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var isExist = await _accountService.IsAccountExistAsync(account.Username);
            if (isExist)
                return Conflict("Tài khoản đã tồn tại.");

            var result = await _accountService.CreateAccountAsync(account);
            if (result)
                return CreatedAtAction(nameof(GetAccountByIdAsync), new { id = account.AccountId }, account);

            return StatusCode(500, "Đã có lỗi xảy ra khi tạo tài khoản.");
        }

        // Cập nhật thông tin tài khoản
        [HttpPut("{id}")]
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

        // Xóa tài khoản
        [HttpDelete("{id}")]
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

        // Xác thực tài khoản (đăng nhập)
        [HttpPost("validate")]
        public async Task<IActionResult> ValidateAccountAsync([FromBody] AccountLoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Dữ liệu không hợp lệ.");

            var account = await _accountService.ValidateAccountAsync(loginRequest.Username, loginRequest.Password);

            if (account == null)
                return Unauthorized("Tên đăng nhập hoặc mật khẩu không đúng.");

            return Ok(account); // Trả về thông tin tài khoản khi đăng nhập thành công
        }
    }

    // Model yêu cầu cho việc đăng nhập
    public class AccountLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
