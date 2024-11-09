using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class UserReport
{
    public int UserReportId { get; set; }

    public int? UserId { get; set; }

    public int? ReportId { get; set; }

    public string AccessLevel { get; set; } = null!;

    public virtual Report? Report { get; set; }

    public virtual User? User { get; set; }
    public int Id { get; internal set; }
}
