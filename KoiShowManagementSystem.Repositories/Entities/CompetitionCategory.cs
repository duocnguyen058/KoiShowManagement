using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class CompetitionCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<KoiCompetitionCategory> KoiCompetitionCategories { get; set; } = new List<KoiCompetitionCategory>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
