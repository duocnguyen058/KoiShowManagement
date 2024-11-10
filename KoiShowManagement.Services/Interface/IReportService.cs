using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IReportService
    {
        Task<List<Report>> GetAllReports();
        Task<bool> DelReport(int Id);
        Task<bool> DelReport(Report report);
        Task<bool> AddReport(Report report);
        Task<bool> UpdReport(Report report);
        Task<Report> GetReportById(int Id);
    }
}
