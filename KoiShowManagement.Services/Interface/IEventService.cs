using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
	public interface IEventService
	{
        Task<List<Event>> GetAllEvents();
        Boolean DelEvent(int Id);
        Boolean DelEvent(Event @event);
        Boolean AddEvent(Event @event);
        Boolean UpdEvent(Event @event);
        Task<Event> GetEventById(int Id);
    }
}

