using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _repository;

        public KoiService(IKoiRepository repository)
        {
            _repository = repository;
        }

        // Lay tat ca ca Koi
        public async Task<List<Koi>> GetAllKoisAsync()
        {
            return await _repository.GetAllKoisAsync();
        }

        // Lay ca Koi theo ID
        public async Task<Koi> GetKoiByIdAsync(int koiId)
        {
            if (koiId <= 0)
                throw new ArgumentException("ID khong hop le, chi chap nhan so nguyen duong", nameof(koiId));

            return await _repository.GetKoiByIdAsync(koiId);
        }

        // Them ca Koi
        public async Task<bool> AddKoiAsync(Koi koi)
        {
            ValidateKoi(koi);
            return await _repository.AddKoiAsync(koi);
        }

        // Cap nhat thong tin ca Koi
        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            ValidateKoi(koi);
            return await _repository.UpdateKoiAsync(koi);
        }

        // Xoa ca Koi theo ID
        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            if (koiId <= 0)
                throw new ArgumentException("ID khong hop le, chi chap nhan so nguyen duong", nameof(koiId));

            return await _repository.DeleteKoiAsync(koiId);
        }

        // Ham xac thuc cac thong tin cua Koi
        private void ValidateKoi(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Thong tin ca Koi khong duoc de trong");

            if (string.IsNullOrWhiteSpace(koi.Name))
                throw new ArgumentException("Ten ca Koi khong duoc de trong hoac chi chua khoang trang", nameof(koi.Name));

            if (koi.Age.HasValue && koi.Age <= 0)
                throw new ArgumentException("Tuoi cua ca Koi phai la so nguyen duong", nameof(koi.Age));

            if (koi.Size.HasValue && koi.Size <= 0)
                throw new ArgumentException("Kich thuoc cua ca Koi phai la so duong", nameof(koi.Size));

            if (string.IsNullOrWhiteSpace(koi.Color))
                throw new ArgumentException("Mau sac cua ca Koi khong duoc de trong hoac chi chua khoang trang", nameof(koi.Color));
        }
    }
}
