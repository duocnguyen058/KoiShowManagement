using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using KoiShowManagementSystem.Repositories.Entity;

namespace KoiShowManagementSystem.Services.Services
{
    // Interface IUserService định nghĩa các phương thức cần triển khai liên quan đến người dùng
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(Users user);                      // Đăng ký người dùng mới
        Task<Users> AuthenticateUserAsync(string username, string password);  // Xác thực người dùng
        List<Users> GetUsersByRole(string role);                        // Lấy danh sách người dùng theo vai trò
        Task<Users> GetUserById(int userId);                            // Lấy thông tin người dùng theo ID
        Task<List<Users>> GetAllUsersAsync();                           // Lấy danh sách tất cả người dùng
        Task<bool> UpdateUserAsync(Users user);                         // Cập nhật thông tin người dùng
        Task<bool> DeleteUserAsync(int id);                             // Xóa người dùng
    }

    // Lớp UserService triển khai IUserService
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext; // DbContext để thao tác với cơ sở dữ liệu
        private readonly ILogger<UserService> _logger; // Logger để ghi log các thông tin lỗi hoặc cảnh báo

        // Constructor nhận vào các tham số cần thiết: ApplicationDbContext và ILogger
        public UserService(ApplicationDbContext dbContext, ILogger<UserService> logger)
        {
            _dbContext = dbContext; // Khởi tạo dbContext để truy xuất cơ sở dữ liệu
            _logger = logger; // Khởi tạo logger để ghi thông tin log
        }

        // Đăng ký người dùng mới
        public async Task<bool> RegisterUserAsync(Users user)
        {
            try
            {
                // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                if (await _dbContext.Users.AnyAsync(u => u.Username == user.Username))
                {
                    _logger.LogWarning($"Username '{user.Username}' đã tồn tại."); // Ghi log cảnh báo nếu tên đăng nhập đã tồn tại
                    return false; // Trả về false nếu tên đăng nhập đã tồn tại
                }

                // Kiểm tra mật khẩu có hợp lệ không
                if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
                {
                    _logger.LogWarning("Mật khẩu phải dài ít nhất 6 ký tự.");
                    return false; // Mật khẩu không hợp lệ
                }

                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _dbContext.Users.Add(user); // Thêm người dùng vào DbContext
                await _dbContext.SaveChangesAsync(); // Lưu vào cơ sở dữ liệu
                return true; // Đăng ký thành công
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xảy ra trong quá trình đăng ký người dùng.");
                throw new Exception("Đã xảy ra lỗi khi đăng ký người dùng.", ex); // Ném lại ngoại lệ để xử lý ở tầng cao hơn
            }
        }

        // Xác thực người dùng
        public async Task<Users> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user; // Trả về người dùng nếu mật khẩu hợp lệ
                }
                _logger.LogWarning($"Tên đăng nhập hoặc mật khẩu không đúng cho username: {username}");
                return null; // Trả về null nếu tên đăng nhập hoặc mật khẩu sai
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xảy ra trong quá trình xác thực người dùng.");
                throw new Exception("Đã xảy ra lỗi khi xác thực người dùng.", ex); // Ném lại ngoại lệ để xử lý ở tầng trên
            }
        }

        // Lấy danh sách người dùng theo vai trò
        public List<Users> GetUsersByRole(string role)
        {
            try
            {
                return _dbContext.Users.Where(u => u.Role == role).ToList(); // Lọc người dùng theo vai trò
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy danh sách người dùng với vai trò {role}.");
                throw new Exception("Đã xảy ra lỗi khi lấy danh sách người dùng theo vai trò.", ex);
            }
        }

        // Lấy thông tin người dùng theo ID
        public async Task<Users> GetUserById(int userId)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId); // Lấy người dùng theo ID
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi xảy ra khi lấy thông tin người dùng với ID {userId}.");
                throw new Exception("Đã xảy ra lỗi khi lấy thông tin người dùng theo ID.", ex);
            }
        }

        // Lấy danh sách tất cả người dùng
        public async Task<List<Users>> GetAllUsersAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync(); // Lấy tất cả người dùng
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xảy ra khi lấy danh sách tất cả người dùng.");
                throw new Exception("Đã xảy ra lỗi khi lấy danh sách tất cả người dùng.", ex);
            }
        }

        // Cập nhật thông tin người dùng
        public async Task<bool> UpdateUserAsync(Users user)
        {
            try
            {
                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    _logger.LogWarning($"Không tìm thấy người dùng với ID {user.Id}.");
                    return false; // Người dùng không tồn tại
                }

                // Cập nhật các trường dữ liệu của người dùng
                existingUser.Username = user.Username ?? existingUser.Username;
                existingUser.Password = user.Password != null ? BCrypt.Net.BCrypt.HashPassword(user.Password) : existingUser.Password;
                existingUser.Role = user.Role ?? existingUser.Role;
                existingUser.Email = user.Email ?? existingUser.Email;

                _dbContext.Users.Update(existingUser); // Cập nhật thông tin người dùng
                await _dbContext.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                return true; // Cập nhật thành công
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xảy ra trong quá trình cập nhật thông tin người dùng.");
                throw new Exception("Đã xảy ra lỗi khi cập nhật thông tin người dùng.", ex);
            }
        }

        // Xóa người dùng
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    _logger.LogWarning($"Không tìm thấy người dùng với ID {id}.");
                    return false; // Người dùng không tồn tại
                }

                _dbContext.Users.Remove(user); // Xóa người dùng khỏi DbContext
                await _dbContext.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                return true; // Xóa thành công
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi xảy ra trong quá trình xóa người dùng.");
                throw new Exception("Đã xảy ra lỗi khi xóa người dùng.", ex);
            }
        }
    }
}
