using System;
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

        public bool AddUser(User user)
        {
            return _repository.AddUser(user);
        }

        public bool DelUser(int Id)
        {
            return _repository.DelUser(Id);
        }

        public bool DelUser(User user)
        {
            return _repository.DelUser(user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public Task<User> GetUserById(int Id)
        {
            return _repository.GetUserById(Id);
        }

        public bool UpdUser(User user)
        {
            return _repository.UpdUser(user);
        }
    }
}
