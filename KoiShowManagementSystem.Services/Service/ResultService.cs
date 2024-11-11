using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;

namespace KoiShowManagementSystem.Services.Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public async Task<bool> CreateResultAsync(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Result cannot be null");

            return await _resultRepository.AddResultAsync(result);
        }

        public async Task<bool> UpdateResultAsync(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Result cannot be null");

            return await _resultRepository.UpdateResultAsync(result);
        }

        public async Task<bool> DeleteResultAsync(int resultId)
        {
            return await _resultRepository.DeleteResultAsync(resultId);
        }

        public async Task<Result> GetResultByIdAsync(int resultId)
        {
            var result = await _resultRepository.GetResultByIdAsync(resultId);
            if (result == null)
                throw new KeyNotFoundException($"Result with ID {resultId} not found.");

            return result;
        }

        public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            return await _resultRepository.GetAllResultsAsync();
        }

        public async Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId)
        {
            return await _resultRepository.GetResultsByCompetitionIdAsync(competitionId);
        }
    }
}
