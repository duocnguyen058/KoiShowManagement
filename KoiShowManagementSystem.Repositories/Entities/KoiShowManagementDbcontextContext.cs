using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiShowManagementSystem.Repositories.Entities
{
    public partial class KoiShowManagementDbcontextContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public KoiShowManagementDbcontextContext(DbContextOptions<KoiShowManagementDbcontextContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionCategory> CompetitionCategories { get; set; }
        public virtual DbSet<Dashboard> Dashboards { get; set; }
        public virtual DbSet<Judge> Judges { get; set; }
        public virtual DbSet<KoiCompetitionCategory> KoiCompetitionCategories { get; set; }
        public virtual DbSet<KoiFish> KoiFishes { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("KoiShowManagementDbContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your model building logic here...
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
