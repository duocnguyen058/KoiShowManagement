using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<bool> DelUser(int Id);
        Task<bool> DelUser(User user);
        Task<bool> AddUser(User user);
        Task<bool> UpdUser(User user);
        Task<User> GetUserById(int Id);
    }
}
