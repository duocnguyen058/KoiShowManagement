using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IUserReportRepository
    {
        Task<List<UserReport>> GetAllUserReportsAsync();
        Task<bool> DeleteUserReportAsync(int id);
        Task<bool> DeleteUserReportAsync(UserReport userReport);
        Task<bool> AddUserReportAsync(UserReport userReport);
        Task<bool> UpdateUserReportAsync(UserReport userReport);
        Task<UserReport> GetUserReportByIdAsync(int id);
    }
}
