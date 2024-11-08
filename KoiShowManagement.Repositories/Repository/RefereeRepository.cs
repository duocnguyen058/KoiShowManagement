using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace KoiShowManagement.Repositories.Repository
{
    public class RefereeRepository : IRefereeRepository
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DelReferee(int Id)
        {

            try
            {
                var refereeToDelete = _dbContext.Referees.Where(r => r.RefereeId.Equals(Id)).FirstOrDefault();
                if (refereeToDelete != null)
                {
                    _dbContext.Referees.Remove(refereeToDelete);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Referee>> GetAllReferees()
        {
            return await _dbContext.Referees.ToListAsync();
        }

        public async Task<Referee> GetByRefereeId(int Id)
        {
            return await _dbContext.Referees.Where(r => r.RefereeId.Equals(Id)).FirstOrDefaultAsync();
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
