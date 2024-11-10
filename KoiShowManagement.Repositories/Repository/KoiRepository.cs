using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public KoiRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<List<Koi>> GetAllKoisAsync()
        {
            return await _dbContext.Kois
                .Include(k => k.Member)
                .Include(k => k.CompetitionResults)
                .Include(k => k.ScoreKois)
                .ToListAsync();
        }

       
        public async Task<Koi> GetKoiByIdAsync(int koiId)
        {
            return await _dbContext.Kois
                .Include(k => k.Member)
                .Include(k => k.CompetitionResults)
                .Include(k => k.ScoreKois)
                .FirstOrDefaultAsync(k => k.KoiId == koiId);
        }

       
        public async Task<bool> AddKoiAsync(Koi koi)
        {
            try
            {
                await _dbContext.Kois.AddAsync(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            try
            {
                _dbContext.Kois.Update(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            try
            {
                var koi = await _dbContext.Kois.FindAsync(koiId);
                if (koi == null) return false;
                _dbContext.Kois.Remove(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

