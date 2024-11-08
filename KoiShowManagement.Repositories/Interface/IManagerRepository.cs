using KoiShowManagement.Repositories.Entities;
using System;

namespace KoiShowManagement.Repositories.Interface
{
    internal interface IManagerRepository
    {
        Task<List<Manager>> GetAllManager();
        Boolean DelManager(int Id);
        Boolean DelManager(Manager manager);
        Boolean AddManager(Manager manager);
        Boolean UpdManager(Manager manager);
        Task<Manager> GetManagerById(int Id);
    }
}
