using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface ICompetitionResultService
    {
        Task<List<CompetitionResult>> GetAllCompetitionResultsAsync();
        Task<bool> DelCompetitionResultAsync(int Id);
        Task<bool> DelCompetitionResultAsync(CompetitionResult result);
        Task<bool> AddCompetitionResultAsync(CompetitionResult result);
        Task<bool> UpdCompetitionResultAsync(CompetitionResult result);
        Task<CompetitionResult> GetCompetitionResultByIdAsync(int Id);
    }
}