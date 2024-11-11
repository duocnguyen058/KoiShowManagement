using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IResultRepository
    {
        Task<bool> AddResultAsync(Result result);
        Task<bool> UpdateResultAsync(Result result);
        Task<bool> DeleteResultAsync(int resultId);
        Task<Result> GetResultByIdAsync(int resultId);
        Task<List<Result>> GetAllResultsAsync();
        Task<List<Result>> GetResultsByCompetitionIdAsync(int competitionId);
        Task<bool> DeleteResultsByCompetitionIdAsync(int competitionId); // Phương thức này thuộc IResultRepository
    }
}
