using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public DashboardRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDashboardAsync(Dashboard dashboard)
        {
            try
            {
                await _context.Dashboards.AddAsync(dashboard);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteDashboardAsync(int Id)
        {
            try
            {
                var objDel = await _context.Dashboards.FirstOrDefaultAsync(d => d.DashboardId == Id);
                if (objDel != null)
                {
                    _context.Dashboards.Remove(objDel);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteDashboardAsync(Dashboard dashboard)
        {
            try
            {
                _context.Dashboards.Remove(dashboard);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Dashboard>> GetAllDashboardsAsync()
        {
            try
            {
                return await _context.Dashboards
                    .Include(d => d.Competition) 
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Dashboard> GetDashboardByIdAsync(int Id)
        {
            try
            {
                return await _context.Dashboards
                    .Include(d => d.Competition) // Including related competition data
                    .FirstOrDefaultAsync(d => d.DashboardId == Id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> UpdateDashboardAsync(Dashboard dashboard)
        {
            try
            {
                _context.Dashboards.Update(dashboard);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
