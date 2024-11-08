using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public StaffRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddStaff(Staff staff)
        {
            try
            {
                _dbContext.Staff.Add(staff);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelStaff(int Id)
        {
            try
            {
                var objDel = _dbContext.Staff.Where(p => p.StaffId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Staff.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelStaff(Staff staff)
        {
            try
            {
                _dbContext.Staff.Remove(staff);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            return await _dbContext.Staff.ToListAsync();
        }

        public async Task<Staff> GetStaffById(int Id)
        {
            return await _dbContext.Staff.Where(p => p.StaffId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdStaff(Staff staff)
        {
            try
            {
                _dbContext.Staff.Update(staff);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        bool IStaffRepository.AddStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        bool IStaffRepository.DelStaff(int Id)
        {
            throw new NotImplementedException();
        }

        bool IStaffRepository.DelStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        Task<List<Staff>> IStaffRepository.GetAllStaffs()
        {
            throw new NotImplementedException();
        }

        Task<Staff> IStaffRepository.GetStaffById(int Id)
        {
            throw new NotImplementedException();
        }

        bool IStaffRepository.UpdStaff(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
