using KoiShowManagement.Repositories.Entities;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Interface
{
    public interface IMemberRepository
    {
        // Thêm một thành vin mới
        void AddMember(Member member);

        // Lấy thông tin thành viên theo ID
        Member GetMemberById(int id);

        // Lấy danh sách tất cả các thành viên
        IEnumerable<Member> GetAllMembers();

        // Cập nhật thông tin thành viên
        void UpdateMember(Member member);

        // Xóa thành viên theo ID
        void DeleteMember(int id);
    }
}
