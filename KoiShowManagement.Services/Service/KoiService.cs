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

        public async Task<bool> AddKoiAsync(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Koi không được để trống.");
            if (koi.KoiId <= 0)
                throw new ArgumentException("ID của Koi phải là số nguyên dương.", nameof(koi.KoiId));
            if (string.IsNullOrWhiteSpace(koi.Name))
                throw new ArgumentException("Tên Koi không được để trống hoặc chỉ chứa khoảng trống.", nameof(koi.Name));
            if (koi.Age < 0)
                throw new ArgumentException("Tuổi của Koi không được là số âm.", nameof(koi.Age));

            return await _repository.AddKoiAsync(koi);
        }

        public async Task<bool> DeleteKoiAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.DeleteKoiAsync(Id);
        }

        public async Task<bool> DeleteKoiAsync(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Koi không được để trống.");

            return await _repository.DeleteKoiAsync(koi);
        }

        public async Task<List<Koi>> GetKoisAsync()
        {
            return await _repository.GetKoisAsync();
        }

        public async Task<Koi> GetKoiByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.GetKoiByIdAsync(Id);
        }

        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Koi không được để trống.");
            if (koi.KoiId <= 0)
                throw new ArgumentException("ID của Koi phải là số nguyên dương.", nameof(koi.KoiId));
            if (string.IsNullOrWhiteSpace(koi.Name))
                throw new ArgumentException("Tên Koi không được để trống hoặc chỉ chứa khoảng trống.", nameof(koi.Name));
            if (koi.Age < 0)
                throw new ArgumentException("Tuổi của Koi không được là số âm.", nameof(koi.Age));

            return await _repository.UpdateKoiAsync(koi);
        }
    }
}
