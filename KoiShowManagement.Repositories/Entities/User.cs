using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<UserReport> UserReports { get; set; } = new List<UserReport>();
}
