using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IMemberRepository
    {
        Task<List<Member>> AllMember { get; }

        Boolean DelMember(int Id);
        Boolean DelMember(Member member);
        Boolean AddMember(Member member);
        Boolean UpdMember(Member member);
        Task<Member> GetMemberById(int Id);
    }
}
