using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
	public interface IUserReportRepository
	{
        Task<List<UserReport>> GetAllUserReports();
        Boolean DelUserReport(int Id);
        Boolean DelUserReport(UserReport userReport);
        Boolean AddUserReport(UserReport userReport);
        Boolean UpdUserReport(UserReport userReport);
        Task<UserReport> GetUserReportById(int Id);
    }
}

