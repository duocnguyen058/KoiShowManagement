using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllStaff();
        Boolean DelStaff(int Id);
        Boolean DelStaff(Staff staff);
        Boolean AddStaff(Staff staff);
        Boolean UpdStaff(Staff staff);
        Task<Staff> GetStaffById(int Id);
    }
}
