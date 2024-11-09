using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IScoreKoiRepository
    {
        Task<List<ScoreKoi>> GetAllScoreKois();
        Task<ScoreKoi> GetScoreKoiById(int Id);
        Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi);
        Task<bool> DeleteScoreKoiAsync(int Id);
        Task<bool> DeleteScoreKoiAsync(ScoreKoi scoreKoi);
        Task<List<ScoreKoi>> GetAllScoreKoisAsync();
        Task<ScoreKoi> GetScoreKoiByIdAsync(int Id);
        Task<bool> UpdateScoreKoiAsync(ScoreKoi scoreKoi);
    }
}
