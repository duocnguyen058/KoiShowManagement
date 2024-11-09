using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> GetAllProfilesAsync()
        {
            return await _profileRepository.GetAllProfilesAsync();
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            if (profileId <= 0)
                throw new ArgumentException("ID hồ sơ không hợp lệ. ID phải là số nguyên dương.", nameof(profileId));

            return await _profileRepository.GetProfileByIdAsync(profileId);
        }

        public async Task<bool> AddProfileAsync(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile), "Hồ sơ không được để trống.");
            if (string.IsNullOrWhiteSpace(profile.Name))
                throw new ArgumentException("Tên không được để trống hoặc chứa khoảng trắng.", nameof(profile.Name));
            if (string.IsNullOrWhiteSpace(profile.Email))
                throw new ArgumentException("Email không được để trống hoặc chứa khoảng trắng.", nameof(profile.Email));

            return await _profileRepository.AddProfileAsync(profile);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile), "Hồ sơ không được để trống.");
            if (profile.ProfileId <= 0)
                throw new ArgumentException("ID hồ sơ không hợp lệ. ID phải là số nguyên dương.", nameof(profile.ProfileId));

            return await _profileRepository.UpdateProfileAsync(profile);
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            if (profileId <= 0)
                throw new ArgumentException("ID hồ sơ không hợp lệ. ID phải là số nguyên dương.", nameof(profileId));

            return await _profileRepository.DeleteProfileAsync(profileId);
        }
    }
}
