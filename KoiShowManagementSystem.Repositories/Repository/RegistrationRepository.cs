using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public RegistrationRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<List<Registration>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Include(r => r.Competition)
                .Include(r => r.KoiFish)
                .ToListAsync();
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            return await _context.Registrations
                .Include(r => r.Competition)
                .Include(r => r.KoiFish)
                .FirstOrDefaultAsync(r => r.RegistrationId == id);
        }

        public async Task<bool> AddRegistrationAsync(Registration registration)
        {
            await _context.Registrations.AddAsync(registration);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRegistrationAsync(Registration registration)
        {
            _context.Registrations.Update(registration);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRegistrationByIdAsync(int id)
        {
            var registration = await GetRegistrationByIdAsync(id);
            if (registration == null) return false;
            _context.Registrations.Remove(registration);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRegistrationAsync(Registration registration)
        {
            _context.Registrations.Remove(registration);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
