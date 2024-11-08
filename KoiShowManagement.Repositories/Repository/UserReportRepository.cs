using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class UserReportRepository : IUserReportRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public UserReportRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUserReport(UserReport userReport)
        {
            try
            {
                _dbContext.UserReports.Add(userReport);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding UserReport: {ex.Message}");
                return false;
            }
        }

        public bool DelUserReport(int id)
        {
            try
            {
                var objDel = _dbContext.UserReports.FirstOrDefault(p => p.Id == id);
                if (objDel != null)
                {
                    _dbContext.UserReports.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting UserReport by Id: {ex.Message}");
                return false;
            }
        }

        public bool DelUserReport(UserReport userReport)
        {
            try
            {
                _dbContext.UserReports.Remove(userReport);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting UserReport: {ex.Message}");
                return false;
            }
        }

        public async Task<List<UserReport>> GetAllUserReport()
        {
            try
            {
                return await _dbContext.UserReports.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all UserReports: {ex.Message}");
                return new List<UserReport>();
            }
        }

        public async Task<UserReport> GetUserReportById(int id)
        {
            try
            {
                return await _dbContext.UserReports.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving UserReport by Id: {ex.Message}");
                return null;
            }
        }

        public bool UpdUserReport(UserReport userReport)
        {
            try
            {
                _dbContext.UserReports.Update(userReport);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating UserReport: {ex.Message}");
                return false;
            }
        }
    }
}
