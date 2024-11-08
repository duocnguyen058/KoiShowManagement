using System;
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

        public bool AddStaff(Staff staff)
        {
            return _repository.AddStaff(staff);
        }

        public bool DelStaff(int Id)
        {
            return _repository.DelStaff(Id);
        }

        public bool DelStaff(Staff staff)
        {
            return _repository.DelStaff(staff);
        }

        public Task<List<Staff>> GetAllStaffs()
        {
            return _repository.GetAllStaffs();
        }

        public Task<Staff> GetStaffById(int Id)
        {
            return _repository.GetStaffById(Id);
        }

        public bool UpdStaff(Staff staff)
        {
            return _repository.UpdStaff(staff);
        }
    }
}
