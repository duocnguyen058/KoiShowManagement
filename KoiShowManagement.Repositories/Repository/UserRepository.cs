using System;
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

        public bool AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelUser(int Id)
        {
            try
            {
                var objDel = _dbContext.Users.Where(u => u.UserId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Users.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelUser(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _dbContext.Users.Where(u => u.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdUser(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }
    }
}
