using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IScoreKoiService
    {
        Task<List<ScoreKoi>> GetAllScoreKoisAsync();  // Return List<ScoreKoi> as Task
        Task<ScoreKoi> GetScoreKoiByIdAsync(int scoreId);  // Return ScoreKoi as Task
        Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi);  // Async method for adding score
        Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi);  // Async method for updating score
        Task<bool> DelScoreKoiAsync(int scoreId);  // Async method for deleting by score ID
        Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi);  // Async method for deleting by ScoreKoi object
    }
}
