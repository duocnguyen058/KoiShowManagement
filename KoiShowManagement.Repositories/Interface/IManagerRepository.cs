using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetAllManagersAsync();
        Task<Manager> GetManagerByIdAsync(int managerId);
        Task<bool> AddManagerAsync(Manager manager);
        Task<bool> UpdateManagerAsync(Manager manager);
        Task<bool> DeleteManagerByIdAsync(int managerId);
        Task<bool> DeleteManagerAsync(Manager manager);
        Task<List<Manager>> GetManagersByDepartmentAsync(string department);

        // Phương thức tìm kiếm với các tiêu chí tùy chọn
        Task<List<Manager>> SearchManagersAsync(string name = null, string email = null, string department = null);
    }
}
