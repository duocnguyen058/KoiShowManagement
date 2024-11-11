using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IKoiFishRepository
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
