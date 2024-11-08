using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
	public interface IUserReportService
	{
        Task<List<UserReport>> GetAllUserReports();
        Boolean DelUserReport(int Id);
        Boolean DelUserReport(UserReport userReport);
        Boolean AddUserReport(UserReport userReport);
        Boolean UpdUserReport(UserReport userReport);
        Task<UserReport> GetUserReportById(int Id);
    }
}

