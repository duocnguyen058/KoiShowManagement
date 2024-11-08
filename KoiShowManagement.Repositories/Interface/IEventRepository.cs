using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvents();
        Boolean DelEvent(int Id);
        Boolean DelEvent(Event @event);
        Boolean AddEvent(Event @event);
        Boolean UpdEvent(Event @event);
        Task<Event> GetEventById(int Id);
    }
}