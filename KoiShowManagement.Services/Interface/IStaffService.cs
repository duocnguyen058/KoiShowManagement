using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffs();
        Boolean DelStaff(int Id);
        Boolean DelStaff(Staff staff);
        Boolean AddStaff(Staff staff);
        Boolean UpdStaff(Staff staff);
        Task<Staff> GetStaffById(int Id);
    }
}
