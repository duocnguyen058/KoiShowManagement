using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class Competition
{
    public int CompetitionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Location { get; set; }

    public bool? IsOnline { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();

    public virtual ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public virtual ICollection<KoiCompetitionCategory> KoiCompetitionCategories { get; set; } = new List<KoiCompetitionCategory>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
