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
            };
        }

        public async Task<bool> DeleteScoreKoiAsync(int Id)
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

        public async Task<bool> DeleteScoreKoiAsync(ScoreKoi scoreKoi)
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

        public async Task<List<ScoreKoi>> GetAllScoreKois()
        {
            return await _dbContext.ScoreKois.ToListAsync();
        }

        public async Task<List<ScoreKoi>> GetAllScoreKoisAsync()
        {
            return await _dbContext.ScoreKois.ToListAsync();
        }

        public Task<ScoreKoi> GetScoreKoiById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ScoreKoi> GetScoreKoiByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Update(scoreKoi);
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
