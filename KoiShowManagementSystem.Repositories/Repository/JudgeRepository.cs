using KoiShowManagementSystem.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories
{
    public class JudgeRepository : IJudgeRepository
    {
        private readonly KoiShowManagementDbContext _context;

        public JudgeRepository(KoiShowManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<Judge>> GetAllAsync()
        {
            return await _context.Judges
                .Include(j => j.Account)
                .Include(j => j.Competition)
                .Include(j => j.Scores)
                .ToListAsync();
        }

        public async Task<Judge> GetByIdAsync(int id)
        {
            return await _context.Judges
                .Include(j => j.Account)
                .Include(j => j.Competition)
                .Include(j => j.Scores)
                .FirstOrDefaultAsync(j => j.JudgeId == id);
        }

        public async Task AddAsync(Judge judge)
        {
            await _context.Judges.AddAsync(judge);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Judge judge)
        {
            _context.Judges.Update(judge);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var judge = await _context.Judges.FindAsync(id);
            if (judge != null)
            {
                _context.Judges.Remove(judge);
                await _context.SaveChangesAsync();
            }
        }
    }
}
