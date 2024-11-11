using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class Dashboard
{
    public int DashboardId { get; set; }

    public int? CompetitionId { get; set; }

    public int? TotalParticipants { get; set; }

    public int? TotalCategories { get; set; }

    public int? TotalJudges { get; set; }

    public virtual Competition? Competition { get; set; }
}
