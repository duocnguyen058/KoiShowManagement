using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IScoreRepository
    {
        Task<Score> GetScoreByIdAsync(int scoreId);
        Task<IEnumerable<Score>> GetScoresByCompetitionIdAsync(int competitionId);
        Task<IEnumerable<Score>> GetScoresByKoiFishIdAsync(int koiFishId);
        Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId);
        Task CreateScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int scoreId);
    }
}
