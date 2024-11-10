using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface ICompetitionResultService
    {
        Task<List<CompetitionResult>> GetAllCompetitionResultsAsync();
        Task<CompetitionResult> GetCompetitionResultByIdAsync(int id);
        Task<bool> AddCompetitionResultAsync(CompetitionResult result);
        Task<bool> UpdCompetitionResultAsync(CompetitionResult result);
        Task<bool> DelCompetitionResultAsync(int id);
        Task<bool> DelCompetitionResultAsync(CompetitionResult result);
    }
}
