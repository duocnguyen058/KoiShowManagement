using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services
{
    public interface IJudgeService
    {
        Task<List<Judge>> GetAllJudgesAsync();
        Task<Judge> GetJudgeByIdAsync(int id);
        Task AddJudgeAsync(Judge judge);
        Task UpdateJudgeAsync(Judge judge);
        Task DeleteJudgeAsync(int id);
    }
}
