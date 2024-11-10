using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            ValidateUser(user);
            return await _repository.AddUserAsync(user);
        }

        public async Task<bool> DelUserAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ. ID phải là số nguyên dương.", nameof(id));

            return await _repository.DelUserAsync(id);
        }

        public async Task<bool> DelUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Người dùng không thể là null.");

            return await _repository.DelUserAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ. ID phải là số nguyên dương.", nameof(id));

            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<bool> UpdUserAsync(User user)
        {
            ValidateUser(user);
            return await _repository.UpdUserAsync(user);
        }

        public async Task<bool> LoginAsync(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Thông tin đăng nhập không hợp lệ.", nameof(user));

            return await _repository.LoginAsync(user);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            // Xử lý đăng ký tại đây (ví dụ: kiểm tra nếu tên người dùng đã tồn tại)
            return await _repository.RegisterAsync(user);
        }

        private void ValidateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Người dùng không thể là null.");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Tên người dùng không thể để trống hoặc chứa khoảng trắng.", nameof(user.Username));

            if (user.UserId <= 0)
                throw new ArgumentException("ID người dùng phải là số nguyên dương.", nameof(user.UserId));

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Mật khẩu không thể để trống hoặc chứa khoảng trắng.", nameof(user.Password));

            if (!string.IsNullOrWhiteSpace(user.Role) && user.Role.Length < 3)
                throw new ArgumentException("Chức vụ phải dài ít nhất 3 ký tự.", nameof(user.Role));
        }
    }
}
