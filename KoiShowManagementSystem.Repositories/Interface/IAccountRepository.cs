using KoiShowManagementSystem.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountByUsernameAsync(string username);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<bool> AddAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int accountId);
        Task<bool> IsAccountExistAsync(string username);
    }
}
