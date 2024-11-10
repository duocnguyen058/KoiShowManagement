using KoiShowManagement.Repositories.Entities;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetGuestsAsync();
        Task<bool> DelGuestAsync(int Id);
        Task<bool> DelGuestAsync(Guest guest);
        Task<bool> AddGuestAsync(Guest guest);
        Task<bool> UpdGuestAsync(Guest guest);
        Task<Guest> GetGuestByIdAsync(int Id);
    }
}
