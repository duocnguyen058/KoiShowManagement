﻿using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Profile
{
    public int ProfileId { get; set; }

    public int? UserId { get; set; }

    public string? Avatar { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Address { get; set; }

    public string? Bio { get; set; }

    public virtual User? User { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
}
