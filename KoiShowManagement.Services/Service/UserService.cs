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

        public async Task<bool> AddUser(User user)
        {
            ValidateUser(user);
            return await _repository.AddUserAsync(user);
        }

        public async Task<bool> DelUser(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID. Must be a positive integer.", nameof(id));

            return await _repository.DelUserAsync(id);
        }

        public async Task<bool> DelUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            return await _repository.DelUserAsync(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID. Must be a positive integer.", nameof(id));

            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<bool> UpdUser(User user)
        {
            ValidateUser(user);
            return await _repository.UpdUserAsync(user);
        }

        private void ValidateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(user.Username));

            if (user.UserId <= 0)
                throw new ArgumentException("User ID must be a positive integer.", nameof(user.UserId));

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password cannot be null or empty.", nameof(user.Password));

            if (!string.IsNullOrWhiteSpace(user.Role) && user.Role.Length < 3)
                throw new ArgumentException("Role must be at least 3 characters long.", nameof(user.Role));
        }
    }
}
