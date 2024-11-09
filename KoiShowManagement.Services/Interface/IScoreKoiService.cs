using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IScoreKoiService
    {
        Task<List<ScoreKoi>> GetAllScoreKoisAsync();
        Task<bool> DeleteScoreKoiAsync(int Id);
        Task<bool> DeleteScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> UpdateScoreKoiAsync(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiByIdAsync(int Id);
    }
}
