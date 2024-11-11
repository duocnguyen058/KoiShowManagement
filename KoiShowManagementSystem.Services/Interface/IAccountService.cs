using KoiShowManagementSystem.Repositories.Entities;
<<<<<<< Updated upstream
using System;
namespace KoiShowManagementSystem.Services.Interface
{
	public interface IAccountService
	{

        Task<List<Dashboard>> GetAllDashboardsAsync();
        Task<Dashboard> GetDashboardByIdAsync(int Id);
        Task<bool> AddDashboardAsync(Dashboard dashboard);
        Task<bool> UpdateDashboardAsync(Dashboard dashboard);
        Task<bool> DeleteDashboardAsync(int Id);
        Task<bool> DeleteDashboardAsync(Dashboard dashboard);
=======
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Interface
{
    public interface IAccountService
    {
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task<bool> IsAccountExistAsync(string username);
        Task<bool> ValidateAccountAsync(string username, string password);
>>>>>>> Stashed changes
    }
}
