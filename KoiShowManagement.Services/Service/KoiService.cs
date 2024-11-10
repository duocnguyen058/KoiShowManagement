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

        public async  Task<bool> AddKoiAsync(Koi koi)
        {
            ValidateKoi(koi);
            return await _repository.AddKoiAsync(koi);
        }

        private void ValidateKoi(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Thong tin ca Koi khong duoc de trong");

            if (koi.KoiId <= 0)
                throw new ArgumentException("Ma Koi phai la so nguyen duong", nameof(koi.KoiId));

            if (string.IsNullOrWhiteSpace(koi.Name))
                throw new ArgumentException("Ten ca Koi khong duoc de trong hoac chi chua khoang trang", nameof(koi.Name));

            if (koi.Age.HasValue && koi.Age <= 0)
                throw new ArgumentException("Tuoi cua ca Koi phai la so nguyen duong", nameof(koi.Age));

            if (koi.Size.HasValue && koi.Size <= 0)
                throw new ArgumentException("Kich thuoc cua ca Koi phai la so duong", nameof(koi.Size));

            if (string.IsNullOrWhiteSpace(koi.Color))
                throw new ArgumentException("Mau sac cua ca Koi khong duoc de trong hoac chi chua khoang trang", nameof(koi.Color));
        }

        public async Task<bool> DeleteKoiAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID khong hop le; chi chap nhan so nguyen duong", nameof(Id));

            return await _repository.DeleteKoiAsync(Id);
        }

        public async Task<bool> DeleteKoiAsync(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Thong tin ca Koi khong duoc de trong");

            return await _repository.DeleteKoiAsync(koi);
        }

        public async Task<List<Koi>> GetAllKoisAsync()
        {
            return await _repository.GetAllKoisAsync();
        }

        public async Task<Koi> GetKoiByIdAsync(int Id)
        {
             if (Id <= 0)
                throw new ArgumentException("ID khong hop le; chi chap nhan so nguyen duong", nameof(Id));

            return await _repository.GetKoiByIdAsync(Id);
        }

        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            ValidateKoi(koi);
            return await _repository.UpdateKoiAsync(koi);
        }
    }
}


