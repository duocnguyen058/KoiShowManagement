using KoiShowManagement.Repositories.Entities;
using System;
namespace KoiShowManagement.Services.Interface
{
    public interface IScoreKoiService
    {
        Task<List<ScoreKoi>> GetAllScoreKois();
        Boolean DelScoreKoi(int Id);
        Boolean DelScoreKoi(ScoreKoi scoreKoi);
        Boolean AddScoreKoi(ScoreKoi scoreKoi);
        Boolean UpdScoreKoi(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiId(int Id);
    }
}
