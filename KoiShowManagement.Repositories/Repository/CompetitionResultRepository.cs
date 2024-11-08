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

        public bool AddCompetitionResult(CompetitionResult result)
        {
            try
            {
                _dbContext.CompetitionResults.Add(result);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }

        }

        public bool DelCompetitionResult(int Id)
        {
            try
            {
                var objDel = _dbContext.CompetitionResults.Where(p => p.ResultId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.CompetitionResults.Remove(objDel);
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

        public bool DelCompetitionResult(CompetitionResult result)
        {
            try
            {
                _dbContext.CompetitionResults.Remove(result);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }

        }

        public async Task<List<CompetitionResult>> GetAllCompetitionResults()
        {
            return await _dbContext.CompetitionResults.ToListAsync();

        }

        public async Task<CompetitionResult> GetCompetitionResultById(int Id)
        {
            return await _dbContext.CompetitionResults.Where(p => p.ResultId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdCompetitionResult(CompetitionResult result)
        {
            try
            {
                _dbContext.CompetitionResults.Update(result);
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