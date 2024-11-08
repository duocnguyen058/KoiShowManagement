using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
	public interface IProfileRepository
	{
        Task<List<Profile>> GetAllProfiles();
        Boolean DelProfile(int Id);
        Boolean DelProfile(Profile profile);
        Boolean AddProfile(Profile profile);
        Boolean UpdProfile(Profile profile);
        Task<Profile> GetEventById(int Id);
    }
}

