using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffsAsync();  // Async method to get all staffs
        Task<Staff> GetStaffByIdAsync(int staffId);  // Async method to get staff by ID
        Task<bool> AddStaffAsync(Staff staff);  // Async method to add a staff
        Task<bool> UpdateStaffAsync(Staff staff);  // Async method to update staff
        Task<bool> DeleteStaffAsync(int staffId);  // Async method to delete staff by ID
        Task<bool> DeleteStaffAsync(Staff staff);  // Async method to delete staff by object

        // Async method for staff search
        Task<List<Staff>> SearchStaffAsync(string? name, string? email, string? position);
    }
}
