using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Service
{
    public class JudgeService : IJudgeService
    {
        private readonly IJudgeRepository _judgeRepository;

        public JudgeService(IJudgeRepository judgeRepository)
        {
            _judgeRepository = judgeRepository;
        }

        public async Task<List<Judge>> GetAllJudgesAsync()
        {
            return await _judgeRepository.GetAllJudgesAsync();
        }

        public async Task<Judge> GetJudgeByIdAsync(int id)
        {
            return await _judgeRepository.GetJudgeByIdAsync(id);
        }

        public async Task<bool> AddJudgeAsync(Judge judge)
        {
            return await _judgeRepository.AddJudgeAsync(judge);
        }

        public async Task<bool> UpdateJudgeAsync(Judge judge)
        {
            return await _judgeRepository.UpdateJudgeAsync(judge);
        }

        public async Task<bool> DeleteJudgeAsync(int id)
        {
            return await _judgeRepository.DeleteJudgeAsync(id);
        }

        public async Task<bool> DeleteJudgeAsync(Judge judge)
        {
            return await _judgeRepository.DeleteJudgeAsync(judge);
        }
    }
}
