using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            ValidateCompetitionResult(result);
            return await _repository.AddCompetitionResultAsync(result);
        }

        public async Task<bool> DelCompetitionResultAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(id));

            return await _repository.DelCompetitionResultAsync(id);
        }

        public async Task<bool> DelCompetitionResultAsync(CompetitionResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Kết quả thi đấu không được để trống");

            return await _repository.DelCompetitionResultAsync(result);
        }

        public async Task<List<CompetitionResult>> GetAllCompetitionResultsAsync()
        {
            return await _repository.GetAllCompetitionResultsAsync();
        }

        public async Task<CompetitionResult> GetCompetitionResultByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(id));

            return await _repository.GetCompetitionResultByIdAsync(id);
        }

        public async Task<bool> UpdCompetitionResultAsync(CompetitionResult result)
        {
            ValidateCompetitionResult(result);
            return await _repository.UpdCompetitionResultAsync(result);
        }

        
        private void ValidateCompetitionResult(CompetitionResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result), "Kết quả thi đấu không được để trống.");

            if (result.ResultId <= 0)
                throw new ArgumentException("Mã kết quả cuộc thi phải là số nguyên dương.", nameof(result.ResultId));

            if (result.KoiId.HasValue && result.KoiId <= 0)
                throw new ArgumentException("Mã Koi phải là số nguyên dương.", nameof(result.KoiId));

            if (result.RefereeId.HasValue && result.RefereeId <= 0)
                throw new ArgumentException("Mã trọng tài phải là số nguyên dương.", nameof(result.RefereeId));

            if (result.EventId.HasValue && result.EventId <= 0)
                throw new ArgumentException("Mã sự kiện phải là số nguyên dương.", nameof(result.EventId));

            if (result.Score.HasValue && (result.Score < 0 || result.Score > 10))
                throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 10.", nameof(result.Score));

            if (string.IsNullOrWhiteSpace(result.Feedback))
                throw new ArgumentException("Ghi nhận xét không được để trống hoặc chỉ chứa khoảng trống.", nameof(result.Feedback));

            
            if (result.Event != null && result.Event.EventId <= 0)
                throw new ArgumentException("Mã sự kiện của đối tượng sự kiện phải là số nguyên dương.", nameof(result.Event));

            if (result.Koi != null && result.Koi.KoiId <= 0)
                throw new ArgumentException("Mã Koi của đối tượng Koi phải là số nguyên dương.", nameof(result.Koi));

            if (result.Referee != null && result.Referee.RefereeId <= 0)
                throw new ArgumentException("Mã trọng tài của đối tượng trọng tài phải là số nguyên dương.", nameof(result.Referee));
        }
    }
}
