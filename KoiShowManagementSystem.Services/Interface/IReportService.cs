using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.CompetitionService
{
    public interface IReportService
    {
        Task<bool> CreateReportAsync(Report report);
        Task<bool> UpdateReportAsync(Report report);
        Task<bool> DeleteReportAsync(int reportId);
        Task<Report> GetReportByIdAsync(int reportId);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<IEnumerable<Report>> GetReportsForCompetitionAsync(int competitionId);
    }
}
