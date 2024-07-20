using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrackMaster.Domain.Models;
using Task = TrackMaster.Domain.Models.Task;
using TaskStatus = TrackMaster.Domain.Models.TaskStatus;

namespace TrackMaster.Domain.Persistence;

public partial class TrackMasterContext : DbContext
{
    public TrackMasterContext()
    {
    }

    public TrackMasterContext(DbContextOptions<TrackMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ResolverGroup> ResolverGroups { get; set; }

    public virtual DbSet<ResolverGroupMember> ResolverGroupMembers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskAttachment> TaskAttachments { get; set; }

    public virtual DbSet<TaskComment> TaskComments { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.OrgNode).HasName("PK__Employee__C1ECAF2A04AB6E64");

            entity.HasIndex(e => new { e.OrgNode, e.OrgLevel }, "EmployeesOrgNCI").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "UQ__Employee__7AD04F10905D4A8D").IsUnique();

            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OrgLevel).HasComputedColumnSql("([OrgNode].[GetLevel]())", false);
        });

        modelBuilder.Entity<ResolverGroupMember>(entity =>
        {
            entity.HasIndex(e => e.ResolverGroupId, "IX_ResolverGroupMembers_ResolverGroupId");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Employee).WithMany(p => p.ResolverGroupMembers)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.ResolverGroup).WithMany(p => p.ResolverGroupMembers).HasForeignKey(d => d.ResolverGroupId);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasIndex(e => e.AttachmentId, "IX_Tasks_AttachmentId");

            entity.HasIndex(e => e.ResolverGroupId, "IX_Tasks_ResolverGroupId");

            entity.HasIndex(e => e.StatusId, "IX_Tasks_StatusId");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.TaskAssignedToNavigations)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.AssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_TaskStatuses_AssignedTo");

            entity.HasOne(d => d.Attachment).WithMany(p => p.Tasks).HasForeignKey(d => d.AttachmentId);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TaskCreatedByNavigations)
                .HasPrincipalKey(p => p.EmployeeId)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_TaskStatuses_CreatedBy");

            entity.HasOne(d => d.ResolverGroup).WithMany(p => p.Tasks).HasForeignKey(d => d.ResolverGroupId);

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks).HasForeignKey(d => d.StatusId);
        });

        modelBuilder.Entity<TaskAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId);
        });

        modelBuilder.Entity<TaskComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.HasIndex(e => e.AttachmentId, "IX_TaskComments_AttachmentId");

            entity.HasIndex(e => e.TaskId, "IX_TaskComments_TaskId");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");

            entity.HasOne(d => d.Attachment).WithMany(p => p.TaskComments).HasForeignKey(d => d.AttachmentId);

            entity.HasOne(d => d.Task).WithMany(p => p.TaskComments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
