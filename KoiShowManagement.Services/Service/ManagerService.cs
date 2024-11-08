using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;
namespace KoiShowManagement.Services.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerService _repository;
        public ManagerService(IManagerService repository)
        {
            _repository = repository;
        }
        public bool AddManager(Manager manager)
        {
            return _repository.AddManager(manager);
        }

        public bool DelManager(int Id)
        {
            return _repository.DelManager(Id);
        }

        public bool DelManager(Manager manager)
        {
            return _repository.AddManager(manager);
        }

        public Task<Manager> GetAllManagerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manager>> GetAllManagers()
        {
            return _repository.GetAllManagers();
        }
        

        public bool UpdManager(Manager manager)
        {
            return _repository.AddManager(manager);
        }

        Task<Guest> IManagerService.GetManagerById(int Id)
        {
            return _repository.GetManagerById(Id);
        }
    }
}
