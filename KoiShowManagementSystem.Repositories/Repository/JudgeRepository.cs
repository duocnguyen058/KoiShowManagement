using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class JudgeRepository : IJudgeRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public JudgeRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<List<Judge>> GetAllJudgesAsync()
        {
            return await _context.Judges
                .Include(j => j.Account)  // Optional: to include related data (Account)
                .Include(j => j.Competition)  // Optional: to include related data (Competition)
                .ToListAsync();
        }

        public async Task<Judge> GetJudgeByIdAsync(int id)
        {
            return await _context.Judges
                .Include(j => j.Account)
                .Include(j => j.Competition)
                .FirstOrDefaultAsync(j => j.JudgeId == id);
        }

        public async Task<bool> AddJudgeAsync(Judge judge)
        {
            try
            {
                await _context.Judges.AddAsync(judge);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateJudgeAsync(Judge judge)
        {
            try
            {
                _context.Judges.Update(judge);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteJudgeAsync(int id)
        {
            try
            {
                var judge = await _context.Judges.FindAsync(id);
                if (judge != null)
                {
                    _context.Judges.Remove(judge);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteJudgeAsync(Judge judge)
        {
            try
            {
                _context.Judges.Remove(judge);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
