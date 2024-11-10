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

        public async Task<bool> DeleteGuestAsync(int Id)
        {
            try
            {
                var objDel = await _dbContext.Guests.FirstOrDefaultAsync(g => g.GuestId == Id);
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

        public async Task<bool> DeleteGuestAsync(Guest guest)
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

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            return await _dbContext.Guests.ToListAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int Id)
        {
            return await _dbContext.Guests.FirstOrDefaultAsync(g => g.GuestId == Id);
        }

        public async Task<List<Guest>> SearchGuestsAsync(string? name, string? email, string? phone)
        {
            var query = _dbContext.Guests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(g => g.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(g => g.Email.Contains(email));

            if (!string.IsNullOrWhiteSpace(phone))
                query = query.Where(g => g.Phone.Contains(phone));

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateGuestAsync(Guest guest)
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

