﻿using KoiShowManagementSystem.Repositories.Entities;
using System;
namespace KoiShowManagementSystem.Services.Interface
{
	public interface IAccountService
	{

        Task<List<Dashboard>> GetAllDashboardsAsync();
        Task<Dashboard> GetDashboardByIdAsync(int Id);
        Task<bool> AddDashboardAsync(Dashboard dashboard);
        Task<bool> UpdateDashboardAsync(Dashboard dashboard);
        Task<bool> DeleteDashboardAsync(int Id);
        Task<bool> DeleteDashboardAsync(Dashboard dashboard);
    }
}
