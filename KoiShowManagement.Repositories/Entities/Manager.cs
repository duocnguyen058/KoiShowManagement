using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
