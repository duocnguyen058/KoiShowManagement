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
        Task<bool> CreateCompetitionAsync(Competition competition);
        Task<bool> UpdateCompetitionAsync(Competition competition);
        Task<bool> DeleteCompetitionAsync(int competitionId);
        Task<bool> AddJudgeToCompetitionAsync(int competitionId, int judgeId);
        Task<bool> RemoveJudgeFromCompetitionAsync(int competitionId, int judgeId);
        Task<bool> AddRegistrationToCompetitionAsync(int competitionId, Registration registration);
        Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId);
        Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId);
        bool IsCompetitionActive(Competition competition);
    }
}
