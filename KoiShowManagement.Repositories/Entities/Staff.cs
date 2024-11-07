using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public DateTime? HireDate { get; set; }
}
