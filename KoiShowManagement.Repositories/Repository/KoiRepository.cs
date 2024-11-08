using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly KoiShowManagementDbContext _dbContext;

        public KoiRepository(KoiShowManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Add(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

     
        public bool DelKoi(int Id)
        {
            try
            {
                var koiToDelete = _dbContext.Kois.Where(k => k.KoiId.Equals(Id)).FirstOrDefault();
                if (koiToDelete != null)
                {
                    _dbContext.Kois.Remove(koiToDelete);
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

        public bool DelKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Remove(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

       
        public async Task<List<Koi>> GetAllKois()
        {
            return await _dbContext.Kois.ToListAsync();
        }

        public async Task<Koi> GetKoiById(int Id)
        {
            return await _dbContext.Kois.Where(k => k.KoiId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdKoi(Koi koi)
        {
            try
            {
                _dbContext.Kois.Update(koi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                return false;
            }
        }

        
        Task<List<Koi>> IKoiRepository.GetAllKois()
        {
            throw new NotImplementedException();
        }

        Task<Koi> IKoiRepository.GetKoiById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
