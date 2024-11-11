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
        Task<bool> CreateScoreAsync(Score score);
        Task<bool> UpdateScoreAsync(Score score);
        Task<bool> DeleteScoreAsync(int scoreId);
        Task DeleteScoresByCompetitionIdAsync(int competitionId);
    }
}
