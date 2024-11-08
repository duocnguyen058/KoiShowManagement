using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities
{
    public partial class User
    {
        // Unique identifier for the user (Primary Key)
        public int serId { get; set; }

        // Username of the user (cannot be null)
        public string username { get; set; } = null!;

        // Password of the user (cannot be null)
        public string password { get; set; } = null!;

        // Optional role of the user (e.g., Admin, User, etc.)
        public string? role { get; set; }

        // Date and time when the user account was created
        public DateTime? createdAt { get; set; }

        // Navigation property for the profiles associated with this user
        public virtual ICollection<Profile> profiles { get; set; } = new List<Profile>();

        // Navigation property for the reports created by the user
        public virtual ICollection<Report> reports { get; set; } = new List<Report>();

        // Navigation property for the user reports associated with this user
        public virtual ICollection<UserReport> userReports { get; set; } = new List<UserReport>();
    }
}
