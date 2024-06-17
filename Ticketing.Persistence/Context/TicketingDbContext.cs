using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Common;
using Ticketing.Domain.Entities;

namespace Ticketing.Persistence.Context;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    //entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.DateCreated = DateOnly.FromDateTime(DateTime.UtcNow);
                    break;
                case EntityState.Modified:
                    //entry.Entity.ModifiedBy = _currentUserService.UserId;
                    entry.Entity.DateModified = DateOnly.FromDateTime(DateTime.UtcNow);
                    break;
            }

        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
