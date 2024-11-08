using KoiShowManagement.Repositories.Entities;
using System;


namespace KoiShowManagement.Services.Interface
{
    public interface IRefereeService
    {
        Task<List<Referee>> GetAllReferees();
        Boolean DelReferee(int Id);
        Boolean DelReferee(Referee referee);
        Boolean AddReferee(Referee referee);
        Boolean UpdReferee(Referee referee);
        Task<Referee> GetRefereeById(int Id);
    }
}
