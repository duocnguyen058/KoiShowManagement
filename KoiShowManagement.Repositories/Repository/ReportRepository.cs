using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ReportRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddReportAsync(Report report)
        {
            try
            {
                await _dbContext.Reports.AddAsync(report);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding report.", ex);
            }
        }

        public async Task<bool> DelReportAsync(int Id)
        {
            try
            {
                var report = await _dbContext.Reports.FindAsync(Id);
                if (report != null)
                {
                    _dbContext.Reports.Remove(report);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting report by Id.", ex);
            }
        }

        public async Task<bool> DelReportAsync(Report report)
        {
            try
            {
                _dbContext.Reports.Remove(report);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting report.", ex);
            }
        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _dbContext.Reports.ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(int Id)
        {
            return await _dbContext.Reports.FindAsync(Id);
        }

        public async Task<bool> UpdReportAsync(Report report)
        {
            try
            {
                _dbContext.Reports.Update(report);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating report.", ex);
            }
        }
    }
}
