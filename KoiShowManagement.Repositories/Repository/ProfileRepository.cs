using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ProfileRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Profile>> GetAllProfilesAsync()
        {
            return await _dbContext.Profiles.ToListAsync();
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileId == profileId);
        }

        public async Task<bool> AddProfileAsync(Profile profile)
        {
            try
            {
                await _dbContext.Profiles.AddAsync(profile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Update(profile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            try
            {
                var profile = await _dbContext.Profiles.FindAsync(profileId);
                if (profile != null)
                {
                    _dbContext.Profiles.Remove(profile);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
