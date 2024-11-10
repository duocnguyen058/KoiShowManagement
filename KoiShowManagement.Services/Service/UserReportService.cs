using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class UserReportService : IUserReportService
    {
        private readonly IUserReportRepository _repository;

        public UserReportService(IUserReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUserReportAsync(UserReport userReport)
        {
            ValidateUserReport(userReport);
            return await _repository.AddUserReportAsync(userReport);
        }

        public async Task<bool> DeleteUserReportAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(id));

            return await _repository.DeleteUserReportAsync(id);
        }

        public async Task<bool> DeleteUserReportAsync(UserReport userReport)
        {
            if (userReport == null)
                throw new ArgumentNullException(nameof(userReport), "Thông tin báo cáo người dùng không được để trống.");

            return await _repository.DeleteUserReportAsync(userReport);
        }

        public async Task<List<UserReport>> GetAllUserReportsAsync()
        {
            return await _repository.GetAllUserReportsAsync();
        }

        public async Task<UserReport> GetUserReportByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(id));

            return await _repository.GetUserReportByIdAsync(id);
        }

        public async Task<bool> UpdateUserReportAsync(UserReport userReport)
        {
            ValidateUserReport(userReport);

            if (userReport.UserReportId <= 0)
                throw new ArgumentException("Mã báo cáo người dùng phải là số nguyên dương.", nameof(userReport.UserReportId));

            return await _repository.UpdateUserReportAsync(userReport);
        }


        private void ValidateUserReport(UserReport userReport)
        {
            if (userReport == null)
                throw new ArgumentNullException(nameof(userReport), "Thông tin báo cáo người dùng không được để trống.");

            if (userReport.UserId.HasValue && userReport.UserId <= 0)
                throw new ArgumentException("UserId phải là số nguyên dương nếu được cung cấp.", nameof(userReport.UserId));

            if (userReport.ReportId.HasValue && userReport.ReportId <= 0)
                throw new ArgumentException("ReportId phải là số nguyên dương nếu được cung cấp.", nameof(userReport.ReportId));

            if (string.IsNullOrWhiteSpace(userReport.AccessLevel))
                throw new ArgumentNullException(nameof(userReport.AccessLevel), "Cấp độ truy cập không được để trống hoặc chỉ chứa khoảng trống.");


            if (userReport.Report != null && userReport.Report.ReportId <= 0)
                throw new ArgumentException("ReportId của đối tượng Report phải là số nguyên dương.", nameof(userReport.Report));

            if (userReport.User != null && userReport.User.UserId <= 0)
                throw new ArgumentException("UserId của đối tượng User phải là số nguyên dương.", nameof(userReport.User));
        }
    }
}
