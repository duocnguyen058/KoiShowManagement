using System;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
	public class CompetitionResultService : ICompetitionResultService
    {
        private readonly ICompetitionResultRepository _repository;
        public CompetitionResultService(ICompetitionResultRepository repository)
		{
            _repository = repository;
		}

        public bool AddCompetitionResult(CompetitionResult result)
        {
            return _repository.AddCompetitionResult(result);
        }

        public bool DelCompetitionResult(int Id)
        {
            return _repository.DelCompetitionResult(Id);
        }

        public bool DelCompetitionResult(CompetitionResult result)
        {
            return _repository.DelCompetitionResult(result);
        }

        public Task<List<CompetitionResult>> GetAllCompetitionResults()
        {
            return _repository.GetAllCompetitionResults();
        }

        public Task<CompetitionResult> GetCompetitionResultById(int Id)
        {
            return _repository.GetCompetitionResultById(Id);
        }

        public bool UpdCompetitionResult(CompetitionResult result)
        {
            return _repository.UpdCompetitionResult(result);
        }
    }
}

