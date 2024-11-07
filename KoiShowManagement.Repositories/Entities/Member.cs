using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities;

public partial class Member
{
    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? MembershipDate { get; set; }

    public string? MembershipType { get; set; }

    public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();
}
