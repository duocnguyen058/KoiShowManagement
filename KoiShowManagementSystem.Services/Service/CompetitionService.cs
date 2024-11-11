using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;

namespace KoiShowManagementSystem.Services.Service
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IJudgeRepository _judgeRepository;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IResultRepository _resultRepository;
        private readonly IScoreRepository _scoreRepository;

        public CompetitionService(
            ICompetitionRepository competitionRepository,
            IJudgeRepository judgeRepository,
            IRegistrationRepository registrationRepository,
            IResultRepository resultRepository,
            IScoreRepository scoreRepository)
        {
            _competitionRepository = competitionRepository;
            _judgeRepository = judgeRepository;
            _registrationRepository = registrationRepository;
            _resultRepository = resultRepository;
            _scoreRepository = scoreRepository;
        }

        // Triển khai phương thức tìm kiếm cuộc thi theo tên và ngày
        public async Task<IEnumerable<Competition>> SearchCompetitionsAsync(string searchQuery, DateTime? date)
        {
            var competitions = await _competitionRepository.GetAllCompetitionsAsync();

            // Lọc theo từ khóa tìm kiếm (nếu có)
            if (!string.IsNullOrEmpty(searchQuery))
            {
                competitions = competitions.Where(c => c.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo ngày (nếu có)
            if (date.HasValue)
            {
                DateTime searchDate = date.Value.Date;
                competitions = competitions.Where(c => c.StartDate <= searchDate && c.EndDate >= searchDate);
            }

            return competitions.ToList();
        }

        // Triển khai các phương thức khác...
        public async Task<Competition> GetCompetitionByIdAsync(int competitionId)
        {
            if (competitionId <= 0)
                throw new ArgumentException("ID cuộc thi phải lớn hơn 0");

            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);
            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}.");

            return competition;
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsAsync()
        {
            return await _competitionRepository.GetAllCompetitionsAsync();
        }

        public async Task<bool> CreateCompetitionAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition), "Cuộc thi không thể null");

            if (string.IsNullOrEmpty(competition.Name))
                throw new ArgumentException("Tên cuộc thi là bắt buộc");

            return await _competitionRepository.CreateCompetitionAsync(competition);
        }

        public async Task<bool> UpdateCompetitionAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition), "Cuộc thi không thể null");

            if (competition.CompetitionId <= 0)
                throw new ArgumentException("ID cuộc thi không hợp lệ");

            var existingCompetition = await _competitionRepository.GetCompetitionByIdAsync(competition.CompetitionId);
            if (existingCompetition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competition.CompetitionId}.");

            return await _competitionRepository.UpdateCompetitionAsync(competition);
        }

        public async Task<bool> DeleteCompetitionAsync(int competitionId)
        {
            if (competitionId <= 0)
                throw new ArgumentException("ID cuộc thi không hợp lệ");

            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);
            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}.");

            // Xóa các đối tượng liên quan đến cuộc thi
            await _scoreRepository.DeleteScoresByCompetitionIdAsync(competitionId);
            await _resultRepository.DeleteResultsByCompetitionIdAsync(competitionId);
            await _registrationRepository.DeleteRegistrationsByCompetitionIdAsync(competitionId);

            return await _competitionRepository.DeleteCompetitionAsync(competitionId);
        }

        public async Task<bool> AddJudgeToCompetitionAsync(int competitionId, int judgeId)
        {
            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);
            var judge = await _judgeRepository.GetJudgeByIdAsync(judgeId);

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}.");

            if (judge == null)
                throw new KeyNotFoundException($"Không tìm thấy giám khảo với ID {judgeId}.");

            if (!competition.Judges.Any(j => j.JudgeId == judgeId))
            {
                competition.Judges.Add(judge);
                await _competitionRepository.UpdateCompetitionAsync(competition);
                return true;
            }

            throw new InvalidOperationException("Giám khảo đã được thêm vào cuộc thi này.");
        }

        public async Task<bool> RemoveJudgeFromCompetitionAsync(int competitionId, int judgeId)
        {
            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}");

            var judge = competition.Judges.FirstOrDefault(j => j.JudgeId == judgeId);

            if (judge == null)
                throw new KeyNotFoundException($"Giám khảo với ID {judgeId} không có trong cuộc thi này.");

            competition.Judges.Remove(judge);
            await _competitionRepository.UpdateCompetitionAsync(competition);
            return true;
        }

        public async Task<bool> AddRegistrationToCompetitionAsync(int competitionId, Registration registration)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration), "Đăng ký không thể null");

            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}");

            competition.Registrations.Add(registration);
            await _competitionRepository.UpdateCompetitionAsync(competition);
            return true;
        }

        public async Task<IEnumerable<Result>> GetResultsForCompetitionAsync(int competitionId)
        {
            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}");

            return await _resultRepository.GetResultsByCompetitionIdAsync(competitionId);
        }

        public async Task<IEnumerable<Score>> GetScoresForCompetitionAsync(int competitionId)
        {
            var competition = await _competitionRepository.GetCompetitionByIdAsync(competitionId);

            if (competition == null)
                throw new KeyNotFoundException($"Không tìm thấy cuộc thi với ID {competitionId}");

            return await _scoreRepository.GetScoresByCompetitionIdAsync(competitionId);
        }

        public bool IsCompetitionActive(Competition competition)
        {
            var now = DateTime.Now;
            return now >= competition.StartDate && now <= competition.EndDate;
        }

        public async Task<IEnumerable<Competition>> GetOngoingCompetitionsAsync()
        {
            var competitions = await _competitionRepository.GetAllCompetitionsAsync();

            // Lọc các cuộc thi đang diễn ra
            var ongoingCompetitions = competitions.Where(c => c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now).ToList();

            return ongoingCompetitions;
        }
    }
}
