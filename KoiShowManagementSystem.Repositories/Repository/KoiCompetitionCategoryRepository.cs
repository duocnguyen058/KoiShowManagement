using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class KoiCompetitionCategoryRepository : IKoiCompetitionCategoryRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public KoiCompetitionCategoryRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<List<KoiCompetitionCategory>> GetAllKoiCompetitionCategoriesAsync()
        {
            return await _context.KoiCompetitionCategories
                .Include(k => k.Competition)
                .Include(k => k.Category)
                .Include(k => k.KoiFish)
                .ToListAsync();
        }

        public async Task<KoiCompetitionCategory> GetKoiCompetitionCategoryByIdAsync(int id)
        {
            return await _context.KoiCompetitionCategories
                .Include(k => k.Competition)
                .Include(k => k.Category)
                .Include(k => k.KoiFish)
                .FirstOrDefaultAsync(k => k.KoiCompetitionCategoryId == id);
        }

        public async Task<bool> AddKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            try
            {
                await _context.KoiCompetitionCategories.AddAsync(koiCompetitionCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            try
            {
                _context.KoiCompetitionCategories.Update(koiCompetitionCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteKoiCompetitionCategoryAsync(int id)
        {
            try
            {
                var koiCategory = await _context.KoiCompetitionCategories.FindAsync(id);
                if (koiCategory != null)
                {
                    _context.KoiCompetitionCategories.Remove(koiCategory);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            try
            {
                _context.KoiCompetitionCategories.Remove(koiCompetitionCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
