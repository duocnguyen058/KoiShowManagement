using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync(); // Lấy danh sách tất cả người dùng
        Task<bool> DelUserAsync(int Id); // Xóa người dùng theo ID
        Task<bool> DelUserAsync(User user); // Xóa người dùng theo đối tượng
        Task<bool> AddUserAsync(User user); // Thêm người dùng mới
        Task<bool> UpdUserAsync(User user); // Cập nhật người dùng
        Task<User> GetUserByIdAsync(int Id); // Lấy người dùng theo ID
        Task<bool> LoginAsync(User user); // Đăng nhập
        Task<bool> RegisterAsync(User user); // Đăng ký
    }
}
