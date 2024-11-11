using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface IKoiFishService
    {
        Task<List<KoiFish>> GetAllKoiFishAsync();
        Task<KoiFish> GetKoiFishByIdAsync(int id);
        Task<bool> AddKoiFishAsync(KoiFish koiFish);
        Task<bool> UpdateKoiFishAsync(KoiFish koiFish);
        Task<bool> DeleteKoiFishByIdAsync(int id);
        Task<bool> DeleteKoiFishAsync(KoiFish koiFish);
    }
}
