using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;
using KoiShowManagementSystem.Services.Interface;
using Microsoft.Extensions.Logging;

namespace KoiShowManagementSystem.Services.Service
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly ILogger<ResultService> _logger;

        // Constructor nhận vào IResultRepository và ILogger
        public ResultService(IResultRepository resultRepository, ILogger<ResultService> logger)
        {
            _resultRepository = resultRepository;  // Nhận vào IResultRepository từ DI container
            _logger = logger;  // Nhận vào ILogger để ghi lại thông tin log
        }

        // Tạo kết quả thi mới
        public async Task<bool> CreateResultAsync(Result result)
        {
            if (result == null)
            {
                _logger.LogError("Kết quả thi không thể là null");
                throw new ArgumentNullException(nameof(result), "Kết quả thi không thể là null");
            }

            var isSuccess = await _resultRepository.AddResultAsync(result);
            if (isSuccess)
            {
                _logger.LogInformation($"Kết quả thi mới đã được tạo với ID {result.ResultId}");
            }
            else
            {
                _logger.LogError("Tạo kết quả thi không thành công.");
            }

            return isSuccess;
        }

        // Cập nhật kết quả thi
        public async Task<bool> UpdateResultAsync(Result result)
        {
            if (result == null)
            {
                _logger.LogError("Kết quả thi không thể là null");
                throw new ArgumentNullException(nameof(result), "Kết quả thi không thể là null");
            }

            var isSuccess = await _resultRepository.UpdateResultAsync(result);
            if (isSuccess)
            {
                _logger.LogInformation($"Kết quả thi đã được cập nhật với ID {result.ResultId}");
            }
            else
            {
                _logger.LogError("Cập nhật kết quả thi không thành công.");
            }

            return isSuccess;
        }

        // Xóa kết quả thi theo ID
        public async Task<bool> DeleteResultAsync(int resultId)
        {
            if (resultId <= 0)
            {
                _logger.LogError("ID kết quả thi không hợp lệ.");
                throw new ArgumentException("ID kết quả thi không hợp lệ", nameof(resultId));
            }

            var isSuccess = await _resultRepository.DeleteResultAsync(resultId);
            if (isSuccess)
            {
                _logger.LogInformation($"Kết quả thi với ID {resultId} đã được xóa");
            }
            else
            {
                _logger.LogError($"Xóa kết quả thi với ID {resultId} không thành công.");
            }

            return isSuccess;
        }

        // Lấy kết quả thi theo ID
        public async Task<Result> GetResultByIdAsync(int resultId)
        {
            if (resultId <= 0)
            {
                _logger.LogError("ID kết quả thi không hợp lệ.");
                throw new ArgumentException("ID kết quả thi không hợp lệ", nameof(resultId));
            }

            var result = await _resultRepository.GetResultByIdAsync(resultId);
            if (result == null)
            {
                _logger.LogWarning($"Không tìm thấy kết quả thi với ID {resultId}");
                throw new KeyNotFoundException($"Không tìm thấy kết quả thi với ID {resultId}");
            }

            return result;
        }

        // Lấy tất cả kết quả thi
        public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            var results = await _resultRepository.GetAllResultsAsync();
            if (results == null || results.Count == 0)
            {
                _logger.LogWarning("Không có kết quả thi nào.");
            }
            else
            {
                _logger.LogInformation($"Lấy {results.Count} kết quả thi.");
            }

            return results;
        }

        // Lấy kết quả thi theo ID cuộc thi
        public async Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId)
        {
            if (competitionId <= 0)
            {
                _logger.LogError("ID cuộc thi không hợp lệ.");
                throw new ArgumentException("ID cuộc thi không hợp lệ", nameof(competitionId));
            }

            var results = await _resultRepository.GetResultsByCompetitionIdAsync(competitionId);
            if (results == null || results.Count == 0)
            {
                _logger.LogWarning($"Không tìm thấy kết quả thi cho cuộc thi với ID {competitionId}");
            }
            else
            {
                _logger.LogInformation($"Lấy {results.Count} kết quả thi cho cuộc thi với ID {competitionId}");
            }

            return results;
        }

        // Tìm kiếm kết quả thi theo koiFishId hoặc competitionId
        public async Task<List<Result>> SearchResultsAsync(int? koiFishId, int? competitionId)
        {
            return await _resultRepository.SearchResultsAsync(koiFishId, competitionId);
        }
    }
}
