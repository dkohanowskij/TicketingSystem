using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Entities;

namespace Ticketing.Persistence.Configuration.Entities
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id).HasName("Ticket_pkey");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            builder.Property(e => e.OfferId).HasColumnName("OfferID");
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.RowId).HasColumnName("RowID");
            builder.Property(e => e.SeatId).HasColumnName("SeatID");
            builder.Property(e => e.SectorId).HasColumnName("SectorID");

            builder.HasOne(d => d.Offer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_offerId");

            builder.HasOne(d => d.Order).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderid");

            builder.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_seadId");
        }
    }
}
