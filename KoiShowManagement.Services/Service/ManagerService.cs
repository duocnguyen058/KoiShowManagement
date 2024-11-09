using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;
namespace KoiShowManagement.Services.Service
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;
        public ManagerService(IManagerRepository repository)
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

        public Task<List<Manager>> GetAllManagers()
        {
            return _repository.GetAllManagers();
        }

        public Task<Manager> GetManagerById(int Id)
        {
            return _repository.GetManagerById(Id);
        }

        public bool UpdManager(Manager manager)
        {
            return _repository.UpdManager(manager);
        }
    }
}
