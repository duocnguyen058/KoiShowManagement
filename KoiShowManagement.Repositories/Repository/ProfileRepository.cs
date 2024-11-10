using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public ProfileRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy tất cả hồ sơ
        public async Task<List<Profile>> GetAllProfilesAsync()
        {
            try
            {
                return await _dbContext.Profiles.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hồ sơ.", ex);
            }
        }

        // Lấy hồ sơ theo ID
        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            try
            {
                return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileId == profileId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy hồ sơ với ID {profileId}.", ex);
            }
        }

        // Thêm hồ sơ mới
        public async Task<bool> AddProfileAsync(Profile profile)
        {
            try
            {
                if (profile == null)
                    throw new ArgumentNullException(nameof(profile), "Hồ sơ không được null.");

                await _dbContext.Profiles.AddAsync(profile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Hồ sơ không hợp lệ", ex);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi thêm hồ sơ vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm hồ sơ.", ex);
            }
        }

        // Cập nhật hồ sơ
        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            try
            {
                if (profile == null)
                    throw new ArgumentNullException(nameof(profile), "Hồ sơ không được null.");

                _dbContext.Profiles.Update(profile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Hồ sơ không hợp lệ khi cập nhật", ex);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi cập nhật hồ sơ vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật hồ sơ.", ex);
            }
        }

        // Xóa hồ sơ theo ID
        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            try
            {
                var profile = await _dbContext.Profiles.FindAsync(profileId);
                if (profile != null)
                {
                    _dbContext.Profiles.Remove(profile);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi xóa hồ sơ khỏi cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi xóa hồ sơ với ID {profileId}.", ex);
            }
        }

        // Lấy hồ sơ theo tên
        public async Task<Profile> GetProfileByNameAsync(string name)
        {
            try
            {
                return await _dbContext.Profiles.FirstOrDefaultAsync(p => p.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm hồ sơ theo tên {name}.", ex);
            }
        }
    }
}
