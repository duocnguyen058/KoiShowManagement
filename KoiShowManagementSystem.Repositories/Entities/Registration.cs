using System;
using System.Collections.Generic;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int? CompetitionId { get; set; }

    public int? KoiFishId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual KoiFish? KoiFish { get; set; }
}
