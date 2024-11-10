using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public UserRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Thêm người dùng mới
        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi thêm người dùng.", ex);
            }
        }

        // Xóa người dùng theo ID
        public async Task<bool> DelUserAsync(int Id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(Id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi xóa người dùng theo ID.", ex);
            }
        }

        // Xóa người dùng theo đối tượng User
        public async Task<bool> DelUserAsync(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi xóa người dùng.", ex);
            }
        }

        // Lấy tất cả người dùng
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        // Lấy người dùng theo ID
        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _dbContext.Users.FindAsync(Id);
        }

        // Cập nhật thông tin người dùng
        public async Task<bool> UpdUserAsync(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi cập nhật người dùng.", ex);
            }
        }

        // Đăng nhập người dùng (cần được triển khai tùy theo yêu cầu)
        public async Task<bool> LoginAsync(User user)
        {
            try
            {
                var existingUser = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
                return existingUser != null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi đăng nhập người dùng.", ex);
            }
        }

        // Đăng ký người dùng (cần được triển khai tùy theo yêu cầu)
        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                var existingUser = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    return false; // Người dùng đã tồn tại
                }

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi khi đăng ký người dùng.", ex);
            }
        }
    }
}
