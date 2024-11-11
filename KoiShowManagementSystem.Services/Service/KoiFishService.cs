using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public KoiFishRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

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
                throw new Exception("Có lỗi xảy ra khi lấy dữ liệu Koi Fish", ex);
            }
        }

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
                throw new Exception("Có lỗi xảy ra khi lấy Koi Fish theo ID", ex);
            }
        }

        public async Task<bool> AddKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                await _context.KoiFishes.AddAsync(koiFish);
                return await _context.SaveChangesAsync() > 0;
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
                _context.KoiFishes.Update(koiFish);
                return await _context.SaveChangesAsync() > 0;
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
                var koiFish = await GetKoiFishByIdAsync(id);
                if (koiFish == null) return false;
                _context.KoiFishes.Remove(koiFish);
                return await _context.SaveChangesAsync() > 0;
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
                if (koiFish == null) return false;
                _context.KoiFishes.Remove(koiFish);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }

        public async Task<List<KoiFish>> SearchKoiFishAsync(string searchQuery, string variety, double? size, int? age)
        {
            var query = _context.KoiFishes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(k => k.Name.Contains(searchQuery) || k.Variety.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(variety))
            {
                query = query.Where(k => k.Variety.Contains(variety));
            }

            if (size.HasValue)
            {
                query = query.Where(k => k.Size == size);
            }

            if (age.HasValue)
            {
                query = query.Where(k => k.Age == age);
            }

            return await query.ToListAsync();
        }
    }
}
