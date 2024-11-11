using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories
{
    public interface IJudgeRepository
    {
        Task<List<Judge>> GetAllAsync();
        Task<Judge> GetByIdAsync(int id);
        Task AddAsync(Judge judge);
        Task UpdateAsync(Judge judge);
        Task DeleteAsync(int id);
    }
}
