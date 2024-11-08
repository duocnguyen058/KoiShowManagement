using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IScoreKoiRepository
    {
        Task<List<ScoreKoi>> GetAllScoreKoi();
        Boolean DelScoreKoi(int Id);
        Boolean DelScoreKoi(ScoreKoi scoreKoi);
        Boolean AddScoreKoi(ScoreKoi scoreKoi);
        Boolean UpdScoreKoi(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiId(int Id);
    }
}
