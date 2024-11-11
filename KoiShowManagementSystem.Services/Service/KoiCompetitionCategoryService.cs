using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Service
{
    public class KoiCompetitionCategoryService : IKoiCompetitionCategoryService
    {
        private readonly IKoiCompetitionCategoryRepository _repository;

        public KoiCompetitionCategoryService(IKoiCompetitionCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KoiCompetitionCategory>> GetAllKoiCompetitionCategoriesAsync()
        {
            return await _repository.GetAllKoiCompetitionCategoriesAsync();
        }

        public async Task<KoiCompetitionCategory> GetKoiCompetitionCategoryByIdAsync(int id)
        {
            return await _repository.GetKoiCompetitionCategoryByIdAsync(id);
        }

        public async Task<bool> AddKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            return await _repository.AddKoiCompetitionCategoryAsync(koiCompetitionCategory);
        }

        public async Task<bool> UpdateKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            return await _repository.UpdateKoiCompetitionCategoryAsync(koiCompetitionCategory);
        }

        public async Task<bool> DeleteKoiCompetitionCategoryAsync(int id)
        {
            return await _repository.DeleteKoiCompetitionCategoryAsync(id);
        }

        public async Task<bool> DeleteKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            return await _repository.DeleteKoiCompetitionCategoryAsync(koiCompetitionCategory);
        }
    }
}
