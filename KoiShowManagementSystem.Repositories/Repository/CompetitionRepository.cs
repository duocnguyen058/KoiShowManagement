using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public CompetitionRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<Competition> GetCompetitionByIdAsync(int competitionId)
        {
            return await _context.Competitions
                .Include(c => c.Dashboards)
                .Include(c => c.Judges)
                .Include(c => c.KoiCompetitionCategories)
                .Include(c => c.Registrations)
                .Include(c => c.Reports)
                .Include(c => c.Results)
                .Include(c => c.Scores)
                .FirstOrDefaultAsync(c => c.CompetitionId == competitionId);
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsAsync()
        {
            return await _context.Competitions
                .Include(c => c.Dashboards)
                .Include(c => c.Judges)
                .Include(c => c.KoiCompetitionCategories)
                .Include(c => c.Registrations)
                .Include(c => c.Reports)
                .Include(c => c.Results)
                .Include(c => c.Scores)
                .ToListAsync();
        }

        public async Task<bool> CreateCompetitionAsync(Competition competition)
        {
            if (competition == null) return false;

            await _context.Competitions.AddAsync(competition);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCompetitionAsync(Competition competition)
        {
            if (competition == null) return false;

            _context.Competitions.Update(competition);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCompetitionAsync(int competitionId)
        {
            var competition = await _context.Competitions.FindAsync(competitionId);
            if (competition == null) return false;

            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
