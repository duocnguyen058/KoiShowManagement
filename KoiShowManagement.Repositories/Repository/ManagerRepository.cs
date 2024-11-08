using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    internal class ManagerRepository : IManagerRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public ManagerRepository (KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddManager(Manager manager)
        {
            try
            {
                _dbContext.Managers.Add(manager);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelManager(int Id)
        {
            try
            {
                var objDel = _dbContext.Managers.Where(p => p.ManagerId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Managers.Remove(objDel);
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

        public bool DelManager(Manager manager)
        {
            try
            {
                _dbContext.Managers.Remove(manager);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<Manager> ManagerById(int Id)
        {
            return await _dbContext.Managers.Where(p => p.ManagerId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Manager>> GetAllManagers()
        {
            return await _dbContext.Managers.ToListAsync();
        }

        public bool UpdManager(Manager manager)
        {
            try
            {
                _dbContext.Managers.Update(manager);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }

        }
        Task<Manager> IManagerRepository.GetManagerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manager>> GetAllManager()
        {
            throw new NotImplementedException();
        }
    }
}
