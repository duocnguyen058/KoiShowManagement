using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class ScoreKoi
{
    public int ScoreId { get; set; }

    public int? KoiId { get; set; }

    public int? EventId { get; set; }

    public int? RefereeId { get; set; }

    public decimal? Score { get; set; }

    public string? Feedback { get; set; }

    public DateTime? ScoreDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Koi? Koi { get; set; }

    public virtual Referee? Referee { get; set; }
    public object ScoreKoiId { get; internal set; }
    public string JudgeName { get; set; }
    public int ScoreValue { get; set; }
    public int FishId { get; set; }
}
