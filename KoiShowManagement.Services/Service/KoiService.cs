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

        public async Task<List<Koi>> GetAllKoisAsync()
        {
            try
            {
                return await _repository.GetAllKoisAsync();
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception("An error occurred while fetching all Kois.", ex);
            }
        }

        public async Task<Koi> GetKoiByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ; chỉ chấp nhận số nguyên dương", nameof(id));

            try
            {
                return await _repository.GetKoiByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception($"An error occurred while fetching Koi with ID {id}.", ex);
            }
        }

        public async Task<bool> AddKoiAsync(Koi koi)
        {
            try
            {
                ValidateKoi(koi);
                return await _repository.AddKoiAsync(koi);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception("An error occurred while adding a new Koi.", ex);
            }
        }

        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            try
            {
                ValidateKoi(koi);
                return await _repository.UpdateKoiAsync(koi);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception("An error occurred while updating the Koi.", ex);
            }
        }

        public async Task<bool> DeleteKoiAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ; chỉ chấp nhận số nguyên dương", nameof(id));

            try
            {
                return await _repository.DeleteKoiAsync(id);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception($"An error occurred while deleting Koi with ID {id}.", ex);
            }
        }

        public async Task<bool> DeleteKoiAsync(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Thông tin cá Koi không được để trống");

            try
            {
                return await _repository.DeleteKoiAsync(koi);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                throw new Exception("An error occurred while deleting the Koi.", ex);
            }
        }

        private void ValidateKoi(Koi koi)
        {
            if (koi == null)
                throw new ArgumentNullException(nameof(koi), "Thông tin cá Koi không được để trống");

            if (koi.KoiId <= 0)
                throw new ArgumentException("Mã Koi phải là số nguyên dương", nameof(koi.KoiId));

            if (string.IsNullOrWhiteSpace(koi.Name))
                throw new ArgumentException("Tên cá Koi không được để trống hoặc chỉ chứa khoảng trắng", nameof(koi.Name));

            if (koi.Age.HasValue && koi.Age <= 0)
                throw new ArgumentException("Tuổi của cá Koi phải là số nguyên dương", nameof(koi.Age));

            if (koi.Size.HasValue && koi.Size <= 0)
                throw new ArgumentException("Kích thước của cá Koi phải là số dương", nameof(koi.Size));

            if (string.IsNullOrWhiteSpace(koi.Color))
                throw new ArgumentException("Màu sắc của cá Koi không được để trống hoặc chỉ chứa khoảng trắng", nameof(koi.Color));
        }
    }
}
