namespace KoiShowManagementSystem.Services.Services
{
    // Interface định nghĩa các phương thức liên quan đến báo cáo
    public interface IReportsService
    {
        Reports GeneratePredictionReport(int eventId); // Tạo báo cáo dự đoán cho sự kiện
        Reports GenerateStatisticsReport(int eventId); // Tạo báo cáo thống kê cho sự kiện
        List<Reports> GetReportsByEvent(int eventId); // Lấy danh sách báo cáo theo sự kiện
    }

    // Lớp thực thi các phương thức trong interface
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository _reportsRepository; // Repository để tương tác với báo cáo
        private readonly IScoresRepository _scoresRepository; // Repository để tương tác với điểm số
        private readonly IEventKoiParticipationRepository _eventKoiParticipationRepository; // Repository để tương tác với sự tham gia của cá Koi trong sự kiện

        // Constructor nhận vào các repository để khởi tạo dịch vụ
        public ReportsService(
            IReportsRepository reportsRepository,
            IScoresRepository scoresRepository,
            IEventKoiParticipationRepository eventKoiParticipationRepository)
        {
            _reportsRepository = reportsRepository;
            _scoresRepository = scoresRepository;
            _eventKoiParticipationRepository = eventKoiParticipationRepository;
        }

        // Phương thức tạo báo cáo dự đoán dựa trên điểm trung bình của các tiêu chí chấm điểm
        public Reports GeneratePredictionReport(int eventId)
        {
            // Lấy danh sách điểm số của các sự kiện
            var scores = _scoresRepository.GetScoresByEvent(eventId);
            var predictionData = scores
                .GroupBy(s => s.Event_Koi_ParticipationId) // Nhóm theo sự tham gia của cá Koi trong sự kiện
                .Select(g => new
                {
                    KoiId = g.Key, // ID của cá Koi
                    AverageScore = g.Average(s => s.TotalScore) // Tính điểm trung bình của cá Koi
                })
                .OrderByDescending(x => x.AverageScore) // Sắp xếp giảm dần theo điểm trung bình
                .ToList();

            // Chuyển dữ liệu dự đoán thành chuỗi JSON
            var reportData = Newtonsoft.Json.JsonConvert.SerializeObject(predictionData);

            // Tạo đối tượng báo cáo
            var report = new Reports
            {
                EventsId = eventId,
                ReportType = "Prediction", // Loại báo cáo là "Dự đoán"
                ReportData = reportData
            };

            // Lưu báo cáo vào cơ sở dữ liệu
            _reportsRepository.Add(report);
            return report;
        }

        // Phương thức tạo báo cáo thống kê về số lượng tham gia và điểm trung bình của các tiêu chí
        public Reports GenerateStatisticsReport(int eventId)
        {
            // Lấy danh sách người tham gia sự kiện và các điểm số
            var participants = _eventKoiParticipationRepository.GetParticipantsByEvent(eventId);
            var scores = _scoresRepository.GetScoresByEvent(eventId);

            // Tạo đối tượng chứa dữ liệu thống kê
            var statisticsData = new
            {
                TotalParticipants = participants.Count, // Tổng số lượng người tham gia
                AverageShapeScore = scores.Average(s => s.ShapeScore), // Điểm trung bình về hình dạng
                AverageColorScore = scores.Average(s => s.ColorScore), // Điểm trung bình về màu sắc
                AveragePatternScore = scores.Average(s => s.PatternScore), // Điểm trung bình về hoa văn
                AverageTotalScore = scores.Average(s => s.TotalScore) // Điểm trung bình tổng thể
            };

            // Chuyển dữ liệu thống kê thành chuỗi JSON
            var reportData = Newtonsoft.Json.JsonConvert.SerializeObject(statisticsData);

            // Tạo đối tượng báo cáo
            var report = new Reports
            {
                EventsId = eventId,
                ReportType = "Statistics", // Loại báo cáo là "Thống kê"
                ReportData = reportData
            };

            // Lưu báo cáo vào cơ sở dữ liệu
            _reportsRepository.Add(report);
            return report;
        }

        // Phương thức lấy danh sách báo cáo của một sự kiện
        public List<Reports> GetReportsByEvent(int eventId)
        {
            return _reportsRepository.GetReportsByEvent(eventId); // Gọi repository để lấy báo cáo theo sự kiện
        }
    }
}
