using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IEventService
    {
        // Gets a list of all events asynchronously
        Task<List<Event>> GetAllEventsAsync();

        // Gets an event by its ID asynchronously
        Task<Event> GetEventByIdAsync(int id);

        // Adds a new event asynchronously
        Task<bool> AddEventAsync(Event eventObj);

        // Updates an existing event asynchronously
        Task<bool> UpdateEventAsync(Event eventObj);

        // Deletes an event by ID asynchronously
        Task<bool> DeleteEventAsync(int id);

        // Deletes an event asynchronously by passing the event object
        Task<bool> DeleteEventAsync(Event eventObj);
    }
}
