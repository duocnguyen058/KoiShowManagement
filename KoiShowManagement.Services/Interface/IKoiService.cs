using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IKoiService
    {
        Task<List<Koi>> GetKoisAsync();
        Task<bool> DeleteKoiAsync(int Id);
        Task<bool> DeleteKoiAsync(Koi koi);
        Task<bool> AddKoiAsync(Koi koi);
        Task<bool> UpdateKoiAsync(Koi koi);
        Task<Koi> GetKoiByIdAsync(int Id);
    }
}
