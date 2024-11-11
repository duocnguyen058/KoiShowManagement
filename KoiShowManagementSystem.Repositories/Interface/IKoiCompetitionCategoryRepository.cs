using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories
{
    public interface IKoiCompetitionRepository
    {
        Task<List<KoiCompetitionCategory>> GetAllAsync();
        Task<KoiCompetitionCategory> GetByIdAsync(int id);
        Task AddAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task UpdateAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task DeleteAsync(int id);
    }
}
