using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddReport(Report report)
        {
            ValidateReport(report);
            return await _repository.AddReportAsync(report);
        }

        public async Task<bool> DelReport(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID. Must be a positive integer.", nameof(id));

            return await _repository.DelReportAsync(id);
        }

        public async Task<bool> DelReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Report cannot be null.");

            return await _repository.DelReportAsync(report);
        }

        public async Task<List<Report>> GetAllReports()
        {
            return await _repository.GetAllReportsAsync();
        }

        public async Task<Report> GetReportById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID. Must be a positive integer.", nameof(id));

            return await _repository.GetReportByIdAsync(id);
        }

        public async Task<bool> UpdReport(Report report)
        {
            ValidateReport(report);
            return await _repository.UpdReportAsync(report);
        }

        private void ValidateReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Report cannot be null.");

            if (string.IsNullOrWhiteSpace(report.Title))
                throw new ArgumentException("Report title cannot be null or empty.", nameof(report.Title));

            if (report.CreatedBy.HasValue && report.CreatedBy <= 0)
                throw new ArgumentException("Invalid CreatedBy value. Must be a positive integer.", nameof(report.CreatedBy));
        }
    }
}
