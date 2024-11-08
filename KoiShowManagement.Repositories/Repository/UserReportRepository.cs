using System;
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
            }catch(Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
            
        }

        public bool DelUserReport(int Id)
        {
            try
            {
                var objDel = _dbContext.UserReports.Where(p => p.UserReportId.Equals(Id)).FirstOrDefault();
                if(objDel != null)
                {
                    _dbContext.UserReports.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                throw new NotImplementedException();
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
            }catch(Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
            throw new NotImplementedException();
        }

        public async Task<List<UserReport>> GetAllUserReport()
        {
            return await _dbContext.UserReports.ToListAsync();
        }

        public async Task<UserReport> GetUserReportById(int Id)
        {
            return await _dbContext.UserReports.Where(p => p.UserReportId.Equals(Id)).FirstOrDefaultAsync();
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
                throw new NotImplementedException();
                return false;
            }
        }
    }
}

