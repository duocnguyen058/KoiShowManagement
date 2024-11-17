namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository quản lý báo cáo (Reports).
    public interface IReportsRepository : IRepository<Reports>
    {
        // Phương thức lấy danh sách báo cáo theo eventId.
        List<Reports> GetReportsByEvent(int eventId);

        // Phương thức lấy báo cáo dự đoán theo eventId.
        Reports GetPredictionReport(int eventId);

        // Phương thức lấy báo cáo thống kê theo eventId.
        Reports GetStatisticsReport(int eventId);
    }

    // Repository triển khai các phương thức đã định nghĩa trong IReportsRepository.
    public class ReportsRepository : RepositoryBase<Reports>, IReportsRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public ReportsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        // Phương thức trả về danh sách các báo cáo liên quan đến một sự kiện (eventId).
        public List<Reports> GetReportsByEvent(int eventId)
        {
            // Truy vấn các báo cáo có `EventsId` khớp với `eventId`.
            return _dbContext.Reports.Where(r => r.EventsId == eventId).ToList();
        }

        // Phương thức trả về báo cáo dự đoán cho sự kiện theo eventId.
        public Reports GetPredictionReport(int eventId)
        {
            // Truy vấn báo cáo có `EventsId` khớp với `eventId` và `ReportType` là "Prediction".
            return _dbContext.Reports.FirstOrDefault(r => r.EventsId == eventId && r.ReportType == "Prediction");
        }

        // Phương thức trả về báo cáo thống kê cho sự kiện theo eventId.
        public Reports GetStatisticsReport(int eventId)
        {
            // Truy vấn báo cáo có `EventsId` khớp với `eventId` và `ReportType` là "Statistics".
            return _dbContext.Reports.FirstOrDefault(r => r.EventsId == eventId && r.ReportType == "Statistics");
        }
    }
}
