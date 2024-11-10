using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IReportRepository
    {
        Task<List<Report>> GetAllReportsAsync();
        Task<bool> DelReportAsync(int Id);
        Task<bool> DelReportAsync(Report report);
        Task<bool> AddReportAsync(Report report);
        Task<bool> UpdReportAsync(Report report);
        Task<Report> GetReportByIdAsync(int Id);
    }
}
