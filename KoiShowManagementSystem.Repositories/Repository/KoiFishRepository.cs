using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;
        private readonly ILogger<KoiFishRepository> _logger;

        public KoiFishRepository(KoiShowManagementDbcontextContext context, ILogger<KoiFishRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Lấy tất cả các Koi Fish
        public async Task<List<KoiFish>> GetAllKoiFishAsync()
        {
            try
            {
                return await _context.KoiFishes
                                     .Include(k => k.Account)
                                     .Include(k => k.KoiCompetitionCategories)
                                     .Include(k => k.Registrations)
                                     .Include(k => k.Results)
                                     .Include(k => k.Scores)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi lấy dữ liệu Koi Fish");
                throw new Exception("Có lỗi xảy ra khi lấy dữ liệu Koi Fish", ex);
            }
        }

        // Lấy Koi Fish theo ID
        public async Task<KoiFish> GetKoiFishByIdAsync(int id)
        {
            try
            {
                return await _context.KoiFishes
                                     .Include(k => k.Account)
                                     .Include(k => k.KoiCompetitionCategories)
                                     .Include(k => k.Registrations)
                                     .Include(k => k.Results)
                                     .Include(k => k.Scores)
                                     .FirstOrDefaultAsync(k => k.KoiFishId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi lấy Koi Fish theo ID");
                throw new Exception("Có lỗi xảy ra khi lấy Koi Fish theo ID", ex);
            }
        }

        // Thêm mới một Koi Fish
        public async Task<bool> AddKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                await _context.KoiFishes.AddAsync(koiFish);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi thêm Koi Fish");
                throw new Exception("Có lỗi xảy ra khi thêm Koi Fish", ex);
            }
        }

        // Cập nhật Koi Fish
        public async Task<bool> UpdateKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                _context.KoiFishes.Update(koiFish);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi cập nhật Koi Fish");
                throw new Exception("Có lỗi xảy ra khi cập nhật Koi Fish", ex);
            }
        }

        // Xóa Koi Fish theo ID
        public async Task<bool> DeleteKoiFishByIdAsync(int id)
        {
            try
            {
                var koiFish = await GetKoiFishByIdAsync(id);
                if (koiFish == null) return false;

                _context.KoiFishes.Remove(koiFish);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi xóa Koi Fish");
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }

        // Xóa Koi Fish theo đối tượng
        public async Task<bool> DeleteKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                if (koiFish == null) return false;

                _context.KoiFishes.Remove(koiFish);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi xóa Koi Fish");
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }

        // Tìm kiếm Koi Fish theo từ khóa, variety, size và age
        public async Task<List<KoiFish>> SearchKoiFishAsync(string searchQuery, string variety, double? size, int? age)
        {
            try
            {
                var query = _context.KoiFishes.AsQueryable();

                // Tìm kiếm theo từ khóa
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query = query.Where(k => k.Name.Contains(searchQuery) || k.Variety.Contains(searchQuery));
                }

                // Tìm kiếm theo variety
                if (!string.IsNullOrWhiteSpace(variety))
                {
                    query = query.Where(k => k.Variety.Contains(variety));
                }

                // Tìm kiếm theo size
                if (size.HasValue)
                {
                    query = query.Where(k => k.Size == size);
                }

                // Tìm kiếm theo age
                if (age.HasValue)
                {
                    query = query.Where(k => k.Age == age);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Có lỗi xảy ra khi tìm kiếm Koi Fish");
                throw new Exception("Có lỗi xảy ra khi tìm kiếm Koi Fish", ex);
            }
        }
    }
}
