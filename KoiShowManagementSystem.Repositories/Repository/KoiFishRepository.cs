using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public KoiFishRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        // Lấy tất cả các Koi Fish
        public async Task<List<KoiFish>> GetAllKoiFishAsync()
        {
            try
            {
                return await _context.KoiFishes
                                     .Include(k => k.Account)  // Bao gồm dữ liệu của Account
                                     .Include(k => k.Category)  // Bao gồm dữ liệu của Category
                                     .Include(k => k.Registrations)  // Bao gồm dữ liệu của Registration
                                     .Include(k => k.Results)  // Bao gồm dữ liệu của Result
                                     .Include(k => k.Scores)  // Bao gồm dữ liệu của Score
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
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
                                     .Include(k => k.Category)
                                     .Include(k => k.Registrations)
                                     .Include(k => k.Results)
                                     .Include(k => k.Scores)
                                     .FirstOrDefaultAsync(k => k.KoiFishId == id);
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                throw new Exception("Có lỗi xảy ra khi lấy Koi Fish theo ID", ex);
            }
        }

        // Thêm mới một Koi Fish
        public async Task<bool> AddKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                await _context.KoiFishes.AddAsync(koiFish);
                return await _context.SaveChangesAsync() > 0;  // Nếu lưu thành công trả về true
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                throw new Exception("Có lỗi xảy ra khi thêm Koi Fish", ex);
            }
        }

        // Cập nhật Koi Fish
        public async Task<bool> UpdateKoiFishAsync(KoiFish koiFish)
        {
            try
            {
                _context.KoiFishes.Update(koiFish);
                return await _context.SaveChangesAsync() > 0;  // Nếu cập nhật thành công trả về true
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
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
                return await _context.SaveChangesAsync() > 0;  // Nếu xóa thành công trả về true
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
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
                return await _context.SaveChangesAsync() > 0;  // Nếu xóa thành công trả về true
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                throw new Exception("Có lỗi xảy ra khi xóa Koi Fish", ex);
            }
        }
    }
}
