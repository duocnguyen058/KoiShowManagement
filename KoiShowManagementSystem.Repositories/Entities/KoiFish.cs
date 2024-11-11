using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class KoiFish
{
    public int KoiFishId { get; set; }

    public int? AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Variety { get; set; }

    public double? Size { get; set; }

    public int? Age { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<KoiCompetitionCategory> KoiCompetitionCategories { get; set; } = new List<KoiCompetitionCategory>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
