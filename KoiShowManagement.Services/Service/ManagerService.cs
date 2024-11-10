using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;

        public ManagerService(IManagerRepository repository)
        {
            _repository = repository;
        }

        // Lấy tất cả quản lý
        public async Task<List<Manager>> GetAllManagersAsync()
        {
            return await _repository.GetAllManagersAsync();
        }

        // Lấy quản lý theo ID
        public async Task<Manager> GetManagerByIdAsync(int managerId)
        {
            if (managerId <= 0)
                throw new ArgumentException("ID không hợp lệ. Chỉ chấp nhận số nguyên dương.", nameof(managerId));

            return await _repository.GetManagerByIdAsync(managerId);
        }

        // Thêm quản lý mới
        public async Task<bool> AddManagerAsync(Manager manager)
        {
            ValidateManager(manager);
            return await _repository.AddManagerAsync(manager);
        }

        // Cập nhật thông tin quản lý
        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            ValidateManager(manager);
            return await _repository.UpdateManagerAsync(manager);
        }

        // Xóa quản lý theo đối tượng
        public async Task<bool> DeleteManagerAsync(Manager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager), "Quản lý không được để trống.");

            return await _repository.DeleteManagerAsync(manager);
        }

        // Lấy quản lý theo phòng ban
        public async Task<List<Manager>> GetManagersByDepartmentAsync(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("Phòng ban không được để trống.", nameof(department));

            return await _repository.GetManagersByDepartmentAsync(department);
        }

        // Tìm kiếm quản lý theo các tiêu chí
        public async Task<List<Manager>> SearchManagersAsync(string name = null, string email = null, string department = null)
        {
            return await _repository.SearchManagersAsync(name, email, department);
        }

        // Kiểm tra và xác thực thông tin quản lý
        private void ValidateManager(Manager manager)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager), "Quản lý không được để trống.");

            if (string.IsNullOrWhiteSpace(manager.Name))
                throw new ArgumentException("Tên quản lý không được để trống.", nameof(manager.Name));

            if (manager.ManagerId <= 0)
                throw new ArgumentException("Mã quản lý phải là số nguyên dương.", nameof(manager.ManagerId));

            if (!string.IsNullOrWhiteSpace(manager.Email) && !manager.Email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.", nameof(manager.Email));

            if (!string.IsNullOrWhiteSpace(manager.Phone) && manager.Phone.Length < 10)
                throw new ArgumentException("Số điện thoại không hợp lệ.", nameof(manager.Phone));

            if (string.IsNullOrWhiteSpace(manager.Department))
                throw new ArgumentException("Phòng ban không được để trống.", nameof(manager.Department));
        }
    }
}
