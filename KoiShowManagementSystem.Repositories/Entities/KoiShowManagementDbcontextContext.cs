using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagementSystem.Repositories.Entities;

public partial class KoiShowManagementDbcontextContext : DbContext
{
    public KoiShowManagementDbcontextContext()
    {
    }

    public KoiShowManagementDbcontextContext(DbContextOptions<KoiShowManagementDbcontextContext> options)
        : base(options)
    {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=KoiShowManagementDBContext;Persist Security Info=True;User ID=SA;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A603E6B5B2");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "UQ__Account__536C85E4ED617D2F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__A9D10534D61C1E57").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PK__Competit__8F32F4D36DB07F08");

            entity.ToTable("Competition");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<CompetitionCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Competit__19093A0BC3A68A1E");

            entity.ToTable("CompetitionCategory");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dashboard>(entity =>
        {
            entity.HasKey(e => e.DashboardId).HasName("PK__Dashboar__C711E1D049A65F2D");

            entity.ToTable("Dashboard");

            entity.HasOne(d => d.Competition).WithMany(p => p.Dashboards)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Dashboard__Compe__656C112C");
        });

        modelBuilder.Entity<Judge>(entity =>
        {
            entity.HasKey(e => e.JudgeId).HasName("PK__Judge__66ACA93DCACC3CE1");

            entity.ToTable("Judge");

            entity.HasOne(d => d.Account).WithMany(p => p.Judges)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Judge__AccountId__5165187F");

            entity.HasOne(d => d.Competition).WithMany(p => p.Judges)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Judge__Competiti__52593CB8");
        });

        modelBuilder.Entity<KoiCompetitionCategory>(entity =>
        {
            entity.HasKey(e => e.KoiCompetitionCategoryId).HasName("PK__KoiCompe__B6FDBDCF71156EEF");

            entity.ToTable("KoiCompetitionCategory");

            entity.HasOne(d => d.Category).WithMany(p => p.KoiCompetitionCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__KoiCompet__Categ__4D94879B");

            entity.HasOne(d => d.Competition).WithMany(p => p.KoiCompetitionCategories)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__KoiCompet__Compe__4CA06362");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.KoiCompetitionCategories)
                .HasForeignKey(d => d.KoiFishId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__KoiCompet__KoiFi__4E88ABD4");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__KoiFish__44D35C251CAD0E74");

            entity.ToTable("KoiFish");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Variety)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__KoiFish__Account__3E52440B");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__6EF588101D576D8F");

            entity.ToTable("Registration");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");

            entity.HasOne(d => d.Competition).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Registrat__Compe__46E78A0C");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.KoiFishId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Registrat__KoiFi__47DBAE45");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD4805E4E6FE79");

            entity.ToTable("Report");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Competition).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Report__Competit__628FA481");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__976902083E2F9D86");

            entity.ToTable("Result");

            entity.HasOne(d => d.Category).WithMany(p => p.Results)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Result__Category__5EBF139D");

            entity.HasOne(d => d.Competition).WithMany(p => p.Results)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Result__Competit__5CD6CB2B");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.Results)
                .HasForeignKey(d => d.KoiFishId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Result__KoiFishI__5DCAEF64");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__Score__7DD229D17882F021");

            entity.ToTable("Score");

            entity.Property(e => e.TotalScore).HasComputedColumnSql("(([BodyScore]*(0.5)+[ColorScore]*(0.3))+[PatternScore]*(0.2))", false);

            entity.HasOne(d => d.Competition).WithMany(p => p.Scores)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK__Score__Competiti__5812160E");

            entity.HasOne(d => d.Judge).WithMany(p => p.Scores)
                .HasForeignKey(d => d.JudgeId)
                .HasConstraintName("FK__Score__JudgeId__59FA5E80");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.Scores)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK__Score__KoiFishId__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
