using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace KoiShowManagement.Repositories.Repository
{
    public class ScoreKoiRepository : IScoreKoiRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ScoreKoiRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                await _dbContext.ScoreKois.AddAsync(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelScoreKoiAsync(int Id)
        {
            try
            {
                var objDel = await _dbContext.ScoreKois.FindAsync(Id);
                if (objDel != null)
                {
                    _dbContext.ScoreKois.Remove(objDel);
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

        public async Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Remove(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<ScoreKoi> GetScoreKoiByIdAsync(int Id)
        {
            return await _dbContext.ScoreKois.Where(p => p.ScoreKoiId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<ScoreKoi>> GetScoreKoisAsync()
        {
            return await _dbContext.ScoreKois.ToListAsync();
        }

        public async Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Update(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                throw new Exception("Error updating ScoreKoi: " + ex.Message);
            }
        }
    }
}
