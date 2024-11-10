using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<bool> AddMemberAsync(Member member);
        Task<bool> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
        Task<bool> DeleteMemberAsync(Member member);

        // Thêm phương thức tìm kiếm
        Task<List<Member>> SearchMembersAsync(string? name, string? email, string? membershipType);
    }
}
