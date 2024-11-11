﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public ResultRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<bool> AddResultAsync(Result result)
        {
            if (result == null) return false;

            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateResultAsync(Result result)
        {
            if (result == null) return false;

            _context.Results.Update(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResultAsync(int resultId)
        {
            var result = await _context.Results.FindAsync(resultId);
            if (result == null) return false;

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Result> GetResultByIdAsync(int resultId)
        {
            return await _context.Results.FirstOrDefaultAsync(r => r.ResultId == resultId);
        }

        public async Task<List<Result>> GetAllResultsAsync()
        {
            return await _context.Results.ToListAsync();
        }

        public async Task<List<Result>> GetResultsByCompetitionIdAsync(int competitionId)
        {
            return await _context.Results
                .Where(r => r.CompetitionId == competitionId)
                .ToListAsync();
        }

        // Cài đặt phương thức DeleteResultsByCompetitionIdAsync
        public async Task<bool> DeleteResultsByCompetitionIdAsync(int competitionId)
        {
            var results = _context.Results.Where(r => r.CompetitionId == competitionId).ToList();

            if (results.Count == 0) return false;

            _context.Results.RemoveRange(results);
            await _context.SaveChangesAsync();
            return true;
        }
        // Triển khai phương thức tìm kiếm kết quả thi
        public async Task<List<Result>> SearchResultsAsync(int? koiFishId, int? competitionId)
        {
            var query = _context.Results.AsQueryable();

            if (koiFishId.HasValue)
            {
                query = query.Where(r => r.KoiFishId == koiFishId.Value);
            }

            if (competitionId.HasValue)
            {
                query = query.Where(r => r.CompetitionId == competitionId.Value);
            }

            return await query.ToListAsync();
        }
    }
}
