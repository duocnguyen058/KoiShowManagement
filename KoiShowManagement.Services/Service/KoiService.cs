using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;
using KoiShowManagement.Repositories.Interface;
using System;
namespace KoiShowManagement.Services.Service
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _repository;
        public KoiService(IKoiRepository repository)
        {
            _repository = repository;
        }
        public bool AddKoi(Koi koi)
        {
            return _repository.AddKoi(koi);
        }

        public bool DelKoi(int Id)
        {
            return _repository.DelKoi(Id);
        }

        public bool DelKoi(Koi koi)
        {
            return _repository.DelKoi(koi);
        }

        public Task<List<Koi>> GetAllKois()
        {
            return _repository.GetAllKois();
        }

        public Task<Koi> GetKoiById(int Id)
        {
            return _repository.GetKoiById(Id);
        }

        public bool UpdKoi(Koi koi)
        {
            return _repository.UpdKoi(koi);
        }
    }
}
