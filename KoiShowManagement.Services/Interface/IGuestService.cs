using KoiShowManagement.Repositories.Entities;
using System;
namespace KoiShowManagement.Services.Interface
{
    public interface IGuestService
    {
        Task<List<Guest>> GetAllGuests();
        Boolean DelGuest(int Id);
        Boolean DelGuest(Guest guest);
        Boolean AddGuest(Guest guest);
        Boolean UpdGuest(Guest guest);
        Task<Guest> GetGuestById(int Id);
    }
}
