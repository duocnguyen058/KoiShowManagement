using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;

        public StaffService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Staff>> GetAllStaffsAsync()
        {
            return await _repository.GetAllStaffsAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int staffId)
        {
            if (staffId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(staffId));

            return await _repository.GetStaffByIdAsync(staffId);
        }

        public async Task<bool> AddStaffAsync(Staff staff)
        {
            ValidateStaff(staff);
            return await _repository.AddStaffAsync(staff);
        }

        public async Task<bool> UpdateStaffAsync(Staff staff)
        {
            ValidateStaff(staff);
            return await _repository.UpdateStaffAsync(staff);
        }

        public async Task<bool> DeleteStaffAsync(int staffId)
        {
            if (staffId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(staffId));

            return await _repository.DeleteStaffAsync(staffId);
        }

        public async Task<bool> DeleteStaffAsync(Staff staff)
        {
            if (staff == null)
                throw new ArgumentNullException(nameof(staff), "Nhân viên không được để trống.");

            return await _repository.DeleteStaffAsync(staff);
        }

        // Triển khai phương thức tìm kiếm
        public async Task<List<Staff>> SearchStaffAsync(string? name, string? email, string? position)
        {
            return await _repository.SearchStaffAsync(name, email, position);
        }

        private void ValidateStaff(Staff staff)
        {
            if (staff == null)
                throw new ArgumentNullException(nameof(staff), "Nhân viên không được để trống.");

            if (string.IsNullOrWhiteSpace(staff.Name))
                throw new ArgumentException("Tên nhân viên không được để trống hoặc chỉ chứa khoảng trắng.", nameof(staff.Name));

            if (!string.IsNullOrEmpty(staff.Email) && !staff.Email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.", nameof(staff.Email));

            if (!string.IsNullOrEmpty(staff.Phone) && staff.Phone.Length < 10)
                throw new ArgumentException("Số điện thoại không hợp lệ.", nameof(staff.Phone));

            if (staff.HireDate.HasValue && staff.HireDate.Value > DateTime.Now)
                throw new ArgumentException("Ngày vào làm không thể ở tương lai.", nameof(staff.HireDate));

            if (!string.IsNullOrWhiteSpace(staff.Position) && staff.Position.Length > 100)
                throw new ArgumentException("Chức vụ không được dài quá 100 ký tự.", nameof(staff.Position));
        }
    }
}
 
