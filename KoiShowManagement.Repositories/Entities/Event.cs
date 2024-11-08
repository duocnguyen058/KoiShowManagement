using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public string? Location { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<CompetitionResult> CompetitionResults { get; set; } = new List<CompetitionResult>();

    public virtual Manager? Manager { get; set; }

    public virtual ICollection<ScoreKoi> ScoreKois { get; set; } = new List<ScoreKoi>();
}
