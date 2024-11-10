using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembersAsync();   // Asynchronous method to get all members
        Task<Member> GetMemberByIdAsync(int memberId);   // Get member by ID
        Task<bool> AddMemberAsync(Member member);    // Add a member
        Task<bool> UpdateMemberAsync(Member member);    // Update a member
        Task<bool> DeleteMemberAsync(int memberId);    // Delete a member by ID
        Task<bool> DeleteMemberAsync(Member member);   // Delete a member by object

        // Updated method to return a list of members
        Task<List<Member>> GetAllMembers();  // Now returns a list of members asynchronously
        Task<Member> GetMemberById(int id);  // Get a specific member by ID
        Task<bool> AddMember(Member member);  // Add a member
    }
}
