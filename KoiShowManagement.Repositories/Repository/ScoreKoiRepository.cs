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

        public bool AddScoreKoi(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Add(scoreKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelScoreKoi(int Id)
        {
             try
            {
                var objDel = _dbContext.ScoreKois.Where(p => p.ScoreKoiId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.ScoreKois.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelScoreKoi(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Remove(scoreKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<ScoreKoi>> GetAllScoreKoi()
        {
            return await _dbContext.ScoreKois.ToListAsync();
        }

        public async Task<ScoreKoi> GetScoreKoiId(int Id)
        {
            return await _dbContext.ScoreKois.Where(p => p.ScoreKoiId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdScoreKoi(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Update(scoreKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }
    }
}
