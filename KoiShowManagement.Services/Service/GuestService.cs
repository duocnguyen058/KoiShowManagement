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
            ValidateGuest(guest);
            return await _repository.AddGuestAsync(guest);
        }

        private void ValidateGuest(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Thong tin khach khong duoc de trong");

            if (guest.GuestId <= 0)
                throw new ArgumentException("Ma khach phai la so nguyen duong", nameof(guest.GuestId));

            if (string.IsNullOrWhiteSpace(guest.Name))
                throw new ArgumentException("Ten khong duoc de trong hoac chi chua khoang trang", nameof(guest.Name));

            if (guest.Email != null && !IsValidEmail(guest.Email))
                throw new ArgumentException("Dinh dang email khong hop le", nameof(guest.Email));

            if (guest.Phone != null && !IsValidPhoneNumber(guest.Phone))
                throw new ArgumentException("Dinh dang so dien thoai khong hop le", nameof(guest.Phone));

            if (guest.RegistrationDate != null && guest.RegistrationDate > DateTime.Now)
                throw new ArgumentException("Ngay dang ky khong duoc lon hon ngay hien tai", nameof(guest.RegistrationDate));
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return phone.Length >= 7 && phone.Length <= 15;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteGuestAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID khong hop le; chi chap nhan so nguyen duong", nameof(Id));

            return await _repository.DeleteGuestAsync(Id);
        }

        public async Task<bool> DeleteGuestAsync(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Thong tin khach khong duoc de trong");

            return await _repository.DeleteGuestAsync(guest);
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            return await _repository.GetAllGuestsAsync();
        }

        public async Task<Guest> GetGuestByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID khong hop le; chi chap nhan so nguyen duong", nameof(Id));

            return await _repository.GetGuestByIdAsync(Id);
        }

        public async Task<bool> UpdateGuestAsync(Guest guest)
        {
            ValidateGuest(guest);
            return await _repository.UpdateGuestAsync(guest);
        }
         public async Task<List<Guest>> SearchGuestsAsync(string? name, string? email, string? phone)
        {
            return await _repository.SearchGuestsAsync(name, email, phone);
        }
    }
}



