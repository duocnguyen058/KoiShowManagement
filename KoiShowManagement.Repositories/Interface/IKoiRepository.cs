using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IKoiRepository
    {
        Task<List<Koi>> GetAllKois();
        bool DelKoi(int Id);
        bool DelKoi(Koi koi);
        bool AddKoi(Koi koi);
        bool UpdKoi(Koi koi);
        Task<Koi> GetKoiById(int Id);
    }
}
