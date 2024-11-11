using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class CompetitionCategoryRepository : ICompetitionCategoryRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public CompetitionCategoryRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompetitionCategoryAsync(CompetitionCategory category)
        {
            try
            {
                await _context.CompetitionCategories.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteCompetitionCategoryAsync(int Id)
        {
            try
            {
                var objDel = await _context.CompetitionCategories
                    .FirstOrDefaultAsync(c => c.CategoryId == Id);
                if (objDel != null)
                {
                    _context.CompetitionCategories.Remove(objDel);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteCompetitionCategoryAsync(CompetitionCategory category)
        {
            try
            {
                _context.CompetitionCategories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<CompetitionCategory>> GetAllCompetitionCategoriesAsync()
        {
            try
            {
                return await _context.CompetitionCategories
                    .Include(c => c.KoiCompetitionCategories) 
                    .Include(c => c.Results) 
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<CompetitionCategory> GetCompetitionCategoryByIdAsync(int Id)
        {
            try
            {
                return await _context.CompetitionCategories
                    .Include(c => c.KoiCompetitionCategories)
                    .Include(c => c.Results) 
                    .FirstOrDefaultAsync(c => c.CategoryId == Id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> UpdateCompetitionCategoryAsync(CompetitionCategory category)
        {
            try
            {
                _context.CompetitionCategories.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
