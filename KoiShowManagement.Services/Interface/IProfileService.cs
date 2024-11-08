using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
	public interface IProfileService
	{
        Task<List<Profile>> GetAllProfiles();
        Boolean DelProfile(int Id);
        Boolean DelProfile(Profile profile);
        Boolean AddProfile(Profile profile);
        Boolean UpdProfile(Profile profile);
        Task<Profile> GetProfileById(int Id);
    }
}

