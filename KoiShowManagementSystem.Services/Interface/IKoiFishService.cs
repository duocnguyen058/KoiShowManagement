using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services
{
    public interface IKoiFishService
    {
        Task<List<KoiFish>> GetAllKoiFishAsync();
        Task<KoiFish> GetKoiFishByIdAsync(int id);
        Task<bool> AddKoiFishAsync(KoiFish koiFish);
        Task<bool> UpdateKoiFishAsync(KoiFish koiFish);
        Task<bool> DeleteKoiFishByIdAsync(int id);
        Task<bool> DeleteKoiFishAsync(KoiFish koiFish);
        Task<List<KoiFish>> SearchKoiFishAsync(string searchQuery, string variety, double? size, int? age);
    }
}
