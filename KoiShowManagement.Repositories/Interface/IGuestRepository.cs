using KoiShowManagement.Repositories.Entities;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetAllGuests();
        Boolean DelGuest(int Id);
        Boolean DelGuest(Guest guest);
        Boolean AddGuest(Guest guest);
        Boolean UpdGuest(Guest guest);
        Task<Guest> GetGuestById(int Id);
    }
}
