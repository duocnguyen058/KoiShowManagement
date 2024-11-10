using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IKoiService
    {
        Task<List<Koi>> GetAllKoisAsync();
        Task<Koi> GetKoiByIdAsync(int koiId);
        Task<bool> AddKoiAsync(Koi koi);
        Task<bool> UpdateKoiAsync(Koi koi);
        Task<bool> DeleteKoiAsync(int koiId);
    }
}
