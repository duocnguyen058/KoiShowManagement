﻿using System;
using KoiShowManagement.Repositories.Entities;

namespace KoiShowManagement.Services.Interface
{
    public interface ICompetitionResultService
    {
        Task<List<CompetitionResult>> GetAllCompetitionResults();
        Boolean DelCompetitionResult(int Id);
        Boolean DelCompetitionResult(CompetitionResult result);
        Boolean AddCompetitionResult(CompetitionResult result);
        Boolean UpdCompetitionResult(CompetitionResult result);
        Task<CompetitionResult> GetCompetitionResultById(int Id);
    }
}