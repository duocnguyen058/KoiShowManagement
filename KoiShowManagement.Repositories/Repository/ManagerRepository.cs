using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ManagerRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Manager>> GetAllManagersAsync()
        {
            return await _dbContext.Managers.Include(m => m.Events).ToListAsync();
        }

        public async Task<Manager> GetManagerByIdAsync(int managerId)
        {
            return await _dbContext.Managers.Include(m => m.Events)
                                            .FirstOrDefaultAsync(m => m.ManagerId == managerId);
        }

        public async Task<bool> AddManagerAsync(Manager manager)
        {
            try
            {
                await _dbContext.Managers.AddAsync(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            try
            {
                _dbContext.Managers.Update(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteManagerByIdAsync(int managerId)
        {
            var manager = await GetManagerByIdAsync(managerId);
            if (manager == null) return false;
            return await DeleteManagerAsync(manager);
        }

        public async Task<bool> DeleteManagerAsync(Manager manager)
        {
            try
            {
                _dbContext.Managers.Remove(manager);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Manager>> GetManagersByDepartmentAsync(string department)
        {
            return await _dbContext.Managers.Where(m => m.Department == department).ToListAsync();
        }

        // Triển khai chức năng tìm kiếm với các tiêu chí tùy chọn
        public async Task<List<Manager>> SearchManagersAsync(string name = null, string email = null, string department = null)
        {
            var query = _dbContext.Managers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(m => m.Email.Contains(email));
            }

            if (!string.IsNullOrWhiteSpace(department))
            {
                query = query.Where(m => m.Department.Contains(department));
            }

            return await query.Include(m => m.Events).ToListAsync();
        }
    }
}
 
