using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddDashboardAsync(Dashboard dashboard)
        {
            ValidateDashboard(dashboard);
            return await _repository.AddDashboardAsync(dashboard);
        }

        public async Task<bool> DeleteDashboardAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));

            return await _repository.DeleteDashboardAsync(Id);
        }

        public async Task<bool> DeleteDashboardAsync(Dashboard dashboard)
        {
            if (dashboard == null)
                throw new ArgumentNullException(nameof(dashboard), "Bảng điều khiển không được để trống");

            return await _repository.DeleteDashboardAsync(dashboard);
        }

        public async Task<List<Dashboard>> GetAllDashboardsAsync()
        {
            return await _repository.GetAllDashboardsAsync();
        }

        public async Task<Dashboard> GetDashboardByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));

            return await _repository.GetDashboardByIdAsync(Id);
        }

        public async Task<bool> UpdateDashboardAsync(Dashboard dashboard)
        {
            ValidateDashboard(dashboard);
            return await _repository.UpdateDashboardAsync(dashboard);
        }

        private void ValidateDashboard(Dashboard dashboard)
        {
            if (dashboard == null)
                throw new ArgumentNullException(nameof(dashboard), "Bảng điều khiển không được để trống.");

            if (dashboard.DashboardId <= 0)
                throw new ArgumentException("Mã bảng điều khiển phải là số nguyên dương.", nameof(dashboard.DashboardId));

            if (dashboard.CompetitionId.HasValue && dashboard.CompetitionId <= 0)
                throw new ArgumentException("Mã cuộc thi phải là số nguyên dương.", nameof(dashboard.CompetitionId));

            if (dashboard.TotalParticipants.HasValue && dashboard.TotalParticipants < 0)
                throw new ArgumentException("Số lượng người tham gia không thể nhỏ hơn 0.", nameof(dashboard.TotalParticipants));

            if (dashboard.TotalCategories.HasValue && dashboard.TotalCategories < 0)
                throw new ArgumentException("Số lượng thể loại không thể nhỏ hơn 0.", nameof(dashboard.TotalCategories));

            if (dashboard.TotalJudges.HasValue && dashboard.TotalJudges < 0)
                throw new ArgumentException("Số lượng trọng tài không thể nhỏ hơn 0.", nameof(dashboard.TotalJudges));

            if (dashboard.Competition != null && dashboard.Competition.CompetitionId <= 0)
                throw new ArgumentException("Mã cuộc thi của đối tượng cuộc thi phải là số nguyên dương.", nameof(dashboard.Competition));
        }

    }
}
