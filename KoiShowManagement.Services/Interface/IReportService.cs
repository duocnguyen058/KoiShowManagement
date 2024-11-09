using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IReportService
    {
        Task<List<Report>> GetAllReports();
        Boolean DelReport(int Id);
        Boolean DelReport(Report report);
        Boolean AddReport(Report report);
        Boolean UpdReport(Report report);
        Task<Report> GetReportById(int Id);
    }
}
