using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IManagerService
    {
        Task<List<Manager>> GetAllManagersAsync();  // Fetch all managers asynchronously
        Task<Manager> GetManagerByIdAsync(int managerId);  // Fetch a manager by ID asynchronously
        Task<bool> AddManagerAsync(Manager manager);  // Add a new manager asynchronously
        Task<bool> UpdateManagerAsync(Manager manager);  // Update an existing manager asynchronously
        Task<bool> DeleteManagerAsync(Manager manager);  // Delete a manager by object asynchronously
        Task<List<Manager>> GetManagersByDepartmentAsync(string department);  // Fetch managers by department asynchronously
        Task<List<Manager>> SearchManagersAsync(string name = null, string email = null, string department = null);  // Search managers with optional criteria
    }
}
