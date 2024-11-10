using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class RefereeRepository : IRefereeRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public RefereeRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Referee>> GetAllRefereesAsync()
        {
            return await _dbContext.Referees.Include(r => r.CompetitionResults).Include(r => r.ScoreKois).ToListAsync();
        }

        public async Task<Referee> GetRefereeByIdAsync(int refereeId)
        {
            return await _dbContext.Referees.Include(r => r.CompetitionResults).Include(r => r.ScoreKois)
                                            .FirstOrDefaultAsync(r => r.RefereeId == refereeId);
        }

        public async Task<bool> AddRefereeAsync(Referee referee)
        {
            try
            {
                await _dbContext.Referees.AddAsync(referee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRefereeAsync(Referee referee)
        {
            try
            {
                _dbContext.Referees.Update(referee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRefereeByIdAsync(int refereeId)
        {
            var referee = await GetRefereeByIdAsync(refereeId);
            if (referee == null) return false;
            return await DeleteRefereeAsync(referee);
        }

        public async Task<bool> DeleteRefereeAsync(Referee referee)
        {
            try
            {
                _dbContext.Referees.Remove(referee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Referee>> GetRefereesByExpertiseLevelAsync(string expertiseLevel)
        {
            return await _dbContext.Referees.Where(r => r.ExpertiseLevel == expertiseLevel).ToListAsync();
        }

        // Triển khai chức năng tìm kiếm với các tiêu chí tùy chọn
        public async Task<List<Referee>> SearchRefereesAsync(string name = null, string email = null, string expertiseLevel = null)
        {
            var query = _dbContext.Referees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(r => r.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(r => r.Email.Contains(email));
            }

            if (!string.IsNullOrWhiteSpace(expertiseLevel))
            {
                query = query.Where(r => r.ExpertiseLevel.Contains(expertiseLevel));
            }

            return await query.Include(r => r.CompetitionResults).Include(r => r.ScoreKois).ToListAsync();
        }
    }
}
 
