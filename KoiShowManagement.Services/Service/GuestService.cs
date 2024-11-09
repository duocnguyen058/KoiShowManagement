using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;
namespace KoiShowManagement.Services.Service
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repository;
        public GuestService(IGuestRepository repository)
        {
            _repository = repository;
        }
        public bool AddGuest(Guest guest)
        {
            return _repository.AddGuest(guest);
        }

        public bool DelGuest(int Id)
        {
            return _repository.DelGuest(Id);
        }

        public bool DelGuest(Guest guest)
        {
            return _repository.DelGuest(guest);
        }

        public Task<List<Guest>> GetAllGuests()
        {
            return _repository.GetAllGuests();
        }

        public Task<Guest> GetGuestById(int Id)
        {
            return _repository.GetGuestById(Id);
        }

        public bool UpdGuest(Guest guest)
        {
            return _repository.UpdGuest(guest);
        }
    }
}
