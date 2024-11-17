using static System.Formats.Asn1.AsnWriter;

namespace KoiShowManagementSystem.Services.Services
{
    // Interface định nghĩa các phương thức liên quan đến điểm số
    public interface IScoresService
    {
        void AddScore(int eventKoiId, int judgeId, float shapeScore, float colorScore, float patternScore); // Thêm điểm cho cá Koi
        List<Scores> GetScoresByEvent(int eventId); // Lấy danh sách điểm số của sự kiện
        bool CheckScoreExists(int eventKoiId, int judgeId); // Kiểm tra xem điểm số đã tồn tại cho cá Koi này và giám khảo này chưa
    }

    // Lớp thực thi các phương thức trong interface
    public class ScoresService : IScoresService
    {
        private readonly IScoresRepository _scoresRepository; // Repository để tương tác với bảng điểm số
        private readonly IEventKoiParticipationRepository _eventKoiParticipationRepository; // Repository để tương tác với tham gia sự kiện của cá Koi

        // Constructor nhận vào các repository để khởi tạo dịch vụ
        public ScoresService(IScoresRepository scoresRepository, IEventKoiParticipationRepository eventKoiParticipationRepository)
        {
            _scoresRepository = scoresRepository ?? throw new ArgumentNullException(nameof(scoresRepository)); // Kiểm tra nếu repository điểm số null
            _eventKoiParticipationRepository = eventKoiParticipationRepository; // Khởi tạo repository tham gia sự kiện cá Koi
        }

        // Phương thức thêm điểm cho cá Koi
        public void AddScore(int eventKoiId, int judgeId, float shapeScore, float colorScore, float patternScore)
        {
            // Tính tổng điểm dựa trên điểm hình dạng, màu sắc và hoa văn
            var totalScore = shapeScore * 0.5f + colorScore * 0.3f + patternScore * 0.2f;

            // Kiểm tra xem giám khảo đã chấm điểm cho cá Koi này chưa
            if (CheckScoreExists(eventKoiId, judgeId))
            {
                throw new Exception("Giám khảo đã chấm điểm cho cá Koi này rồi."); // Ném lỗi nếu điểm đã tồn tại
            }

            // Tạo đối tượng Scores mới để lưu điểm số
            var score = new Scores
            {
                Event_Koi_ParticipationId = eventKoiId, // ID tham gia sự kiện của cá Koi
                UsersId = judgeId, // ID giám khảo
                ShapeScore = shapeScore, // Điểm hình dạng
                ColorScore = colorScore, // Điểm màu sắc
                PatternScore = patternScore, // Điểm hoa văn
                TotalScore = totalScore // Tổng điểm
            };

            // Thêm điểm vào cơ sở dữ liệu
            _scoresRepository.Add(score);

            // Cập nhật điểm tổng vào bảng tham gia sự kiện cá Koi
            var eventKoiParticipation = _eventKoiParticipationRepository.GetById(eventKoiId);
            if (eventKoiParticipation != null)
            {
                eventKoiParticipation.Score = totalScore; // Cập nhật điểm tổng cho tham gia sự kiện
                _eventKoiParticipationRepository.Update(eventKoiParticipation); // Lưu thay đổi
            }
            else
            {
                throw new Exception("Không tìm thấy tham gia sự kiện cho cá Koi này."); // Ném lỗi nếu không tìm thấy tham gia sự kiện
            }
        }

        // Phương thức kiểm tra điểm đã tồn tại cho sự kiện và giám khảo hay chưa
        public bool CheckScoreExists(int eventKoiId, int judgeId)
        {
            var score = _scoresRepository.GetScoreByEventKoiAndJudge(eventKoiId, judgeId); // Lấy điểm số dựa trên sự tham gia của cá Koi và giám khảo
            return score != null; // Trả về true nếu điểm đã tồn tại, false nếu không
        }

        // Phương thức lấy tất cả các điểm số của sự kiện
        public List<Scores> GetScoresByEvent(int eventId)
        {
            return _scoresRepository.GetScoresByEvent(eventId); // Lấy điểm số cho tất cả các cá Koi tham gia sự kiện
        }
    }
}
