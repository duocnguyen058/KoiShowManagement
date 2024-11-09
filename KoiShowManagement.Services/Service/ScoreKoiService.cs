using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;

namespace KoiShowManagement.Services.Service
{
    public class ScoreKoiService : IScoreKoiService
    {
        private readonly IScoreKoiRepository _repository;

        public ScoreKoiService(IScoreKoiRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "ScoreKoi không được để trống.");
            if (scoreKoi.KoiId <= 0)
                throw new ArgumentException("ID của Koi phải là số nguyên dương.", nameof(scoreKoi.KoiId));
            if (scoreKoi.Score < 0 || scoreKoi.Score > 100)
                throw new ArgumentException("Điểm của ScoreKoi phải nằm trong khoảng từ 0 đến 100.", nameof(scoreKoi.Score));

            return await _repository.AddScoreKoiAsync(scoreKoi);
        }

        public async Task<bool> DeleteScoreKoiAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.DeleteScoreKoiAsync(Id);
        }

        public async Task<bool> DeleteScoreKoiAsync(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "ScoreKoi không được để trống.");

            return await _repository.DeleteScoreKoiAsync(scoreKoi);
        }

        public async Task<List<ScoreKoi>> GetAllScoreKoisAsync()
        {
            return await _repository.GetAllScoreKoisAsync();
        }

        public async Task<ScoreKoi> GetScoreKoiByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.GetScoreKoiByIdAsync(Id);
        }

        public async Task<bool> UpdateScoreKoiAsync(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "ScoreKoi không được để trống.");
            if (scoreKoi.KoiId <= 0)
                throw new ArgumentException("ID của Koi phải là số nguyên dương.", nameof(scoreKoi.KoiId));
            if (scoreKoi.Score < 0 || scoreKoi.Score > 100)
                throw new ArgumentException("Điểm của ScoreKoi phải nằm trong khoảng từ 0 đến 100.", nameof(scoreKoi.Score));

            return await _repository.UpdateScoreKoiAsync(scoreKoi);
        }
    }
}      
