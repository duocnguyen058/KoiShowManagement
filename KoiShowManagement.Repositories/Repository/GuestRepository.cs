using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace KoiShowManagement.Repositories.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public GuestRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddGuestAsync(Guest guest)
        {
            try
            {
                await _dbContext.Guests.AddAsync(guest);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        public async Task<bool> DelGuestAsync(int Id)
        {
            try
            {
                var objDel = _dbContext.Guests.Where(p => p.GuestId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Guests.Remove(objDel);
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

        public async Task<bool> DelGuestAsync(Guest guest)
        {
            try
            {
                _dbContext.Guests.Remove(guest);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        public async Task<Guest> GetGuestByIdAsync(int Id)
        {
            return await _dbContext.Guests.Where(p => p.GuestId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Guest>> GetGuestsAsync()
        {
            return await _dbContext.Guests.ToListAsync();
        }

        public async Task<bool> UpdGuestAsync(Guest guest)
        {
            try
            {
                _dbContext.Guests.Update(guest);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }
    }
}
