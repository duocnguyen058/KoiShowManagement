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
            ValidateProfile(profile);
            return await _profileRepository.AddProfileAsync(profile);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile), "Hồ sơ không được để trống.");
            if (profile.ProfileId <= 0)
                throw new ArgumentException("ID hồ sơ không hợp lệ. ID phải là số nguyên dương.", nameof(profile.ProfileId));

            ValidateProfile(profile);
            return await _profileRepository.UpdateProfileAsync(profile);
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            if (profileId <= 0)
                throw new ArgumentException("ID hồ sơ không hợp lệ. ID phải là số nguyên dương.", nameof(profileId));

            return await _profileRepository.DeleteProfileAsync(profileId);
        }

        // Private helper method to validate profile data
        private void ValidateProfile(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile), "Hồ sơ không được để trống.");

            if (string.IsNullOrWhiteSpace(profile.Name))
                throw new ArgumentException("Tên không được để trống hoặc chỉ chứa khoảng trắng.", nameof(profile.Name));

            if (string.IsNullOrWhiteSpace(profile.Email))
                throw new ArgumentException("Email không được để trống hoặc chỉ chứa khoảng trắng.", nameof(profile.Email));

            if (profile.UserId.HasValue && profile.UserId <= 0)
                throw new ArgumentException("UserId phải là số nguyên dương nếu được cung cấp.", nameof(profile.UserId));

            if (!string.IsNullOrWhiteSpace(profile.PhoneNumber) && profile.PhoneNumber.Length > 15)
                throw new ArgumentException("Số điện thoại không được vượt quá 15 ký tự.", nameof(profile.PhoneNumber));

            if (!string.IsNullOrWhiteSpace(profile.Avatar) && profile.Avatar.Length > 255)
                throw new ArgumentException("URL của ảnh đại diện không được vượt quá 255 ký tự.", nameof(profile.Avatar));

            if (profile.Birthdate.HasValue && profile.Birthdate > DateTime.Now)
                throw new ArgumentException("Ngày sinh không thể là một ngày trong tương lai.", nameof(profile.Birthdate));

            if (!string.IsNullOrWhiteSpace(profile.Address) && profile.Address.Length > 200)
                throw new ArgumentException("Địa chỉ không được vượt quá 200 ký tự.", nameof(profile.Address));

            if (!string.IsNullOrWhiteSpace(profile.Bio) && profile.Bio.Length > 500)
                throw new ArgumentException("Tiểu sử không được vượt quá 500 ký tự.", nameof(profile.Bio));

            if (string.IsNullOrWhiteSpace(profile.FullName))
                throw new ArgumentException("Họ và tên không được để trống hoặc chỉ chứa khoảng trắng.", nameof(profile.FullName));

            // Validate User object if provided
            if (profile.User != null && profile.User.UserId <= 0)
                throw new ArgumentException("UserId của đối tượng User phải là số nguyên dương.", nameof(profile.User));
        }
    }
}
