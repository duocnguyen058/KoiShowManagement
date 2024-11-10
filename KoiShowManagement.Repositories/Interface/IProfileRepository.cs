using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileByIdAsync(int profileId);
        Task<bool> AddProfileAsync(Profile profile);
        Task<bool> UpdateProfileAsync(Profile profile);
        Task<bool> DeleteProfileAsync(int profileId);
        Task<Profile> GetProfileByNameAsync(string name);
    }
}
