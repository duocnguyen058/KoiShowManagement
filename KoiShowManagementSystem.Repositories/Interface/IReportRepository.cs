using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IReportRepository
    {
        Task<bool> AddReportAsync(Report report);
        Task<bool> UpdateReportAsync(Report report);
        Task<bool> DeleteReportAsync(int reportId);
        Task<Report> GetReportByIdAsync(int reportId);
        Task<List<Report>> GetAllReportsAsync();
        Task<List<Report>> GetReportsByCompetitionIdAsync(int competitionId);
    }
}
