using KoiShowManagement.Repositories.Entities;
using System;
using System.Threading.Task;
namespace KoiShowManagement.Services.Interface
{
    public interface IScoreKoiService
    {
        Task<List<ScoreKoi>> GetAllScoreKois();
        Task<bool> DelScoreKoi(int Id);
        Task<bool>  DelScoreKoi(ScoreKoi scoreKoi);
        Task<bool>  AddScoreKoi(ScoreKoi scoreKoi);
        Task<bool>  UpdScoreKoi(ScoreKoi scoreKoi);
        Task<ScoreKoi> GetScoreKoiId(int Id);
        string? GetAll();
        string? GetById(int id);
    }
}
