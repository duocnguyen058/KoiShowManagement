using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IScoreKoiRepository
    {
        Task<List<ScoreKoi>> GetScoreKoisAsync();
        Task<bool> DelScoreKoiAsync(int Id);
        Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiByIdAsync(int Id);
    }
}
