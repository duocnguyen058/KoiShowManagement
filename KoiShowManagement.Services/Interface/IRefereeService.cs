using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IRefereeService
    {
        Task<List<Referee>> GetAllRefereesAsync();
        Task<Referee> GetRefereeByIdAsync(int refereeId);
        Task<bool> AddRefereeAsync(Referee referee);  // Corrected to async method
        Task<bool> UpdateRefereeAsync(Referee referee);
        Task<bool> DeleteRefereeByIdAsync(int refereeId);
        Task<bool> DeleteRefereeAsync(Referee referee);
        Task<List<Referee>> GetRefereesByExpertiseLevelAsync(string expertiseLevel);
        Task<List<Referee>> SearchRefereesAsync(string name = null, string email = null, string expertiseLevel = null);
    }
}
