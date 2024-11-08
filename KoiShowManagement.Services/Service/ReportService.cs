using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Repositories.Repository;
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

        public bool AddReport(Report report)
        {
            return _repository.AddReport(report);
        }

        public bool DelReport(int Id)
        {
            return _repository.DelReport(Id);
        }

        public bool DelReport(Report report)
        {
            return _repository.DelReport(report);
        }

        public Task<List<Report>> GetAllReports()
        {
            return _repository.GetAllReports();
        }

        public Task<Report> GetReportById(int Id)
        {
            return _repository.GetReportById(Id);
        }

        public bool UpdReport(Report report)
        {
            return _repository.UpdReport(report);
        }
    }
}
