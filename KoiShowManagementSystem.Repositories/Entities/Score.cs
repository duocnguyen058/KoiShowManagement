using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class Score
{
    public int ScoreId { get; set; }

    public int? CompetitionId { get; set; }

    public int? KoiFishId { get; set; }

    public int? JudgeId { get; set; }

    public double? BodyScore { get; set; }

    public double? ColorScore { get; set; }

    public double? PatternScore { get; set; }

    public double? TotalScore { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual Judge? Judge { get; set; }

    public virtual KoiFish? KoiFish { get; set; }
}
