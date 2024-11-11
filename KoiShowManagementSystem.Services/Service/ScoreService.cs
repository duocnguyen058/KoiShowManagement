using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Services.Service
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IJudgeRepository _judgeRepository;
        private readonly IKoiFishRepository _koiFishRepository;

        public ScoreService(
            IScoreRepository scoreRepository,
            ICompetitionRepository competitionRepository,
            IJudgeRepository judgeRepository,
            IKoiFishRepository koiFishRepository)
        {
            _scoreRepository = scoreRepository;
            _competitionRepository = competitionRepository;
            _judgeRepository = judgeRepository;
            _koiFishRepository = koiFishRepository;
        }

        public async Task<Score> GetScoreByIdAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID điểm số phải lớn hơn 0");

            return await _scoreRepository.GetScoreByIdAsync(scoreId);
        }

        public async Task<IList<Score>> GetScoresForCompetitionAsync(int competitionId)
        {
            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);
            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}.");

            return await _scoreRepository.GetScoresByCompetitionIdAsync(competitionId);
        }

        public async Task<bool> CreateScoreAsync(Score score)
        {
            if (score == null)
                throw new ArgumentNullException(nameof(score), "Điểm số không thể null");

            if (!IsScoreComponentsValid(score))
                throw new ArgumentException("Điểm số phải nằm trong khoảng từ 0 đến 10.");

            if (score.KoiFishId == null || score.JudgeId == null || score.CompetitionId == null)
                throw new ArgumentException("Điểm số phải có cá koi, giám khảo và cuộc thi");

            var koiFish = await _koiFishRepository.GetKoiFishByIdAsync(score.KoiFishId.Value);
            var judge = await _judgeRepository.GetJudgeByIdAsync(score.JudgeId.Value);
            var competition = await _competitionRepository.GetCompetitionByIdAsync(score.CompetitionId.Value);

            if (koiFish == null || judge == null || competition == null)
                throw new KeyNotFoundException("Dữ liệu không đầy đủ");

            score.TotalScore = CalculateTotalScore(score);

            return await _scoreRepository.CreateScoreAsync(score);
        }

        public async Task<bool> UpdateScoreAsync(Score score)
        {
            if (score == null)
                throw new ArgumentNullException(nameof(score), "Điểm số không thể null");

            if (score.ScoreId <= 0)
                throw new ArgumentException("ID điểm số không hợp lệ");

            if (!IsScoreComponentsValid(score))
                throw new ArgumentException("Điểm số phải nằm trong khoảng từ 0 đến 10.");

            var existingScore = await _scoreRepository.GetScoreByIdAsync(score.ScoreId);

            if (existingScore == null)
                throw new KeyNotFoundException($"Không tìm thấy điểm số với ID {score.ScoreId}");

            score.TotalScore = CalculateTotalScore(score);

            return await _scoreRepository.UpdateScoreAsync(score);
        }

        public async Task<bool> DeleteScoreAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID điểm số không hợp lệ");

            return await _scoreRepository.DeleteScoreAsync(scoreId);
        }

        public async Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId)
        {
            return await _scoreRepository.GetScoreByKoiAndJudgeAsync(koiFishId, judgeId, competitionId);
        }

        public async Task<IList<Score>> GetScoresByKoiFishAsync(int koiFishId)
        {
            var koiFish = await _koiFishRepository.GetKoiFishByIdAsync(koiFishId);

            if (koiFish == null)
                throw new KeyNotFoundException($"Không tìm thấy cá koi với ID {koiFishId}");

            return await _scoreRepository.GetScoresByKoiFishIdAsync(koiFishId);
        }

        public async Task<bool> IsScoreValid(Score score)
        {
            return IsScoreComponentsValid(score);
        }

        private bool IsScoreComponentsValid(Score score)
        {
            return score.BodyScore >= 0 && score.BodyScore <= 10 &&
                   score.ColorScore >= 0 && score.ColorScore <= 10 &&
                   score.PatternScore >= 0 && score.PatternScore <= 10;
        }

        private float CalculateTotalScore(Score score)
        {
            return (float)((score.BodyScore * 0.5) + (score.ColorScore * 0.3) + (score.PatternScore * 0.2));
        }
    }
}
