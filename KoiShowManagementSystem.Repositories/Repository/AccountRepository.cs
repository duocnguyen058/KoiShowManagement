using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KoiShowManagementDbcontextContext _context;

        public AccountRepository(KoiShowManagementDbcontextContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("ID tài khoản phải lớn hơn 0");

            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với ID {accountId}");

            return account;
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Tên đăng nhập không thể trống");

            var account = await _context.Accounts
                                         .FirstOrDefaultAsync(a => a.Username == username);

            if (account == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với tên đăng nhập {username}");

            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task AddAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Tài khoản không thể null");

            if (await _context.Accounts.AnyAsync(a => a.Username == account.Username))
                throw new InvalidOperationException("Tên đăng nhập đã tồn tại");

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Tài khoản không thể null");

            var existingAccount = await _context.Accounts.FindAsync(account.AccountId);
            if (existingAccount == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với ID {account.AccountId}");

            existingAccount.Username = account.Username;
            existingAccount.PasswordHash = account.PasswordHash;
            existingAccount.Role = account.Role;
            existingAccount.FullName = account.FullName;
            existingAccount.Email = account.Email;
            existingAccount.PhoneNumber = account.PhoneNumber;
            existingAccount.CreatedAt = account.CreatedAt;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("ID tài khoản không hợp lệ");

            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với ID {accountId}");

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsAccountExistAsync(string username)
        {
            return await _context.Accounts
                                 .AnyAsync(a => a.Username == username);
        }
    }
}
