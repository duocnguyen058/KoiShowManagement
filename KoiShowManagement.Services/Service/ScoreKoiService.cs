using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class ScoreKoiService : IScoreKoiService
    {
        private readonly IScoreKoiRepository _repository;

        public ScoreKoiService(IScoreKoiRepository repository)
        {
            _repository = repository;
        }

        // Add a score result for Koi
        public async Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi)
        {
            ValidateScoreKoi(scoreKoi);
            return await _repository.AddScoreKoiAsync(scoreKoi);
        }

        // Delete a score result by ScoreId
        public async Task<bool> DelScoreKoiAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(scoreId));

            return await _repository.DelScoreKoiAsync(scoreId);
        }

        // Delete a score result by ScoreKoi object
        public async Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "Kết quả chấm điểm không được để trống");

            return await _repository.DelScoreKoiAsync(scoreKoi);
        }

        // Get all score results
        public async Task<List<ScoreKoi>> GetAllScoreKoisAsync()
        {
            return await _repository.GetAllScoreKoisAsync();
        }

        // Get score result by ScoreId
        public async Task<ScoreKoi> GetScoreKoiByIdAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(scoreId));

            return await _repository.GetScoreKoiByIdAsync(scoreId);
        }

        // Update a score result
        public async Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi)
        {
            ValidateScoreKoi(scoreKoi);
            return await _repository.UpdScoreKoiAsync(scoreKoi);
        }

        // Validate score result data before performing actions
        private void ValidateScoreKoi(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "Kết quả chấm điểm không được để trống");

            if (scoreKoi.ScoreId <= 0)
                throw new ArgumentException("Mã kết quả chấm điểm phải là số nguyên dương.", nameof(scoreKoi.ScoreId));

            if (scoreKoi.KoiId.HasValue && scoreKoi.KoiId <= 0)
                throw new ArgumentException("Mã Koi phải là số nguyên dương.", nameof(scoreKoi.KoiId));

            if (scoreKoi.RefereeId.HasValue && scoreKoi.RefereeId <= 0)
                throw new ArgumentException("Mã trọng tài phải là số nguyên dương.", nameof(scoreKoi.RefereeId));

            if (scoreKoi.EventId.HasValue && scoreKoi.EventId <= 0)
                throw new ArgumentException("Mã sự kiện phải là số nguyên dương.", nameof(scoreKoi.EventId));

            if (scoreKoi.Score.HasValue && (scoreKoi.Score < 0 || scoreKoi.Score > 10))
                throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 10.", nameof(scoreKoi.Score));

            if (string.IsNullOrWhiteSpace(scoreKoi.Feedback))
                throw new ArgumentException("Ghi nhận xét không được để trống hoặc chỉ chứa khoảng trắng.", nameof(scoreKoi.Feedback));

            if (scoreKoi.Event != null && scoreKoi.Event.EventId <= 0)
                throw new ArgumentException("Mã sự kiện của đối tượng sự kiện phải là số nguyên dương.", nameof(scoreKoi.Event));

            if (scoreKoi.Koi != null && scoreKoi.Koi.KoiId <= 0)
                throw new ArgumentException("Mã Koi của đối tượng Koi phải là số nguyên dương.", nameof(scoreKoi.Koi));

            if (scoreKoi.Referee != null && scoreKoi.Referee.RefereeId <= 0)
                throw new ArgumentException("Mã trọng tài của đối tượng trọng tài phải là số nguyên dương.", nameof(scoreKoi.Referee));

            if (scoreKoi.ScoreDate == null)
                throw new ArgumentException("Ngày chấm điểm không được để trống.", nameof(scoreKoi.ScoreDate));

            if (string.IsNullOrWhiteSpace(scoreKoi.JudgeName))
                throw new ArgumentException("Tên trọng tài không được để trống.", nameof(scoreKoi.JudgeName));

            if (scoreKoi.ScoreValue <= 0)
                throw new ArgumentException("Điểm chấm phải là số nguyên dương.", nameof(scoreKoi.ScoreValue));

            if (scoreKoi.FishId <= 0)
                throw new ArgumentException("Mã cá phải là số nguyên dương.", nameof(scoreKoi.FishId));
        }
    }
}
