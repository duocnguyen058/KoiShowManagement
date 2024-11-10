using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class RefereeService : IRefereeService
    {
        private readonly IRefereeRepository _repository;

        public RefereeService(IRefereeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Referee>> GetAllRefereesAsync()
        {
            return await _repository.GetAllRefereesAsync();
        }

        public async Task<Referee> GetRefereeByIdAsync(int refereeId)
        {
            if (refereeId <= 0)
                throw new ArgumentException("ID không hợp lệ. Chỉ chấp nhận số nguyên dương.", nameof(refereeId));

            return await _repository.GetRefereeByIdAsync(refereeId);
        }

        public async Task<bool> AddRefereeAsync(Referee referee)
        {
            ValidateReferee(referee);
            return await _repository.AddRefereeAsync(referee);
        }

        public async Task<bool> UpdateRefereeAsync(Referee referee)
        {
            ValidateReferee(referee);
            return await _repository.UpdateRefereeAsync(referee);
        }

        public async Task<bool> DeleteRefereeByIdAsync(int refereeId)
        {
            if (refereeId <= 0)
                throw new ArgumentException("ID không hợp lệ. Chỉ chấp nhận số nguyên dương.", nameof(refereeId));

            return await _repository.DeleteRefereeByIdAsync(refereeId);
        }

        public async Task<bool> DeleteRefereeAsync(Referee referee)
        {
            if (referee == null)
                throw new ArgumentNullException(nameof(referee), "Trọng tài không được để trống.");

            return await _repository.DeleteRefereeAsync(referee);
        }

        public async Task<List<Referee>> GetRefereesByExpertiseLevelAsync(string expertiseLevel)
        {
            if (string.IsNullOrWhiteSpace(expertiseLevel))
                throw new ArgumentException("Chuyên môn không được để trống.", nameof(expertiseLevel));

            return await _repository.GetRefereesByExpertiseLevelAsync(expertiseLevel);
        }

        public async Task<List<Referee>> SearchRefereesAsync(string name = null, string email = null, string expertiseLevel = null)
        {
            return await _repository.SearchRefereesAsync(name, email, expertiseLevel);
        }

        private void ValidateReferee(Referee referee)
        {
            if (referee == null)
                throw new ArgumentNullException(nameof(referee), "Trọng tài không được để trống.");

            if (string.IsNullOrWhiteSpace(referee.Name))
                throw new ArgumentException("Tên trọng tài không được để trống.", nameof(referee.Name));

            if (referee.RefereeId <= 0)
                throw new ArgumentException("Mã trọng tài phải là số nguyên dương.", nameof(referee.RefereeId));

            if (!string.IsNullOrWhiteSpace(referee.Email) && !referee.Email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.", nameof(referee.Email));

            if (!string.IsNullOrWhiteSpace(referee.Phone) && referee.Phone.Length < 10)
                throw new ArgumentException("Số điện thoại không hợp lệ.", nameof(referee.Phone));

            if (string.IsNullOrWhiteSpace(referee.ExpertiseLevel))
                throw new ArgumentException("Mức độ chuyên môn không được để trống.", nameof(referee.ExpertiseLevel));
        }
    }
}
