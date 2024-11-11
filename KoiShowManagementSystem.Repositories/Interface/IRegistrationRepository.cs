using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IRegistrationRepository
    {
        Task<List<Registration>> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<bool> AddRegistrationAsync(Registration registration);
        Task<bool> UpdateRegistrationAsync(Registration registration);
        Task<bool> DeleteRegistrationByIdAsync(int id);
        Task<bool> DeleteRegistrationAsync(Registration registration);
        Task<bool> DeleteRegistrationsByCompetitionIdAsync(int competitionId);  // Thêm phương thức này
    }
}
