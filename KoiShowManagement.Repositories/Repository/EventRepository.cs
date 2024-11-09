using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public EventRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.EventId == id);
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            try
            {
                await _dbContext.Events.AddAsync(eventObj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> UpdateEventAsync(Event eventObj)
        {
            try
            {
                _dbContext.Events.Update(eventObj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var eventObj = await _dbContext.Events.FindAsync(id);
                if (eventObj != null)
                {
                    _dbContext.Events.Remove(eventObj);
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

        public async Task<bool> DeleteEventAsync(Event eventObj)
        {
            try
            {
                _dbContext.Events.Remove(eventObj);
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
