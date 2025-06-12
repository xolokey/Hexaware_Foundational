using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssertManagementMVC.Models;

public partial class AssertManagementMvcContext : DbContext
{
    public AssertManagementMvcContext()
    {
    }

    public AssertManagementMvcContext(DbContextOptions<AssertManagementMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetAuditLog> AssetAuditLogs { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<AuditRequest> AuditRequests { get; set; }

    public virtual DbSet<EmployeeAsset> EmployeeAssets { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AssertManagementMVC;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Assets__4349237277A460CE");

            entity.HasIndex(e => e.AssetNo, "UQ__Assets__434A45B9B1790F5B").IsUnique();

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssetModel).HasMaxLength(100);
            entity.Property(e => e.AssetName).HasMaxLength(100);
            entity.Property(e => e.AssetNo).HasMaxLength(50);
            entity.Property(e => e.AssetValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Available");

            entity.HasOne(d => d.Category).WithMany(p => p.Assets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Assets__Category__300424B4");
        });

        modelBuilder.Entity<AssetAuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AssetAud__5E5499A8AB264806");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.AuditRequestId).HasColumnName("AuditRequestID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.VerifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.AuditRequest).WithMany(p => p.AssetAuditLogs)
                .HasForeignKey(d => d.AuditRequestId)
                .HasConstraintName("FK__AssetAudi__Audit__44FF419A");

            entity.HasOne(d => d.VerifiedByNavigation).WithMany(p => p.AssetAuditLogs)
                .HasForeignKey(d => d.VerifiedBy)
                .HasConstraintName("FK__AssetAudi__Verif__45F365D3");
        });

        modelBuilder.Entity<AssetCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__AssetCat__19093A2BC5DFFDDD");

            entity.HasIndex(e => e.CategoryName, "UQ__AssetCat__8517B2E0191EA670").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<AuditRequest>(entity =>
        {
            entity.HasKey(e => e.AuditRequestId).HasName("PK__AuditReq__8B380A4EB16CD956");

            entity.Property(e => e.AuditRequestId).HasColumnName("AuditRequestID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AuditDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AuditStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Asset).WithMany(p => p.AuditRequests)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__AuditRequ__Asset__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.AuditRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AuditRequ__UserI__403A8C7D");
        });

        modelBuilder.Entity<EmployeeAsset>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__Employee__B3C6D6AB7EA9574C");

            entity.Property(e => e.AllocationId).HasColumnName("AllocationID");
            entity.Property(e => e.AllocationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Allocated");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Asset).WithMany(p => p.EmployeeAssets)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__EmployeeA__Asset__34C8D9D1");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeeAssets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__EmployeeA__UserI__33D4B598");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Logs__5E5499A81DC84FC8");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.LogLevel).HasMaxLength(50);
            entity.Property(e => e.LoggedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Logs__UserID__4F7CD00D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A84E2B5D7");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61603FBB57AF").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__ServiceR__33A8519AAF39E556");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IssueType).HasMaxLength(50);
            entity.Property(e => e.RequestedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ResolvedDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Asset).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__ServiceRe__Asset__3A81B327");

            entity.HasOne(d => d.User).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ServiceRe__UserI__398D8EEE");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F4927007839B55");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.IsValid).HasDefaultValue(true);
            entity.Property(e => e.Jwttoken).HasColumnName("JWTToken");
            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sessions__UserID__49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACD533605C");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105342A5E85A5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
