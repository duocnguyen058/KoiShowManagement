using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IManagerRepository 
    {
        Task<List<Manager>> GetAllManagers();
        Boolean DelManager(int Id);
        Boolean DelManager(Manager manager);
        Boolean AddManager(Manager manager);
        Boolean UpdManager(Manager manager);
        Task<Manager> GetManagerById(int Id);
    }
}
