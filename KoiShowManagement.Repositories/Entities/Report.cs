using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Report
{
    public int ReportId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<UserReport> UserReports { get; set; } = new List<UserReport>();
}
