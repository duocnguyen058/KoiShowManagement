using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;

namespace KoiShowManagement.Services.Service
{
    public class GuestService : IGuestService
    {
        private readonly IGuestService _repository;
        public GuestService(IGuestService repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddGuestAsync(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Guest không được để trống.");
            if (guest.GuestId <= 0)
                throw new ArgumentException("ID của Guest phải là số nguyên dương.", nameof(guest.GuestId));
            if (string.IsNullOrWhiteSpace(guest.Name))
                throw new ArgumentException("Tên Guest không được để trống hoặc chỉ chứa khoảng trống.", nameof(guest.Name));
            return await _repository.AddGuestAsync(guest);
        }

        public async Task<bool> DeleteGuestAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.DeleteGuestAsync(Id);
        }

        public async Task<bool> DeleteGuestAsync(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Guest không được để trống.");

            return await _repository.DeleteGuestAsync(guest);
        }

        public async Task<Guest> GetGuestByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(Id));

            return await _repository.GetGuestByIdAsync(Id);
        }

        public async Task<List<Guest>> GetGuestsAsync()
        {
            return await _repository.GetGuestsAsync();
        }

        public async Task<bool> UpdateGuestAsync(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Guest không được để trống.");
            if (guest.GuestId <= 0)
                throw new ArgumentException("ID của Guest phải là số nguyên dương.", nameof(guest.GuestId));
            if (string.IsNullOrWhiteSpace(guest.Name))
                throw new ArgumentException("Tên Guest không được để trống hoặc chỉ chứa khoảng trống.", nameof(guest.Name));
          
            return await _repository.UpdateGuestAsync(guest);
        }
    }
}
