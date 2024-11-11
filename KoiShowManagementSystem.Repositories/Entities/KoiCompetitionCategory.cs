using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class KoiCompetitionCategory
{
    public int KoiCompetitionCategoryId { get; set; }

    public int? CompetitionId { get; set; }

    public int? CategoryId { get; set; }

    public int? KoiFishId { get; set; }

    public virtual CompetitionCategory? Category { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual KoiFish? KoiFish { get; set; }
}
