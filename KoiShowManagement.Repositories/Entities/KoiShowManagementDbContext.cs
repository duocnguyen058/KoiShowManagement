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

    public virtual DbSet<Referee> Referees { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=KoiShowManagementDB;Persist Security Info=True;User ID=SA;Password=123456aA@$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompetitionResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Competit__AFB3C31602B9D7E7");

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
            entity.HasKey(e => e.EventId).HasName("PK__Event__2370F7278E1E8B1A");

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
            entity.HasKey(e => e.GuestId).HasName("PK__Guest__19778E35D868C3D8");

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
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__8D4905E723A9A5FB");

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
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__5A6073FCD8DBD82B");

            entity.ToTable("Manager");

            entity.HasIndex(e => e.Email, "UQ__Manager__AB6E6164554F55A3").IsUnique();

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
            entity.HasKey(e => e.MemberId).HasName("PK__Member__B29B85341FA77049");

            entity.ToTable("Member");

            entity.HasIndex(e => e.Email, "UQ__Member__AB6E6164824F49CF").IsUnique();

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

        modelBuilder.Entity<Referee>(entity =>
        {
            entity.HasKey(e => e.RefereeId).HasName("PK__Referee__28102F7A7BB35F5F");

            entity.ToTable("Referee");

            entity.HasIndex(e => e.Email, "UQ__Referee__AB6E6164485E9B13").IsUnique();

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

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__1963DD9C2B557435");

            entity.HasIndex(e => e.Email, "UQ__Staff__AB6E61649B6C5377").IsUnique();

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
