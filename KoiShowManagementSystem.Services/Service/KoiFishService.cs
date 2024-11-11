using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;

namespace KoiShowManagementSystem.Services.Service
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _repository;

        public KoiFishService(IKoiFishRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KoiFish>> GetAllKoiFishAsync()
        {
            return await _repository.GetAllKoiFishAsync();
        }

        public async Task<KoiFish> GetKoiFishByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ.");
            return await _repository.GetKoiFishByIdAsync(id);
        }

        public async Task<bool> AddKoiFishAsync(KoiFish koiFish)
        {
            if (koiFish == null) throw new ArgumentNullException(nameof(koiFish));
            return await _repository.AddKoiFishAsync(koiFish);
        }

        public async Task<bool> UpdateKoiFishAsync(KoiFish koiFish)
        {
            if (koiFish == null) throw new ArgumentNullException(nameof(koiFish));
            return await _repository.UpdateKoiFishAsync(koiFish);
        }

        public async Task<bool> DeleteKoiFishByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("ID không hợp lệ.");
            return await _repository.DeleteKoiFishByIdAsync(id);
        }

        public async Task<bool> DeleteKoiFishAsync(KoiFish koiFish)
        {
            if (koiFish == null) throw new ArgumentNullException(nameof(koiFish));
            return await _repository.DeleteKoiFishAsync(koiFish);
        }
    }
}
