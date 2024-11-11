using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Implementation
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public ScoreRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<Score> GetScoreByIdAsync(int scoreId)
        {
            return await _context.Scores.FindAsync(scoreId);
        }

        public async Task<IList<Score>> GetScoresByCompetitionIdAsync(int competitionId)
        {
            return await _context.Scores
                .Where(s => s.CompetitionId == competitionId)
                .ToListAsync();
        }

        public async Task<IList<Score>> GetScoresByKoiFishIdAsync(int koiFishId)
        {
            return await _context.Scores
                .Where(s => s.KoiFishId == koiFishId)
                .ToListAsync();
        }

        public async Task<Score> GetScoreByKoiAndJudgeAsync(int koiFishId, int judgeId, int competitionId)
        {
            return await _context.Scores
                .FirstOrDefaultAsync(s => s.KoiFishId == koiFishId && s.JudgeId == judgeId && s.CompetitionId == competitionId);
        }

        public async Task<bool> CreateScoreAsync(Score score)
        {
            await _context.Scores.AddAsync(score);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateScoreAsync(Score score)
        {
            _context.Scores.Update(score);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteScoreAsync(int scoreId)
        {
            var score = await _context.Scores.FindAsync(scoreId);
            if (score != null)
            {
                _context.Scores.Remove(score);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteScoresByCompetitionIdAsync(int competitionId)
        {
            var scores = await _context.Scores
                .Where(s => s.CompetitionId == competitionId)
                .ToListAsync();

            if (scores.Any())
            {
                _context.Scores.RemoveRange(scores);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
