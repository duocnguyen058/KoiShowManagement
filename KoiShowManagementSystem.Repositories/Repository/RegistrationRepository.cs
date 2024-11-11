using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly KoiShowManagementDbcontextContext _dbContext;

        public RegistrationRepository(KoiShowManagementDbcontextContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Registration>> GetAllRegistrationsAsync()
        {
            return await _dbContext.Registrations.ToListAsync();
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            return await _dbContext.Registrations.FindAsync(id);
        }

        public async Task<bool> AddRegistrationAsync(Registration registration)
        {
            await _dbContext.Registrations.AddAsync(registration);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRegistrationAsync(Registration registration)
        {
            _dbContext.Registrations.Update(registration);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRegistrationByIdAsync(int id)
        {
            var registration = await _dbContext.Registrations.FindAsync(id);
            if (registration != null)
            {
                _dbContext.Registrations.Remove(registration);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteRegistrationAsync(Registration registration)
        {
            _dbContext.Registrations.Remove(registration);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRegistrationsByCompetitionIdAsync(int competitionId)
        {
            var registrations = await _dbContext.Registrations
                .Where(r => r.CompetitionId == competitionId)
                .ToListAsync();

            if (registrations.Any())
            {
                _dbContext.Registrations.RemoveRange(registrations);
                return await _dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
