using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public bool AddMember(Member member)
        {
            return _repository.AddMember(member);
        }

        public bool DelMember(int Id)
        {
            return _repository.DelMember(Id);
        }

        public bool DelMember(Member member)
        {
            return _repository.DelMember(member);
        }

        public Task<List<Member>> GetAllMembers()
        {
            return _repository.GetAllMembers();
        }

        public Task<Member> GetMemberById(int Id)
        {
            return _repository.GetMemberById(Id);
        }

        public bool UpdMember(Member member)
        {
            return _repository.UpdMember(member);
        }
    }
}
