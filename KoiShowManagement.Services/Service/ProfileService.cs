using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
	public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        public ProfileService(IProfileRepository repository)
		{
            _repository = repository;
		}

        public bool AddProfile(Profile profile)
        {
            return _repository.AddProfile(profile);
        }

        public bool DelProfile(int Id)
        {
            return _repository.DelProfile(Id);
        }

        public bool DelProfile(Profile profile)
        {
            return _repository.DelProfile(profile);
        }

        public Task<List<Profile>> GetAllProfiles()
        {
            return _repository.GetAllProfiles();
        }

        public Task<Profile> GetProfileById(int Id)
        {
            return _repository.GetEventById(Id);
        }

        public bool UpdProfile(Profile profile)
        {
            return _repository.UpdProfile(profile);
        }
    }
}

