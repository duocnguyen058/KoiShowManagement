using System.Collections.Generic;
using System.Linq;
using KoiShowManagement.Repositories;
using KoiShowManagement.Models;

namespace KoiShowManagement.Repositories.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly KoiShowDbContext _context;

        public StaffRepository(KoiShowDbContext context)
        {
            _context = context;
        }

        // Thêm một nhân viên mới
        public void AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }

        // Lấy thông tin nhân viên theo ID
        public Staff GetStaffById(int id)
        {
            return _context.Staffs.Find(id);
        }

        // Lấy danh sách tất cả nhân viên
        public IEnumerable<Staff> GetAllStaff()
        {
            return _context.Staffs.ToList();
        }

        // Cập nhật thông tin nhân viên
        public void UpdateStaff(Staff staff)
        {
            _context.Staffs.Update(staff);
            _context.SaveChanges();
        }

        // Xóa nhân viên theo ID
        public void DeleteStaff(int id)
        {
            var staff = _context.Staffs.Find(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                _context.SaveChanges();
            }
        }
    }
}
