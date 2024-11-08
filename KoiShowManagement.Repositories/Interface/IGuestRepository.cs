using KoiShowManagement.Repositories.Entities;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetAllGuests();
        bool DelGuest(int Id);
        bool DelGuest(Guest guest);
        bool AddGuest(Guest guest);
        bool UpdGuest(Guest guest);
        Task<Guest> GetGuestById(int Id);
    }
}
