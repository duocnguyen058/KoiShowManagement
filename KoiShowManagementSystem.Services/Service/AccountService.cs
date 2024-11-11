using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Lấy tài khoản theo ID
        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("ID tài khoản phải lớn hơn 0");

            return await _accountRepository.GetAccountByIdAsync(accountId);
        }

        // Lấy tài khoản theo Username
        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Tên đăng nhập không thể trống");

            return await _accountRepository.GetAccountByUsernameAsync(username);
        }

        // Lấy tất cả tài khoản
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }

        // Tạo tài khoản mới
        public async Task CreateAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Tài khoản không thể null");

            // Kiểm tra tài khoản đã tồn tại chưa
            if (await _accountRepository.IsAccountExistAsync(account.Username))
                throw new InvalidOperationException($"Tài khoản với tên đăng nhập {account.Username} đã tồn tại");

            await _accountRepository.AddAccountAsync(account);
        }

        // Cập nhật tài khoản
        public async Task UpdateAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Tài khoản không thể null");

            // Kiểm tra tài khoản có tồn tại không
            var existingAccount = await _accountRepository.GetAccountByIdAsync(account.AccountId);
            if (existingAccount == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với ID {account.AccountId}");

            // Cập nhật tài khoản
            await _accountRepository.UpdateAccountAsync(account);
        }

        // Xóa tài khoản
        public async Task DeleteAccountAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("ID tài khoản không hợp lệ");

            // Kiểm tra tài khoản có tồn tại không
            var account = await _accountRepository.GetAccountByIdAsync(accountId);
            if (account == null)
                throw new KeyNotFoundException($"Không tìm thấy tài khoản với ID {accountId}");

            await _accountRepository.DeleteAccountAsync(accountId);
        }

        // Kiểm tra tài khoản đã tồn tại chưa
        public async Task<bool> IsAccountExistAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Tên đăng nhập không thể trống");

            return await _accountRepository.IsAccountExistAsync(username);
        }

        // Kiểm tra tính hợp lệ của tài khoản (username, password)
        public async Task<bool> ValidateAccountAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Tên đăng nhập hoặc mật khẩu không thể trống");

            var account = await _accountRepository.GetAccountByUsernameAsync(username);
            if (account == null || account.PasswordHash != password)
                return false;

            return true;
        }
    }
}
