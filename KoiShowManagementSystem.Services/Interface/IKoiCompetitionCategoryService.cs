using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services
{
    public interface IKoiCompetitionCategoryService
    {
        Task<List<KoiCompetitionCategory>> GetAllCategoriesAsync();
        Task<KoiCompetitionCategory> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task UpdateCategoryAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task DeleteCategoryAsync(int id);
    }
}
