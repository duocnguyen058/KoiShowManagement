using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public ReportRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReportAsync(Report report)
        {
            if (report == null) return false;

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateReportAsync(Report report)
        {
            if (report == null) return false;

            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report == null) return false;

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<List<Report>> GetReportsByCompetitionIdAsync(int competitionId)
        {
            return await _context.Reports
                                 .Where(r => r.CompetitionId == competitionId)
                                 .ToListAsync();
        }
    }
}
