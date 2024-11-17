using KoiShowManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KoiShowManagementSystem.Repositories.Entity;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Controllers
{
    // Chỉ cho phép truy cập controller này nếu người dùng có vai trò "ADMIN"
    [Authorize(Roles = "ADMIN")]
    public class UserController : Controller
    {
        // Khai báo service IUserService để tương tác với dữ liệu người dùng
        private readonly IUserService _userService;

        // Constructor: Inject IUserService thông qua Dependency Injection
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User - Hiển thị danh sách người dùng
        public async Task<IActionResult> Index()
        {
            // Lấy tất cả người dùng từ service
            var users = await _userService.GetAllUsersAsync();
            return View(users); // Trả về view với danh sách người dùng
        }

        // GET: User/Edit/5 - Hiển thị form chỉnh sửa người dùng theo ID
        public async Task<IActionResult> Edit(int id)
        {
            // Lấy thông tin người dùng theo ID
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Nếu không tìm thấy người dùng, trả về lỗi NotFound
            }
            return View(user); // Trả về view để chỉnh sửa thông tin người dùng
        }

        // POST: User/Edit/5 - Xử lý cập nhật thông tin người dùng
        [HttpPost]
        [ValidateAntiForgeryToken] // Bảo vệ chống các tấn công CSRF
        public async Task<IActionResult> Edit(int id, Users user)
        {
            // Kiểm tra xem ID trong URL có khớp với ID người dùng không
            if (id != user.Id)
            {
                return NotFound(); // Nếu không khớp, trả về lỗi NotFound
            }

            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của model
            {
                // Gọi service để cập nhật người dùng
                var result = await _userService.UpdateUserAsync(user);
                if (result)
                {
                    return RedirectToAction(nameof(Index)); // Nếu thành công, chuyển hướng về trang danh sách người dùng
                }
                ModelState.AddModelError("", "Cập nhật người dùng không thành công."); // Nếu thất bại, hiển thị thông báo lỗi
            }
            return View(user); // Trả về view nếu có lỗi hoặc không hợp lệ
        }

        // GET: User/Delete/5 - Hiển thị form xác nhận xóa người dùng
        public async Task<IActionResult> Delete(int id)
        {
            // Lấy thông tin người dùng theo ID
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Nếu không tìm thấy người dùng, trả về lỗi NotFound
            }
            return View(user); // Trả về view xác nhận xóa người dùng
        }

        // POST: User/Delete/5 - Xử lý xóa người dùng
        [HttpPost, ActionName("Delete")] // POST yêu cầu xác nhận xóa
        [ValidateAntiForgeryToken] // Bảo vệ chống các tấn công CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Gọi service để xóa người dùng
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index)); // Nếu xóa thành công, chuyển hướng về trang danh sách người dùng
            }
            return View(); // Nếu xóa thất bại, trả về view xác nhận xóa
        }
    }
}
