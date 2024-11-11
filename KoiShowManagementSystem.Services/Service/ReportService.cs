using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;

namespace KoiShowManagementSystem.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<bool> CreateReportAsync(Report report)
        {
            if (report == null) throw new ArgumentNullException(nameof(report), "Report cannot be null");

            report.CreatedAt = DateTime.Now;
            return await _reportRepository.AddReportAsync(report);
        }

        public async Task<bool> UpdateReportAsync(Report report)
        {
            if (report == null) throw new ArgumentNullException(nameof(report), "Report cannot be null");

            return await _reportRepository.UpdateReportAsync(report);
        }

        public async Task<bool> DeleteReportAsync(int reportId)
        {
            return await _reportRepository.DeleteReportAsync(reportId);
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            var report = await _reportRepository.GetReportByIdAsync(reportId);
            if (report == null)
                throw new KeyNotFoundException($"Report with ID {reportId} not found.");

            return report;
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllReportsAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsForCompetitionAsync(int competitionId)
        {
            return await _reportRepository.GetReportsByCompetitionIdAsync(competitionId);
        }
    }
}
