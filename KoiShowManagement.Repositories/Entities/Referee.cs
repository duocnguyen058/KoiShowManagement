using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Referee
{
    public int RefereeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ExpertiseLevel { get; set; }

    public virtual ICollection<CompetitionResult> CompetitionResults { get; set; } = new List<CompetitionResult>();

    public virtual ICollection<ScoreKoi> ScoreKois { get; set; } = new List<ScoreKoi>();
}
