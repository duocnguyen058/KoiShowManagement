using KoiShowManagement.Repositories.Entities;
using System;
using System.Threading.Tasks;
namespace KoiShowManagement.Services.Interface
{
    public interface IKoiService
    {
        Task<List<Koi>> GetAllKois();
        Boolean DelKoi(int Id);
        Boolean DelKoi(Koi koi);
        Task<bool> AddKoi(Koi koi); // Thay đổi thành Task<bool>
        Boolean UpdKoi(Koi koi);
        Task<Koi> GetKoiById(int Id);
        string? GetAll();
        string? GetById(int id);
    }
}
