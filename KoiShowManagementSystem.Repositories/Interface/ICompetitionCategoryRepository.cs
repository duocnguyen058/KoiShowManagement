using KoiShowManagementSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface ICompetitionCategoryRepository
    {
       
        Task<List<CompetitionCategory>> GetAllCompetitionCategoriesAsync();
        Task<CompetitionCategory> GetCompetitionCategoryByIdAsync(int Id);
        Task<bool> AddCompetitionCategoryAsync(CompetitionCategory category);
        Task<bool> UpdCompetitionCategoryAsync(CompetitionCategory category);
        Task<bool> DelCompetitionCategoryAsync(int Id);
        Task<bool> DelCompetitionCategoryAsync(CompetitionCategory category);
        Task<bool> DeleteCompetitionCategoryAsync(int id);
    }
}
