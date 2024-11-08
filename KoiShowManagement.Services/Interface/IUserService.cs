using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Boolean DelUser(int Id);
        Boolean DelUser(User user);
        Boolean AddUser(User user);
        Boolean UpdUser(User user);
        Task<User> GetUserById(int Id);
    }
}
