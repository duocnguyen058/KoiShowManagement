using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories;

namespace KoiShowManagementSystem.Services
{
    public class KoiCompetitionCategoryService : IKoiCompetitionCategoryService
    {
        private readonly IKoiCompetitionCategoryRepository _repository;

        public KoiCompetitionCategoryService(IKoiCompetitionCategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<List<KoiCompetitionCategory>> GetAllCategoriesAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<KoiCompetitionCategory> GetCategoryByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            return _repository.AddAsync(koiCompetitionCategory);
        }

        public Task UpdateCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            return _repository.UpdateAsync(koiCompetitionCategory);
        }

        public Task DeleteCategoryAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
