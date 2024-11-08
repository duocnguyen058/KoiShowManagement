using System;
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

        public bool AddEvent(Event @event)
        {
            try
            {
                _dbContext.Events.Add(@event);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelEvent(int Id)
        {
            try
            {
                var objDel = _dbContext.Events.Where(p => p.EventId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Events.Remove(objDel);
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

        public bool DelEvent(Event @event)
        {
            try
            {
                _dbContext.Events.Remove(@event);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }

        }
        public async Task<Event> EventById(int Id)
        {
            return await _dbContext.Events.Where(p => p.EventId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public bool UpdEvent(Event @event)
        {
            try
            {
                _dbContext.Events.Update(@event);
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