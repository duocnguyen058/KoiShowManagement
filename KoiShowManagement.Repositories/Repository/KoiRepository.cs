using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public KoiRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddKoiAsync(Koi koi)
        {
            try
            {
                await _dbContext.Kois.AddAsync(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteKoiAsync(int Id)
        {
            try
            {
                var objDel = await _dbContext.Kois.FindAsync(Id);
                if (objDel != null)
                {
                    _dbContext.Kois.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteKoiAsync(Koi koi)
        {
            try
            {
                _dbContext.Kois.Remove(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Koi> GetKoiByIdAsync(int Id)
        {
            return await _dbContext.Kois.Where(p => p.KoiId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Koi>> GetKoisAsync()
        {
            return await _dbContext.Kois.ToListAsync();
        }

        public async Task<bool> UpdateKoiAsync(Koi koi)
        {
            try
            {
                _dbContext.Kois.Update(koi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
