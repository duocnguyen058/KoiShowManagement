using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
	public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        public EventService(IEventRepository repository)
		{
            _repository = repository;
		}

        public bool AddEvent(Event @event)
        {
            return _repository.AddEvent(@event);
        }

        public bool DelEvent(int Id)
        {
            return _repository.DelEvent(Id);
        }

        public bool DelEvent(Event @event)
        {
            return _repository.DelEvent(@event);
        }

        public Task<List<Event>> GetAllEvents()
        {
            return _repository.GetAllEvents();
        }

        public Task<Event> GetEventById(int Id)
        {
            return _repository.GetEventById(Id);
        }

        public bool UpdEvent(Event @event)
        {
            return _repository.UpdEvent(@event);
        }
    }
}

