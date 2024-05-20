using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ticketing.Persistence.Models;

public partial class TicketingDbContext : DbContext
{
    public TicketingDbContext()
    {
    }

    public TicketingDbContext(DbContextOptions<TicketingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Row> Rows { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TicketingDB;Username=postgres;Password=Serengeti1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Events_pkey");

            entity.HasIndex(e => e.PlaceId, "fki_FK_PlaceID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

            entity.HasOne(d => d.Place).WithMany(p => p.Events)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaceID");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Offers_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Event).WithMany(p => p.Offers)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_eventId");

            entity.HasOne(d => d.Venue).WithMany(p => p.Offers)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venueId");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("fk_ticketId");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_userrId");
        });

        modelBuilder.Entity<Row>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Rows_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Sector).WithMany(p => p.Rows)
                .HasForeignKey(d => d.SectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sectorId");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Seats_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Row).WithMany(p => p.Seats)
                .HasForeignKey(d => d.RowId)
                .HasConstraintName("fo_rowId");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sectors_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Venue).WithMany(p => p.Sectors)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venueId");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Ticket_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.OfferId).HasColumnName("OfferID");
            entity.Property(e => e.RowId).HasColumnName("RowID");
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.SectorId).HasColumnName("SectorID");

            entity.HasOne(d => d.Offer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_offerId");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_seadId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Places_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
