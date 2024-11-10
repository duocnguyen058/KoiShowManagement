using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IKoiService
    {
        Task<List<Koi>> GetAllKoisAsync();  // Fetch all Kois asynchronously
        Task<Koi> GetKoiByIdAsync(int id);  // Fetch a single Koi by ID asynchronously
        Task<bool> AddKoiAsync(Koi koi);    // Add a new Koi asynchronously
        Task<bool> UpdateKoiAsync(Koi koi); // Update an existing Koi asynchronously
        Task<bool> DeleteKoiAsync(int id);  // Delete a Koi by ID asynchronously
        Task<bool> DeleteKoiAsync(Koi koi); // Delete a Koi by object asynchronously
    }
}
