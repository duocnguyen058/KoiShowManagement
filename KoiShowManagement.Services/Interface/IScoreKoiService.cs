using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IScoreKoiService
    {
        Task<List<ScoreKoi>> GetAllScoreKoisAsync();
        Task<ScoreKoi> GetScoreKoiByIdAsync(int scoreId);
        Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> DelScoreKoiAsync(int scoreId);
        Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi);
    }
}
