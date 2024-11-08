using KoiShowManagement.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories.Repository
{
    public class ReportRepository
    {
        private readonly KoiShowManagementDbContext _context;

        public ReportRepository(KoiShowManagementDbContext context)
        {
            _context = context;
        }

        // Retrieve all reports asynchronously
        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Reports
                .Include(r => r.CreatedByNavigation)  // Eager load CreatedByNavigation
                .ToListAsync();
        }

        // Retrieve a report by its ID asynchronously
        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports
                .Include(r => r.CreatedByNavigation) // Eager load CreatedByNavigation
                .FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        // Add a new report
        public async Task<bool> AddReportAsync(Report report)
        {
            if (report != null)
            {
                await _context.Reports.AddAsync(report);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Update an existing report
        public async Task<bool> UpdateReportAsync(Report report)
        {
            var existingReport = await _context.Reports
                .FirstOrDefaultAsync(r => r.ReportId == report.ReportId);

            if (existingReport != null)
            {
                existingReport.Title = report.Title;
                existingReport.Content = report.Content;
                existingReport.CreatedAt = report.CreatedAt;
                existingReport.CreatedBy = report.CreatedBy;

                _context.Reports.Update(existingReport);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // Delete a report by its ID
        public async Task<bool> DeleteReportByIdAsync(int reportId)
        {
            var report = await _context.Reports
                .FirstOrDefaultAsync(r => r.ReportId == reportId);

            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // Delete a specific report object
        public async Task<bool> DeleteReportAsync(Report report)
        {
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
