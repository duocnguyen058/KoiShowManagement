using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public MemberRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _dbContext.Members.ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            return await _dbContext.Members.FindAsync(memberId);
        }

        public async Task<bool> AddMemberAsync(Member member)
        {
            try
            {
                await _dbContext.Members.AddAsync(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi thêm thành viên.", ex);
            }
        }

        public async Task<bool> UpdateMemberAsync(Member member)
        {
            try
            {
                _dbContext.Members.Update(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi cập nhật thành viên.", ex);
            }
        }

        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            var member = await _dbContext.Members.FindAsync(memberId);
            if (member == null) return false;

            _dbContext.Members.Remove(member);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMemberAsync(Member member)
        {
            try
            {
                _dbContext.Members.Remove(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Có lỗi xảy ra khi xóa thành viên.", ex);
            }
        }
    }
}
