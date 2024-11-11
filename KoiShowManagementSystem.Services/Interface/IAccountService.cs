using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagementSystem.Repositories.Entities;

namespace KoiShowManagementSystem.Services.CompetitionService
{
    public interface IAccountService
    {
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<bool> CreateAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int accountId);
        Task<bool> IsAccountExistAsync(string username);

        // Change this to return Task<Account> instead of Task<bool>
        Task<Account> ValidateAccountAsync(string username, string password);
    }
}
