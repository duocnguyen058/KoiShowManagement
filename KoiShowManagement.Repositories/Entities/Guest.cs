using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Guest
{
    public int GuestId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
