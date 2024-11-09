using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class UserReportRepository : IUserReportRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public UserReportRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserReportAsync(UserReport userReport)
        {
            try
            {
                await _dbContext.UserReports.AddAsync(userReport);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteUserReportAsync(int id)
        {
            try
            {
                var userReport = await _dbContext.UserReports.FirstOrDefaultAsync(ur => ur.UserReportId == id);
                if (userReport != null)
                {
                    _dbContext.UserReports.Remove(userReport);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteUserReportAsync(UserReport userReport)
        {
            try
            {
                _dbContext.UserReports.Remove(userReport);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<UserReport>> GetAllUserReportsAsync()
        {
            return await _dbContext.UserReports.ToListAsync();
        }

        public async Task<UserReport> GetUserReportByIdAsync(int id)
        {
            return await _dbContext.UserReports.FirstOrDefaultAsync(ur => ur.UserReportId == id);
        }

        public async Task<bool> UpdateUserReportAsync(UserReport userReport)
        {
            try
            {
                _dbContext.UserReports.Update(userReport);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
