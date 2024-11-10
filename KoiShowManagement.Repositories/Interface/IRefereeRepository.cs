using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IRefereeRepository
    {
        Task<List<Referee>> GetAllRefereesAsync();
        Task<Referee> GetRefereeByIdAsync(int refereeId);
        Task<bool> AddRefereeAsync(Referee referee);
        Task<bool> UpdateRefereeAsync(Referee referee);
        Task<bool> DeleteRefereeByIdAsync(int refereeId);
        Task<bool> DeleteRefereeAsync(Referee referee);
        Task<List<Referee>> GetRefereesByExpertiseLevelAsync(string expertiseLevel);

        // Phương thức tìm kiếm với các tiêu chí tùy chọn
        Task<List<Referee>> SearchRefereesAsync(string name = null, string email = null, string expertiseLevel = null);
    }
}
