using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;

namespace KoiShowManagementSystem.Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _repository;

        public RegistrationService(IRegistrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Registration>> GetAllRegistrationsAsync()
        {
            return await _repository.GetAllRegistrationsAsync();
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ.");
            return await _repository.GetRegistrationByIdAsync(id);
        }

        public async Task<bool> AddRegistrationAsync(Registration registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            return await _repository.AddRegistrationAsync(registration);
        }

        public async Task<bool> UpdateRegistrationAsync(Registration registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            return await _repository.UpdateRegistrationAsync(registration);
        }

        public async Task<bool> DeleteRegistrationByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("ID không hợp lệ.");
            return await _repository.DeleteRegistrationByIdAsync(id);
        }

        public async Task<bool> DeleteRegistrationAsync(Registration registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));
            return await _repository.DeleteRegistrationAsync(registration);
        }

        // Cài đặt phương thức xóa các đăng ký của một cuộc thi
        public async Task<bool> DeleteRegistrationsByCompetitionIdAsync(int competitionId)
        {
            if (competitionId <= 0) throw new ArgumentException("ID cuộc thi không hợp lệ.");
            return await _repository.DeleteRegistrationsByCompetitionIdAsync(competitionId);
        }
    }
}
