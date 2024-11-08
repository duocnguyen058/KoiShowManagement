using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KoiShowManagement.Repositories.Repository
{
	public class ProfileRepository : IProfileRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public ProfileRepository(KoiShowManagementDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public bool AddProfile(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Add(profile);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelProfile(int Id)
        {
            try
            {
                var objDel = _dbContext.Profiles.Where(p => p.ProfileId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Profiles.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelProfile(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Remove(profile);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _dbContext.Profiles.ToListAsync();
        }

        public async Task<Profile> GetEventById(int Id)
        {
            return await _dbContext.Profiles.Where(p => p.ProfileId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdProfile(Profile profile)
        {
            try
            {
                _dbContext.Profiles.Update(profile);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }
    }
}

