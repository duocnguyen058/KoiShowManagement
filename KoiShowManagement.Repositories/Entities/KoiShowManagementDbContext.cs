using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories.Entities;

public partial class KoiShowManagementDbContext : DbContext
{
    public KoiShowManagementDbContext()
    {
    }

    public KoiShowManagementDbContext(DbContextOptions<KoiShowManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompetitionResult> CompetitionResults { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Referee> Referees { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ScoreKoi> ScoreKois { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserReport> UserReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=KoiShowManagementDB;Persist Security Info=True;User ID=SA;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompetitionResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Competit__AFB3C316123E7CCE");

            entity.ToTable("CompetitionResult");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(500)
                .HasColumnName("feedback");
            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.RefereeId).HasColumnName("referee_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("score");

            entity.HasOne(d => d.Event).WithMany(p => p.CompetitionResults)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Competiti__event__5441852A");

            entity.HasOne(d => d.Koi).WithMany(p => p.CompetitionResults)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Competiti__koi_i__52593CB8");

            entity.HasOne(d => d.Referee).WithMany(p => p.CompetitionResults)
                .HasForeignKey(d => d.RefereeId)
                .HasConstraintName("FK__Competiti__refer__534D60F1");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__2370F72733C3CA9E");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventDate)
                .HasColumnType("date")
                .HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasColumnName("event_name");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .HasColumnName("location");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.Events)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Event__manager_i__4BAC3F29");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__19778E359E13A67C");

            entity.ToTable("Guest");

            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("registration_date");
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__8D4905E72D6512BB");

            entity.ToTable("Koi");

            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Size)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("size");

            entity.HasOne(d => d.Member).WithMany(p => p.Kois)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Koi__member_id__4E88ABD4");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__5A6073FCFE5EB14E");

            entity.ToTable("Manager");

            entity.HasIndex(e => e.Email, "UQ__Manager__AB6E6164625DF5A2").IsUnique();

            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__B29B8534C7344038");

            entity.ToTable("Member");

            entity.HasIndex(e => e.Email, "UQ__Member__AB6E61641CC951E1").IsUnique();

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.MembershipDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("membership_date");
            entity.Property(e => e.MembershipType)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Silver')")
                .HasColumnName("membership_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Profile__AEBB701F53C96E39");

            entity.ToTable("Profile");

            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar");
            entity.Property(e => e.Bio)
                .HasMaxLength(500)
                .HasColumnName("bio");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Profile__user_id__6FE99F9F");
        });

        modelBuilder.Entity<Referee>(entity =>
        {
            entity.HasKey(e => e.RefereeId).HasName("PK__Referee__28102F7A6449E3DC");

            entity.ToTable("Referee");

            entity.HasIndex(e => e.Email, "UQ__Referee__AB6E616400C8478A").IsUnique();

            entity.Property(e => e.RefereeId).HasColumnName("referee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.ExpertiseLevel)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Intermediate')")
                .HasColumnName("expertise_level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__779B7C58857B9DD2");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Report__created___5DCAEF64");
        });

        modelBuilder.Entity<ScoreKoi>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__ScoreKoi__8CA19050F484E207");

            entity.ToTable("ScoreKoi");

            entity.Property(e => e.ScoreId).HasColumnName("score_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(500)
                .HasColumnName("feedback");
            entity.Property(e => e.KoiId).HasColumnName("koi_id");
            entity.Property(e => e.RefereeId).HasColumnName("referee_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("score");
            entity.Property(e => e.ScoreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("score_date");

            entity.HasOne(d => d.Event).WithMany(p => p.ScoreKois)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__ScoreKoi__event___75A278F5");

            entity.HasOne(d => d.Koi).WithMany(p => p.ScoreKois)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ScoreKoi__koi_id__74AE54BC");

            entity.HasOne(d => d.Referee).WithMany(p => p.ScoreKois)
                .HasForeignKey(d => d.RefereeId)
                .HasConstraintName("FK__ScoreKoi__refere__76969D2E");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__1963DD9CC9D3907D");

            entity.HasIndex(e => e.Email, "UQ__Staff__AB6E61643F4EA742").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370FA14DB28A");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC57236BDA6CA").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Guest')")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserReport>(entity =>
        {
            entity.HasKey(e => e.UserReportId).HasName("PK__UserRepo__A22E22934FB3FE14");

            entity.ToTable("UserReport");

            entity.Property(e => e.UserReportId).HasColumnName("user_report_id");
            entity.Property(e => e.AccessLevel)
                .HasMaxLength(50)
                .HasDefaultValueSql("('View')")
                .HasColumnName("access_level");
            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Report).WithMany(p => p.UserReports)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UserRepor__repor__6383C8BA");

            entity.HasOne(d => d.User).WithMany(p => p.UserReports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UserRepor__user___628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
