using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KoiShowManagementSystem.Services;
using KoiShowManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiShowManagementSystem.Controllers
{
    public class KoiManagerController : Controller
    {
        private readonly IKoiService _koiService; // Dịch vụ để xử lý thông tin cá Koi
        private readonly ILogger<KoiManagerController> _logger; // Công cụ ghi log để ghi lại lỗi hoặc thông tin

        // Constructor nhận các dịch vụ cần thiết qua Dependency Injection
        public KoiManagerController(IKoiService koiService, ILogger<KoiManagerController> logger)
        {
            this._koiService = koiService;
            this._logger = logger;
        }

        // GET: KoiManagerController
        // Hiển thị danh sách cá Koi thuộc sở hữu của người dùng hiện tại
        public IActionResult Index(string search = "")
        {
            var userId = GetUserId(); // Lấy ID người dùng hiện tại
            if (userId == null) return Unauthorized(); // Kiểm tra quyền truy cập

            var koiList = _koiService.GetKoiByUserId(userId.Value); // Lấy danh sách cá Koi của người dùng

            // Lọc danh sách cá Koi theo tên hoặc giống (nếu có từ khóa tìm kiếm)
            if (!string.IsNullOrEmpty(search))
            {
                koiList = koiList.Where(k => k.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                             k.Variety.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Hiển thị thông báo nếu danh sách trống
            if (!koiList.Any())
            {
                ViewBag.Message = "Chưa có hồ sơ cá Koi nào. Bạn có thể thêm cá Koi mới.";
            }

            return View(koiList); // Trả về danh sách cá Koi
        }

        // GET: KoiManagerController/IndexMng
        // Hiển thị danh sách tất cả cá Koi (chỉ dành cho quản trị viên)
        [HttpGet]
        public IActionResult IndexMng(string search = "")
        {
            if (!User.IsInRole("ADMIN")) // Kiểm tra quyền admin
            {
                return Unauthorized(); // Trả về lỗi nếu không phải admin
            }

            var koiList = _koiService.GetAllKoi(); // Lấy tất cả cá Koi

            // Lọc danh sách cá Koi theo tên hoặc giống
            if (!string.IsNullOrEmpty(search))
            {
                koiList = koiList.Where(k => k.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                             k.Variety.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(koiList); // Trả về danh sách cá Koi
        }

        // GET: KoiManagerController/Details/5
        // Hiển thị chi tiết một cá Koi
        public ActionResult Details(int id)
        {
            var koi = _koiService.GetKoiById(id); // Lấy cá Koi theo ID
            if (koi == null || !CanAccessKoi(koi)) // Kiểm tra quyền truy cập
            {
                return NotFound(); // Trả về lỗi nếu không tìm thấy hoặc không có quyền
            }

            return View(koi); // Trả về thông tin cá Koi
        }

        // GET: KoiManagerController/Create
        // Hiển thị form tạo mới cá Koi
        public ActionResult Create() => View();

        // POST: KoiManagerController/Create
        // Xử lý logic tạo mới cá Koi
        [HttpPost]
        public async Task<IActionResult> Create(Koi koi, IFormFile? photo)
        {
            var userId = GetUserId(); // Lấy ID người dùng hiện tại
            if (userId == null) return Unauthorized(); // Kiểm tra quyền truy cập

            koi.UsersId = userId.Value; // Gắn ID người dùng vào cá Koi

            // Kiểm tra và lưu ảnh nếu được tải lên
            if (photo != null && !IsValidPhoto(photo))
            {
                return View(koi); // Trả về lỗi nếu ảnh không hợp lệ
            }

            if (photo != null)
            {
                koi.PhotoPath = await SavePhotoAsync(photo); // Lưu ảnh và lấy đường dẫn
            }

            if (ModelState.IsValid) // Kiểm tra dữ liệu hợp lệ
            {
                try
                {
                    _koiService.CreateKoi(koi); // Thêm cá Koi vào cơ sở dữ liệu
                    TempData["SuccessMessage"] = "Cá Koi đã được thêm thành công!"; // Thông báo thành công
                    return RedirectToAction(nameof(Index)); // Quay lại trang danh sách
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while creating Koi: {ex.Message}"); // Ghi lại lỗi
                    ModelState.AddModelError("", "Có lỗi xảy ra khi tạo cá Koi. Vui lòng thử lại."); // Hiển thị lỗi cho người dùng
                }
            }

            return View(koi); // Nếu có lỗi, trả về form tạo mới
        }

        // GET: KoiManagerController/Edit/5
        // Hiển thị form chỉnh sửa cá Koi
        public IActionResult Edit(int id)
        {
            var koi = _koiService.GetKoiById(id); // Lấy cá Koi theo ID
            if (koi == null || koi.UsersId != GetUserId()) return NotFound(); // Kiểm tra quyền truy cập

            ViewBag.RegistrationStatuses = GetRegistrationStatuses(); // Gửi danh sách trạng thái đăng ký tới view

            return View(koi); // Trả về thông tin cá Koi để chỉnh sửa
        }

        // POST: KoiManagerController/Edit/5
        // Xử lý logic cập nhật thông tin cá Koi
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Koi koi, IFormFile? photo)
        {
            var currentUserId = GetUserId(); // Lấy ID người dùng hiện tại
            if (currentUserId == null) return Unauthorized(); // Kiểm tra quyền truy cập

            var existingKoi = _koiService.GetKoiById(id); // Lấy cá Koi từ cơ sở dữ liệu
            if (existingKoi == null || existingKoi.UsersId != currentUserId) return Unauthorized(); // Kiểm tra quyền

            // Cập nhật thông tin cá Koi
            existingKoi.Name = koi.Name;
            existingKoi.Variety = koi.Variety;
            existingKoi.Size = koi.Size;
            existingKoi.Age = koi.Age;
            existingKoi.RegistrationStatus = koi.RegistrationStatus;

            // Kiểm tra và xử lý ảnh mới
            if (photo != null && !IsValidPhoto(photo))
            {
                return View(koi);
            }

            if (photo != null)
            {
                existingKoi.PhotoPath = await SavePhotoAsync(photo); // Lưu ảnh mới
            }

            if (ModelState.IsValid) // Kiểm tra dữ liệu hợp lệ
            {
                try
                {
                    _koiService.UpdateKoi(existingKoi); // Cập nhật cá Koi
                    TempData["SuccessMessage"] = "Cá Koi đã được cập nhật thành công!"; // Thông báo thành công
                    return RedirectToAction(nameof(Index)); // Quay lại trang danh sách
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while updating Koi: {ex.Message}"); // Ghi lại lỗi
                    ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật cá Koi. Vui lòng thử lại."); // Hiển thị lỗi
                }
            }

            ViewBag.RegistrationStatuses = GetRegistrationStatuses(); // Gửi lại trạng thái đăng ký tới view

            return View(koi); // Nếu có lỗi, trả về form chỉnh sửa
        }

        // POST: KoiManagerController/Delete/5
        // Xử lý logic xóa cá Koi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var koi = _koiService.GetKoiById(id); // Lấy cá Koi theo ID
            if (koi == null || koi.UsersId != GetUserId()) return NotFound(); // Kiểm tra quyền

            try
            {
                _koiService.DeleteKoi(id); // Xóa cá Koi
                TempData["SuccessMessage"] = "Cá Koi đã được xóa thành công!"; // Thông báo thành công
                return RedirectToAction(nameof(Index)); // Quay lại trang danh sách
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting Koi: {ex.Message}"); // Ghi lại lỗi
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa cá Koi. Vui lòng thử lại."; // Hiển thị lỗi
                return RedirectToAction(nameof(Index)); // Quay lại trang danh sách
            }
        }

        // Hàm hỗ trợ kiểm tra định dạng và kích thước ảnh
        private bool IsValidPhoto(IFormFile photo)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" }; // Định dạng cho phép
            var fileExtension = Path.GetExtension(photo.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("photo", "Chỉ cho phép tải lên các định dạng ảnh: .jpg, .jpeg, .png");
                return false;
            }

            if (photo.Length > 5 * 1024 * 1024)  // Kích thước tối đa 5 MB
            {
                ModelState.AddModelError("photo", "Kích thước ảnh không được vượt quá 5 MB");
                return false;
            }

            return true;
        }

        // Hàm hỗ trợ lưu ảnh và trả về đường dẫn
        private async Task<string> SavePhotoAsync(IFormFile photo)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads"); // Thư mục lưu ảnh
            Directory.CreateDirectory(uploadsFolder); // Tạo thư mục nếu chưa tồn tại
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName); // Tạo tên file duy nhất
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            return "/uploads/" + uniqueFileName; // Trả về đường dẫn ảnh
        }

        // Hàm hỗ trợ lấy ID người dùng hiện tại
        private int? GetUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier); // Lấy claim ID người dùng
            return string.IsNullOrEmpty(userIdClaim) ? (int?)null : int.Parse(userIdClaim);
        }

        // Hàm kiểm tra quyền truy cập cá Koi
        private bool CanAccessKoi(Koi koi)
        {
            var userId = GetUserId();
            return userId != null && (User.IsInRole("ADMIN") || koi.UsersId == userId.Value); // Kiểm tra quyền admin hoặc sở hữu
        }

        // Hàm hỗ trợ lấy danh sách trạng thái đăng ký
        private List<SelectListItem> GetRegistrationStatuses()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Hoạt động", Text = "Hoạt động" },
                new SelectListItem { Value = "Tạm ngừng", Text = "Tạm ngừng" },
                new SelectListItem { Value = "Ngừng hoạt động", Text = "Ngừng hoạt động" }
            };
        }
    }
}
