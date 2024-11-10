using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<bool> AddEventAsync(Event eventObj);
        Task<bool> UpdateEventAsync(Event eventObj);
        Task<bool> DeleteEventAsync(int id);
        Task<bool> DeleteEventAsync(Event eventObj);
    }
}
