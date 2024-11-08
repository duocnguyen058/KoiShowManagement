using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using System;

namespace KoiShowManagement.Services.Service
{
    public class RefereeService : IRefereeService
    {
        private readonly IRefereeService _repository;
        public RefereeService(IRefereeService repository)
        {
            _repository = repository;
        }

        public bool AddReferee(Referee referee)
        {
            return _repository.AddReferee(referee);
        }

        public bool DelReferee(int Id)
        {
            return _repository.DelReferee(Id);
        }

        public bool DelReferee(Referee referee)
        {
            return _repository.DelReferee(referee);
        }

        public Task<List<Referee>> GetAllReferees()
        {
            return _repository.GetAllReferees();
        }

        public Task<Referee> GetRefereeById(int Id)
        {
            return _repository.GetRefereeById(Id);
        }

        public bool UpdReferee(Referee referee)
        {
            return _repository.UpdReferee(referee);
        }
    }
}
    

