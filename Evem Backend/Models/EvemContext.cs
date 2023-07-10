using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Evem_Backend.Models;

public partial class EvemContext : DbContext
{
    public EvemContext()
    {
    }

    public EvemContext(DbContextOptions<EvemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventCashFlow> EventCashFlows { get; set; }

    public virtual DbSet<EventExpense> EventExpenses { get; set; }

    public virtual DbSet<EventsNew> EventsNews { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserEventRole> UserEventRoles { get; set; }

    public virtual DbSet<UsersNew> UsersNews { get; set; }

    public virtual DbSet<VendorDetail> VendorDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-GNIU54KE; Database=Evem;Trusted_Connection=True;Encrypt=False; User Id=sa; Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_EventsUser");
        });

        modelBuilder.Entity<EventCashFlow>(entity =>
        {
            entity.HasKey(e => e.CexId);

            entity.Property(e => e.CexId).HasColumnName("Cex_id");
            entity.Property(e => e.CexAmount).HasColumnName("Cex_amount");
            entity.Property(e => e.CexDate).HasColumnName("Cex_date");
            entity.Property(e => e.CexName).HasColumnName("Cex_name");
            entity.Property(e => e.CexType).HasColumnName("Cex_type");
        });

        modelBuilder.Entity<EventExpense>(entity =>
        {
            entity.HasKey(e => e.TransacId);

            entity.Property(e => e.TransacId).HasColumnName("Transac_id");
            entity.Property(e => e.TransacAmount).HasColumnName("Transac_amount");
            entity.Property(e => e.TransacDate).HasColumnName("Transac_date");
            entity.Property(e => e.TransacName).HasColumnName("Transac_name");
            entity.Property(e => e.TransacType).HasColumnName("Transac_type");
        });

        modelBuilder.Entity<EventsNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventsNe__3214EC27E62C237E");

            entity.ToTable("EventsNew");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EventName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Locations)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32B6A1D7AC");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.NotificationContent)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Event).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Notificat__Event__70DDC3D8");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__71D1E811");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2765155D25");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Designation)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventRole)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegisteredDate).HasColumnType("date");
            entity.Property(e => e.RequestedDate).HasColumnType("date");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Event).WithMany(p => p.Users)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Users__EventId__6383C8BA");
        });

        modelBuilder.Entity<UserEventRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC2710C03721");

            entity.ToTable("UserEventRole");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeRole).HasMaxLength(255);
        });

        modelBuilder.Entity<UsersNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsersNew__3214EC275735DD85");

            entity.ToTable("UsersNew");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Designation)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VendorDetail>(entity =>
        {
            entity.HasKey(e => e.VendorId);

            entity.Property(e => e.VendorId).HasColumnName("Vendor_id");
            entity.Property(e => e.AddInfo).HasColumnName("Add_info");
            entity.Property(e => e.ContactEmail).HasColumnName("Contact_email");
            entity.Property(e => e.ContactNo).HasColumnName("Contact_no");
            entity.Property(e => e.ContactPerson).HasColumnName("Contact_person");
            entity.Property(e => e.ServiceOffered).HasColumnName("Service_offered");
            entity.Property(e => e.VendorName).HasColumnName("Vendor_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
