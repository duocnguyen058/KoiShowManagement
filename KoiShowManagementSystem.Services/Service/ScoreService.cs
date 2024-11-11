using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;

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

            var score = await _scoreRepository.GetScoreByIdAsync(scoreId);

            if (score == null)
                throw new KeyNotFoundException($"Không tìm thấy điểm số với ID {scoreId}.");

            return score;
        }

        public async Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId)
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

            if (score.KoiFishId == null || score.JudgeId == null || score.CompetitionId == null)
                throw new ArgumentException("Điểm số phải có cá koi, giám khảo và cuộc thi");

            var koiFish = await _koiFishRepository.GetKoiFishByIdAsync(score.KoiFishId.Value);
            var judge = await _judgeRepository.GetJudgeByIdAsync(score.JudgeId.Value);
            var competition = await _competitionRepository.GetCompetitionByIdAsync(score.CompetitionId.Value);

            if (koiFish == null)
                throw new KeyNotFoundException($"Không tìm thấy cá koi với ID {score.KoiFishId}");

            if (judge == null)
                throw new KeyNotFoundException($"Không tìm thấy giám khảo với ID {score.JudgeId}");

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {score.CompetitionId}");

            score.TotalScore = (score.BodyScore ?? 0) + (score.ColorScore ?? 0) + (score.PatternScore ?? 0);

            return await _scoreRepository.CreateScoreAsync(score);
        }

        public async Task<bool> UpdateScoreAsync(Score score)
        {
            if (score == null)
                throw new ArgumentNullException(nameof(score), "Điểm số không thể null");

            if (score.ScoreId <= 0)
                throw new ArgumentException("ID điểm số không hợp lệ");

            var existingScore = await _scoreRepository.GetScoreByIdAsync(score.ScoreId);

            if (existingScore == null)
                throw new KeyNotFoundException($"Không tìm thấy điểm số với ID {score.ScoreId}");

            score.TotalScore = (score.BodyScore ?? 0) + (score.ColorScore ?? 0) + (score.PatternScore ?? 0);

            return await _scoreRepository.UpdateScoreAsync(score);
        }

        public async Task<bool> DeleteScoreAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID điểm số không hợp lệ");

            var score = await _scoreRepository.GetScoreByIdAsync(scoreId);

            if (score == null)
                throw new KeyNotFoundException($"Không tìm thấy điểm số với ID {scoreId}");

            return await _scoreRepository.DeleteScoreAsync(scoreId);
        }

        public async Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId)
        {
            var score = await _scoreRepository.GetScoreByKoiAndJudgeAsync(koiFishId, judgeId, competitionId);

            if (score == null)
                throw new KeyNotFoundException("Không tìm thấy điểm số cho cá koi này, giám khảo và cuộc thi.");

            return score;
        }

        public async Task<IEnumerable<Score>> GetScoresByKoiFishAsync(int koiFishId)
        {
            var koiFish = await _koiFishRepository.GetKoiFishByIdAsync(koiFishId);

            if (koiFish == null)
                throw new KeyNotFoundException($"Không tìm thấy cá koi với ID {koiFishId}");

            return await _scoreRepository.GetScoresByKoiFishIdAsync(koiFishId);
        }

        public bool IsScoreValid(Score score)
        {
            if (score.BodyScore < 0 || score.ColorScore < 0 || score.PatternScore < 0)
                return false;

            return true;
        }
    }
}
