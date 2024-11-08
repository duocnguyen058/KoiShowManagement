using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KoiShowManagement.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public ReportRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddReport(Report report)
        {
            try
            {
                _dbContext.Reports.Add(report);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelReport(int Id)
        {
            try
            {
                var objDel = _dbContext.Reports.Where(r => r.ReportId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Reports.Remove(objDel);
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

        public bool DelReport(Report report)
        {
            try
            {
                _dbContext.Reports.Remove(report);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<Report>> GetAllReports()
        {
            return await _dbContext.Reports.ToListAsync();
        }

        public async Task<Report> GetReportById(int Id)
        {
            return await _dbContext.Reports.Where(r => r.ReportId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdReport(Report report)
        {
            try
            {
                _dbContext.Reports.Update(report);
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
