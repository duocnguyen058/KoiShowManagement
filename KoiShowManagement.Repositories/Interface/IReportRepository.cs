using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IReportRepository
    {
        Task<List<Report>> GetAllReports();
        Boolean DelReport(int Id);
        Boolean DelReport(Report report);
        Boolean AddReport(Report report);
        Boolean UpdReport(Report report);
        Task<Report> GetReportById(int Id);
    }
}
