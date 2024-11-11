using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IJudgeRepository
    {
        Task<List<Judge>> GetAllJudgesAsync();
        Task<Judge> GetJudgeByIdAsync(int id);
        Task<bool> AddJudgeAsync(Judge judge);
        Task<bool> UpdateJudgeAsync(Judge judge);
        Task<bool> DeleteJudgeAsync(int id);
        Task<bool> DeleteJudgeAsync(Judge judge);
    }
}
