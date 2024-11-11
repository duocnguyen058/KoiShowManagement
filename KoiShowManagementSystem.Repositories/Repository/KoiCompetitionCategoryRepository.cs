using KoiShowManagementSystem.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories
{
    public class KoiCompetitionRepository : IKoiCompetitionRepository
    {
        private readonly KoiShowManagementDbContext _context;

        public KoiCompetitionRepository(KoiShowManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<KoiCompetitionCategory>> GetAllAsync()
        {
            return await _context.KoiCompetitionCategories
                .Include(k => k.Competition)
                .Include(k => k.Category)
                .Include(k => k.KoiFish)
                .ToListAsync();
        }

        public async Task<KoiCompetitionCategory> GetByIdAsync(int id)
        {
            return await _context.KoiCompetitionCategories
                .Include(k => k.Competition)
                .Include(k => k.Category)
                .Include(k => k.KoiFish)
                .FirstOrDefaultAsync(k => k.KoiCompetitionCategoryId == id);
        }

        public async Task AddAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            await _context.KoiCompetitionCategories.AddAsync(koiCompetitionCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KoiCompetitionCategory koiCompetitionCategory)
        {
            _context.KoiCompetitionCategories.Update(koiCompetitionCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var koiCompetitionCategory = await _context.KoiCompetitionCategories.FindAsync(id);
            if (koiCompetitionCategory != null)
            {
                _context.KoiCompetitionCategories.Remove(koiCompetitionCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
