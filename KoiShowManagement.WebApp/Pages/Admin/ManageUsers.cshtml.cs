using KoiShowManagement.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Admin
{
    public class ManageUsersModel : PageModel
    {
        private readonly IUserService _userService;

        // Tiêm dịch vụ UserService vào qua constructor
        public ManageUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        // Thuộc tính để lưu danh sách người dùng cho trang
        public List<Repositories.Entities.User> Users { get; set; }

        // Phương thức xử lý khi trang được truy cập qua HTTP GET
        public void OnGet()
        {
            // Lấy danh sách người dùng từ cơ sở dữ liệu hoặc dịch vụ
            Users = _userService.GetAllUsers();
        }

        // Phương thức xử lý xóa người dùng
        public IActionResult OnPostDelete(int userId)
        {
            var success = _userService.DeleteUser(userId);
            if (success)
            {
                TempData["Message"] = "Đã xóa người dùng thành công.";
            }
            else
            {
                TempData["Error"] = "Có lỗi xảy ra khi xóa người dùng.";
            }

            return RedirectToPage(); // Tải lại trang sau khi thực hiện xong
        }
    }

    public interface IUserService
    {
        bool DeleteUser(int userId);
        List<User> GetAllUsers();
    }
}
