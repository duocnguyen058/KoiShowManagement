using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IScoreKoiRepository
    {
        Task<List<ScoreKoi>> GetAllScoreKois();
        Boolean DelScoreKoi(int Id);
        Boolean DelScoreKoi(ScoreKoi scoreKoi);
        Boolean AddScoreKoi(ScoreKoi scoreKoi);
        Boolean UpdScoreKoi(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiById(int id);
    }
}
