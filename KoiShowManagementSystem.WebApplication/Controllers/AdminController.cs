using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Services.Interface;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Services.CompetitionService;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly ICompetitionService _competitionService;

        public AdminController(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                               IAccountService accountService,
                               ICompetitionService competitionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountService = accountService;
            _competitionService = competitionService;
        }

        #region ** Web View Routes **

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Tìm người dùng theo tên đăng nhập
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    // Gọi phương thức kiểm tra vai trò và điều hướng
                    return await RedirectToDashboardBasedOnRole(user);
                }
                else
                {
                    // Người dùng không tồn tại
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // Trang đăng nhập
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email không tồn tại.");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToAction("AdminDashboard");
                }
                else if (await _userManager.IsInRoleAsync(user, "Manager"))
                {
                    return RedirectToAction("ManagerDashboard");
                }
                else if (await _userManager.IsInRoleAsync(user, "Staff"))
                {
                    return RedirectToAction("StaffDashboard");
                }
                else if (await _userManager.IsInRoleAsync(user, "Referee"))
                {
                    return RedirectToAction("RefereeDashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Mật khẩu không chính xác.");
            return View();
        }

        // Đăng xuất
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region ** API Routes - Account Management **

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

        #region ** API Routes - Competition Management **

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

        // Phương thức điều hướng theo vai trò
        private async Task<IActionResult> RedirectToDashboardBasedOnRole(IdentityUser user)
        {
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("AdminDashboard");
            }
            else if (await _userManager.IsInRoleAsync(user, "Manager"))
            {
                return RedirectToAction("ManagerDashboard");
            }
            else if (await _userManager.IsInRoleAsync(user, "Staff"))
            {
                return RedirectToAction("StaffDashboard");
            }
            else if (await _userManager.IsInRoleAsync(user, "Referee"))
            {
                return RedirectToAction("RefereeDashboard");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
