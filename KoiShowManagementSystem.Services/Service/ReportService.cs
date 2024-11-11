using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        // Khởi tạo ReportService với IReportRepository thông qua Dependency Injection
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // Tạo báo cáo mới
        public async Task<bool> CreateReportAsync(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không thể là null");

            // Cập nhật thời gian tạo báo cáo
            report.CreatedAt = DateTime.Now;
            return await _reportRepository.AddReportAsync(report);
        }

        // Cập nhật báo cáo
        public async Task<bool> UpdateReportAsync(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không thể là null");

            return await _reportRepository.UpdateReportAsync(report);
        }

        // Xóa báo cáo theo ID
        public async Task<bool> DeleteReportAsync(int reportId)
        {
            return await _reportRepository.DeleteReportAsync(reportId);
        }

        // Lấy báo cáo theo ID
        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            var report = await _reportRepository.GetReportByIdAsync(reportId);
            if (report == null)
                throw new KeyNotFoundException($"Không tìm thấy báo cáo với ID {reportId}");

            return report;
        }

        // Lấy tất cả các báo cáo
        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllReportsAsync();
        }

        // Lấy báo cáo theo ID cuộc thi
        public async Task<IEnumerable<Report>> GetReportsForCompetitionAsync(int competitionId)
        {
            return await _reportRepository.GetReportsByCompetitionIdAsync(competitionId);
        }
    }
}
