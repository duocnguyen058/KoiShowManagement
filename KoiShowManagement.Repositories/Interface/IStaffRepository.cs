using KoiShowManagement.Repositories.Entities;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IStaffRepository
    {
        // Thêm một nhân viên mới
        void AddStaff(Staff staff);

        // Lấy thông tin nhân viên theo ID
        Staff GetStaffById(int id);

        // Lấy danh sách tất cả nhân viên
        IEnumerable<Staff> GetAllStaff();

        // Cập nhật thông tin nhân viên
        void UpdateStaff(Staff staff);

        // Xóa nhân viên theo ID
        void DeleteStaff(int id);
    }
}
