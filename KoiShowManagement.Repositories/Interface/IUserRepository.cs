using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> DelUserAsync(int Id);
        Task<bool> DelUserAsync(User user);
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdUserAsync(User user);
        Task<User> GetUserByIdAsync(int Id);
    }
}
