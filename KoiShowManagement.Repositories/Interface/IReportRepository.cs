using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Entities
{
    public partial class Report
    {
        // Unique identifier for each report (Primary Key)
        public int reportId { get; set; }

        // Title of the report (required field, cannot be null)
        public string title { get; set; } = null!;

        // Content of the report (optional, can be null)
        public string? content { get; set; }

        // Date and time when the report was created (nullable, can be null if not set)
        public DateTime? createdAt { get; set; }

        // The ID of the user who created the report (foreign key, nullable)
        public int? createdBy { get; set; }

        // Navigation property for the user who created the report (nullable in case of missing user)
        public virtual User? createdByNavigation { get; set; }

        // Collection of UserReport objects associated with this report
        public virtual ICollection<UserReport> userReports { get; set; } = new List<UserReport>();
    }
}
