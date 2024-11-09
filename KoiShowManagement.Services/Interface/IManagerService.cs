using KoiShowManagement.Repositories.Entities;
using System;

namespace KoiShowManagement.Services.Interface
{
    public interface IManagerService
    {
        Task<List<Manager>> GetAllManagers();
        Boolean DelManager(int Id);
        Boolean DelManager(Manager manager);
        Boolean AddManager(Manager manager);
        Boolean UpdManager(Manager manager);
        Task<Manager> GetManagerById(int Id);

    }
}
