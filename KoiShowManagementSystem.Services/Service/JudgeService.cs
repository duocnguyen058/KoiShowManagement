using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories;

namespace KoiShowManagementSystem.Services
{
    public class JudgeService : IJudgeService
    {
        private readonly IJudgeRepository _repository;

        public JudgeService(IJudgeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Judge>> GetAllJudgesAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Judge> GetJudgeByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task AddJudgeAsync(Judge judge)
        {
            return _repository.AddAsync(judge);
        }

        public Task UpdateJudgeAsync(Judge judge)
        {
            return _repository.UpdateAsync(judge);
        }

        public Task DeleteJudgeAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
