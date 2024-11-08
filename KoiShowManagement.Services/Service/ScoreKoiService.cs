using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;
using System;
namespace KoiShowManagement.Services.Service
{
    public class ScoreKoiService : IScoreKoiService
    {
        private readonly IScoreKoiRepository _repository;

        public ScoreKoiService(IScoreKoiRepository repository)
        {
            _repository = repository;
        }
        public bool AddScoreKoi(ScoreKoi scoreKoi)
        {
            return _repository.AddScoreKoi(scoreKoi);
        }

        public bool DelScoreKoi(int Id)
        {
            return _repository.DelScoreKoi(Id);
        }

        public bool DelScoreKoi(ScoreKoi scoreKoi)
        {
            return _repository.DelScoreKoi(scoreKoi);
        }

        public Task<List<ScoreKoi>> GetAllScoreKois()
        {
            return _repository.GetAllScoreKois();
        }

        public Task<ScoreKoi> GetScoreKoiId(int Id)
        {
            return _repository.GetScoreKoiById(Id);
        }

        public bool UpdScoreKoi(ScoreKoi scoreKoi)
        {
            return _repository.UpdScoreKoi(scoreKoi);
        }
    }
}      