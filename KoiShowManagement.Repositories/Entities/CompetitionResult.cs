using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class CompetitionResult
{
    public int ResultId { get; set; }

    public int? KoiId { get; set; }

    public int? RefereeId { get; set; }

    public int? EventId { get; set; }

    public decimal? Score { get; set; }

    public string? Feedback { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Referee? Referee { get; set; }
}
