using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface ICompetitionRepository
    {
        Task<Competition> GetCompetitionByIdAsync(int competitionId);
        Task<IEnumerable<Competition>> GetAllCompetitionsAsync();
        Task<bool> CreateCompetitionAsync(Competition competition);
        Task<bool> UpdateCompetitionAsync(Competition competition);
        Task<bool> DeleteCompetitionAsync(int competitionId);
    }
}
