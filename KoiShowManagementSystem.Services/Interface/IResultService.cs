using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.CompetitionService
{
    public interface IResultService
    {
        Task<bool> CreateResultAsync(Result result);
        Task<bool> UpdateResultAsync(Result result);
        Task<bool> DeleteResultAsync(int resultId);
        Task<Result> GetResultByIdAsync(int resultId);
        Task<IEnumerable<Result>> GetAllResultsAsync();
        Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId);
        Task<List<Result>> SearchResultsAsync(int? koiFishId, int? competitionId);
    }
}
