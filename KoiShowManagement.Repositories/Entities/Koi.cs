using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Koi
{
    public int KoiId { get; set; }

    public int? MemberId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public decimal? Size { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<CompetitionResult> CompetitionResults { get; set; } = new List<CompetitionResult>();

    public virtual Member? Member { get; set; }
}
