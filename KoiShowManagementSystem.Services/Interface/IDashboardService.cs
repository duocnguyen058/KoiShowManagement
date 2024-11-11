using KoiShowManagementSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface IDashboardService
    {
        Task<List<Dashboard>> GetAllDashboardsAsync();
        Task<Dashboard> GetDashboardByIdAsync(int Id);
        Task<bool> AddDashboardAsync(Dashboard dashboard);
        Task<bool> UpdateDashboardAsync(Dashboard dashboard);
        Task<bool> DeleteDashboardAsync(int Id);
        Task<bool> DeleteDashboardAsync(Dashboard dashboard);
    }
}
