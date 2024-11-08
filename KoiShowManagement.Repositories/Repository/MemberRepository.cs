using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public MemberRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddMember(Member member)
        {
            try
            {
                _dbContext.Members.Add(member);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelMember(int Id)
        {
            try
            {
                var objDel = _dbContext.Members.Where(p => p.MemberId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Members.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelMember(Member member)
        {
            try
            {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        public async Task<List<Member>> GetAllMember()
        {
            return await _dbContext.Members.ToListAsync();
        }

        public async Task<Member> GetMemberById(int Id)
        {
            return await _dbContext.Members.Where(p => p.MemberId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdMember(Member member)
        {
            try
            {
                _dbContext.Members.Update(member);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }
    }
}
