using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public StaffRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Staff>> GetAllStaffsAsync()
        {
            return await _dbContext.Staff.ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int staffId)
        {
            return await _dbContext.Staff.FindAsync(staffId);
        }

        public async Task<bool> AddStaffAsync(Staff staff)
        {
            try
            {
                await _dbContext.Staff.AddAsync(staff);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi thêm nhân viên.", ex);
            }
        }

        public async Task<bool> UpdateStaffAsync(Staff staff)
        {
            try
            {
                _dbContext.Staff.Update(staff);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi cập nhật thông tin nhân viên.", ex);
            }
        }

        public async Task<bool> DeleteStaffAsync(int staffId)
        {
            var staff = await _dbContext.Staff.FindAsync(staffId);
            if (staff == null) return false;

            _dbContext.Staff.Remove(staff);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStaffAsync(Staff staff)
        {
            try
            {
                _dbContext.Staff.Remove(staff);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi xóa nhân viên.", ex);
            }
        }
    }
}
