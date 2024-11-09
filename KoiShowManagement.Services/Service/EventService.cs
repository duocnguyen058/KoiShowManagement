using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ. ID phải là số nguyên dương.", nameof(id));

            return await _eventRepository.GetEventByIdAsync(id);
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            if (eventObj == null)
                throw new ArgumentNullException(nameof(eventObj), "Sự kiện không được để trống.");
            if (string.IsNullOrWhiteSpace(eventObj.EventName))
                throw new ArgumentException("Tên sự kiện không được để trống hoặc chứa khoảng trắng.", nameof(eventObj.EventName));

            return await _eventRepository.AddEventAsync(eventObj);
        }

        public async Task<bool> UpdateEventAsync(Event eventObj)
        {
            if (eventObj == null)
                throw new ArgumentNullException(nameof(eventObj), "Sự kiện không được để trống.");
            if (eventObj.EventId <= 0)
                throw new ArgumentException("ID sự kiện không hợp lệ. ID phải là số nguyên dương.", nameof(eventObj.EventId));

            return await _eventRepository.UpdateEventAsync(eventObj);
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ. ID phải là số nguyên dương.", nameof(id));

            return await _eventRepository.DeleteEventAsync(id);
        }

        public async Task<bool> DeleteEventAsync(Event eventObj)
        {
            if (eventObj == null)
                throw new ArgumentNullException(nameof(eventObj), "Sự kiện không được để trống.");

            return await _eventRepository.DeleteEventAsync(eventObj);
        }
    }
}
