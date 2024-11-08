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
        public bool AddGuest(Guest guest)
        {
            try
            {
                _dbContext.Guests.Add(guest);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DelGuest(int Id)
        {
            try
            {
                var guestToDelete = _dbContext.Guests.Where(g => g.GuestId.Equals(Id)).FirstOrDefault();
                if (guestToDelete != null)
                {
                    _dbContext.Guests.Remove(guestToDelete);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DelGuest(Guest guest)
        {
            try
            {
                _dbContext.Guests.Remove(guest);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Guest>> GetAllGuests()
        {
            return await _dbContext.Guests.ToListAsync();
        }

        public async Task<Guest> GetGuestById(int Id)
        {
            return await _dbContext.Guests.Where(g => g.GuestId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdGuest(Guest guest)
        {
            try
            {
                _dbContext.Guests.Update(guest);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
