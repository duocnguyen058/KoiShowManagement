using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface IScoreService
    {
        Task<Score> GetScoreByIdAsync(int scoreId);
        Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId);
        Task<bool> CreateScoreAsync(Score score);
        Task<bool> UpdateScoreAsync(Score score);
        Task<bool> DeleteScoreAsync(int scoreId);
        Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId);
        Task<IEnumerable<Score>> GetScoresByKoiFishAsync(int koiFishId);
        bool IsScoreValid(Score score);
    }
}
