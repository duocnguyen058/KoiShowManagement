using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembers();
        Boolean DelMember(int Id);
        Boolean DelMember(Member member);
        Boolean AddMember(Member member);
        Boolean UpdMember(Member member);
        Task<Member> GetMemberById(int Id);
    }
}
