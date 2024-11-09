using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class CompetitionResultService : ICompetitionResultService
    {
        private readonly ICompetitionResultRepository _repository;
        public CompetitionResultService(ICompetitionResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddCompetitionResultAsync(CompetitionResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Kết quả thi đấu không được để trống.");
            if (result.ResultId <= 0)
                throw new ArgumentNullException("Mã kết quả cuộc thi phải là số nguyên dương.",nameof(result.ResultId));
            if (result.ResultId <= 0)
                throw new ArgumentNullException("Mã kết quả cuộc thi phải là số nguyên dương.", nameof(result.ResultId));
            if (string.IsNullOrWhiteSpace(result.Feedback))
                throw new ArgumentNullException("Ghi nhận xét không được để hoặc chỉ chứa khoảng trống.",nameof(result.Feedback));
            return await _repository.AddCompetitionResultAsync(result);
        }

        public async Task<bool> DelCompetitionResultAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return await _repository.DelCompetitionResultAsync(Id);
        }

        public async Task<bool> DelCompetitionResultAsync(CompetitionResult result)
        {
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result), "Kết quả thi đấu không được để trống");
            }
            return await _repository.DelCompetitionResultAsync(result);
        }

        public async Task<List<CompetitionResult>> GetAllCompetitionResultsAsync()
        {
            return await _repository.GetAllCompetitionResultsAsync();
        }

        public async Task<CompetitionResult> GetCompetitionResultByIdAsync(int Id)
        {
            if(Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return await _repository.GetCompetitionResultByIdAsync(Id);
        }

        public async Task<bool> UpdCompetitionResultAsync(CompetitionResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Kết quả thi đấu không được để trống.");
            if (result.ResultId <= 0)
                throw new ArgumentNullException("Mã kết quả cuộc thi phải là số nguyên dương.", nameof(result.ResultId));
            if (result.ResultId <= 0)
                throw new ArgumentNullException("Mã kết quả cuộc thi phải là số nguyên dương.", nameof(result.ResultId));
            if (string.IsNullOrWhiteSpace(result.Feedback))
                throw new ArgumentNullException("Ghi nhận xét không được để hoặc chỉ chứa khoảng trống.", nameof(result.Feedback));
            return await _repository.UpdCompetitionResultAsync(result);
        }
    }
}
        