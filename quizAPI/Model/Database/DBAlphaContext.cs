using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quizAPI.Model.Database;

public partial class DBAlphaContext : DbContext
{
    public DBAlphaContext()
    {
    }

    public DBAlphaContext(DbContextOptions<DBAlphaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccessControl> TbAccessControls { get; set; }

    public virtual DbSet<TbCompany> TbCompanys { get; set; }

    public virtual DbSet<TbCounter> TbCounters { get; set; }

    public virtual DbSet<TbFile> TbFiles { get; set; }

    public virtual DbSet<TbMember> TbMembers { get; set; }

    public virtual DbSet<TbPosition> TbPositions { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserRole> TbUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.5.56.35;Database=DB_Alpha;User ID=sa;Password=P@ssw0rd;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<TbAccessControl>(entity =>
        {
            entity.HasKey(e => e.ControlId);

            entity.ToTable("TbAccessControl");

            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.TbAccessControls)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__TbAccessC__RoleI__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.TbAccessControls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TbAccessC__UserI__403A8C7D");
        });

        modelBuilder.Entity<TbCompany>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK_TbCompany");

            entity.Property(e => e.CompId).HasColumnName("CompID");
            entity.Property(e => e.CompAddress).HasMaxLength(500);
            entity.Property(e => e.CompCode).HasMaxLength(8);
            entity.Property(e => e.CompName).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbCounter>(entity =>
        {
            entity.HasKey(e => e.CounterId);

            entity.ToTable("TbCounter");
        });

        modelBuilder.Entity<TbFile>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.ContentType).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbMember>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK_TBPosition");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PositionName).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CompId).HasColumnName("CompID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.Signature).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserCode).HasMaxLength(8);

            entity.HasOne(d => d.Comp).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FK__TbUsers__CompID__3E52440B");

            entity.HasOne(d => d.Position).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__TbUsers__Positio__3F466844");
        });

        modelBuilder.Entity<TbUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
