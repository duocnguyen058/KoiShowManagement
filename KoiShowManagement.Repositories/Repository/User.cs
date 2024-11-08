using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class UserRepository
    {
        private readonly KoiShowManagementDbContext _context;

        public UserRepository(KoiShowManagementDbContext context)
        {
            _context = context;
        }

        // Retrieves all users asynchronously from the database
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Retrieves a user by their UserId asynchronously
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // Adds a new user to the database
        public async Task<bool> AddUserAsync(User user)
        {
            if (user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Updates an existing user
        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                existingUser.CreatedAt = user.CreatedAt;

                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Deletes a user by their UserId
        public async Task<bool> DeleteUserByIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Deletes a specific user
        public async Task<bool> DeleteUserAsync(User user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
