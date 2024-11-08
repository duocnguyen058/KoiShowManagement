using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Repository
{
    internal class RefereeRepository : IRefereeRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;
        public RefereeRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddReferee(Referee referee)
        {
            try
            {
                _dbContext.Referees.Add(referee);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
                return false;
            }
        }

        public bool DelReferee(int Id)
        {
            try
            {
                var objDel = _dbContext.Referees.Where(p => p.RefereeId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Referees.Remove(objDel);
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

        public bool DelReferee(Referee referee)
        {
            try
            {
                _dbContext.Referees.Remove(referee);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
                return false;
            }

        }
        public async Task<Referee> RefereeById(int Id)
        {
            return await _dbContext.Referees.Where(p => p.RefereeId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Referee>> GetAllReferees()
        {
            return await _dbContext.Referees.ToListAsync();
        }

        public bool UpdReferee(Referee referee)
        {
            try
            {
                _dbContext.Referees.Update(referee);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }
        public Task<List<Referee>> GetAllReferee()
        {
            throw new NotImplementedException();
        }

        public Task<Referee> GetRefereeById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

