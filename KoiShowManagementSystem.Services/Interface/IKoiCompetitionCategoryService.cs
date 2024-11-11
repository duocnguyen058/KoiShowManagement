﻿using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.CompetitionService
{
    public interface IKoiCompetitionCategoryService
    {
        Task<List<KoiCompetitionCategory>> GetAllKoiCompetitionCategoriesAsync();
        Task<KoiCompetitionCategory> GetKoiCompetitionCategoryByIdAsync(int id);
        Task<bool> AddKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task<bool> UpdateKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory);
        Task<bool> DeleteKoiCompetitionCategoryAsync(int id);
        Task<bool> DeleteKoiCompetitionCategoryAsync(KoiCompetitionCategory koiCompetitionCategory);
    }
}
