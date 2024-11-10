using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IGuestService
    {
        Task<List<Guest>> GetAllGuestsAsync();
        Task<bool> DeleteGuestAsync(int Id);
        Task<bool> DeleteGuestAsync(Guest guest);
        Task<bool> AddGuestAsync(Guest guest);
        Task<bool> UpdateGuestAsync(Guest guest);
        Task<Guest> GetGuestByIdAsync(int Id);
        Task<List<Guest>> SearchGuestsAsync(string? name, string? email, string? phone);
    }
}
