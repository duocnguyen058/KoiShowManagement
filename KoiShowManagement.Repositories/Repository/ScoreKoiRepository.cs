using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class ScoreKoiRepository : IScoreKoiRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ScoreKoiRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy tất cả các kết quả chấm điểm
        public async Task<List<ScoreKoi>> GetAllScoreKoisAsync()
        {
            return await _dbContext.ScoreKois
                .Include(s => s.Event)
                .Include(s => s.Koi)
                .Include(s => s.Referee)
                .ToListAsync();
        }

        // Lấy kết quả chấm điểm theo ScoreId
        public async Task<ScoreKoi> GetScoreKoiByIdAsync(int scoreId)
        {
            return await _dbContext.ScoreKois
                .Include(s => s.Event)
                .Include(s => s.Koi)
                .Include(s => s.Referee)
                .FirstOrDefaultAsync(s => s.ScoreId == scoreId);
        }

        // Thêm một kết quả chấm điểm mới
        public async Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                await _dbContext.ScoreKois.AddAsync(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Cập nhật kết quả chấm điểm
        public async Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Update(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xóa kết quả chấm điểm theo ScoreId
        public async Task<bool> DelScoreKoiAsync(int scoreId)
        {
            try
            {
                var scoreKoi = await _dbContext.ScoreKois.FindAsync(scoreId);
                if (scoreKoi == null) return false;
                _dbContext.ScoreKois.Remove(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xóa kết quả chấm điểm theo đối tượng ScoreKoi
        public async Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi)
        {
            try
            {
                _dbContext.ScoreKois.Remove(scoreKoi);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
