using KoiShowManagement.Repositories.Entities;
using System;

namespace KoiShowManagement.Repositories.Interface
{
    internal interface IRefereeRepository
    {
        Task<List<Referee>> GetAllReferee();
        Boolean DelReferee(int Id);
        Boolean DelReferee(Referee referee);
        Boolean AddReferee(Referee referee);
        Boolean UpdReferee(Referee referee);
        Task<Referee> GetRefereeById(int Id);
    }
}
