using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface IScoreService
    {
        Task<Score> GetScoreByIdAsync(int scoreId);
        Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId);
        Task CreateScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int scoreId);
        Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId);
        Task<IEnumerable<Score>> GetScoresByKoiFishAsync(int koiFishId);
        bool IsScoreValid(Score score);
    }
}
