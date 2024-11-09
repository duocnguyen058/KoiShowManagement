using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Repositories.Interface
{
    public interface IRefereeRepository
    {
        Task<List<Referee>> GetAllReferees();
        Boolean DelReferee(int Id);
        Boolean DelReferee(Referee referee);
        Boolean AddReferee(Referee referee);
        Boolean UpdReferee(Referee referee);
        Task<Referee> GetByRefereeId(int Id);

    }
}