using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class Judge
{
    public int JudgeId { get; set; }

    public int? AccountId { get; set; }

    public int? CompetitionId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
