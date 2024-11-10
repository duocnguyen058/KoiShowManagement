using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IProfileService
    {
        Task<List<Profile>> GetAllProfilesAsync();
        Task<Profile> GetProfileByIdAsync(int profileId);
        Task<bool> AddProfileAsync(Profile profile);
        Task<bool> UpdateProfileAsync(Profile profile);
        Task<bool> DeleteProfileAsync(int profileId);
        Task<Profile> GetProfile(string? name);  // Corrected return type to Task<Profile>
    }
}
