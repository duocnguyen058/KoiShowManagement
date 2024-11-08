using System;
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

        public bool AddUserReport(UserReport userReport)
        {
            return _repository.AddUserReport(userReport);
        }

        public bool DelUserReport(int Id)
        {
            return _repository.DelUserReport(Id);
        }

        public bool DelUserReport(UserReport userReport)
        {
            return _repository.DelUserReport(userReport);
        }

        public Task<List<UserReport>> GetAllUserReports()
        {
            return _repository.GetAllUserReports();
        }

        public Task<UserReport> GetUserReportById(int Id)
        {
            return _repository.GetUserReportById(Id);
        }

        public bool UpdUserReport(UserReport userReport)
        {
            return _repository.UpdUserReport(userReport);
        }
    }
}

