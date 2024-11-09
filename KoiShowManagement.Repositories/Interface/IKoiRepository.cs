using KoiShowManagement.Repositories.Entities;
using System;
namespace KoiShowManagement.Repositories.Interface
{
    public interface IKoiRepository
    {
        Task<List<Koi>> GetKoiAsync();
        Task<bool> DelKoiAsync(int Id);
        Task<bool> DelKoiAsync(Koi koi);
        Task<bool> AddKoiAsync(Koi koi);
        Task<bool> UpdKoiAsync(Koi koi);
        Task<Koi> GetKoiByIdAsync(int Id);
    }
}
