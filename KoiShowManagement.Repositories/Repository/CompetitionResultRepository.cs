using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class CompetitionResultRepository : ICompetitionResultRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public CompetitionResultRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCompetitionResultAsync(CompetitionResult result)
        {
            try
            {
                await _dbContext.CompetitionResults.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        public async Task<bool> DelCompetitionResultAsync(int Id)
        {
            try
            {
                var objDel = _dbContext.CompetitionResults.Where(p => p.ResultId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.CompetitionResults.Remove(objDel);
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

        public async Task<bool> DelCompetitionResultAsync(CompetitionResult result)
        {
            try
            {
                _dbContext.CompetitionResults.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        public async Task<List<CompetitionResult>> GetAllCompetitionResultsAsync()
        {
            return await _dbContext.CompetitionResults.ToListAsync();
        }

        public async Task<CompetitionResult> GetCompetitionResultByIdAsync(int Id)
        {
            return await _dbContext.CompetitionResults.Where(p => p.ResultId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdCompetitionResultAsync(CompetitionResult result)
        {
            try
            {
                _dbContext.CompetitionResults.Update(result);
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