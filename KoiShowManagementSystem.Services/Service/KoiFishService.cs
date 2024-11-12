using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Services.Service
{
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _koiFishRepository;

        public KoiFishService(IKoiFishRepository koiFishRepository)
        {
            _koiFishRepository = koiFishRepository;
        }

        public async Task<List<KoiFish>> GetAllKoiFishAsync()
        {
            try
            {
                return await _koiFishRepository.GetAllKoiFishAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy dữ liệu Koi Fish", ex);
            }
        }

        public async Task<KoiFish> GetKoiFishByIdAsync(int id)
        {
            try
            {
                var koiFish = await _koiFishRepository.GetKoiFishByIdAsync(id);
                if (koiFish == null)
                {
                    throw new Exception($"Không tìm thấy Koi Fish với ID {id}");
                }
                return koiFish;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi lấy Koi Fish theo ID", ex);
            }
        }

        public async Task<bool> AddKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                return await _koiFishRepository.AddKoiFishAsync(koiFish);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi thêm Koi Fish", ex);
            }
        }

        public async Task<bool> UpdateKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                return await _koiFishRepository.UpdateKoiFishAsync(koiFish);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật Koi Fish", ex);
            }
        }

        public async Task<bool> DeleteKoiFishByIdAsync(int id)
        {
            try
            {
                return await _koiFishRepository.DeleteKoiFishByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }

        public async Task<bool> DeleteKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                return await _koiFishRepository.DeleteKoiFishAsync(koiFish);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }

        public async Task<List<KoiFish>> SearchKoiFishAsync(string searchQuery, string variety, double? size, int? age)
        {
            try
            {
                return await _koiFishRepository.SearchKoiFishAsync(searchQuery, variety, size, age);
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi tìm kiếm Koi Fish", ex);
            }
        }
    }
}
