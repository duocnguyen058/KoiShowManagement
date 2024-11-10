using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffsAsync();
        Task<Staff> GetStaffByIdAsync(int staffId);
        Task<bool> AddStaffAsync(Staff staff);
        Task<bool> UpdateStaffAsync(Staff staff);
        Task<bool> DeleteStaffAsync(int staffId);
        Task<bool> DeleteStaffAsync(Staff staff);

        // Thêm phương thức tìm kiếm
        Task<List<Staff>> SearchStaffAsync(string? name, string? email, string? position);
    }
}
