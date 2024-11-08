using System.Collections.Generic;
using System.Linq;
using KoiShowManagement.Repositories;
using KoiShowManagement.Models;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Repositories.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly KoiShowDbContext _context;

        public MemberRepository(KoiShowDbContext context)
        {
            _context = context;
        }

        // Thêm một thành viên mới
        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        // Lấy thông tin thành viên theo ID
        public Member GetMemberById(int id)
        {
            return _context.Members.Find(id);
        }

        // Lấy danh sách tất cả các thành viên
        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        // Cập nhật thông tin thành viên
        public void UpdateMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }

        // Xóa thành viên theo ID
        public void DeleteMember(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
        }
    }
}
