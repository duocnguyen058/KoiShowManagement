using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Boolean DelUser(int Id);
        Boolean DelUser(User user);
        Boolean AddUser(User user);
        Boolean UpdUser(User user);
        Task<User> GetUserById(int Id);
    }
}
