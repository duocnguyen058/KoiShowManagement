using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();  // Async method to get all users
        Task<User> GetUserByIdAsync(int id);  // Async method to get user by ID
        Task<bool> AddUserAsync(User user);  // Async method to add a user
        Task<bool> UpdUserAsync(User user);  // Async method to update a user
        Task<bool> DelUserAsync(int id);  // Async method to delete user by ID
        Task<bool> DelUserAsync(User user);  // Async method to delete user by object
        Task<bool> LoginAsync(User user);  // Async method for login
        Task<bool> RegisterAsync(User user);  // Register should be async
    }
}
