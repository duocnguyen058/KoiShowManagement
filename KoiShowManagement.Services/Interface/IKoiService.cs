using KoiShowManagement.Repositories.Entities;
using System;
namespace KoiShowManagement.Services.Interface
{
    public interface IKoiService
    {
        Task<List<Koi>> GetAllKois();
        Boolean DelKoi(int Id);
        Boolean DelKoi(Koi koi);
        Boolean AddKoi(Koi koi);
        Boolean UpdKoi(Koi koi);
        Task<Koi> GetKoiById(int Id);
    }
}
