using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface ICompetitionService
    {
        Task<Competition> GetCompetitionByIdAsync(int competitionId);
        Task<IEnumerable<Competition>> GetAllCompetitionsAsync();
        Task CreateCompetitionAsync(Competition competition);
        Task UpdateCompetitionAsync(Competition competition);
        Task DeleteCompetitionAsync(int competitionId);
        Task AddJudgeToCompetitionAsync(int competitionId, int judgeId);
        Task RemoveJudgeFromCompetitionAsync(int competitionId, int judgeId);
        Task AddRegistrationToCompetitionAsync(int competitionId, Registration registration);
        Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId);
        Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId);
        bool IsCompetitionActive(Competition competition);
    }
}
