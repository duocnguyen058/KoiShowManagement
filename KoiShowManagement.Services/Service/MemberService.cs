using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _repository.GetAllMembersAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            if (memberId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(memberId));

            return await _repository.GetMemberByIdAsync(memberId);
        }

        public async Task<bool> AddMemberAsync(Member member)
        {
            ValidateMember(member);
            return await _repository.AddMemberAsync(member);
        }

        public async Task<bool> UpdateMemberAsync(Member member)
        {
            ValidateMember(member);
            return await _repository.UpdateMemberAsync(member);
        }

        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            if (memberId <= 0)
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương.", nameof(memberId));

            return await _repository.DeleteMemberAsync(memberId);
        }

        public async Task<bool> DeleteMemberAsync(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "Thành viên không được để trống.");

            return await _repository.DeleteMemberAsync(member);
        }

        // Triển khai phương thức tìm kiếm
        public async Task<List<Member>> SearchMembersAsync(string? name, string? email, string? membershipType)
        {
            return await _repository.SearchMembersAsync(name, email, membershipType);
        }

        private void ValidateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "Thành viên không được để trống.");

            if (string.IsNullOrWhiteSpace(member.Name))
                throw new ArgumentException("Tên thành viên không được để trống hoặc chỉ chứa khoảng trắng.", nameof(member.Name));

            if (!string.IsNullOrEmpty(member.Email) && !member.Email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.", nameof(member.Email));

            if (!string.IsNullOrEmpty(member.Phone) && member.Phone.Length < 10)
                throw new ArgumentException("Số điện thoại không hợp lệ.", nameof(member.Phone));

            if (member.MembershipDate.HasValue && member.MembershipDate.Value > DateTime.Now)
                throw new ArgumentException("Ngày đăng ký thành viên không thể ở tương lai.", nameof(member.MembershipDate));

            var validMembershipTypes = new List<string> { "Standard", "Premium", "VIP" };
            if (!string.IsNullOrEmpty(member.MembershipType) && !validMembershipTypes.Contains(member.MembershipType))
                throw new ArgumentException("Loại thành viên không hợp lệ.", nameof(member.MembershipType));
        }
    }
}
