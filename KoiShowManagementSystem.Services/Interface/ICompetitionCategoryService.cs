using KoiShowManagementSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface ICompetitionCategoryService
    {
        Task<List<CompetitionCategory>> GetAllCompetitionCategoriesAsync();
        Task<CompetitionCategory> GetCompetitionCategoryByIdAsync(int Id);
        Task<bool> AddCompetitionCategoryAsync(CompetitionCategory category);
        Task<bool> UpdateCompetitionCategoryAsync(CompetitionCategory category);
        Task<bool> DeleteCompetitionCategoryAsync(int Id);
        Task<bool> DeleteCompetitionCategoryAsync(CompetitionCategory category);
    }
}
